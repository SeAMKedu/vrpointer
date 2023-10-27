using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_moving : MonoBehaviour {
	public InputActionProperty Move;
	public Transform Player;
	Transform controller;

	public float Speed;

	// Start is called before the first frame update
	void Start() {
		controller = transform;
	}

	// Update is called once per frame
	void Update() {
		Vector2 inputMove = Move.action.ReadValue<Vector2>();
		inputMove.Normalize();
		Vector3 usedMovement = controller.forward * inputMove.y * Speed + controller.right * inputMove.x * Speed;
		Player.position += usedMovement * Time.deltaTime;
	}
}
