using CapLib.Common;
using Feature.CameraModuleInput;
using Sirenix.OdinInspector;
using UniRx;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Feature.CameraModule
{
	public sealed class OverviewLevelSystem : MonoBehaviour, ISystem
	{
		[ReadOnly]
		[SerializeField] VirtualCameraMode virtualCameraMode;
		[Space]
		[SerializeField] int _activePriority = 10;
		[SerializeField] int _waitingPriority = 0;

		[Inject] ICameraInput _cameraInput;
		[Inject] ICameraProvider _cameraProvider;

		[Inject]
		void Construct(
			[Inject(Id = VirtualCameraMode.LevelOverview)]
			CinemachineVirtualCameraBase levelOverviewCamera)
		{
			_cameraProvider.LevelOverviewVirtualCamera = levelOverviewCamera;
		}

		void Awake()
		{
			_cameraInput
				.SwitchCameraModePerformed
				.Subscribe(_ => SwitchCameraMode())
				.AddTo(this);
		}

		void SwitchCameraMode()
		{
			switch (virtualCameraMode)
			{
				case VirtualCameraMode.Main:
					SetAsWaiting(_cameraProvider.MainVirtualCamera);
					SetAsActive(_cameraProvider.LevelOverviewVirtualCamera);
					virtualCameraMode = VirtualCameraMode.LevelOverview;
					break;

				case VirtualCameraMode.LevelOverview:
					SetAsWaiting(_cameraProvider.LevelOverviewVirtualCamera);
					SetAsActive(_cameraProvider.MainVirtualCamera);
					virtualCameraMode = VirtualCameraMode.Main;
					break;

				default:
					Debug.LogError($"Unknown camera mode: {virtualCameraMode}");
					return;
			}
		}

		void SetAsActive(CinemachineVirtualCameraBase virtualCamera)
		{
			virtualCamera.Priority = _activePriority;
		}

		void SetAsWaiting(CinemachineVirtualCameraBase virtualCamera)
		{
			virtualCamera.Priority = _waitingPriority;
		}
	}
}