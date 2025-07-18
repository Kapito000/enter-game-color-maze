using System;
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
				.Bind(typeof(ICameraInput), typeof(IDisposable))
				.To<CameraInput>()
				.AsSingle();
		}
	}
}