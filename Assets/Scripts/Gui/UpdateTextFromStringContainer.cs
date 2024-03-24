using SudokuGame.DI;
using TMPro;
using UnityEngine;

namespace SudokuGame.Gameplay.Gui
{
    public class UpdateTextFromStringContainer : MonoBehaviour
    {
        [SerializeField]
        protected TMP_Text fileNameText = default;

        [SerializeField]
        protected StringContainer selectedSaveFileNameContainer = default;

        protected virtual void OnEnable() => selectedSaveFileNameContainer.onDataChanged += SetText;

        protected virtual void OnDisable() => selectedSaveFileNameContainer.onDataChanged -= SetText;

        protected virtual void SetText(string textValue) => fileNameText.text = textValue;
    }
}
