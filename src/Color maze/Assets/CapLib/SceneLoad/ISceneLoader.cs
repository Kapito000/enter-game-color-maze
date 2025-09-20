using System;
using CapLib.Common;

namespace CapLib.SceneLoad
{
	public interface ISceneLoader : IService
	{
		void Load(string name, Action onLoaded = null);
	}
}