using CapLib.Common;
using UnityEngine;

namespace Feature.UI
{
	public interface IUiAssetProvider : IAssetProvider
	{
		GameObject UI { get; }
	}
}