using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SceneEdit))]
public class PrefabInstantiateSelected : Editor
{		
	private SceneEdit m_pSceneEdit;	
	private Plane m_pXZPlane;
	private GameObject m_pSelectedObject;	
	private GameObject m_pPreviewPrefab;	
	
	void OnEnable()
	{
		Debug.Log("init");
		m_pSceneEdit = (SceneEdit)target;
		m_pXZPlane = new Plane(Vector3.up, Vector3.zero);
		SceneView.onSceneGUIDelegate = SceneUpdate;	
		EditorApplication.update += Update;
	}	
	
	void Update()
	{						
		GameObject pNewSelectedObject = Selection.activeObject as GameObject;			
		if (m_pSelectedObject != pNewSelectedObject && IsPrefab(pNewSelectedObject))
		{
			Debug.Log("new preview prefab: "+pNewSelectedObject.name);			
			if (m_pPreviewPrefab != null)
			{
				DestroyImmediate(m_pPreviewPrefab);
			}
			m_pSelectedObject = pNewSelectedObject;
			m_pPreviewPrefab = (GameObject)PrefabUtility.InstantiatePrefab(m_pSelectedObject);
			m_pPreviewPrefab.transform.position = Vector3.zero;
		}
	}
	
	// returns true if object is prefab in project view
	bool IsPrefab(GameObject pGO)
	{
		if (pGO)
		{
			return (PrefabUtility.GetPrefabType(pGO) == PrefabType.Prefab || PrefabUtility.GetPrefabType(pGO) == PrefabType.ModelPrefab);
		}
		return false;		
	}
		
	// called every frame
	void SceneUpdate(SceneView pSceneView)
	{	
		Event e = Event.current;
		if (e.type == EventType.MouseDown && e.button == 0) 
		{				
			if (e.alt)
			{				
	            InstantiateSelectedPrefab(e);
				e.Use();
			}
        }		
	}
	
	// instantiate prefab selected in project view and place it in scene view on XZ plane under mouse cursor
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
