namespace SudokuGame.Gameplay.Gui
{
    using SudokuGame.DI;
    using SudokuGame.Systems;

    public class GameStarterContainerInit : BaseContainerInit<BaseGameStarter>
    {
        protected override void InitializeContainer()
        {
            DontDestroyOnLoad(data);
            base.InitializeContainer();
        }
    }
}
