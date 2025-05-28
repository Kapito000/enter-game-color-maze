using Zenject;

namespace Feature.EndLevelProcess
{
	public sealed class EndLeveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindEndLevelService();
		}

		void BindEndLevelService()
		{
			Container.Bind<IEndLevelService>().To<EndLevelService>().AsSingle();
		}
	}
}