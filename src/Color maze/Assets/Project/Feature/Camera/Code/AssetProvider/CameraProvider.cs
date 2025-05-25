using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace Feature.Camera.AssetProvider
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(CameraProvider))]
	public sealed class CameraProvider : ScriptableObject, ICameraProvider
	{
		[Required]
		[SerializeField] UnityEngine.Camera _camera;
		[Required]
		[SerializeField] CinemachineCamera _cinemachineCamera;

		public UnityEngine.Camera Camera() => _camera;

		public CinemachineCamera CinemachineCamera() => _cinemachineCamera;
	}
}