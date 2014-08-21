using UnityEngine;

public sealed class AISystem 
{
	// ai system singleton 
	public static readonly AISystem Instance = new AISystem();	
	
	public AISystem() 
	{	
		Random.seed = (int)System.DateTime.Now.Ticks;
	}	
}
