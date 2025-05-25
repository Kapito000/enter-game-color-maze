using CapLib.GameStatus;
using Game.Input;
using Infrastructure.Configuration;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class Boot : IState
	{
		[Inject] IGameConfig _gameConfig;
		[Inject] IInputService _inputService;
		[Inject] ISceneLoadState _sceneLoadState;
		[Inject] IGameStateMachine _gameStateMachine;

		public void Enter()
		{
			if (TryLoadFirstScene() == false)
			{
				Debug.LogError("Failed to load first scene.");
				return;
			}

			_inputService.Enable();
		}

		public void Exit()
		{ }


		bool TryLoadFirstScene()
		{
			var firstSceneName = FirestScene();
			return TryLoadScene(firstSceneName);
		}

		bool TryLoadScene(string sceneName)
		{
			_sceneLoadState.SetLoadingScene(sceneName);

			if (_gameStateMachine.TryEnter<SceneLoad>() == false)
			{
				Debug.LogError($"Cannot to load first scene: {sceneName}");
				return false;
			}

			return true;
		}

		string FirestScene()
		{
#if UNITY_EDITOR
			var shouldLoadBootstrapScene = CapLib.SceneBootstrapper.SceneBootstrapper
				.ShouldLoadBootstrapScene;
			var previousScene = CapLib.SceneBootstrapper.SceneBootstrapper
				.PreviousScene;

			if (shouldLoadBootstrapScene && !string.IsNullOrEmpty(previousScene))
				return previousScene;
#endif

			return _gameConfig.FirstSceneName;
		}
	}
}