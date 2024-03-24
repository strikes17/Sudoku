namespace SudokuGame.Gameplay.Gui
{
    using SudokuGame.DI;
    using UnityEngine;

    public class LoadGameButton : AbstractButton
    {
        [SerializeField]
        protected StringContainer selectedSaveFileNameContainer = default;

        [SerializeField]
        protected FieldStateLoader fieldStateLoader = default;

        protected override void OnButtonClicked()
        {
            string fileName = selectedSaveFileNameContainer.Data;
            Debug.Log(fileName);
            fieldStateLoader.Load(fileName);
        }
    }
}
