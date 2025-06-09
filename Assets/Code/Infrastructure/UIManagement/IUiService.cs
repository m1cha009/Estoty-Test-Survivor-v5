namespace Code.Infrastructure.UIManagement
{
	public interface IUiService
	{
		T GetWindow<T>() where T : WindowBase;
		T OpenWindow<T>(bool pauseGame = false) where T : WindowBase;
		void CloseWindow<T>() where T : WindowBase;
		void CloseWindow(WindowBase windowBase);
		void Back();
	}
}