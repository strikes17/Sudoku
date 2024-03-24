namespace SudokuGame.Gameplay
{
    using System;
    using System.IO;
    using SudokuGame.DI;
    using UnityEngine;

    public class FieldStateLoader : MonoBehaviour
    {
        [SerializeField]
        protected SudokuSolutionContainer sudokuSolutionContainer = default;

        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        [SerializeField]
        protected FieldSolutionValidator fieldSolutionValidator = default;

        public event Action onLoaded = delegate { };

        public virtual void Load(string saveFileName)
        {
            string fileContents = File.ReadAllText(saveFileName);
            SudokuSolitionSaveFile savedFile = JsonUtility.FromJson<SudokuSolitionSaveFile>(fileContents);

            SudokuSolution solvedSolution = savedFile.SolvedSolution.GetSudokuSolution();
            SudokuSolution activeSolution = savedFile.ActiveSolution.GetSudokuSolution();
            Set(solvedSolution, activeSolution);
            
            onLoaded();
        }

        protected virtual void Set(SudokuSolution solvedSolution, SudokuSolution activeSolution)
        {
            foreach (SudokuCell sudokuCell in sudokuCells.DataCollection)
            {
                int number = activeSolution.GetNumberAtPosition(sudokuCell.Data.FieldPosition);
                sudokuCell.SetNumber(number);
            }
            sudokuSolutionContainer.AddData(sudokuSolutionContainer.MAIN_SOLUTION, solvedSolution);
        }

    }
}
