using System.Collections.Generic;
using CapLib.StateMachine;
using Feature.FlipWall.StateMachine;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.FlipWall
{
	public sealed class WallInstaller : MonoInstaller
	{
		[SerializeField] Wall _wall;
		[Header("Only two triggers.")]
		[SerializeField] WallTrigger[] _wallTriggers;

		public override void InstallBindings()
		{
			BindWall();
			BindWallTriggers();
			BindWallStateMachine();
		}

		void BindWallStateMachine()
		{
			Container
				.Bind<IStateMediatorFactory<IWallState>>()
				.To<MediatorFactory<IWallState>>()
				.AsTransient();
			Container
				.Bind<IMediatorContainer<State, IWallState>>()
				.To<DictionaryMediatorContainer<State, IWallState>>()
				.AsTransient();
			Container
				.Bind<IWallStateMachine>()
				.To<WallStateMachine>()
				.AsTransient();
		}

		void BindWall()
		{
			Container.BindInterfacesTo<Wall>().FromInstance(_wall).AsSingle();
		}

		void BindWallTriggers()
		{
#if UNITY_EDITOR
			foreach (var t in _wallTriggers)
				Assert.IsNotNull(t);
#endif

			Container
				.BindInterfacesTo<WallTrigger>()
				.FromMethodMultiple(GetWallTriggers)
				.AsSingle();
		}

		IEnumerable<WallTrigger> GetWallTriggers(InjectContext context) =>
			_wallTriggers;

		void OnValidate()
		{
			if (_wallTriggers.Length > 2)
				_wallTriggers = new[] { _wallTriggers[0], _wallTriggers[1] };
		}
	}
}