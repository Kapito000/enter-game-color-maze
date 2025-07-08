using CapLib.GameStatus;
using CapLib.SceneLoad;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class SceneLoad : ISceneLoadState, IState
	{
		[Inject] ISceneLoader _sceneLoader;
		
		string _loadingSceneName;

		public void SetLoadingScene(string sceneName)
		{
			_loadingSceneName = sceneName;
		}

		public void Enter()
		{
			_sceneLoader.Load(_loadingSceneName);
		}

		public void Exit()
		{ }
	}
}