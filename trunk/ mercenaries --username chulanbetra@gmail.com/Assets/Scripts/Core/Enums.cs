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

// tile flags
public enum eTileFlag
{
	NONE = 0x00,
	// flags for moving
	WALKABLE = 0x01,
	// wall flags	
	WALL_LEFT = 0x02,
	WALL_JUMP_LEFT = 0x04,
	WALL_DOWN = 0x08,
	WALL_JUMP_DOWN = 0x10,
	// open door flags
	DOOR_LEFT = 0x20,
	DOOR_RIGHT = 0x40,
	DOOR_UP = 0x80,
	DOOR_DOWN = 0x100,
	// dynamics (actors, destroyable objects etc)
	OBSTACLE = 0x200,
	// can be moved through by animation
	CRAWL_UNDER = 0x400,
	JUMP_OVER = 0x800,
}

// nodes neighbor direction
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