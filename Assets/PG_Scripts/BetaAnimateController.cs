using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaAnimateController : MonoBehaviour {

	private Animator animator;

	private bool isRunning;
	private bool isWalking;

	private bool isMovingForward;
	private bool isMovingBackward;
	private bool isTurningLeft;
	private bool isTurningRight;

	private bool isJumping;

	private float fwdback;
	private float rightleft;

	void Awake () {
		animator = GetComponent<Animator> ();
		isWalking = false;
		isRunning = false;
		isMovingForward = false;
		isTurningLeft = false;
		isTurningRight = false;
		isMovingBackward = false;
		isJumping = false;
		fwdback = 0.5f;
		rightleft = 0.5f;
		animator.SetBool ("IsMoving", false);
		animator.SetBool ("IsRunning", false);
		animator.SetFloat ("FwdBckward", 0.5f);
		animator.SetFloat ("LeftRight", 0.5f);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.W)) {
			isMovingForward = true;
			isMovingBackward = false;
			animator.SetBool ("IsMoving", true);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			isMovingBackward = true;
			isMovingForward = false;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (isMovingForward || isMovingBackward) {
				isRunning = true;
				animator.SetBool ("IsRunning", true);
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			isJumping = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			isTurningLeft = true;
			isTurningRight = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			isTurningLeft = true;
			isTurningRight = false;
		}

		if (isMovingForward) {
			fwdback = 0.8f * fwdback;
		}
		if (isMovingBackward) {
			fwdback = 0.8f * fwdback + 0.2f;
		}
		if (isTurningRight) {
			rightleft = 0.8f * rightleft + 0.2f;
		}
		if (isTurningLeft) {
			rightleft = 0.8f * rightleft;
		}
		animator.SetFloat ("FwdBckward", fwdback);
		animator.SetFloat ("LeftRight", rightleft);
	}
}
