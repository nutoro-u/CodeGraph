using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CodeGraph.Editor
{
    public class CodeGraphEditorNode : Node
    {
		public CodeGraphEditorNode()
		{
			AddToClassList("code-graph-node");
		}
    }
}
