using Zenject;

namespace Feature.CameraModuleInput
{
	public sealed class CameraInputInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindOverviewLevelInput();
		}

		void BindOverviewLevelInput()
		{
			Container
				.Bind<ICameraInput>()
				.To<CameraInput>()
				.AsSingle();
		}
	}
}