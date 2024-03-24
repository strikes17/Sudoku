namespace SudokuGame.DI
{
    using System;
    using UnityEngine;

    public class BaseContainer<T> : ScriptableObject
    {
        public event Action<T> onDataChanged = delegate { };

        public virtual T Data
        {
            get => data;
            set
            {
                if (value != null)
                {
                    data = value;
                    OnDataChanged();
                }
                else
                {
                    Debug.LogError("Data cannot be null");
                }
            }
        }

        public virtual void Clear() => data = default;

        protected virtual void OnDataChanged() => onDataChanged(data);

        [SerializeField]
        protected T data = default;

    }
}
