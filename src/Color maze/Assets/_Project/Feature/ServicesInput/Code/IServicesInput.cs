using System;
using Game.Input;
using UniRx;

namespace Feature.ServicesInput
{
	public interface IServicesInput : IInputService
	{
		IObservable<Unit> QuitePerformed { get; }
		IObservable<Unit> RestartPerformed { get; }
	}
}