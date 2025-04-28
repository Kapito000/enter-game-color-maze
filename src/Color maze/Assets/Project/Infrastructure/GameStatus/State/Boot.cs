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
			TryLoadFirstScene();
			_inputService.Enable();
		}

		public void Exit()
		{ }

		bool TryLoadFirstScene()
		{
			var firstSceneName = _gameConfig.FirstSceneName;
			_sceneLoadState.SetLoadingScene(firstSceneName);

			if (_gameStateMachine.TryEnter<SceneLoad>() == false)
			{
				Debug.LogError($"Cannot to load first scene: {firstSceneName}");
				return false;
			}

			return true;
		}
	}
}