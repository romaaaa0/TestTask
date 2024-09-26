using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAttack : MonoBehaviour
{
    protected abstract float attackDelayTime { get; set; }
    protected abstract float damage { get; set; }
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float attackTimer;
    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Attack();
    }
    public virtual void Attack()
    {
        if (enemy.IsDead || SceneManager.Instance.Player.IsDead) return;
        var distance = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
        attackTimer -= Time.deltaTime;
        if (distance <= enemy.AttackDistance)
        {
            navMeshAgent.isStopped = true;
            if (attackTimer <= 0)
            {
                attackTimer = attackDelayTime;
                SceneManager.Instance.Player.Hp -= damage;
                animator.SetTrigger("Attack");
                enemy.EnemyAttacking();
            }
        }
    }
}
