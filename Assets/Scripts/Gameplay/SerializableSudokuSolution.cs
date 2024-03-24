namespace SudokuGame.Gameplay
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class SerializableSudokuSolution
    {
        [Serializable]
        protected class SudokuInfo
        {
            [SerializeField]
            protected Vector2Int position = default;

            [SerializeField]
            protected int number = default;

            public Vector2Int Position => position;

            public int Number => number;

            public SudokuInfo(Vector2Int position, int number)
            {
                this.position = position;
                this.number = number;
            }
        }

        [SerializeField]
        protected List<SudokuInfo> sudokuInfos = new List<SudokuInfo>();

        public virtual void AddNumberAtPosition(Vector2Int position, int number)
        {
            sudokuInfos.Add(new SudokuInfo(position, number));
        }

        public SudokuSolution GetSudokuSolution()
        {
            SudokuSolution sudokuSolution = new SudokuSolution();
            for (int i = 0; i < sudokuInfos.Count; i++)
            {
                sudokuSolution.SetNumberAtPosition(sudokuInfos[i].Position, sudokuInfos[i].Number);
            }
            return sudokuSolution;
        }
    }
}
