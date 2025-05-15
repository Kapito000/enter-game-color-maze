using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace Feature.HeroSpawn.AssetProvider
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(HeroAssetProvider))]
	public sealed class HeroAssetProvider : ScriptableObject, IHeroAssetProvider
	{
		[SerializeField] GameObject _hero;

		public GameObject HeroPrefab() => _hero;
	}
}