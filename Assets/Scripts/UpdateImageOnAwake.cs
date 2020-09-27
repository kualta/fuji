using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateImageOnAwake : MonoBehaviour
{
    public GameController gameController;

    void Awake() {
        gameController.UpdateLevelButton();
        gameController.UpdateArrowButtons();
    }
}
