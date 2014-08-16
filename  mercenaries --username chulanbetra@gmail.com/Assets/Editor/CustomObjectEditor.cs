using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BaseObject))]
public class CustomObjectEditor : Editor
{
	public override void OnInspectorGUI() 
	{
		// tile flag edit button
		if(GUILayout.Button("Edit Tile Flags"))
        {
		}
	}
}
