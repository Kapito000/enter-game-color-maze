using CapLib.Common;

namespace Game.Input
{
	public interface IInputService : IService
	{
		void Enable();
		void Disable();
	}
}