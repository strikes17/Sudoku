namespace SudokuGame.Gameplay
{
    using System;
    using SudokuGame.DI;
    using UnityEngine;

    public class SudokuCellEventHandler : MonoBehaviour
    {
        public event Action<SudokuCell> onSelected = delegate { };
        public event Action<SudokuCell> onDeselected = delegate { };
        public event Action<SudokuCell, int> onNumberSet = delegate { };
        public event Action<SudokuCell, Vector2Int> onFieldPositionSet = delegate { };
        public event Action<SudokuCell, bool> onValidationStatusChanged = delegate { };
        public event Action<SudokuCell> onHighlighted = delegate { };
        public event Action<SudokuCell> onUnHighlighted = delegate { };
        public event Action<SudokuCell, int> onNoteSet = delegate { };

        protected virtual void OnSelected(SudokuCell sudokuCell) => onSelected(sudokuCell);
        protected virtual void OnDeselected(SudokuCell sudokuCell) => onDeselected(sudokuCell);
        protected virtual void OnNumberSet(SudokuCell sudokuCell, int number) => onNumberSet(sudokuCell, number);
        protected virtual void OnHighlighted(SudokuCell sudokuCell) => onHighlighted(sudokuCell);
        protected virtual void OnUnHighlighted(SudokuCell sudokuCell) => onUnHighlighted(sudokuCell);
        protected virtual void OnNoteSet(SudokuCell sudokuCell, int number) => onNoteSet(sudokuCell, number);

        protected virtual void OnFieldPositionSet(SudokuCell sudokuCell, Vector2Int position) =>
            onFieldPositionSet(sudokuCell, position);
            
        protected virtual void OnValidationStatusChanged(SudokuCell sudokuCell, bool isValid) =>
            onValidationStatusChanged(sudokuCell, isValid);
    }
}
