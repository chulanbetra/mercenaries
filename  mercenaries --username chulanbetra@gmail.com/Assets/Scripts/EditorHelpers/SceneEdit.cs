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
		// draw grid on zero y plane
	    for (float z = - 200.0f; z < 200.0f; z += 1)
	    {
	        Gizmos.DrawLine(new Vector3(-1000000.0f, 0, z), new Vector3(1000000.0f, 0, z));
	    }
	    
	    for (float x = -200.0f; x < 200.0f; x += 1)
	    {
	        Gizmos.DrawLine(new Vector3(x, 0, -1000000.0f), new Vector3(x, 0, 1000000.0f));
	    }
	}
}
