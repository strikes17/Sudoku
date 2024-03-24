namespace SudokuGame.Gameplay
{
    using SudokuGame.DI;
    using UnityEngine;

    public class SudokuCellData : SudokuCellEventHandler
    {
        [SerializeField]
        protected SudokuCell sudokuCell = default;

        public Vector2Int FieldPosition => fieldPosition;
        public Vector2Int QuadPosition => quadPosition;

        public int Number => number;

        public bool IsValid => isValid;
        public bool IsHighlited => isHighlited;
        public bool IsSelected => isSelected;

        protected int number = 0;

        protected Vector2Int fieldPosition = default;
        protected Vector2Int quadPosition = default;

        protected bool isPositionSet = false;

        [SerializeField]
        protected bool isValid = false;
        protected bool isHighlited = false;
        protected bool isSelected = false;

        protected virtual void OnEnable()
        {
            sudokuCell.onSelected += OnSelected;
            sudokuCell.onDeselected += OnDeselected;
            sudokuCell.onNumberSet += OnNumberSet;
            sudokuCell.onFieldPositionSet += OnFieldPositionSet;
            sudokuCell.onValidationStatusChanged += OnValidationStatusChanged;
            sudokuCell.onHighlighted += OnHighlighted;
            sudokuCell.onUnHighlighted += OnUnHighlighted;
            sudokuCell.onNoteSet += OnNoteSet;
        }

        protected virtual void OnDisable()
        {
            sudokuCell.onSelected -= OnSelected;
            sudokuCell.onDeselected -= OnDeselected;
            sudokuCell.onNumberSet -= OnNumberSet;
            sudokuCell.onFieldPositionSet -= OnFieldPositionSet;
            sudokuCell.onValidationStatusChanged -= OnValidationStatusChanged;
            sudokuCell.onHighlighted -= OnHighlighted;
            sudokuCell.onUnHighlighted -= OnUnHighlighted;
            sudokuCell.onNoteSet -= OnNoteSet;
        }

        protected override void OnSelected(SudokuCell sudokuCell)
        {
            isSelected = true;
            base.OnSelected(sudokuCell);
        }

        protected override void OnDeselected(SudokuCell sudokuCell)
        {
            isSelected = false;
            base.OnDeselected(sudokuCell);
        }

        protected override void OnHighlighted(SudokuCell sudokuCell)
        {
            isHighlited = true;
            base.OnHighlighted(sudokuCell);
        }

        protected override void OnUnHighlighted(SudokuCell sudokuCell)
        {
            isHighlited = false;
            base.OnUnHighlighted(sudokuCell);
        }

        protected override void OnValidationStatusChanged(SudokuCell sudokuCell, bool isValid)
        {
            this.isValid = isValid;
            base.OnValidationStatusChanged(sudokuCell, isValid);
        }

        protected override void OnFieldPositionSet(SudokuCell sudokuCell, Vector2Int position)
        {
            if (!isPositionSet)
            {
                fieldPosition = position;
                quadPosition = new Vector2Int(fieldPosition.x / 3, fieldPosition.y / 3);
                isPositionSet = true;
                base.OnFieldPositionSet(sudokuCell, position);
            }
        }

        protected override void OnNumberSet(SudokuCell sudokuCell, int newNumber)
        {
            number = newNumber;
            base.OnNumberSet(sudokuCell, number);
        }

    }
}
