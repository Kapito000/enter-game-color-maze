using System.Collections;
using UnityEngine;

namespace CapLib.Common
{
	public interface ICoroutineRunner : IService
	{
		Coroutine StartCoroutine(IEnumerator coroutine);
	}
}