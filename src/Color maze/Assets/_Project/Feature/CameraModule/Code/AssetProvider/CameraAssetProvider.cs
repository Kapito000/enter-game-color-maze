using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace Feature.CameraModule.AssetProvider
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(CameraAssetProvider))]
	public sealed class CameraAssetProvider : ScriptableObject, ICameraAssetProvider
	{
		[Required]
		[SerializeField] UnityEngine.Camera _camera;
		[Required]
		[SerializeField] CinemachineCamera _cinemachineCamera;

		public UnityEngine.Camera Camera() => _camera;

		public CinemachineCamera CinemachineCamera() => _cinemachineCamera;
	}
}