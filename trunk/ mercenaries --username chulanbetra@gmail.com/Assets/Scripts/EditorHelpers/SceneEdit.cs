using UnityEngine;
using System.Collections;

public class SceneEdit : MonoBehaviour 
{		
	// Use this for initialization
	void Start () 
	{	
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
