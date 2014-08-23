using UnityEngine;

public sealed class MapSettings
{
	public static readonly MapSettings Instance = new MapSettings();
	
	public float WallWidth = 0.2f;
	public float TileWidth = 1.5f;
	public int TileCountX = 30;
	public int TileCountZ = 30;
	
	MapSettings()
	{
	}	
	
	public static Vector3 IndexToVector3(int i, int j)		
	{		
		float fTileWidth = Instance.TileWidth;
		return new Vector3(i * fTileWidth + fTileWidth * 0.5f, 0, j * fTileWidth + fTileWidth * 0.5f);
	}
	
	public static Vector3 PointToVector3(Point pPoint)
	{
		float fTileWidth = Instance.TileWidth;
		return new Vector3(pPoint.X * fTileWidth + fTileWidth * 0.5f, 0, pPoint.Y * fTileWidth + fTileWidth * 0.5f);
	}
}
