using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Humanoid
{
	public sealed class HumanoidInstaller : MonoInstaller
	{
		[SerializeField] HumanoidMovement _humanoidMovement;

		public override void InstallBindings()
		{
			BindHumanoidMovement();
		}

		void BindHumanoidMovement()
		{
			Assert.IsNotNull(_humanoidMovement);
			Container
				.Bind<IHumanoidMovement>()
				.FromInstance(_humanoidMovement)
				.AsSingle();
		}
	}
}