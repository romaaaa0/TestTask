using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyDie : IDie
{
    private Animator animator;
    private BigEnemy bigEnemy;
    private NavMeshAgent navMeshAgent;
    private List<SimpleEnemy> cloneEnemies = new List<SimpleEnemy>();
    public BigEnemyDie(Animator animator, List<SimpleEnemy> cloneEnemies, BigEnemy bigEnemy, NavMeshAgent navMeshAgent)
    {
        this.animator = animator;
        this.cloneEnemies = cloneEnemies;
        this.bigEnemy = bigEnemy;
        this.navMeshAgent = navMeshAgent;
    }
    public bool Die()
    {

        if (bigEnemy.Health <= 0)
        {
            SceneManager.Instance.Player.AddHP();
            navMeshAgent.isStopped = true;
            foreach (var enemy in cloneEnemies)
                enemy.gameObject.SetActive(true);
            SceneManager.Instance.RemoveEnemie(bigEnemy);
            animator.SetTrigger("Die");
            return true;
        }
        return false;
    }
}
