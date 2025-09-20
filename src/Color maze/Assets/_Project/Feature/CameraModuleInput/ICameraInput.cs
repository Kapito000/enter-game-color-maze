using System;
using Game.Input;
using UniRx;

namespace Feature.CameraModuleInput
{
	public interface ICameraInput : IInputService
	{
		IObservable<Unit> SwitchCameraModePerformed { get; }
	}
}