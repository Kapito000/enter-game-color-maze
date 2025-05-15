using CapLib.Instantiate;
using Zenject;

namespace Infrastructure.Installer
{
	public sealed class ForAllSubContainersProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindInstantiateService();
		}

		void BindInstantiateService()
		{
			Container.Bind<IInstantiateService>()
				.To<DiInstantiateService>()
				.AsSingle()
				.MoveIntoAllSubContainers()
				;
		}
	}
}