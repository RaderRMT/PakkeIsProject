using UnityEngine.InputSystem;

public class PlayerInformation {

    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    
    public PlayerInformation(PlayerInput input) {
        PlayerIndex = input.playerIndex;
        Input = input;
    }
}

