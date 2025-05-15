using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.Assertions;
using Menu = Constant.CreateAssetMenu;

namespace Infrastructure.LevelsSequence
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(LevelsSequenceData))]
	public sealed class LevelsSequenceData : ScriptableObject, ILevelsSequenceData
	{
		[SerializeField] SceneReference[] _scenes;

		public bool TryGetScene(int index, out SceneReference scene)
		{
			Assert.IsFalse(index < 0);

			if (index < 0 || index >= _scenes.Length)
			{
				scene = null;
				return false;
			}

			scene = _scenes[index];
			if (scene == null)
				return false;

			return true;
		}
	}
}