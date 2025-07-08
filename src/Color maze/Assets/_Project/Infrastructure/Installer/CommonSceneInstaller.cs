using Infrastructure.Coroutine;
using Zenject;

namespace Infrastructure.Installer
{
	public sealed class CommonSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindCoroutineRunner();
		}

		void BindCoroutineRunner()
		{
			Container.Bind<ICoroutineRunnerFactory>().To<CoroutineRunnerFactory>()
				.AsSingle();
		}
	}
}