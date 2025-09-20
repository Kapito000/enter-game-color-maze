using JetBrains.Annotations;

namespace CapLib.Id
{
	public class IntId : IId
	{
		readonly int _value;

		public IntId(int value)
		{
			_value = value;
		}

		public bool Equals([CanBeNull] IId other)
		{
			if (other is not IntId id)
				return false;

			return _value == id._value;
		}
	}
}