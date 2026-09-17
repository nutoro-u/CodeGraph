using System;
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

		[SerializeField]
		private CodeGraphView m_currentView;

		private void Load(CodeGraphAsset target)
		{
			m_currentGraph = target;
			DrawGraph();
		}

		private void DrawGraph()
		{
			m_serializedObject = new SerializedObject(m_currentGraph);
			m_currentView = new CodeGraphView(m_serializedObject);
			rootVisualElement.Add(m_currentView);
		}
	}
}
