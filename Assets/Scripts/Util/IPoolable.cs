namespace SudokuGame.Util
{
    using System;

    public interface IPoolable
    {
        event Action onStateChanged;

        void SetActiveState();
        void SetDisableState();
        void Dispose();

        IPoolable NewInstance { get; }

        bool IsActiveState { get; }
    }
}
