namespace SudokuGame.Gameplay
{
    using System.Collections.Generic;
    using SudokuGame.DI;
    using SudokuGame.Difficulty;
    using UnityEngine;

    public class FieldDifficultySetter : MonoBehaviour
    {
        [SerializeField]
        protected DifficultyLevelContainer difficultyLevelContainer = default;

        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        [SerializeField]
        protected FieldSolution fieldSolution = default;

        protected virtual void OnEnable() => fieldSolution.onSolutionHandled += Init;

        protected virtual void OnDisable() => fieldSolution.onSolutionHandled -= Init;

        protected virtual void Init()
        {
            int totalHiddenCells = Mathf.RoundToInt
                (sudokuCells.TotalSudokuCellsCount * difficultyLevelContainer.Data.HiddenCellsRatio);

            List<SudokuCell> cells = sudokuCells.DataCollection as List<SudokuCell>;
            for (int i = 0; i < totalHiddenCells;)
            {
                int randomIndex = Random.Range(0, sudokuCells.TotalSudokuCellsCount);
                SudokuCell sudokuCell = cells[randomIndex];
                if (sudokuCell.Data.Number != 0)
                {
                    sudokuCell.SetNumber(0);
                    i++;
                }
            }
        }
    }
}
