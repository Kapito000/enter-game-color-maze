using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CapLib.SceneLoad
{
	public class SceneLoader : ISceneLoader
	{
		public void Load(string name, Action onLoaded)
		{
			SceneManager.LoadSceneAsync(name)
				.AsObservable()
				.Do(x=> Debug.Log(x.progress))
				.First()
				.Subscribe(_ => onLoaded?.Invoke());
		}
	}
}