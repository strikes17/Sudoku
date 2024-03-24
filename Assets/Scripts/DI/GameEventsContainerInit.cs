namespace SudokuGame.DI
{
    using SudokuGame.Systems;
    using UnityEngine;

    public class GameEventsContainerInit : BaseContainerInit<GameEventsHandler>
    {
        protected override void InitializeContainer()
        {
            DontDestroyOnLoad(data);
            base.InitializeContainer();
        }
    }
}
