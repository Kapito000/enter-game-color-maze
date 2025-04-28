using Zenject;

namespace Game.Input
{
	public sealed class InputService : IInputService
	{
		[Inject] readonly Actions _actions;

		public void Enable()
		{
			_actions.Enable();
		}

		public void Disable()
		{
			_actions.Disable();
		}
	}
}