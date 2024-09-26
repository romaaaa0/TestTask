using UnityEngine;

public class PlayerDistanceToClosestEnemy
{
    public Enemy Distance(Transform player)
    {
        var enemies = SceneManager.Instance.Enemies;
        Enemy closestEnemy = null;

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            var enemyType = enemy as MonoBehaviour;
            if (enemy == null) continue;

            if (closestEnemy == null)
            {
                closestEnemy = enemy;
                continue;
            }
            var distance = Vector3.Distance(player.position, enemyType.transform.position);
            var closestDistance = Vector3.Distance(player.position, enemyType.transform.position);
            if (distance < closestDistance)
            {
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
