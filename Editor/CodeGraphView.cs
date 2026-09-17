using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace CodeGraph.Editor
{
	public class CodeGraphView : GraphView
	{
		private CodeGraphAsset m_codeGraph;
		private SerializedObject m_serializedObject;

		private CodeGraphEditorWindow m_window;
		public CodeGraphEditorWindow Window => m_window;

		public List<CodeGraphEditorNode> m_graphNodes;
		public Dictionary<string, CodeGraphEditorNode> m_nodeDictionary;

		public CodeGraphView(SerializedObject serializedObject, CodeGraphEditorWindow window)
		{
			m_serializedObject = serializedObject;
			m_codeGraph = (CodeGraphAsset)serializedObject.targetObject;
			m_window = window;

			StyleSheet style = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/CodeGraph/Scripts/Editor/USS/CodeGraphEditor.uss");
			styleSheets.Add(style);

			GridBackground background = new GridBackground();
			background.name = "Grid";
			Add(background);

			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
			this.AddManipulator(new ClickSelector());
		}

		public void Add(CodeGraphNode node)
		{
			Undo.RecordObject(m_serializedObject.targetObject, "Added Node");
			m_codeGraph.Nodes.Add(node);
			m_serializedObject.Update();

			AddNodeToGraph(node);
		}

		private void AddNodeToGraph(CodeGraphNode node)
		{
			node.typeName = node.GetType().AssemblyQualifiedName;

			CodeGraphEditorNode editorNode = new CodeGraphEditorNode();
			editorNode.SetPosition(node.Position);
			AddElement(editorNode);
		}
	}
}
