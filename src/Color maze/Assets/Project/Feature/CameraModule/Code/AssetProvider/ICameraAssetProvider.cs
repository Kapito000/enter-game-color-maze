using CapLib.Common;
using Unity.Cinemachine;

namespace Feature.CameraModule.AssetProvider
{
	public interface ICameraAssetProvider : IAssetProvider
	{
		UnityEngine.Camera Camera();
		CinemachineCamera CinemachineCamera();
	}
}