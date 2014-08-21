using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AIPathgraph 
{
	List<AINode> m_pNodes;
	int m_iLevel;
	
	// pathgraph nodes
	public List<AINode> Nodes
	{
		get
		{
			return m_pNodes;
		}
		set
		{
			m_pNodes = value;
		}
	}
	
	// pathgraph height level
	public int Level
	{
		get
		{
			return m_iLevel;
		}
		set
		{
			m_iLevel = value;
		}
	}
	
	public AIPathgraph()
	{
	}
}
