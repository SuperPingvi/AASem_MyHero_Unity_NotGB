using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    public CharacterStats selfStats;
    public EnemyControllerFSM enemyController;
    // Start is called before the first frame update
    void Start()
    {
        if (selfStats == null)
            selfStats = gameObject.GetComponent<CharacterStats>();
        if (enemyController == null)
            enemyController = gameObject.GetComponent<EnemyControllerFSM>();
    }
    public override void Interact()
    {
        base.Interact();
        Attack();
    }
    void Attack()
    {
        enemyController.state = EnemyControllerFSM.State.Stunned;
    }
}
