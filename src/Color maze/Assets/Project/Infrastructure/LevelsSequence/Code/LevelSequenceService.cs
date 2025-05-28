using CapLib.GameStatus;
using Infrastructure.GameProgress;
using Infrastructure.GameStatus.State;
using UnityEngine;
using Zenject;

namespace Infrastructure.LevelsSequence
{
	public sealed class LevelSequenceService : ILevelSequenceService
	{
		[Inject] ILevelProgressService _levelProgressService;
		[Inject] ISceneLoadState _sceneLoadState;
		[Inject] IGameStateMachine _gameStateMachine;
		[Inject] ILevelsSequenceData _levelsSequenceData;

		public void LoadNextLevel()
		{
			var currentLevel = _levelProgressService.CurrentLevel;
			var nextLevel = currentLevel;
			if (_levelsSequenceData.TryGetScene(nextLevel, out var scene) == false)
			{
				Debug.LogError($"Cannot to get the next level by num {nextLevel}.");
				return;
			}

			_sceneLoadState.SetLoadingScene(scene.Name);
			_gameStateMachine.TryEnter<SceneLoad>();
		}
	}
}