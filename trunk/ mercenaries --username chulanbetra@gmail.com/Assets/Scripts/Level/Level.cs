using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class Level 
{
	public static readonly Level Instance = new Level();
	
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
	
	Level()
	{
		m_pTiles = new Dictionary<Point, Tile>(new PointEqualityComparer());
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
