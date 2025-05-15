using CapLib.ZenjectExtension;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace CapLib.ZenjectEditor
{
	[CustomEditor(typeof(SceneContext))]
	public class SceneContextEditor : Editor
	{
		SceneContext _context;

		void Awake()
		{
			_context = (SceneContext)target;
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			if (GUILayout.Button("Collect mono installers from children"))
			{
				var newInstallers = _context.GetMonoInstallersInChildren();
				_context.SetMonoInstallers(newInstallers);
				EditorUtility.SetDirty(target);
			}
		}
	}
}