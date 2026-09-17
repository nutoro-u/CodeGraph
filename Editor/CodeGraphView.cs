using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace CodeGraph.Editor
{
	public class CodeGraphView : GraphView
	{
		private SerializedObject m_serializedObject;

		public CodeGraphView(SerializedObject serializedObject)
		{
			m_serializedObject = serializedObject;

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
	}
}
