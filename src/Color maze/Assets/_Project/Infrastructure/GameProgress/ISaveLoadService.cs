using System;
using CapLib.Common;

namespace Infrastructure.GameProgress
{
	public interface ISaveLoadService : IService
	{
		void SaveProgress();
		void LoadProgress();
		IObservable<GameProgress> SavingProgress { get; }
		IObservable<GameProgress> LoadingProgress { get; }
	}
}