using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	Camera m_pViewCamera;
	public float TurnSpeed = 3.0f;
	public float ZoomSpeed = 1.0f;
	public float DefaultZoomLevel = 10.0f;
	public float ScrollSpeed = 20.0f;
	
	void Awake()
	{
		m_pViewCamera = this.GetComponentInChildren<Camera>();
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (Input.GetKey(KeyCode.W))
		{
			// move camera up
			Vector3 vDir = new Vector3(m_pViewCamera.transform.forward.x, 0, m_pViewCamera.transform.forward.z);
			vDir.Normalize();
			m_pViewCamera.transform.Translate(ScrollSpeed * vDir * Time.deltaTime, Space.World);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			// move camera down
			Vector3 vDir = new Vector3(m_pViewCamera.transform.forward.x, 0, m_pViewCamera.transform.forward.z);
			vDir.Normalize();
			m_pViewCamera.transform.Translate(-ScrollSpeed * vDir * Time.deltaTime, Space.World);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			// move camera left
			m_pViewCamera.transform.Translate(-ScrollSpeed * m_pViewCamera.transform.right * Time.deltaTime, Space.World);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			// move camera right
			m_pViewCamera.transform.Translate(ScrollSpeed * m_pViewCamera.transform.right * Time.deltaTime, Space.World);
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			// rotate camera clockwise around Z axis
			CameraRotate(TurnSpeed);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			// rotate camera counter clockwise around Z axis
			CameraRotate(-TurnSpeed);
		}
		else if (Input.GetKey(KeyCode.Z))
		{
			// zoom in	
			CameraZoom(-ZoomSpeed);
		}
		else if (Input.GetKey(KeyCode.X))
		{
			// zoom out 
			CameraZoom(ZoomSpeed);
		}
	}
	
	// rotate camera around Z axis going through center of the screen
	void CameraRotate(float fAngle)
	{		
		Vector3 vRotationPoint = m_pViewCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		m_pViewCamera.transform.RotateAround(vRotationPoint, Vector3.up, fAngle);
	}
	
	// zoom camera in or out, values are clamped
	void CameraZoom(float fZoom)
	{
		float fZoomLevel = m_pViewCamera.orthographicSize;
		m_pViewCamera.orthographicSize = Mathf.Clamp(fZoomLevel + fZoom, 5.0f, 50.0f);
	}
}
