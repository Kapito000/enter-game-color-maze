using CapLib.Common;
using UnityEngine;

namespace Infrastructure.Coroutine
{
	public sealed class CoroutineRunnerFactory : ICoroutineRunnerFactory
	{
		public ICoroutineRunner Create(out GameObject obj, Transform parent)
		{
			obj = new GameObject(nameof(CoroutineRunner));
			obj.transform.SetParent(parent);
			var coroutineRunner = obj.AddComponent<CoroutineRunner>();
			return coroutineRunner;
		}
	}
}