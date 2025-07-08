using UnityEngine;
using Zenject;

namespace Infrastructure.LevelsSequence
{
	public sealed class LevelsSequenceInstaller : MonoInstaller
	{
		[SerializeField] LevelsSequenceData _data;

		public override void InstallBindings()
		{
			BindLevelsSequenceData();
			BindLevelSequenceService();
		}

		void BindLevelSequenceService()
		{
			Container
				.Bind<ILevelSequenceService>()
				.To<LevelSequenceService>()
				.AsSingle();
		}

		void BindLevelsSequenceData()
		{
			Container
				.Bind<ILevelsSequenceData>()
				.FromInstance(_data)
				.AsSingle();
		}
	}
}