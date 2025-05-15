using Infrastructure.LevelsSequence;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.EndLevel
{
	public sealed class EndLevelTrigger : MonoBehaviour
	{
		[Inject] ILevelSequenceService _levelSequenceService;

		void Awake()
		{
			Assert.IsNotNull(_levelSequenceService);
		}

		void OnTriggerEnter(Collider other)
		{
			Debug.Log(other.gameObject.name);
			if (other.TryGetComponent<IEndLevelActor>(out _) == false)
				return;

			_levelSequenceService.LoadNextLevel();
		}
	}
}