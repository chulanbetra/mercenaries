using UnityEngine;
using UnityEditor;
using System.Collections;

public class SnapToGrid : ScriptableObject 
{
	[MenuItem ("Window/Snap to Grid %g")]
	static void MenuSnapToGrid() 
	{
		foreach (Transform pTransform in Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable)) 
		{
			float fSnapX = EditorPrefs.GetFloat("MoveSnapX");
			float fSnapZ = EditorPrefs.GetFloat("MoveSnapZ");
			// TODO: snapovanie wall / door roznych typov
			pTransform.position = new Vector3 (
				Mathf.Floor(pTransform.position.x / fSnapX) * fSnapX + fSnapX * 0.5f,
				pTransform.localScale.y * 0.5f, 
				Mathf.Floor(pTransform.position.z / fSnapZ) * fSnapZ + fSnapZ * 0.5f
			);
		}
	}
}
