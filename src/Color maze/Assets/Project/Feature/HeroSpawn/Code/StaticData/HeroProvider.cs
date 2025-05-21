using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace Feature.HeroSpawn.StaticData
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(HeroProvider))]
	public sealed class HeroProvider : ScriptableObject, IHeroProvider
	{
		[SerializeField] GameObject _hero;

		public GameObject Hero() => _hero;
	}
}