using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Wall))]
[CanEditMultipleObjects]
public class CustomWallEditor : Editor 
{	
	void OnEnable()
	{		
	}
	
	public override void OnInspectorGUI() 
	{		
		Wall pWall = (Wall)target;		
		eWallType oldWallType = pWall.WallType;
		
		pWall.WallType = (eWallType)EditorGUILayout.EnumPopup("Wall Type:", pWall.WallType);		
		
		if (oldWallType != pWall.WallType)
		{			
			WallPropertyChanged(pWall.WallType, pWall.transform);
			SceneView.RepaintAll();
		}
	}	
	
	void WallPropertyChanged(eWallType WallType, Transform pTransform)
	{			
		Vector3 vRotation = pTransform.localEulerAngles;
		if (WallType == eWallType.WALL_LEFT)
		{							
			pTransform.localEulerAngles = new Vector3(vRotation.x, 0.0f, vRotation.z);
		}
		else
		{			
			pTransform.localEulerAngles = new Vector3(vRotation.x, 90.0f, vRotation.z);			
		}	
	}
}
