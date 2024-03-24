using SudokuGame.DI;
using UnityEngine;

namespace SudokuGame.Gameplay.Gui
{
    public class SelectSaveButton : AbstractButton
    {
        [SerializeField]
        protected StringContainer selectedSaveFileNameContainer = default;

        [SerializeField]
        protected SelectSaveBehaviour selectSaveBehaviour = default;

        protected override void OnButtonClicked() => selectedSaveFileNameContainer.Data = selectSaveBehaviour.SaveFileName;
    }
}
