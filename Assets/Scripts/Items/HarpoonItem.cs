public class HarpoonItem : AttackItem {

    public int Damage;
    
    protected override void Use(PlayerController playerController) {
        playerController.Health -= Damage;
    }
}