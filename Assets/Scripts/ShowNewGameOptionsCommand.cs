using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNewGameOptionsCommand : Command {
    private GuiController GameController { get; set; }

    public ShowNewGameOptionsCommand(GuiController gameController) {
        GameController = gameController;
    }

    public void Run() {
        GameController.ShowGameOptions();
    }
}
