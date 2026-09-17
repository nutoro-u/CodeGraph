using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeGraph.Editor
{
	[CustomEditor(typeof(CodeGraphAsset))]
    public class CodeGraphAssetEditor : UnityEditor.Editor
    {
		public override void OnInspectorGUI()
		{
			if(GUILayout.Button("Open"))
			{
				CodeGraphEditorWindow.Open(target as CodeGraphAsset);
			}
		}
    }
}
