using System;

namespace CapLib.SceneLoad
{
	public interface ISceneLoader
	{
		void Load(string name, Action onLoaded = null);
	}
}