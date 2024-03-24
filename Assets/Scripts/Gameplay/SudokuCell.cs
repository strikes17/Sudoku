namespace SudokuGame.Gameplay
{
    using System;
    using System.Collections.Generic;
    using SudokuGame.DI;
    using SudokuGame.Util;
    using UnityEngine;
    using UnityEngine.EventSystems;

    [RequireComponent(typeof(SudokuCellData), typeof(BoxCollider2D))]
    public class SudokuCell : SudokuCellEventHandler, IPoolable
    {
        [SerializeField]
        protected SudokuCellData sudokuCellData = default;

        public event Action onStateChanged = delegate { };

        public SudokuCellData Data => sudokuCellData;

        public IPoolable NewInstance => Instantiate(this);

        public bool IsActiveState => gameObject.activeSelf;

        public void SetValidationStatus(bool isValid) => OnValidationStatusChanged(this, isValid);
        public void Select() => OnSelected(this);
        public void Deselect() => OnDeselected(this);
        public void SetNumber(int number) => OnNumberSet(this, number);
        public void SetNote(int number) => OnNoteSet(this, number);
        public void SetFieldPosition(Vector2Int position) => OnFieldPositionSet(this, position);
        public void Highlight() => OnHighlighted(this);
        public void UnHighlight() => OnUnHighlighted(this);

        public void SetActiveState() => gameObject.SetActive(true);

        public void SetDisableState() => gameObject.SetActive(false);

        public void Dispose() => gameObject.SetActive(false);
    }
}
