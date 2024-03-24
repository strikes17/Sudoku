using System.ComponentModel;
using TMPro;
using UnityEngine;

namespace SudokuGame.Gameplay.Gui
{
    public class SelectSaveTextView : MonoBehaviour
    {
        [SerializeField]
        protected TMP_Text fileNameText = default;

        [SerializeField]
        protected SelectSaveBehaviour selectSaveBehaviour = default;

        protected virtual void OnEnable()
        {
            SetText(selectSaveBehaviour.SaveFileName);
            selectSaveBehaviour.onFileNameChanged += SetText;
        }

        protected virtual void OnDisable() => selectSaveBehaviour.onFileNameChanged -= SetText;

        protected virtual void SetText(string textValue) => fileNameText.text = textValue.Replace($"{Application.dataPath}/saves\\", string.Empty);
    }
}
