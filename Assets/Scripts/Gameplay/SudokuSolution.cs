namespace SudokuGame.Gameplay
{
    using System.Collections.Generic;
    using SudokuGame.DI;
    using UnityEngine;

    public class SudokuSolution
    {
        protected Dictionary<Vector2Int, int> sudokuNumbersAtPositions = new Dictionary<Vector2Int, int>();

        public virtual SudokuSolution Set(SudokuCellsCollectionContainer sudokuCellsCollectionContainer)
        {
            foreach (SudokuCell sudokuCell in sudokuCellsCollectionContainer.DataCollection)
            {
                sudokuNumbersAtPositions.Add(sudokuCell.Data.FieldPosition, sudokuCell.Data.Number);
            }

            return this;
        }

        public virtual void SetNumberAtPosition(Vector2Int cellPosition, int number) => sudokuNumbersAtPositions.TryAdd(cellPosition, number);

        public virtual int GetNumberAtPosition(Vector2Int cellPosition)
        {
            if (sudokuNumbersAtPositions.TryGetValue(cellPosition, out int number))
            {
                return number;
            }
            return 0;
        }

        public virtual SerializableSudokuSolution GetSerializableSudoku()
        {
            SerializableSudokuSolution serializableSudoku = new SerializableSudokuSolution();
            foreach (KeyValuePair<Vector2Int, int> pair in sudokuNumbersAtPositions)
            {
                serializableSudoku.AddNumberAtPosition(pair.Key, pair.Value);
            }
            return serializableSudoku;
        }
    }
}
