namespace SudokuGame.Gameplay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SudokuGame.DI;
    using SudokuGame.Gameplay.Gui;
    using UnityEngine;

    [RequireComponent(typeof(FieldInitializer))]
    public class FieldGenerator : MonoBehaviour
    {
        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        [SerializeField]
        protected FieldInitializer fieldInitializer = default;

        [SerializeField]
        protected GameEventsContainer gameEventsContainer = default;

        public event Action onFieldGenerated = delegate { };

        protected virtual void OnEnable()
        {
            fieldInitializer.onFieldInitialized += GenerateField;
        }

        protected virtual void OnDisable()
        {
            fieldInitializer.onFieldInitialized -= GenerateField;
        }

        protected virtual void GenerateField()
        {
            GenerateSudoku();
            onFieldGenerated();
        }

        protected virtual void GenerateSudoku()
        {
            List<SudokuCell> allSudokuCells = (List<SudokuCell>)sudokuCells.DataCollection;

            int randomSwapsCount = UnityEngine.Random.Range(3, 10);
            for (int i = 0; i < randomSwapsCount; i++)
            {
                RandomizeRows();
                RandomizeColumns();
            }
        }

        protected virtual void RandomizeRows()
        {
            for (int i = 0; i < sudokuCells.SudokuDimensionsCount; i++)
            {
                List<SudokuCell> firstRow = sudokuCells.GetColumn(i * 3);
                List<SudokuCell> secondRow = sudokuCells.GetColumn(i * 3 + 1);
                List<SudokuCell> thirdRow = sudokuCells.GetColumn(i * 3 + 2);
                List<List<SudokuCell>> rows = new List<List<SudokuCell>>
                {
                    firstRow,
                    secondRow,
                    thirdRow
                };
                RandomSwap(rows);
            }
        }

        protected virtual void RandomizeColumns()
        {
            for (int i = 0; i < sudokuCells.SudokuDimensionsCount; i++)
            {
                List<SudokuCell> firstColumn = sudokuCells.GetColumn(i * 3);
                List<SudokuCell> secondColumn = sudokuCells.GetColumn(i * 3 + 1);
                List<SudokuCell> thirdColumn = sudokuCells.GetColumn(i * 3 + 2);
                List<List<SudokuCell>> columns = new List<List<SudokuCell>>
                {
                    firstColumn,
                    secondColumn,
                    thirdColumn
                };
                RandomSwap(columns);
            }
        }

        protected virtual void RandomSwap(List<List<SudokuCell>> swapTargets)
        {
            bool areEqualRndIndex = true;
            int rndIndex1 = 0;
            int rndIndex2 = 0;
            while (areEqualRndIndex)
            {
                rndIndex1 = UnityEngine.Random.Range(0, 3);
                rndIndex2 = UnityEngine.Random.Range(0, 3);
                if (rndIndex1 != rndIndex2)
                {
                    areEqualRndIndex = false;
                }
            }

            SwapSudokuLines(swapTargets[rndIndex1], swapTargets[rndIndex2]);
        }

        protected virtual void SwapSudokuLines(List<SudokuCell> line1, List<SudokuCell> line2)
        {
            for (int i = 0; i < line1.Count; i++)
            {
                int temp = line1[i].Data.Number;
                line1[i].SetNumber(line2[i].Data.Number);
                line2[i].SetNumber(temp);
            }
        }
    }
}
