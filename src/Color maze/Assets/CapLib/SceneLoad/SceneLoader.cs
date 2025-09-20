using System;
using UniRx;
using UnityEngine.SceneManagement;

namespace CapLib.SceneLoad
{
	public class SceneLoader : ISceneLoader
	{
		public void Load(string name, Action onLoaded)
		{
			SceneManager.LoadSceneAsync(name)
				.AsObservable()
				.First()
				.Subscribe(_ => onLoaded?.Invoke());
		}
	}
}