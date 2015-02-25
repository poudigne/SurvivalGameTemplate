using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Transform AttackPoint;

    void Attack()
    {
        var hits = Physics.OverlapSphere(AttackPoint.position, 0.5f);

        foreach (var hit in hits)
        {
            ActiveHitables.HitAll(hit.gameObject);
        }
    }
}