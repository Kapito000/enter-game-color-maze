using Feature.HeroSpawn.AssetProvider;
using Feature.HeroSpawn.Factory;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.HeroSpawn
{
	public sealed class HeroSpawnInstaller : MonoInstaller
	{
		[SerializeField] HeroSpawnPoint _heroSpawnPoint;
		[SerializeField] HeroSpawnSystem _heroSpawnSystem;
		[SerializeField] HeroAssetProvider _heroAssetProvider;

		public override void InstallBindings()
		{
			BindHeroFactory();
			BindHeroSpawnPoint();
			BindHeroSpawnSystem();
			BindHeroAssetProvider();
		}

		void BindHeroAssetProvider()
		{
			Assert.IsNotNull(_heroAssetProvider);
			Container
				.Bind<IHeroAssetProvider>()
				.FromInstance(_heroAssetProvider)
				.AsSingle();
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