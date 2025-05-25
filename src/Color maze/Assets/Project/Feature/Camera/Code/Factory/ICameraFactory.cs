using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Feature.Camera.Factory
{
	public interface ICameraFactory : IFactory
	{
		CinemachineCamera Create(Transform target);
	}
}