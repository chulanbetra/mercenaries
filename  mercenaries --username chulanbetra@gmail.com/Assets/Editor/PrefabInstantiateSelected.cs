using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SceneEdit))]
public class PrefabInstantiateSelected : Editor
{		
	private SceneEdit m_pSceneEdit;	
	private Plane m_pXZPlane;
	private GameObject m_pSelectedObject;	
	
	void OnEnable()
	{
		Debug.Log("init");
		m_pSceneEdit = (SceneEdit)target;
		m_pXZPlane = new Plane(Vector3.up, Vector3.zero);
		SceneView.onSceneGUIDelegate = SceneUpdate;		
	}	
	
	bool IsPrefab(GameObject pGO)
	{
		if (pGO)
		{
			return (PrefabUtility.GetPrefabType(pGO) == PrefabType.Prefab || PrefabUtility.GetPrefabType(pGO) == PrefabType.ModelPrefab);
		}
		return false;		
	}
	
	void SceneUpdate(SceneView pSceneView)
	{	
		HandleMouseClick(Event.current);		
	}
	
	void HandleMouseClick(Event e)
	{	
		m_pSelectedObject = Selection.activeObject as GameObject;
		if (e.type == EventType.MouseDown && e.button == 0) 
		{				
			if (e.alt)
			{				
	            InstantiateSelectedPrefab(e);
			}
        }
	}	
	
	void InstantiateSelectedPrefab(Event e)
	{
		Ray pRay = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        float fRayDistance;
        if (m_pXZPlane.Raycast(pRay, out fRayDistance))
		{			
			if (IsPrefab(m_pSelectedObject))
			{						
				GameObject pNewGameObject = (GameObject)PrefabUtility.InstantiatePrefab(m_pSelectedObject);            		
            	pNewGameObject.transform.position = pRay.GetPoint(fRayDistance) + Vector3.up * pNewGameObject.transform.localScale.y * 0.5f;
			}				
		}
	}
}
