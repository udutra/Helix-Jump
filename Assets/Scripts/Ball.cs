using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rb;
	public LayerMask ground;
	public float jumpForce = 10f;
	
	private void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	private void OnTriggerEnter(Collider other){
		if(((1 << other.gameObject.layer) & ground) == 0)
		{
			return;
		}
		
		rb.velocity = Vector3.zero;
		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}
}
