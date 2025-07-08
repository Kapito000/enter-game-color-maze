using CapLib.Common;
using CapLib.GameStatus;
using CapLib.Id;
using CapLib.SceneLoad;
using Infrastructure.Configuration;
using Infrastructure.GameProgress;
using Infrastructure.GameStatus.State;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Infrastructure.Installer
{
	public sealed class ProjectInstaller : MonoInstaller, ICoroutineRunner
	{
		[SerializeField] GameConfig gameConfig;

		public override void InstallBindings()
		{
			BindIdFactory();
			BindSceneLoader();
			BindCoroutineRunner();
			BindGameSceneMachine();
			BindGameConfiguration();
		}

		void BindIdFactory()
		{
			Container.Bind<IIdFactory>().To<IntIdFactory>().AsSingle();
			Container.Bind<IId>().FromMethod(CreateNewId).AsTransient();
		}

		IId CreateNewId(InjectContext context)
		{
			var idFactory = Container.Resolve<IIdFactory>();
			return idFactory.CreateId();
		}

		void BindCoroutineRunner()
		{
			Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
		}

		void BindGameConfiguration()
		{
			Assert.IsNotNull(gameConfig);

			Container.Bind<IGameConfig>().FromInstance(gameConfig).AsSingle();
		}

		void BindGameSceneMachine()
		{
			Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
			
			Container.Bind<IState>().To<Boot>().AsSingle();
			Container.BindInterfacesTo<SceneLoad>().AsSingle();
			Container.Bind<IState>().To<StartLevel>().AsSingle();
			Container.Bind<IState>().To<Loop>().AsSingle();
			Container.Bind<IState>().To<EndLevel>().AsSingle();
			Container.Bind<IState>().To<Quit>().AsSingle();
		}

		void BindSceneLoader() =>
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
	}
}