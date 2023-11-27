public class NetItem : AttackItem {

    public float NewVelocity;
    public float Duration;
    
    protected override void Use(PlayerController playerController) {
        playerController.Slowdown(NewVelocity, Duration);
    }
}