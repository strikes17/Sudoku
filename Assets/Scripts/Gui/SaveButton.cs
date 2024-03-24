namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;

    public class SaveButton : AbstractButton
    {
        [SerializeField]
        protected FieldStateSaver fieldStateSaver = default;

        protected override void OnButtonClicked() => fieldStateSaver.Save();
    }
}
