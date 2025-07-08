using UnityEngine;
using Zenject;

namespace Feature.EndLevelProcess
{
	public sealed class EndLevelTrigger : MonoBehaviour
	{
		[Inject] IEndLevelService _endLevelService;

		void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<IEndLevelActor>(out _) == false)
				return;

			_endLevelService.EndCurrentLevel();
		}
	}
}