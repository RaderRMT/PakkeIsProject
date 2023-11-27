using UnityEngine.InputSystem;

public class PlayerInformation {

    public PlayerInput Input { get; set; }
    public JoinMenuController JoinMenuController { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    
    public PlayerInformation(PlayerInput input, JoinMenuController joinMenuController) {
        PlayerIndex = input.playerIndex;
        JoinMenuController = joinMenuController;
        Input = input;
    }
}

