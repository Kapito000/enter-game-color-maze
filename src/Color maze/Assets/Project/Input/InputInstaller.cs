using System;
using Zenject;

namespace Game.Input
{
	public sealed class InputInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindInputServices();
		}

		void BindInputServices()
		{
			Container.Bind<InputActions>().AsSingle();
			Container.Bind<IInputService>().To<InputService>().AsSingle();
			Container
				.Bind(typeof(IMovementInput), typeof(IDisposable))
				.To<MovementInput>().AsSingle();
		}
	}
}