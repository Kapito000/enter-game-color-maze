using CapLib.GameStatus;
using Infrastructure.GameProgress;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class EndLevel : IState
	{
		[Inject] ISaveLoadService _saveLoadService;
		[Inject] ILevelProgressService _levelProgressService;

		public void Enter()
		{
			_levelProgressService.CurrentLevel++;
			_saveLoadService.SaveProgress();
		}

		public void Exit()
		{ }
	}
}