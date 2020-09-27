using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int levelNumber;
    public Sprite[] levelImages;
    public Sprite[] leftArrowImages;
    public Sprite[] rightArrowImages;

    public static GameController Instance;
    public LevelController levelController;
     

    public void OnCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void OnNextLevel() {
        if (levelNumber < 7) {
            levelNumber++;
        }
        UpdateLevelButton();
        UpdateArrowButtons();
    }

    public void OnPreviousLevel() {
        if (levelNumber > 1) {
            levelNumber--;
        }
        UpdateLevelButton();
        UpdateArrowButtons();
    }

    public void OnMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnSiteOpen() {
        Application.OpenURL("https://lectro.moe");
        Debug.Log("Opening URL: https://lectro.moe");
    }

    public void OnTwitterOpen() {
        Application.OpenURL("https://twitter.com/lectroMathew");
        Debug.Log("Opening URL: https://twitter.com/lectroMathew");
    }

    public void OnPlay() {
        levelController.LoadLevelAssets();
        SceneManager.LoadScene("Level");
    }

    public void UpdateLevelButton() {
        Image levelButtonImage = GameObject.Find("Level Button").GetComponent<Image>();
        levelButtonImage.sprite = levelImages[levelNumber];
    }

    public void UpdateArrowButtons() {
        Image leftArrowButtonImage = GameObject.Find("Left Button").GetComponent<Image>();
        leftArrowButtonImage.sprite = leftArrowImages[levelNumber];

        Image rightArrowButtonImage = GameObject.Find("Right Button").GetComponent<Image>();
        rightArrowButtonImage.sprite = rightArrowImages[levelNumber];
    }

    void Awake() {
        Instance = this;
        Application.targetFrameRate = 120;
        UpdateLevelButton();
        UpdateArrowButtons();
    }

    internal void LoadLastLevel() {

        // FIXME: This is not an expected behaviour.
        // A real implementation is needed.

        levelNumber = 1;
    }
}
