using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour, IKillable {


    public void Kill()
    {
        Debug.Log("Player die!");
    }
}
