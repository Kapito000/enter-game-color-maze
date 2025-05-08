using CapLib.Common;
using UnityEngine;

namespace CapLib.Instantiate
{
	public interface IInstantiateService : IService
	{
		T Instantiate<T>();
		
		GameObject Instantiate(Object prefab);
		GameObject Instantiate(Object prefab, Vector2 pos);
		GameObject Instantiate(Object prefab, Transform parent);

		GameObject Instantiate(GameObject prefab, Vector2 pos, Transform parent);
		GameObject Instantiate(GameObject prefab, Vector2 pos, Quaternion rot,
			Transform parent);

		GameObject Instantiate(GameObject prefab, string name,
			Vector2 pos = new(), Transform parent = null);
		GameObject Instantiate(GameObject prefab, string name,
			Vector2 pos = new(), Quaternion rot = new(), Transform parent = null);

		TComponent Instantiate<TComponent>(Object prefab)
			where TComponent : Component;
		TComponent Instantiate<TComponent>(Object prefab, Transform parent)
			where TComponent : Component;
		
		TComponent AddComponent<TComponent>(GameObject instance)
			where TComponent : Component;
	}
}