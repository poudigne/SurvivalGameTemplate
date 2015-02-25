using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class AttackAnimation : MonoBehaviour {
  	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            animation.Play("AxeSwing");
        }
		else if (IsAttackFinished)
            animation.CrossFade("AxeIdle");
	}

    private bool IsAttackFinished
    {
        get { return animation["AxeSwing"].time > animation["AxeSwing"].length; }
    }
}
