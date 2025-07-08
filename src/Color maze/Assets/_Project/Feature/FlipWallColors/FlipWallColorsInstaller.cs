using UnityEngine;
using Zenject;

namespace Feature.FlipWallColors
{
	public sealed class FlipWallColorsInstaller : MonoInstaller
	{
		[SerializeField] WallColorSystem _wallColorSystem;

		public override void InstallBindings()
		{
			BindWallColorSystem();
		}

		void BindWallColorSystem()
		{
			Container.Bind<IWallColorSystem>().FromInstance(_wallColorSystem)
				.AsSingle();
		}
	}
}