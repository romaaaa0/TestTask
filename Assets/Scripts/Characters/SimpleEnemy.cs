using Assets;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : Enemy
{
    public override float Health { get; set; } = 1;
    public override float AttackDistance { get; set; } = 2;
    public bool WasEnemyCreated { get; set; } = false;
    protected override void Start()
    {
        base.Start();
        if (!WasEnemyCreated)
        {
            SceneManager.Instance.AddEnemie(this);
            WasEnemyCreated = false;
        }
        navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        die = new SimpleEnemyDie(this, animator, navMeshAgent);
    }
}
