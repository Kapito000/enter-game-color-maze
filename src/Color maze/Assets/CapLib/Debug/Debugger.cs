using UnityEngine;

namespace CapLib.StateMachine
{
	public class Debugger : IDebugger
	{
		public void Log(string msg)
		{
			Debug.Log(msg);
		}

		public void Error(string msg)
		{
			Debug.LogError(msg);
		}
	}
}