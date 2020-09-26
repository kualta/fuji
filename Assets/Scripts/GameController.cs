using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int levelNumber;
    public Sprite[] levelImages;

    public static GameController Instance;
    public LevelController levelController;
     

    public void OnCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void OnNextLevel() {
        if (levelNumber < 7) {
            levelNumber++;
        }
        UpdateLevelButton(levelNumber);
        Debug.Log(levelNumber);
    }

    public void OnPreviousLevel() {
        if (levelNumber > 1) {
            levelNumber--;
        }
        UpdateLevelButton(levelNumber);
        Debug.Log(levelNumber);
    }

    public void OnMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnPlay() {
        levelController.LoadLevelAssets();
        SceneManager.LoadScene("Level");
    }

    public void UpdateLevelButton(int number) {
        Image levelButtonImage = GameObject.Find("Level Button").GetComponent<Image>();

        levelButtonImage.sprite = levelImages[number];
    }

    public void UpdateLevelButton() {
        Image levelButtonImage = GameObject.Find("Level Button").GetComponent<Image>();

        levelButtonImage.sprite = levelImages[levelNumber];
    }

    void Start() {
        LoadLastLevel();
    }

    void Awake() {
        Instance = this;
        Application.targetFrameRate = 120;
        UpdateLevelButton(levelNumber);
    }

    internal void LoadLastLevel() {

        // FIXME: This is not an expected behaviour.
        // A real implementation is needed.

        levelNumber = 1;
    }
}
