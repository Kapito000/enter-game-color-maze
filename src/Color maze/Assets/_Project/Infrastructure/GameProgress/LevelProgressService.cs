using System;
using UniRx;
using Zenject;

namespace Infrastructure.GameProgress
{
	public sealed class LevelProgressService : ILevelProgressService, IDisposable
	{
		[Inject] ISaveLoadService _saveLoadService;

		readonly CompositeDisposable _disposables = new();

		public int CurrentLevel { get; set; }

		public void Init()
		{
			_saveLoadService
				.SavingProgress
				.Subscribe(data => data.CurrentLevel = CurrentLevel)
				.AddTo(_disposables);

			_saveLoadService
				.LoadingProgress
				.Subscribe(data => CurrentLevel = data.CurrentLevel)
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables?.Dispose();
		}
	}
}