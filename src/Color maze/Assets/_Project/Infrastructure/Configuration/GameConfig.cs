using CapLib.Common;
using Constant;
using UnityEngine;

namespace Infrastructure.Configuration
{
	[CreateAssetMenu(menuName = CreateAssetMenu.StaticData + nameof(GameConfig))]
	public sealed class GameConfig : ScriptableObject, IStaticData, IGameConfig
	{
		[SerializeField] string _firstSceneName;

		public string FirstSceneName => _firstSceneName;
	}
}