using CapLib.Common;

namespace CapLib.Id
{
	public interface IIdFactory : IFactory
	{
		IId CreateId();
	}
}