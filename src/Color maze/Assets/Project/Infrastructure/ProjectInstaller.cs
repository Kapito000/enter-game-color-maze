using CapLib.GameStatus;
using CapLib.SceneLoad;
using Infrastructure.GameStatus.State;
using Zenject;

namespace Infrastructure
{
	public sealed class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindSceneLoader();
			BindGameSceneMachine();
		}

		void BindGameSceneMachine()
		{
			Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
			Container.Bind<IState>().To<Start>().AsSingle();
			Container.Bind<IState>().To<Loop>().AsSingle();
			Container.Bind<IState>().To<ExitGame>().AsSingle();
		}

		void BindSceneLoader() =>
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
	}
}