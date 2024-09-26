using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

namespace Assets
{
    public class SimpleEnemyDie : IDie
    {
        private SimpleEnemy simpleEnemy;
        private Animator animator;
        private NavMeshAgent navMeshAgent;

        public SimpleEnemyDie(SimpleEnemy simpleEnemy, Animator animator, NavMeshAgent navMeshAgent)
        {
            this.simpleEnemy = simpleEnemy;
            this.animator = animator;
            this.navMeshAgent = navMeshAgent;
        }
        public bool Die()
        {
            if(simpleEnemy.Health <= 0)
            {
                SceneManager.Instance.RemoveEnemie(simpleEnemy);
                animator.SetTrigger("Die");
                navMeshAgent.isStopped = true;
                SceneManager.Instance.Player.AddHP();
                return true;
            }
            return false;
        }
    }
}
