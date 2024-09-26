using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerAttack : MonoBehaviour
{
    [SerializeField] protected Image attackButton;
    protected PlayerDistanceToClosestEnemy playerDistanceToClosestEnemy;
    protected Animator animatorController;
    protected abstract float attackTimer { get; set; }
    protected abstract float attackDelayTime { get; set; }
    protected abstract float attackDistance { get; set; }
    private Player player;

    protected virtual void Start()
    {
        player = GetComponent<Player>();
        animatorController = GetComponent<Animator>();
        playerDistanceToClosestEnemy = new PlayerDistanceToClosestEnemy();
    }
    protected virtual void Update()
    {
        attackTimer -= Time.deltaTime;
        attackButton.fillAmount += Time.deltaTime / attackDelayTime;
    }
    public abstract void Attack();
    protected virtual void Fight()
    {
        attackButton.fillAmount = 0;
        attackTimer = attackDelayTime;
        player.IsFighting = true;
        player.IsRunning = false;
    }
}
