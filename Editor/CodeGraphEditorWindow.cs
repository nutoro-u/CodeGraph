using UnityEditor;
using UnityEngine;

namespace CodeGraph.Editor
{
	public class CodeGraphEditorWindow : EditorWindow
	{
		public static void Open(CodeGraphAsset target)
		{
			CodeGraphEditorWindow[] windows = Resources.FindObjectsOfTypeAll<CodeGraphEditorWindow>();
			foreach (CodeGraphEditorWindow w in windows)
			{
				if (w == target)
				{
					w.Focus();
					return;
				}
			}

			CodeGraphEditorWindow window = CreateWindow<CodeGraphEditorWindow>(typeof(CodeGraphEditorWindow), typeof(SceneView));
			window.titleContent = new GUIContent($"{target.name}", EditorGUIUtility.ObjectContent(null, typeof(CodeGraphAsset)).image);
			window.Load(target);
		}

		[SerializeField]
		private CodeGraphAsset m_currentGraph;
		public CodeGraphAsset CurrentGraph => m_currentGraph;

		[SerializeField]
		private SerializedObject m_serializedObject;

		private void Load(CodeGraphAsset target)
		{
			m_currentGraph = target;
		}
	}
}
