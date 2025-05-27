using System;
using Game.Input;
using Zenject;

namespace Feature.MovementInput
{
	public sealed class MovementInputInstaller : MonoInstaller
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