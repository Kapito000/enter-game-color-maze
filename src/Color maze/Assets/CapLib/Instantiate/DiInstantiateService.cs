using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace CapLib.Instantiate
{
	public sealed class DiInstantiateService : IInstantiateService
	{
		[Inject] DiContainer _container;

		public T Instantiate<T>() => 
			_container.Instantiate<T>();

		public GameObject Instantiate(Object prefab)
		{
			var instance = _container.InstantiatePrefab(prefab);
			return instance;
		}

		public GameObject Instantiate(Object prefab, Vector3 pos) =>
			_container.InstantiatePrefab(prefab, pos, quaternion.identity, null);

		public GameObject Instantiate(Object prefab, Vector3 pos, Quaternion rot) =>
			_container.InstantiatePrefab(prefab, pos, rot, null);
		
		public GameObject Instantiate(Object prefab, Transform parent)
		{
			return _container.InstantiatePrefab(prefab, parent);
		}


		public GameObject Instantiate(GameObject prefab, Vector3 pos,
			Transform parent) =>
			Instantiate(prefab, pos, quaternion.identity, parent);

		public GameObject Instantiate(GameObject prefab, Vector3 pos = new(),
			Quaternion rot = new(), Transform parent = null)
		{
			var instance = _container
				.InstantiatePrefab(prefab, pos, rot, parent);
			return instance;
		}


		public GameObject Instantiate(GameObject prefab, string name,
			Vector3 pos = new(), Transform parent = null) =>
			Instantiate(prefab, name, pos, quaternion.identity, parent);

		public GameObject Instantiate(GameObject prefab, string name,
			Vector3 pos = new(), Quaternion rot = new(),
			Transform parent = null)
		{
			var parameters = new GameObjectCreationParameters()
			{
				Position = pos,
				Rotation = rot,
				ParentTransform = parent,
				Name = name,
			};

			var instance = _container.InstantiatePrefab(prefab, parameters);
			return instance;
		}


		public TComponent Instantiate<TComponent>(Object prefab)
			where TComponent : Component =>
			_container.InstantiatePrefabForComponent<TComponent>(prefab);

		public TComponent Instantiate<TComponent>(Object prefab, Transform parent)
			where TComponent : Component =>
			_container.InstantiatePrefabForComponent<TComponent>(prefab, parent);


		public TComponent AddComponent<TComponent>(GameObject instance)
			where TComponent : Component
		{
			return _container.InstantiateComponent<TComponent>(instance);
		}
	}
}