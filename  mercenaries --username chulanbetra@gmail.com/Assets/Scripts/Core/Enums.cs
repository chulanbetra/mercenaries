using System.Collections;

// game mode
public enum eGameMode
{
	REALTIME = 0,
	TURNBASED = 1,
}

// defines wall / door rotation and position on tile
public enum eWallType
{
	WALL_LEFT = 0,
	WALL_BOTTOM = 1,
}

// defines door opening directions
public enum eDoorType
{
	DOOR_OPEN_LEFT = 0,
	DOOR_OPEN_RIGHT = 1,
	DOOR_OPEN_BOTTOM = 2,
	DOOR_OPEN_UP = 3,
}