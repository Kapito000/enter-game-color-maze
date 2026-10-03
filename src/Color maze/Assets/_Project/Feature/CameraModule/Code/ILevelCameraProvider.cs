using Unity.Cinemachine;

namespace Feature.CameraModule
{
	public interface ILevelCameraProvider
	{
		CinemachineCamera LevelCamera { get; }
	}
}