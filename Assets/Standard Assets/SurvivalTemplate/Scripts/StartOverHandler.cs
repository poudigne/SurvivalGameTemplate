using UnityEngine;
using System.Collections;

public class StartOverHandler : MonoBehaviour {

    void OnClick()
    {
        Application.LoadLevel("GameScene");
    }
}
