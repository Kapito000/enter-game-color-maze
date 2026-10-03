using Unity.Cinemachine;

namespace Feature.CameraModule
{
	public class LevelCameraProvider : ILevelCameraProvider
	{
		public CinemachineCamera LevelCamera { get; }

		public LevelCameraProvider(CinemachineCamera levelCamera)
		{
			LevelCamera = levelCamera;
		}
	}
}

