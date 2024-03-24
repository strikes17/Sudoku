namespace SudokuGame.Gameplay
{
    using System;
    using SudokuGame.Data;
    using SudokuGame.DI;
    using SudokuGame.Difficulty;
    using SudokuGame.Systems;
    using SudokuGame.Util;
    using Unity.Mathematics;
    using UnityEngine;

    public class FieldCreator : MonoBehaviour
    {
        #region DI Fields

        [SerializeField]
        protected BaseContainer<GameEventsHandler> gameEventsContainer = default;

        [SerializeField]
        protected DifficultyLevelContainer difficultyLevelContainer = default;

        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        protected ObjectPool<SudokuCell> sudokuCellsPool = default;

        #endregion

        #region Core

        protected const int CELLS_IN_QUAD = 3;
        protected const float CELL_HALF_SIZE = 0.5f;

        [SerializeField]
        protected SudokuCell sudokuCellPrefab = default;

        [SerializeField]
        protected Transform fieldCenterTransform = default;

        protected GameEventsHandler gameEventsHandler = default;

        protected virtual void Awake()
        {
            sudokuCellsPool = new ObjectPool<SudokuCell>(sudokuCellPrefab);
            gameEventsHandler = gameEventsContainer.Data;
            gameEventsHandler.onGameStarted += OnGameStarted;
        }

        protected virtual void OnDestroy()
        {
            gameEventsHandler.onGameStarted -= OnGameStarted;
        }

        protected virtual void OnGameStarted() => CreateSudukuCellsField(difficultyLevelContainer.Data.Dimensions);

        public virtual void CreateSudukuCellsField(int dimensionsCount)
        {
            Clear();
            Vector3 totalScale = fieldCenterTransform.localScale;
            int iterationsCount = sudokuCells.SudokuRowLength;
            Vector3 centerOffset = new Vector3(-iterationsCount / 2, -iterationsCount / 2, 0);
            Vector3 cellOffset = dimensionsCount % 2 == 0 ? new Vector3(CELL_HALF_SIZE, CELL_HALF_SIZE, 0) : Vector3.zero;
            for (int i = 0; i < iterationsCount; i++)
            {
                for (int j = 0; j < iterationsCount; j++)
                {
                    SudokuCell sudokuCell = sudokuCellsPool.Get();
                    sudokuCell.SetFieldPosition(new Vector2Int(i, j));
                    var fieldPosition = sudokuCell.Data.FieldPosition;
                    sudokuCell.transform.position = centerOffset + cellOffset +
                     new Vector3(fieldPosition.x * totalScale.x, fieldPosition.y * totalScale.y);
                    sudokuCell.transform.rotation = quaternion.identity;
                    sudokuCell.transform.SetParent(fieldCenterTransform);
                    sudokuCell.SetActiveState();
                    sudokuCells.AddData(sudokuCell);
                }
            }
        }

        protected virtual void Clear()
        {
            sudokuCells.Clear();
            foreach (SudokuCell sudokuCell in sudokuCellsPool.Objects)
            {
                sudokuCell.Dispose();
            }
        }

        #endregion


    }
}
