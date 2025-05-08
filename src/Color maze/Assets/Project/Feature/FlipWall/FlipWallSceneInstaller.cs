using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.FlipWall
{
	public sealed class FlipWallSceneInstaller : MonoInstaller
	{
		[SerializeField] FlipWallSystem _flipWallSystem;

		public override void InstallBindings()
		{
			BindFlipWallSystem();
		}

		void BindFlipWallSystem()
		{
			Assert.IsNotNull(_flipWallSystem);
			Container.Bind<IFlipWallSystem>().FromInstance(_flipWallSystem)
				.AsSingle();
		}
	}
}