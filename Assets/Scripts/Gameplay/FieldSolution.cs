namespace SudokuGame.Gameplay
{
    using System;
    using SudokuGame.DI;
    using UnityEngine;

    public class FieldSolution : MonoBehaviour
    {
        [SerializeField]
        protected SudokuSolutionContainer sudokuSolutionContainer = default;

        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        [SerializeField]
        protected FieldGenerator fieldGenerator = default;

        public event Action onSolutionHandled = delegate { };

        protected virtual void OnEnable() => fieldGenerator.onFieldGenerated += SaveSolution;

        protected virtual void OnDisable() => fieldGenerator.onFieldGenerated -= SaveSolution;

        protected virtual void SaveSolution()
        {
            sudokuSolutionContainer.Clear();
            sudokuSolutionContainer.AddData(sudokuSolutionContainer.MAIN_SOLUTION, new SudokuSolution().Set(sudokuCells));
            onSolutionHandled();
        }

        public virtual void Solve()
        {
            foreach (SudokuCell sudokuCell in sudokuCells.DataCollection)
            {
                sudokuCell.SetNumber(sudokuSolutionContainer.Main.GetNumberAtPosition(sudokuCell.Data.FieldPosition));
            }
        }
    }
}
