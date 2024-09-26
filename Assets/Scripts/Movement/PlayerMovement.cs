using UnityEngine;

public class PlayerMovement : IMovement
{
    private Player player;
    private Animator animator;
    private IAnimation animationMove;
    public PlayerMovement()
    {
        player = SceneManager.Instance.Player;
        animationMove = new PlayerMoveAnimation();
    }
    public void Move()
    {        
        if (player.MovementDirection.magnitude != 0)
        {
            player.transform.position += player.MovementDirection * Time.deltaTime * player.Speed;
        }
        animationMove.Animation();
    }
}
