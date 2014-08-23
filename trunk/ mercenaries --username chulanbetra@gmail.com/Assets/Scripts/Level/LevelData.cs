using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class LevelData :MonoBehaviour
{
	public static LevelData Instance ;
	
	private Dictionary<Point, Tile> m_pTiles;
	
	public Dictionary<Point, Tile> Tiles
	{
		get
		{
			return m_pTiles;
		}
		set
		{
			m_pTiles = value;
		}
	}
	
	// Use this for initialization
	void Start () 
	{	
	}
	
	// create new tile with default flag and level
	Tile CreateTile()
	{
		Tile pTile = new Tile();
		pTile.Level = 0;
		pTile.SetFlag(eTileFlag.WALKABLE);
		return pTile;
	}
	
	void Awake()
	{
		Instance = this;
		m_pTiles = new Dictionary<Point, Tile>(new PointEqualityComparer());
		
		int iTileCountXDiv2 = MapSettings.Instance.TileCountX / 2;
		int iTileCountZDiv2 = MapSettings.Instance.TileCountZ / 2;		
		
		for (int i = -iTileCountXDiv2; i < iTileCountXDiv2; i++)
		{
			for (int j = -iTileCountZDiv2; j < iTileCountZDiv2; j++)
			{					
				m_pTiles.Add(new Point(i, j), CreateTile());
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}
	
	void OnDrawGizmos()
	{
		float fTileWidth = MapSettings.Instance.TileWidth;		
		
		#region Grid
		// draw grid on zero y plane
		Gizmos.color = Color.white;
	    for (float z = - 150.0f; z < 150.0f; z += fTileWidth)
	    {
	        Gizmos.DrawLine(new Vector3(-1000000.0f, 0.05f, z), new Vector3(1000000.0f, 0.05f, z));
	    }
	    
	    for (float x = -150.0f; x < 150.0f; x += fTileWidth)
	    {
	        Gizmos.DrawLine(new Vector3(x, 0.05f, -1000000.0f), new Vector3(x, 0.05f, 1000000.0f));
	    }
		#endregion
		
		#region Tiles
		// draw tiles gizmo		
		/*if (this.Tiles != null)
		{
			Gizmos.color = Color.green;
			Vector3 vMoveUp = Vector3.up * fTileWidth * 0.5f;
			foreach (var pTile in this.Tiles)
			{				
				Gizmos.DrawSphere(MapSettings.PointToVector3(pTile.Key) + vMoveUp, fTileWidth * 0.3f);
			}
		}*/	
		#endregion
		
		// draw pathgraph nodes gizmo
		#region Nodes
		/*if (this.Tiles != null)
		{
			Gizmos.color = Color.green;
			Vector3 vMoveUp = Vector3.up * fTileWidth * 0.5f;
			foreach (var pTile in this.Tiles)
			{				
				Gizmos.DrawSphere(MapSettings.PointToVector3(pTile.Key) + vMoveUp, fTileWidth * 0.3f);
			}
		}*/	
		#endregion
	}
}

public class PointEqualityComparer : IEqualityComparer<Point>
{
    public bool Equals(Point vPoint1, Point vPoint2)
    {
        return vPoint1.X == vPoint2.X && vPoint1.Y == vPoint2.Y;
    }

    public int GetHashCode(Point vPoint)
    {
        return vPoint.X ^ vPoint.Y;
    }
}
