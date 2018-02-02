using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayer : MonoBehaviour {
	private const float step = 0.008f;
	private Vector3 vStep = new Vector3(step, step, step);
	private Vector3 hStep = new Vector3(0f, step/2, 0f);
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale -= vStep;
		transform.position -= hStep;
		if (transform.localScale.y < 0f) Destroy(gameObject);
	}

	public void UpdateTransform(float dx) {
		vStep.x = dx * step;
		transform.localScale = new Vector3(
			dx * Mathf.Abs(transform.localScale.x),
			transform.localScale.y,
			transform.localScale.z
		);
	}
}
