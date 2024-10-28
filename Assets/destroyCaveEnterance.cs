using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCaveEntrance : MonoBehaviour
{
	private GameManager gm;

	// References to the door states
	public GameObject nocollisiondoorremoved;
	public GameObject collisiondoorremoved;

	void Start()
	{
		gm = FindObjectOfType<GameManager>();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && gm.hasAxe && Input.GetMouseButtonDown(0)) // 0 is the left mouse button
		{
			Destroy(gameObject); // Destroy the cave wall
		}
	}
}
