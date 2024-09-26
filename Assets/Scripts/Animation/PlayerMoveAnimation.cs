public class PlayerMoveAnimation : IAnimation
{
    private Player player;
    public PlayerMoveAnimation()
    {
        player = SceneManager.Instance.Player;
    }
    public void Animation()
    {
        if(player.MovementDirection.magnitude == 0 && !player.IsIdle)
        {
            player.AnimatorController.SetTrigger("Idle");
            player.IsRunning = false;
            player.IsIdle = true;
        }
        else if (player.MovementDirection.magnitude != 0 && !player.IsRunning && player.IsIdle)
        {
            player.AnimatorController.SetTrigger("Run");
            player.IsRunning = true;
            player.IsIdle = false;
        }
    }
}
