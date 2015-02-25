using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AIPath))]
public class EnnemyKill : MonoBehaviour, IKillable {
    
    public AudioClip DeathSound;
    public AnimationClip DeathAnimation;

    AIPath aiPath;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
            throw new MissingComponentException("AIPath components is required. AIPath Component not found.");
    }

    public void Kill()
    {
        Destroy(gameObject, 2);
        audio.PlayOneShot(DeathSound);

        animation.CrossFade(DeathAnimation.name);
        aiPath.canMove = false;
    }
}
