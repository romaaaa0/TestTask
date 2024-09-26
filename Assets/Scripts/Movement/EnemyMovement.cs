using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : IMovement
{
    private NavMeshAgent navMeshAgent;
    private Enemy enemy;
    private Animator animator;
    private Transform enemyTransform;
    public EnemyMovement(NavMeshAgent navMeshAgent, Transform transform, Enemy enemy, Animator animator)
    {
        this.navMeshAgent = navMeshAgent;
        this.enemy = enemy;
        this.animator = animator;
        enemyTransform = transform;
    }
    public void Move()
    {
        var distanceToPlayer = Vector3.Distance(enemyTransform.position, SceneManager.Instance.Player.transform.position);
        if (distanceToPlayer > enemy.AttackDistance)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
    }
}
