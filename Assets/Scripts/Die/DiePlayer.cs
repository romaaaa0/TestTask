public class DiePlayer : IDie
{
    private Player player;
    public DiePlayer()
    {
        player = SceneManager.Instance.Player;
    }
    public bool Die()
    {
        if (player.Hp <= 0)
        {
            player.AnimatorController.SetTrigger("Die");
            SceneManager.Instance.GameOver();
            return true;
        }
        return false;
    }
}