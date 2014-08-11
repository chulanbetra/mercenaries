public sealed class GameSettings
{
	public static readonly GameSettings Instance = new GameSettings();
	
	public float WallWidth = 0.2f;
	public float TileWidth = 1.5f;
	
	GameSettings()
	{
	}
}
