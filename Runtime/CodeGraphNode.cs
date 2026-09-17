using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeGraph
{
	[Serializable]
    public class CodeGraphNode
    {
		[SerializeField]
		private string m_guid;

		[SerializeField]
		private Rect m_position;

		public string typeName;

		public string Id => m_guid;
		public Rect Position => m_position;

		public CodeGraphNode()
		{
			NewGuid();
		}

		private void NewGuid()
		{
			m_guid = Guid.NewGuid().ToString();
		}

		public void SetPosition(Rect position)
		{
			m_position = position;
		}
	}
}
