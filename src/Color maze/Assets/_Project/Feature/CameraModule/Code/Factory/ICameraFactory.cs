using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Feature.CameraModule.Factory
{
	public interface ICameraFactory : IFactory
	{
		CinemachineCamera CreateVirtualCamera(Transform target);
		Camera CreateCamera();
	}
}