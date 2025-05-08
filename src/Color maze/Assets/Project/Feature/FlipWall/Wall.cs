using CapLib.Id;
using CapLib.Instantiate;
using CapLib.StateMachine;
using Feature.FlipWall.StateMachine;
using Feature.FlipWall.StateMachine.States;
using UniRx;
using UnityEngine;
using Zenject;

namespace Feature.FlipWall
{
	public sealed class Wall : MonoBehaviour, IWallData
	{
		[Inject] IId _id;
		[Inject] IWallTrigger[] _wallTriggers;
		[Inject] IWallStateMachine _stateMachine;
		[Inject] IInstantiateService _instantiator;

		public IId Id => _id;
		public IWallTransitActor Actor { get; set; }
		public IWallTrigger[] ContactTriggers { get; private set; }

		[Inject]
		void Construct(IAssociationWithId association)
		{
			association.Associate(_id);
		}

		void Awake()
		{
			InitContactTriggersArray();
			InitStateMachine();
			TriggersEventProcess();
		}

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

		void InitContactTriggersArray() =>
			ContactTriggers = new IWallTrigger[_wallTriggers.Length];

		T CreateState<T>() where T : IWallState =>
			_instantiator.Instantiate<T>();
	}
}