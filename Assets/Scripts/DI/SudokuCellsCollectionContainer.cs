namespace SudokuGame.DI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using SudokuGame.Difficulty;
    using SudokuGame.Gameplay;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Sudoku Cells Collection Container",
    menuName = "Sudoku Game/DI/Sudoku Cells Collection Container")]
    public class SudokuCellsCollectionContainer : BaseCollectionContainer<SudokuCell>
    {
        public event Action onSudokuReady = delegate { };

        [SerializeField]
        protected DifficultyLevelContainer difficultyLevelContainer = default;

        public IEnumerable FieldDataCollection => sudokuCellsField;

        public List<SudokuCell> GetRow(int rowIndex) =>
            dataCollection.Where(x => x.Data.FieldPosition.x == rowIndex).ToList();

        public List<SudokuCell> GetColumn(int columnIndex) =>
            dataCollection.Where(x => x.Data.FieldPosition.y == columnIndex).ToList();

        public List<SudokuCell> GetQuad(Vector2Int quadPosition) =>
            dataCollection.Where(x => x.Data.QuadPosition == quadPosition).ToList();

        public int SudokuRowLength => difficultyLevelContainer.Data.Dimensions * 3;
        public int SudokuDimensionsCount => difficultyLevelContainer.Data.Dimensions;
        public int TotalSudokuCellsCount => totalSudokuCellsCount;

        protected int totalSudokuCellsCount = 0;

        protected Dictionary<Vector2Int, SudokuCell> sudokuCellsField = new Dictionary<Vector2Int, SudokuCell>();

        public override void AddData(SudokuCell sudokuCell)
        {
            dataCollection.Add(sudokuCell);
            sudokuCellsField.Add(sudokuCell.Data.FieldPosition, sudokuCell);
            totalSudokuCellsCount++;
            if (totalSudokuCellsCount == difficultyLevelContainer.Data.TotalSudukoCellsCount)
            {
                onSudokuReady();
            }
        }

        public override void Clear()
        {
            base.Clear();
            sudokuCellsField.Clear();
            sudokuCellsField = new Dictionary<Vector2Int, SudokuCell>();
            totalSudokuCellsCount = 0;
        }
    }
}
