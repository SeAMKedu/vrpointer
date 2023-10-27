using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineController : MonoBehaviour {
	public float angleMultiplier = 1;
	public float maxLineRotation = 25;
	public Transform Line;
	ActionBasedController Controller;

	private void Start() {
		Controller = GetComponent<ActionBasedController>();
		Line.position = Controller.transform.position;
		Line.rotation = Controller.transform.rotation;
	}

	void Update() {
		float smoothing; 
		float theAngle = Quaternion.Angle(Line.rotation, Controller.transform.rotation);
		smoothing = angleMultiplier * theAngle;
		if (smoothing > maxLineRotation) smoothing = maxLineRotation;
		Line.rotation = Quaternion.Lerp(Line.rotation, Controller.transform.rotation, smoothing * Time.deltaTime);
		Line.position = Controller.transform.position;
	}

}
