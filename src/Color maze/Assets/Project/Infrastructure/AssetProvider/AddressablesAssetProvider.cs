using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Infrastructure.AssetProvider
{
	public sealed class AddressablesAssetProvider : IAssetProvider
	{
		Dictionary<string, AsyncOperationHandle> _handles = new();

		public async UniTask<T> Load<T>(string address)
			where T : UnityEngine.Object
		{
			if (_handles.TryGetValue(address, out var handle) == false)
			{
				handle = Addressables.LoadAssetAsync<T>(address);
				_handles.Add(address, handle);
				await handle.ToUniTask();

				if (CheckSucceededStatus(handle, address))
					return null;

				return handle.Result as T;
			}

			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				return handle.Result as T;
			}

			if (handle.Status == AsyncOperationStatus.None)
			{
				await handle.ToUniTask();
				if (CheckSucceededStatus(handle, address))
					return null;
			}

			return handle.Result as T;
		}

		public void CleanUp()
		{
			foreach (var handle in _handles)
				Addressables.Release(handle);
		}

		bool CheckSucceededStatus(AsyncOperationHandle handle, string address)
		{
			var result = handle.Status == AsyncOperationStatus.Succeeded;

			if (result == false)
				CannotLoadAssetLogError(address);

			return result;
		}

		void CannotLoadAssetLogError(string address) =>
			Debug.LogError($"Cannot load asset by address: {address}");
	}
}