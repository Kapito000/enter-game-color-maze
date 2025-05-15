using System;
using CapLib.Id;
using UniRx;
using UnityEngine;

namespace Feature.FlipWall
{
	public class WallTrigger : MonoBehaviour, IWallTrigger, IAssociationWithId
	{
		readonly Subject<IWallTransitActor> _actorEntered = new();
		readonly Subject<IWallTransitActor> _actorExited = new();

		public IId WallId { get; private set; }
		public IObservable<IWallTransitActor> ActorEntered => _actorEntered;
		public IObservable<IWallTransitActor> ActorExited => _actorExited;

		void OnTriggerEnter(Collider other)
		{
			if (TryGetActor(other, out var actor) == false)
				return;

			_actorEntered.OnNext(actor);
		}

		void OnTriggerExit(Collider other)
		{
			if (TryGetActor(other, out var actor) == false)
				return;

			_actorExited.OnNext(actor);
		}

		public void Associate(IId id)
		{
			WallId = id;
		}

		bool TryGetActor(Collider other, out IWallTransitActor actor)
		{
			if (other.TryGetComponent<IWallTransitActor>(out actor))
				return true;

			actor = null;
			return false;
		}

		void OnDestroy()
		{
			_actorEntered.OnCompleted();
			_actorEntered.Dispose();
			_actorExited.OnCompleted();
			_actorExited.Dispose();
		}
	}
}