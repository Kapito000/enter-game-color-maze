using CapLib.GameStatus;
using Infrastructure.GameProgress;
using Infrastructure.GameStatus.State;
using Infrastructure.LevelsSequence;
using Zenject;

namespace Feature.EndLevelProcess
{
	public sealed class EndLevelService : IEndLevelService
	{
		[Inject] ISaveLoadService _saveLoadService;
		[Inject] IGameStateMachine _gameStateMachine;
		[Inject] ILevelSequenceService _levelSequenceService;

		public void EndCurrentLevel()
		{
			_gameStateMachine.TryEnter<EndLevel>();
			_levelSequenceService.LoadNextLevel();
		}
	}
}