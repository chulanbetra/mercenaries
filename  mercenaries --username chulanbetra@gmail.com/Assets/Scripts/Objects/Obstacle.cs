using UnityEngine;
using System.Collections;

public class Obstacle : BaseObject 
{
	// Use this for initialization
	void Start () 
	{				
	}
	
	void Awake()
	{
		// floodfillom oznacit tily ako obstacles
		// zacne sa od tile ktory ma bounds.center 
		// pokracuje sa susedmi kym nie je tile pred nejakym faceom vo vzdialenosti >= 0.75
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}
}
