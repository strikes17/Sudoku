using System;
using SudokuGame.Util;
using UnityEngine;

namespace SudokuGame.Gameplay.Gui
{
    public class SelectSaveBehaviour : MonoBehaviour, IPoolable
    {
        public IPoolable NewInstance => Instantiate(this);

        public bool IsActiveState => gameObject.activeSelf;

        public event Action onStateChanged = delegate { };

        public void Dispose() => gameObject.SetActive(false);

        public void SetActiveState() => gameObject.SetActive(true);

        public void SetDisableState() => gameObject.SetActive(false);

        public Action<string> onFileNameChanged = delegate { };

        public virtual string SaveFileName
        {
            get => saveFileName;
            set
            {
                if (saveFileName != value)
                {
                    saveFileName = value;
                    onFileNameChanged(saveFileName);
                }
            }
        }

        protected string saveFileName = string.Empty;
    }
}
