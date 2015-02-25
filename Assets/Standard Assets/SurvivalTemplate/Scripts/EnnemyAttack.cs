using UnityEngine;
using System.Collections;

public class EnnemyAttack : MonoBehaviour {

    Transform player;
    public float attackRange = 2.0f;
    public float attackDelay = 2.0f;

    bool isCharging = false;
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

	// Update is called once per frame
	void Update () {
	    //check distance between enemy and player
        if (Vector3.Distance(transform.position, player.position) < attackRange && !isCharging)
        {
            Invoke("Attack", attackDelay);
            isCharging = true;
        }
            
	}

    private void Attack()
    {

        ActiveHitables.HitAll(player.gameObject);
        isCharging = false;
    }
}
