using CapLib.Common;
using Unity.Cinemachine;

namespace Feature.Camera.AssetProvider
{
	public interface ICameraProvider : IAssetProvider
	{
		UnityEngine.Camera Camera();
		CinemachineCamera CinemachineCamera();
	}
}