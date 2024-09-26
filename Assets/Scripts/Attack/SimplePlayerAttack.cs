using UnityEngine;

public class SimplePlayerAttack : PlayerAttack
{
    protected override float attackTimer { get; set ; }
    protected override float attackDelayTime { get; set; } = 1;
    protected override float attackDistance { get; set; } = 2;
    private float damage = 1;
    public override void Attack()
    {
        var closestEnemy = playerDistanceToClosestEnemy.Distance(gameObject.transform);
        if (closestEnemy != null)
        {
            var enemyType = closestEnemy as MonoBehaviour;
            var distance = Vector3.Distance(transform.position, enemyType.transform.position);
            if (distance <= attackDistance && attackTimer <= 0)
            {
                transform.transform.rotation = Quaternion.LookRotation(enemyType.transform.position - transform.position);
                closestEnemy.Health -= damage;
                Fight();
            }
            else if (attackTimer <= 0)
            {
                Fight();
            }
        }
    }
    protected override void Fight()
    {
        base.Fight();
        animatorController.SetTrigger("Attack");
    }
}
