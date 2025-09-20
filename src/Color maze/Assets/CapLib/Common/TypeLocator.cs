using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace CapLib.Common
{
	public class TypeLocator<TType> where TType : class
	{
		readonly Dictionary<Type, TType> _dictionary = new();

		public TypeLocator<TType> Register(TType instance)
		{
			_dictionary[instance.GetType()] = instance;
			return this;
		}

		public TypeLocator<TType> Register<T>(IEnumerable<T> range)
			where T : class, TType
		{
			foreach (var item in range)
				Register(item);
			return this;
		}

		public TypeLocator<TType> RegisterAs<T>(TType instance)
			where T : class, TType
		{
			_dictionary[typeof(T)] = instance;
			return this;
		}

		public TypeLocator<TType> Unregister<T>() where T : class, TType
		{
			_dictionary.Remove(typeof(T));
			return this;
		}

		public bool TryGet<T>(out TType value) where T : class, TType =>
			_dictionary.TryGetValue(typeof(T), out value);
	}
}