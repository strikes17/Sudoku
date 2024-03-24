
namespace SudokuGame.Systems
{
    using System;
    using UnityEngine;

    public class BaseGameStarter : MonoBehaviour
    {
        public event Action onGameStarted = delegate { };

        public virtual void StartGame() => onGameStarted();
    }
}
