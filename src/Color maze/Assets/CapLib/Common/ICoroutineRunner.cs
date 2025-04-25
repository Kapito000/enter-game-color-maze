using System.Collections;
using UnityEngine;

namespace CapLib.Common
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator coroutine);
	}
}