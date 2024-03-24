namespace SudokuGame.Gameplay
{
    using System;
    using System.Collections.Generic;
    using SudokuGame.DI;
    using UnityEngine;

    public class FieldInitializer : MonoBehaviour
    {
        [SerializeField]
        protected SudokuCellsCollectionContainer sudukuCells = default;

        public event Action onFieldInitialized = delegate { };

        protected virtual void OnEnable() => sudukuCells.onSudokuReady += InitFieldWithZeroes;

        protected virtual void OnDisable() => sudukuCells.onSudokuReady -= InitFieldWithZeroes;

        protected virtual void InitFieldWithZeroes()
        {
            Dictionary<Vector2Int, SudokuCell> sudokuCellsField =
            sudukuCells.FieldDataCollection as Dictionary<Vector2Int, SudokuCell>;

            var baseGrid = BaseSudokuGrid(sudukuCells.SudokuRowLength);

            for (int i = 0; i < sudukuCells.SudokuRowLength; i++)
            {
                for (int j = 0; j < sudukuCells.SudokuRowLength; j++)
                {
                    Vector2Int fieldPosition = new Vector2Int(i, j);
                    if (sudokuCellsField.TryGetValue(fieldPosition, out SudokuCell sudokuCell))
                    {
                        sudokuCell.SetNumber(baseGrid[fieldPosition.x, fieldPosition.y]);
                    }
                    else
                    {
                        Debug.LogError($"Failed at {fieldPosition}");
                    }
                }
            }

            OnFieldInitialized();
        }

        protected int[,] BaseSudokuGrid(int count)
        {
            int[,] baseGrid = new int[,]
            {
                {1,2,3,4,5,6,7,8,9},
                {4,5,6,7,8,9,1,2,3},
                {7,8,9,1,2,3,4,5,6},
                {2,3,4,5,6,7,8,9,1},
                {5,6,7,8,9,1,2,3,4},
                {8,9,1,2,3,4,5,6,7},
                {3,4,5,6,7,8,9,1,2},
                {6,7,8,9,1,2,3,4,5},
                {9,1,2,3,4,5,6,7,8}
            };

            int[,] grid = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    grid[i, j] = baseGrid[i, j];
                }
            }
            return grid;
        }

        protected virtual void OnFieldInitialized() => onFieldInitialized();
    }
}
