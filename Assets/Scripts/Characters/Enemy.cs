using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public abstract float Health { get; set; }
    public abstract float AttackDistance { get; set; }
    public bool IsDead { get; set; }
    public bool IsRunning { get; set; }
    public bool IsAttacking { get; set; }
    protected Animator animator;
    protected NavMeshAgent navMeshAgent;
    protected IDie die;
    protected IMovement movement;
    private IAnimation animationMove;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animationMove = new EnemyMovementAnimation(this, animator, transform);
        movement = new EnemyMovement(navMeshAgent, transform, this, animator);
    }
    protected void Update()
    {
        if (IsDead || SceneManager.Instance.Player.IsDead) return;
        IsDead = die.Die();
        movement.Move();
        animationMove.Animation();
    }
    public void EnemyRunning()
    {
        IsRunning = true;
        IsAttacking = false;
    }
    public void EnemyAttacking()
    {
        IsRunning = false;
        IsAttacking = true;
    }
}