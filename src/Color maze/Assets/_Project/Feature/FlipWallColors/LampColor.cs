using Feature.FlipWall;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.FlipWallColors
{
	public sealed class LampColor : MonoBehaviour
	{
		[SerializeField] Light _light;
		
		[Inject] IFlipWallSystem _flipWallSystem;
		[Inject] IWallColorSystem _wallColorSystem;
		
		void Awake()
		{
			_flipWallSystem.CurrentAvailableKey
				.Subscribe(OnCurrentAvailableKeyChanged)
				.AddTo(this);
		}

		void OnCurrentAvailableKeyChanged(WallKey wallKey)
		{
			ChangeLightColor(wallKey);
		}

		void ChangeLightColor(WallKey wallKey)
		{
			var result = _wallColorSystem.TryGetColor(wallKey, out var color);
			Assert.IsTrue(result);
			
			_light.color = color;
		}
	}
}