using UnityEngine;
using System.Collections;

public enum eTileFlag
{
	NONE = 0x00,
	// flags for moving
	WALKABLE = 0x01,
	// wall flags	
	WALL_LEFT = 0x02,
	WALL_DOWN = 0x04,
	// open door flags
	DOOR_LEFT = 0x08,
	DOOR_RIGHT = 0x10,
	DOOR_UP = 0x20,
	DOOR_DOWN = 0x40,
	// dynamics
	OBSTACLE = 0x80,
}

[System.Serializable]
// tile class
public class Tile
{
	// tile mask
	public int TileMask;
	// specific object on tile (player, enemy, etc.)
	private GameObject TileObject;
	
	// constructor
	public Tile()
	{
		TileMask = 0;
		TileObject = null;
	}
	
	//---------- Flag Functions ----------
	
	// check if mask has flag
	public bool HasFlag(eTileFlag f)
	{
		if ((TileMask & (int)f) > 0)
		{
			return true;
		}
		return false;
	}
	
	// sets flag into tile mask
	public void SetFlag(eTileFlag f)
	{
		TileMask |= (int)f;
	}
	
	// clears flag from tile mask
	public void ClearFlag(eTileFlag f)
	{
		TileMask &= ~(int)f;
	}
	
	// toggle flag (turns it on if it was off and vice versa)
	public void Toggle(eTileFlag f)
	{
		TileMask ^= (int)f;
	}
	//-------------------------------------
	
	public GameObject GetTileObject()
	{
		return TileObject;
	}
	
	public void SetTileObject(GameObject o)
	{
		TileObject = o;
	}
	
	// check if there is wall in dir direction
	/*public bool IsWall(Ipos dir)
	{
		if (dir.Equals(Ipos.up))
		{
			return HasFlag(eTileFlag.WALL_UP);
		}
		else if(dir.Equals(Ipos.down))
		{
			return HasFlag(eTileFlag.WALL_DOWN);
		}
		else if(dir.Equals(Ipos.left))
		{
			return HasFlag(eTileFlag.WALL_LEFT);
		}
		else if(dir.Equals(Ipos.right))
		{
			return HasFlag(eTileFlag.WALL_RIGHT);
		}
		return false;
	}
	
	// check if there is ai wall in dir direction
	public bool IsAIWall(Ipos dir)
	{
		if (dir.Equals(Ipos.up))
		{
			return HasFlag(eTileFlag.AI_WALL_UP);
		}
		else if(dir.Equals(Ipos.down))
		{
			return HasFlag(eTileFlag.AI_WALL_DOWN);
		}
		else if(dir.Equals(Ipos.left))
		{
			return HasFlag(eTileFlag.AI_WALL_LEFT);
		}
		else if(dir.Equals(Ipos.right))
		{
			return HasFlag(eTileFlag.AI_WALL_RIGHT);
		}
		return false;
	}*/
}
