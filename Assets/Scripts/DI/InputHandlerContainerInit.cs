namespace SudokuGame.DI
{
    using SudokuGame.Input;
    
    public class InputHandlerContainerInit : BaseContainerInit<InputHandler>
    {
        protected override void InitializeContainer()
        {
            DontDestroyOnLoad(data);
            base.InitializeContainer();
        }
    }
}
