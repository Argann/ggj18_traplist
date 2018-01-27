using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAction : MonoBehaviour {
	public Piege TODELETE;

	private List<Piege> pieges = new List<Piege>();
	// Use this for initialization
	void Start () {
		pieges.Add(TODELETE);
	}
	
	// Update is called once per frame
	void Update () {
		 float action = Input.GetAxisRaw ("ActionP2");
		 if (action != 0f && pieges.Count > 0 ) {
			 Instantiate(pieges[0], transform.position, transform.rotation);
			 pieges.RemoveAt(0);
		 }
	}
}
