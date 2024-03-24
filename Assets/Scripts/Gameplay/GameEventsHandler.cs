namespace SudokuGame.Systems
{
    using System;
    using UnityEngine;

    public class GameEventsHandler : MonoBehaviour
    {
        [SerializeField]
        protected BaseGameStarter gameStarter = default;

        public event Action onGameStarted = delegate { };

        public event Action onGameStopped = delegate { };

        protected virtual void OnGameStarted() => onGameStarted();

        protected virtual void OnGameStopped() => onGameStopped();

        protected virtual void Awake() => gameStarter.onGameStarted += OnGameStarted;

        protected virtual void OnDestroy() => gameStarter.onGameStarted -= OnGameStarted;
    }

}
