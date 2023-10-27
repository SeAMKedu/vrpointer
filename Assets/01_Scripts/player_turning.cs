using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_turning : MonoBehaviour {
	public InputActionProperty Move;
	public Transform Player;
	public Transform Head;
	public float Speed;

	void Update() {
		Vector2 inputMove = Move.action.ReadValue<Vector2>();
		float usedMovement = inputMove.x * Speed;
		Player.RotateAround(Head.position, Vector3.up, usedMovement * Time.deltaTime);
	}
}
