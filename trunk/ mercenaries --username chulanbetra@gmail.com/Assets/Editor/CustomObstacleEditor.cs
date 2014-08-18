using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Obstacle))]
public class CustomObjectEditor : Editor
{
	public override void OnInspectorGUI() 
	{
		// obstacle boundary box (defines tiles which the object occupies)
		Obstacle pObstacle = (Obstacle)target;
		Vector3 vBBoxSize = pObstacle.renderer.bounds.extents;
		Debug.Log (pObstacle.name + ": " + vBBoxSize.x * 2 + ", " + vBBoxSize.z * 2);
		
		// tile flag edit button
		if(GUILayout.Button("Edit Tile Flags"))
        {
		}
	}
}
