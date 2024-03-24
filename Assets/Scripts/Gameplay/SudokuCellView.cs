namespace SudokuGame.Gameplay.View
{
    using System;
    using SudokuGame.Data;
    using SudokuGame.DI;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class SudokuCellView : MonoBehaviour
    {
        [SerializeField]
        protected SpriteRenderer spriteRenderer = default;

        [SerializeField]
        protected TMP_Text numberText = default;

        [SerializeField]
        protected SudokuCellData sudokuCellData = default;

        [SerializeField]
        protected ColorVariant selectedColor = default;

        [SerializeField]
        protected ColorVariant defaultColor = default;

        [SerializeField]
        protected ColorVariant invalidColor = default;

        [SerializeField]
        protected ColorVariant hightlightColor = default;

        protected virtual void SetSelectionColor(SudokuCell sudokuCell)
        {
            spriteRenderer.color = selectedColor.Data;
        }

        protected virtual void SetDefaultColor(SudokuCell sudokuCell)
        {
            SetValidationColor(sudokuCell, sudokuCell.Data.IsValid);
        }

        protected virtual void SetHighlightColor(SudokuCell sudokuCell)
        {
            if (sudokuCell.Data.IsValid)
            {
                spriteRenderer.color = hightlightColor.Data;
            }
        }

        protected virtual void SetValidationColor(SudokuCell sudokuCell, bool isValid)
        {
            ColorVariant colorVariant = default;
            if (sudokuCell.Data.IsSelected)
            {
                colorVariant = selectedColor;
            }
            else if (!sudokuCell.Data.IsValid)
            {
                colorVariant = invalidColor;
            }
            else if (sudokuCell.Data.IsHighlited)
            {
                colorVariant = hightlightColor;
            }
            else
            {
                colorVariant = defaultColor;
            }
            spriteRenderer.color = colorVariant.Data;
        }

        protected virtual void SetNumber(SudokuCell sudokuCell, int value)
        {
            if (value == 0)
            {
                numberText.gameObject.SetActive(false);
            }
            else
            {
                numberText.gameObject.SetActive(true);
            }
            numberText.text = value.ToString();
        }

        protected virtual void OnEnable()
        {
            sudokuCellData.onSelected += SetSelectionColor;
            sudokuCellData.onDeselected += SetDefaultColor;
            sudokuCellData.onNumberSet += SetNumber;
            sudokuCellData.onValidationStatusChanged += SetValidationColor;
            sudokuCellData.onHighlighted += SetHighlightColor;
            sudokuCellData.onUnHighlighted += SetDefaultColor;
        }

        protected virtual void OnDisable()
        {
            sudokuCellData.onSelected -= SetSelectionColor;
            sudokuCellData.onDeselected -= SetDefaultColor;
            sudokuCellData.onNumberSet -= SetNumber;
            sudokuCellData.onValidationStatusChanged -= SetValidationColor;
            sudokuCellData.onHighlighted -= SetHighlightColor;
            sudokuCellData.onUnHighlighted -= SetDefaultColor;
        }

    }
}
