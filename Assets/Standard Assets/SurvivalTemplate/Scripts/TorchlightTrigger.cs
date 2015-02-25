using UnityEngine;
using System.Collections;

public class TorchlightTrigger : MonoBehaviour {

    public bool LightState;
    public Light TorchLight;
    void Start()
    {
        LightState = TorchLight.gameObject.activeSelf;
    }

	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightState = !LightState;
            TorchLight.enabled = LightState;
            
        }
	}
}
