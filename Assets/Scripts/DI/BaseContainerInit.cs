namespace SudokuGame.DI
{
    using UnityEngine;

    public class BaseContainerInit<T> : MonoBehaviour
    {
        [SerializeField]
        protected BaseContainer<T> container = default;

        [SerializeField]
        protected T data = default;

        protected virtual void InitializeContainer() => container.Data = data;

        protected virtual void Awake()
        {
            DontDestroyOnLoad(transform.parent.gameObject);
            DontDestroyOnLoad(gameObject);
            InitializeContainer();
        }

        protected virtual void OnDestroy() => container.Clear();

    }
}
