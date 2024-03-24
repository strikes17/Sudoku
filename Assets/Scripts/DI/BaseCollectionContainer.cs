namespace SudokuGame.DI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BaseCollectionContainer<T> : ScriptableObject
    {
        [SerializeField]
        protected bool canHaveDuplicates = false;

        public event Action<T> onDataChanged = delegate { };

        public virtual IEnumerable DataCollection => dataCollection;

        public virtual void AddData(T data)
        {
            if (canHaveDuplicates)
            {
                if (dataCollection.Contains(data))
                {
                    dataCollection.Add(data);
                }
            }
            else
            {
                if (!dataCollection.Contains(data))
                {
                    dataCollection.Add(data);
                }
            }
        }

        public virtual void Clear() => dataCollection.Clear();

        public virtual void RemoveData(T data) => dataCollection.Remove(data);

        [SerializeField]
        protected List<T> dataCollection = new List<T>();

    }
}
