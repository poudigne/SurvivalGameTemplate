using UnityEngine;
using System.Collections;
using System;
[RequireComponent(typeof(Stats))]
public class HitDamage : MonoBehaviour, IHitable {

    public Action hasDied;

    Stats CharacterStats;
    IKillable killable;

    bool isDead = false;

    void Start()
    {
        CharacterStats = GetComponent<Stats>();
        killable = (IKillable) GetComponent(typeof(IKillable));

        if (killable == null)
            throw new MissingComponentException("Requires a components with an implementation of IKillable");
    }

    public void Hit()
    {
        CharacterStats.Health -= 10;

        if (CharacterStats.Health <= 0 && !isDead)
        {
            killable.Kill();

            if (hasDied != null)
                hasDied();
            isDead = true;
        }
    }
}
