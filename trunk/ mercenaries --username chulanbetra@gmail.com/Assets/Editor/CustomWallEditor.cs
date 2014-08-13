using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Wall))]
[CanEditMultipleObjects]
public class CustomWallEditor : Editor 
{
	private SerializedProperty WallType;
	private eWallType oldWallType;
	private GameObject activeObject;
	
	void OnEnable()
	{
		WallType = serializedObject.FindProperty("WallType");
		oldWallType = (eWallType)WallType.enumValueIndex;
		activeObject = Selection.activeGameObject;
	}
	
	public override void OnInspectorGUI() 
	{
		serializedObject.Update();			
		
		eWallType propertyValue = (eWallType)WallType.enumValueIndex;
		if (oldWallType != propertyValue)
		{	
			oldWallType = propertyValue;
			WallPropertyChanged();
			SceneView.RepaintAll();
		}
		
		serializedObject.ApplyModifiedProperties();		
		DrawDefaultInspector();		
	}	
	
	void WallPropertyChanged()
	{		
		Transform pTransform = activeObject.transform;
		Vector3 vRotation = pTransform.localEulerAngles;
		if (oldWallType == eWallType.WALL_LEFT)
		{							
			pTransform.localEulerAngles = new Vector3(vRotation.x, 0.0f, vRotation.z);
		}
		else
		{			
			pTransform.localEulerAngles = new Vector3(vRotation.x, 90.0f, vRotation.z);			
		}	
	}
}
