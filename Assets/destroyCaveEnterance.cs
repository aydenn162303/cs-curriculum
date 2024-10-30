using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCaveEntrance : MonoBehaviour
{
	private GameManager gm;
	private bool isDestroyed = false; // Flag to track if the object is already destroyed

	// References to the doors
	public GameObject nocollisiondoorremoved;
	public GameObject collisiondoorremoved;

	void Start()
	{
		gm = FindObjectOfType<GameManager>();
		if (gm.hasAxe && !isDestroyed)
		{
			Destroy(collisiondoorremoved); 
			Destroy(nocollisiondoorremoved); 
			Destroy(gameObject); 
			isDestroyed = true; // Set the flag to true
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && gm.hasAxe && Input.GetMouseButtonDown(0) && !isDestroyed) //left mouse button
		{
			Destroy(collisiondoorremoved); 
			Destroy(nocollisiondoorremoved); 
			Destroy(gameObject); 
			isDestroyed = true; // Set the flag to true
		}
	}
}
