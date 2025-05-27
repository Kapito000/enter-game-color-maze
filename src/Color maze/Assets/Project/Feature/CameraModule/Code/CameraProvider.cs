using Unity.Cinemachine;
using UnityEngine;

namespace Feature.CameraModule
{
	public sealed class CameraProvider : ICameraProvider
	{
		public Camera Camera { get; set; }
		public CinemachineVirtualCameraBase MainVirtualCamera {get; set; }
		public CinemachineVirtualCameraBase LevelOverviewVirtualCamera {get; set; }
	}
}