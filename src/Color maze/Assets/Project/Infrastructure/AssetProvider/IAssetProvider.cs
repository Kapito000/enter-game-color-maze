using CapLib.Common;
using Cysharp.Threading.Tasks;

namespace Infrastructure.AssetProvider
{
	public interface IAssetProvider : IService
	{
		UniTask<T> Load<T>(string address)
			where T : UnityEngine.Object;

		void CleanUp();
	}
}