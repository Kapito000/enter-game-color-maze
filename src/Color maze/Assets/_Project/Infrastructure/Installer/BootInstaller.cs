using CapLib.GameStatus;
using Infrastructure.GameStatus.State;
using Zenject;

namespace Infrastructure.Installer
{
	public sealed class BootInstaller : MonoInstaller, IInitializable
	{
		[Inject] IGameStateMachine _gameStateMachine;

		public override void InstallBindings()
		{
			BindInitializable();
		}

		public void Initialize()
		{
			_gameStateMachine.TryEnter<Boot>();
		}

		void BindInitializable()
		{
			Container.Bind<IInitializable>().FromInstance(this).AsSingle();
		}
	}
}