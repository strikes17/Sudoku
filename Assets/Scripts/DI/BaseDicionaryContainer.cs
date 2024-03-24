namespace SudokuGame.DI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BaseDicionaryContainer<K, T> : ScriptableObject
    {
        public event Action<T> onDataChanged = delegate { };

        public IEnumerable DataCollection => dataCollection;

        public virtual void AddData(K key, T data)
        {
            if (dataCollection.ContainsKey(key))
            {
                dataCollection.Remove(key);
            }
            dataCollection.Add(key, data);
        }

        public virtual T GetData(K key)
        {
            if (dataCollection.TryGetValue(key, out T data))
            {
                return data;
            }
            return default;
        }

        public virtual void Clear() => dataCollection.Clear();

        public virtual void RemoveData(K key) => dataCollection.Remove(key);

        protected Dictionary<K, T> dataCollection = new Dictionary<K, T>();

    }
}
