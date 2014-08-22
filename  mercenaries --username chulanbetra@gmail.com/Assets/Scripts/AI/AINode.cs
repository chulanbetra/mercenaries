using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum eDirection
{
	UP = 0,
	DOWN = 1,
	LEFT = 2,
	RIGHT = 3,
	UP_LEFT = 4,
	UP_RIGHT = 5,
	DOWN_LEFT = 6,
	DOWN_RIGHT = 7,
}

[System.Serializable]
public class AINode
{	
	private Point m_vPoint;	
	private Vector3 m_vPos;
	private Tile m_pTile;
	
	// neighbor AI nodes (max 8)
	public Dictionary<eDirection, AINode> NeighborNodes;	
	
	// used in pathfinding
	public bool Visited;
	public bool IsInOpenSet;
	// distance from start node	in pathgraf
	public int DistanceFromStart;
	// total distance from start to end through this node
	public float TotalDistance;
	// reference to parent node (used when creating shortest path)
	public AINode ParentNode;
	
	#region Properties
	
	// index position of tile (index position in map)
	public Point IndexPosition
	{
		get
		{
			return m_vPoint;
		}
		
		set
		{
			m_vPoint = value;
		}
	}
	
	// world position of tile
	public Vector3 Position
	{
		get
		{
			return m_vPos;
		}
		
		set
		{
			m_vPos = value;
		}
	}
	
	// tile reference
	public Tile Tile
	{
		get
		{
			return m_pTile;
		}
		set
		{
			m_pTile = value;
		}
	}
	#endregion
	
	public AINode(Point vPoint, Vector3 vPos, int iLevel)
	{
		this.NeighborNodes = new Dictionary<eDirection, AINode>();
		this.IndexPosition = vPoint;
		this.Position = vPos;
		this.Level = iLevel;
	}
}
