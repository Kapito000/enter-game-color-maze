using CapLib.GameStatus;
using Feature.CameraModule;
using Feature.EndLevelProcess;
using Feature.HeroSpawn;
using Feature.UI;
using Infrastructure.GameStatus.State;
using UnityEngine;
using Zenject;

namespace Feature.InitLevel
{
	public class InitLevelSystem : MonoBehaviour
	{
		[Inject] IUiFactory _uiFactory;
		[Inject] IHeroSpawnSystem _heroSpawnSystem;
		[Inject] IEndLevelService _endLevelService;
		[Inject] IGameStateMachine _gameStateMachine;
		[Inject] ISpawnCameraSystem  _spawnCameraSystem;
		
		void Start()
		{
			_gameStateMachine.TryEnter<StartLevel>();
			
			if (_heroSpawnSystem.TrySpawn(out var heroObj) == false)
			{
				Debug.LogError("Failed to spawn hero.");
				return;
			}
			
			_spawnCameraSystem.Spawn(heroObj.transform);

			_uiFactory.Create();

			_gameStateMachine.TryEnter<Loop>();
		}
	}
}