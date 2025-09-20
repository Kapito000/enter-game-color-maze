using CapLib.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Feature.HeroSpawn.Factory
{
	public interface IHeroFactory : IFactory
	{
		GameObject Create(Vector3 pos, Quaternion rot);
	}
}