using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour {

	public CharacterMotor motor;
	public float animationSpeedModifier = 0.1f;
	public float baseAnimationSpeed = 0.5f;

	Animation animationClip;

	// Use this for initialization
	void Start () {
		animationClip = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		animationClip[animationClip.clip.name].speed = motor.movement.velocity.magnitude * animationSpeedModifier + baseAnimationSpeed;
	}
}
