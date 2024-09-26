using UnityEngine;

internal class EnemyMovementAnimation : IAnimation
{
    private Enemy enemy;
    private Animator animator;
    private Transform transform;
    public EnemyMovementAnimation(Enemy enemy, Animator animator, Transform transform)
    {
        this.enemy = enemy;
        this.animator = animator;
        this.transform = transform;
    }
    public void Animation()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
        if (distanceToPlayer > enemy.AttackDistance && !enemy.IsRunning)
        {
            animator.SetTrigger("Run");
            enemy.EnemyRunning();
        }
        else if(distanceToPlayer <= enemy.AttackDistance)
        {
            enemy.EnemyAttacking();
        }
    }
}
