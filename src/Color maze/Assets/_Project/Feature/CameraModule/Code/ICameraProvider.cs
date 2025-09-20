using Unity.Cinemachine;
using UnityEngine;

namespace Feature.CameraModule
{
	public interface ICameraProvider
	{
		Camera Camera { get; set; }
		CinemachineVirtualCameraBase MainVirtualCamera { get; set; }
		CinemachineVirtualCameraBase LevelOverviewVirtualCamera { get; set; }
	}
}