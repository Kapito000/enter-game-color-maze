using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace Feature.UI
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(UiAssetProvider))]
	public sealed class UiAssetProvider : ScriptableObject, IUiAssetProvider
	{
		[SerializeField] GameObject _ui;

		public GameObject UI => _ui;
	}
}