using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BigEnemy : Enemy
{
    public override float Health { get; set; } = 4;
    public override float AttackDistance { get; set; } = 2;

    [SerializeField] private List<SimpleEnemy> Enemies;

    private List<SimpleEnemy> cloneEnemies = new List<SimpleEnemy>();
    protected override void Start()
    {
        base.Start();   
        SceneManager.Instance.AddEnemie(this);
        CreateSpareEnemies();
        navMeshAgent.SetDestination(SceneManager.Instance.Player.transform.position);
        die = new BigEnemyDie(animator, cloneEnemies, this, navMeshAgent);
    }
    private void CreateSpareEnemies()
    {
        var position = transform.position;
        foreach (var character in Enemies)
        {
            Vector3 pos = new Vector3(Random.Range(position.x + 2, position.x - 2), 0,
                Random.Range(position.z + 2, position.z - 2));
            var enemy = Instantiate(character, pos, Quaternion.identity);
            enemy.WasEnemyCreated = true;
            enemy.gameObject.SetActive(false);
            SceneManager.Instance.AddEnemie(enemy);
            cloneEnemies.Add(enemy);
        }
    }
}
