using Zenject;

namespace Infrastructure.GameProgress
{
	public sealed class GameProgressInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindSaveLoadService();
			BindLevelProgressService();
		}

		void BindLevelProgressService()
		{
			Container
				.BindInterfacesTo<LevelProgressService>()
				.AsSingle();
		}

		void BindSaveLoadService()
		{
			Container
				.BindInterfacesTo<SaveLoadService>()
				.AsSingle();
		}
	}
}