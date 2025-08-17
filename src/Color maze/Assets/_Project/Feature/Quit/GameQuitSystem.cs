using Feature.ServicesInput;
using UniRx;
using UnityEngine;
using Zenject;

namespace Feature.Quit
{
	public class GameQuitSystem : MonoBehaviour
	{
		[Inject] IServicesInput _servicesInput;

		void Awake()
		{
			_servicesInput.QuitePerformed
				.Subscribe(OnQuitePerformed)
				.AddTo(this);
		}

		void OnQuitePerformed(Unit unit)
		{
			Application.Quit();
		}
	}
}