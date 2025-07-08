using CapLib.Common;
using UnityEngine;

namespace Infrastructure.Coroutine
{
	public interface ICoroutineRunnerFactory : IFactory
	{
		ICoroutineRunner Create(out GameObject obj, Transform parent = null);
	}
}