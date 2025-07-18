using System;
using Zenject;

namespace Feature.ServicesInput
{
	public sealed class ServicesInputInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind(typeof(IServicesInput), typeof(IDisposable))
				.To<ServicesInput>()
				.AsSingle();
		}
	}
}