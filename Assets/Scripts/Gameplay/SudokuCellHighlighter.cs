namespace SudokuGame.Gameplay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SudokuGame.DI;
    using UnityEngine;

    public class SudokuCellHighlighter : MonoBehaviour
    {
        [SerializeField]
        protected SudokuCellEventHandler cellEventHandler = default;

        [SerializeField]
        protected SudokuCellsCollectionContainer sudokuCells = default;

        protected List<SudokuCell> lastHightlightedCells = new List<SudokuCell>();

        protected virtual void OnEnable()
        {
            cellEventHandler.onSelected += HighlightNeighbours;
            cellEventHandler.onDeselected += UnHighlightNeighbours;
        }

        protected virtual void OnDisable()
        {
            cellEventHandler.onSelected -= HighlightNeighbours;
            cellEventHandler.onDeselected -= UnHighlightNeighbours;
        }

        protected virtual void UnHighlightNeighbours(SudokuCell cell)
        {
            lastHightlightedCells.ForEach(x => x.UnHighlight());
            lastHightlightedCells.Clear();
        }

        protected virtual void HighlightNeighbours(SudokuCell cell)
        {
            lastHightlightedCells.AddRange(sudokuCells.GetRow(cell.Data.FieldPosition.x));
            lastHightlightedCells.AddRange(sudokuCells.GetColumn(cell.Data.FieldPosition.y));
            lastHightlightedCells.AddRange(sudokuCells.GetQuad(cell.Data.QuadPosition));
            lastHightlightedCells = lastHightlightedCells.Distinct().ToList();
            lastHightlightedCells.Remove(cell);
            lastHightlightedCells.ForEach(x => x.Highlight());
        }
    }
}
