using Feature.HeroSpawn.Factory;
using Feature.HeroSpawn.StaticData;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.HeroSpawn
{
	public sealed class HeroSpawnInstaller : MonoInstaller
	{
		[SerializeField] HeroProvider _heroProvider;
		[SerializeField] HeroSpawnPoint _heroSpawnPoint;
		[SerializeField] HeroSpawnSystem _heroSpawnSystem;

		public override void InstallBindings()
		{
			BindHeroFactory();
			BindHeroProvider();
			BindHeroSpawnPoint();
			BindHeroSpawnSystem();
		}

		void BindHeroProvider()
		{
			Assert.IsNotNull(_heroProvider);
			Container.Bind<IHeroProvider>().FromInstance(_heroProvider).AsSingle();
		}

		void BindHeroFactory()
		{
			Container
				.Bind<IHeroFactory>()
				.To<HeroFactory>()
				.AsSingle();
		}

		void BindHeroSpawnSystem()
		{
			Assert.IsNotNull(_heroSpawnSystem);
			Container
				.Bind<IHeroSpawnSystem>()
				.FromInstance(_heroSpawnSystem)
				.AsSingle();
		}

		void BindHeroSpawnPoint()
		{
			Assert.IsNotNull(_heroSpawnPoint);

			Container
				.Bind<IHeroSpawnPoint>()
				.FromInstance(_heroSpawnPoint)
				.AsSingle();
		}
	}
}