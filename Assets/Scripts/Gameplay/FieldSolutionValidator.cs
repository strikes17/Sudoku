namespace SudokuGame.Gameplay
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using SudokuGame.DI;
    using UnityEditor;
    using UnityEngine;

    public class FieldSolutionValidator : MonoBehaviour
    {
        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        [SerializeField]
        protected FieldSolution fieldSolution = default;

        [SerializeField]
        protected FieldStateLoader fieldStateLoader = default;

        [SerializeField]
        protected GameEventsContainer gameEventsContainer = default;

        public event Action<SudokuCell, List<SudokuCell>> onSolutionFailed = delegate { };

        public event Action onSolutionSucceded = delegate { };

        public event Action<SudokuCell, List<SudokuCell>> onSolutionFixedForCell = delegate { };

        private Dictionary<SudokuCell, List<SudokuCell>> failedCellsDictionary =
            new Dictionary<SudokuCell, List<SudokuCell>>();

        [SerializeField]
        protected bool isOn = true;

        public bool IsOn
        {
            set
            {
                isOn = value;
            }
            get => isOn;
        }

        protected virtual void OnEnable()
        {
            fieldSolution.onSolutionHandled += ValidateSolution;
            fieldSolution.onSolutionHandled += Init;
            fieldStateLoader.onLoaded += ValidateSolution;
        }

        protected virtual void Init()
        {
            foreach (SudokuCell sudokuCell in sudokuCells.DataCollection)
            {
                sudokuCell.onNumberSet += ValidateSolutionSingle;
                ResetValidationStatus(sudokuCell);
            }
        }

        protected virtual void OnDisable()
        {
            fieldSolution.onSolutionHandled -= ValidateSolution;
            fieldSolution.onSolutionHandled -= Init;
            fieldStateLoader.onLoaded -= ValidateSolution;
            foreach (SudokuCell sudokuCell in sudokuCells.DataCollection)
            {
                sudokuCell.onNumberSet -= ValidateSolutionSingle;
            }
        }

        protected virtual void ValidateSolutionSingle(SudokuCell sudokuCell, int number)
        {
            if (!isOn) return;
            List<SudokuCell> failedCells = ValidateSolutionSingle(sudokuCell);
            if (failedCells.Count > 0)
            {
                onSolutionFailed(sudokuCell, failedCells);
            }
            else
            {
                onSolutionSucceded();
                if (failedCellsDictionary.TryGetValue(sudokuCell, out List<SudokuCell> failedCellsList))
                {
                    onSolutionFixedForCell(sudokuCell, failedCellsList);
                }
                failedCellsDictionary.Remove(sudokuCell);
            }
        }

        protected virtual void ValidateSolution()
        {
            if (!isOn) return;
            List<SudokuCell> failedCells = ValidateSolutionAll();
            if (failedCells.Count > 0)
            {
                onSolutionFailed(failedCells[0], failedCells);
            }
            else
            {
                onSolutionSucceded();
            }
        }

        protected virtual List<SudokuCell> ValidateSolutionSingle(SudokuCell sudokuCell)
        {
            List<SudokuCell> failedCells = new List<SudokuCell>();
            List<SudokuCell> allSudokuCells = (List<SudokuCell>)sudokuCells.DataCollection;

            IEnumerable<SudokuCell> sudokuCellsSameQuad =
            allSudokuCells.Where(x => x.Data.QuadPosition == sudokuCell.Data.QuadPosition && x != sudokuCell);

            IEnumerable<SudokuCell> sudokuCellsSameRow =
            allSudokuCells.Where(x => x.Data.FieldPosition.x == sudokuCell.Data.FieldPosition.x && x != sudokuCell);

            IEnumerable<SudokuCell> sudokuCellsSameCol =
            allSudokuCells.Where(x => x.Data.FieldPosition.y == sudokuCell.Data.FieldPosition.y && x != sudokuCell);

            failedCells.AddRange(ValidateNumberByRules(sudokuCellsSameQuad, sudokuCell.Data.Number));
            failedCells.AddRange(ValidateNumberByRules(sudokuCellsSameRow, sudokuCell.Data.Number));
            failedCells.AddRange(ValidateNumberByRules(sudokuCellsSameCol, sudokuCell.Data.Number));

            if (failedCells.Count > 0)
            {
                failedCells.Add(sudokuCell);
                if (failedCellsDictionary.ContainsKey(sudokuCell))
                {
                    failedCellsDictionary[sudokuCell].AddRange(failedCells);
                }
                else
                {
                    failedCellsDictionary.TryAdd(sudokuCell, failedCells);
                }

                failedCells.ForEach(x => x.SetValidationStatus(false));
            }
            else
            {
                ResetValidationStatus(sudokuCell);
            }
            return failedCells.Distinct().ToList();
        }

        protected virtual void ResetValidationStatus(SudokuCell sudokuCell)
        {
            if (failedCellsDictionary.TryGetValue(sudokuCell, out List<SudokuCell> failedCellsList))
            {
                failedCellsList.ForEach(x => x.SetValidationStatus(true));
            }
            sudokuCell.SetValidationStatus(true);
        }

        protected virtual List<SudokuCell> ValidateSolutionAll()
        {
            List<SudokuCell> failedCells = new List<SudokuCell>();
            List<SudokuCell> allSudokuCells = (List<SudokuCell>)sudokuCells.DataCollection;
            foreach (SudokuCell sudokuCell in allSudokuCells)
            {
                failedCells.AddRange(ValidateSolutionSingle(sudokuCell));
            }
            return failedCells.Distinct().ToList();
        }

        protected List<SudokuCell> ValidateNumberByRules(IEnumerable<SudokuCell> collection, int newSudokuNumber)
        {
            List<SudokuCell> failedCells = new List<SudokuCell>();
            foreach (SudokuCell sudokuCell in collection)
            {
                int number = sudokuCell.Data.Number;
                if (newSudokuNumber == number && number != 0)
                {
                    failedCells.Add(sudokuCell);
                }
            }
            return failedCells;
        }
    }
}
