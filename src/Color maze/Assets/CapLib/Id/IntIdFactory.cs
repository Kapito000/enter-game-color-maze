namespace CapLib.Id
{
	public class IntIdFactory : IIdFactory
	{
		int _nextId;

		public IId CreateId() =>
			new IntId(_nextId++);
	}
}