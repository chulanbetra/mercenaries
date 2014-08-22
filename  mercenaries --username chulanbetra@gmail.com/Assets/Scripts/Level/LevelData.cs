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
	
	void Awake()
	{
		Instance = this;
		m_pTiles = new Dictionary<Point, Tile>(new PointEqualityComparer());
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}
	
	void OnDrawGizmos()
	{
		float fTileWidth = GameSettings.Instance.TileWidth;
		// draw grid on zero y plane
	    for (float z = - 150.0f; z < 150.0f; z += fTileWidth)
	    {
	        Gizmos.DrawLine(new Vector3(-1000000.0f, 0.05f, z), new Vector3(1000000.0f, 0.05f, z));
	    }
	    
	    for (float x = -150.0f; x < 150.0f; x += fTileWidth)
	    {
	        Gizmos.DrawLine(new Vector3(x, 0.05f, -1000000.0f), new Vector3(x, 0.05f, 1000000.0f));
	    }
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
