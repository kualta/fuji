using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void OnCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void OnNextLevel() {

    }

    public void OnPreviousLevel() {

    }

    public void OnMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
