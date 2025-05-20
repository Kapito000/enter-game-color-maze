using System.Diagnostics;
using CapLib.Id;
using CapLib.StateMachine;
using Feature.FlipWall.StateMachine;
using Feature.FlipWall.StateMachine.States;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UniRx;
using UnityEngine;
using Zenject;

namespace Feature.FlipWall
{
	public sealed class Wall : MonoBehaviour, IWall, IWallData
	{
		[SerializeField] WallKey _key;
#if UNITY_EDITOR
		[Space, ReadOnly]
		[SerializeField] State _state;
#endif

		[Inject] IId _id;
		[Inject] Collider _blockCollider;
		[Inject] IWallTrigger[] _wallTriggers;
		[Inject] IFlipWallSystem _flipWallSystem;
		[Inject] IWallStateMachine _stateMachine;
		[Inject] IInstantiator _instantiator;

		public IId Id => _id;
		public IWallTransitActor Actor { get; set; }
		public IWallTrigger[] ContactTriggers { get; private set; }

		[Inject]
		void Construct(IAssociationWithId[] association)
		{
			association.ForEach(x => x.Associate(_id));
		}

		void Awake()
		{
			InitContactTriggersArray();
			InitStateMachine();
			TriggersEventProcess();
			RegistryInSystem();
			CurrentStateKeyChangeSubscribe();
		}

		public void Block(bool enable)
		{
			_blockCollider.enabled = enable;
		}

		void InitContactTriggersArray() =>
			ContactTriggers = new IWallTrigger[_wallTriggers.Length];

		void InitStateMachine()
		{
			_stateMachine
				.AddState(CreateState<OutsideState>())
				.AddState(CreateState<AtEnterState>())
				.AddState(CreateState<AtMiddleState>())
				.AddState(CreateState<AtExitState>())
				;

			_stateMachine.Enter(State.Outside);
		}

		void TriggersEventProcess()
		{
			foreach (var trigger in _wallTriggers)
			{
				trigger.ActorEntered
					.Subscribe(actor => _stateMachine.ActorEnterProcess(actor, trigger))
					.AddTo(this);
				trigger.ActorExited
					.Subscribe(actor => _stateMachine.ActorExitProcess(actor, trigger))
					.AddTo(this);
			}
		}

		void RegistryInSystem()
		{
			_flipWallSystem.Registry(this, _key);
		}

		T CreateState<T>() where T : IWallState =>
			_instantiator.Instantiate<T>();

		[Conditional("UNITY_EDITOR")]
		void CurrentStateKeyChangeSubscribe()
		{
#if UNITY_EDITOR
			_stateMachine.CurrentStateKey.Subscribe(value => _state = value)
				.AddTo(this);
#endif
		}
	}
}