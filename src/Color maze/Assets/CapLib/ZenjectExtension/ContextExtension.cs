using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace CapLib.ZenjectExtension
{
	public static class ContextExtension
	{
		public static IEnumerable<MonoInstaller> GetMonoInstallersInChildren(
			this Context context) =>
			context.GetComponentsInChildren<IInstaller>()
				.Select(x => x as MonoInstaller)
				.Where(x => x != null);

		public static void SetMonoInstallers(this Context context,
			IEnumerable<MonoInstaller> newInstallers) =>
			context.Installers = newInstallers;
	}
}