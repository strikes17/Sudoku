namespace SudokuGame.Gameplay.Gui
{
    using SudokuGame.DI;
    using UnityEngine;

    public class NumberNoteButton : AbstractButton
    {
        [SerializeField]
        protected SudokuCellContainer selectedSudokuCell = default;

        [SerializeField]
        protected NumberBehaviour numberBehaviour = default;

        protected override void OnButtonClicked() => selectedSudokuCell.Data.SetNote(numberBehaviour.NumberContainer.Data);
    }
}
