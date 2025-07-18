using System;
using Game.Input;
using UniRx;

namespace Feature.ServicesInput
{
	public interface IServicesInput : IInputService
	{
		IObservable<Unit> RestartPerformed { get; }
	}
}