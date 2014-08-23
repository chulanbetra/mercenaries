using UnityEngine;
using UnityEditor;
using System.Collections;

public class SnapToGrid : ScriptableObject 
{
	[MenuItem ("Window/Snap to Grid %g")]
	static void MenuSnapToGrid() 
	{
		// menu item for snaping objects to grid
		foreach (Transform pTransform in Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable)) 
		{
			BaseObject pObject = pTransform.gameObject.GetComponent<BaseObject>();
			SnapObjectToGrid(pObject, pTransform);
		}
	}
	
	// snap objects to tile / walls and doors to the edge of tile depending on type
	static void SnapObjectToGrid(BaseObject pObject, Transform pTransform)
	{		
		if (pObject is Wall)
		{			
			// snap to grid
			Snap(pTransform);
			
			Wall pWall = (Wall)pObject;
			Vector3 vPosition = pTransform.position;
			float fTileWidth = MapSettings.Instance.TileWidth;
			float fWallWidth = MapSettings.Instance.WallWidth;
			
			// snap to edge
			switch (pWall.WallType)
			{
				case eWallType.WALL_LEFT:
					vPosition.x = vPosition.x + 0.5f * (fWallWidth - fTileWidth);
					break;
				case eWallType.WALL_BOTTOM:
					vPosition.z = vPosition.z + 0.5f * (fWallWidth - fTileWidth);
					break;
			}			
			pTransform.position = vPosition;
		}			
		else
		{
			Snap(pTransform);
		}
	}
	
	// detects tile from object pivot a snaps object to the center of the tile
	static void Snap(Transform pTransform)
	{
		float fTileWidth = MapSettings.Instance.TileWidth;	
		pTransform.position = new Vector3 (
			Mathf.Floor(pTransform.position.x / fTileWidth) * fTileWidth + fTileWidth * 0.5f,
			pTransform.localScale.y * 0.5f, 
			Mathf.Floor(pTransform.position.z / fTileWidth) * fTileWidth + fTileWidth * 0.5f
		);
	}
}
