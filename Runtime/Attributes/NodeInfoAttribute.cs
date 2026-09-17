using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeGraph
{
    public class NodeInfoAttribute : Attribute
    {
		private string m_nodeTitle;
		private string m_menuItem;

		public string Title => m_nodeTitle;
		public string MenuItem => m_menuItem;

		public NodeInfoAttribute(string nodeTitle, string menuItem = "")
		{
			m_menuItem = menuItem;
			m_nodeTitle = nodeTitle;
		}
    }
}
