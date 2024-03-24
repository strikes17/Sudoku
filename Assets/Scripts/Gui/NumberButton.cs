namespace SudokuGame.Gameplay.Gui
{
    using System;
    using SudokuGame.DI;
    using SudokuGame.Util;
    using TMPro;
    using Unity.Collections;
    using UnityEngine;

    public class NumberButton : AbstractButton
    {
        [SerializeField]
        protected SudokuCellContainer selectedSudokuCell = default;

        [SerializeField]
        protected NumberBehaviour numberBehaviour = default;

        protected override void OnButtonClicked()
        {
            if (selectedSudokuCell.Data != default)
            {
                selectedSudokuCell.Data.SetNumber(numberBehaviour.NumberContainer.Data);
            }
        }
    }
}
