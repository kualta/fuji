using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    internal GameController gameController;

    [Space(10)]
    public GameObject firstPlatform;
    public GameObject platform;
    public GameObject background;

    [Space(10)]
    public GameObject player;
    public GameObject canvas;
    public GameObject victorySign;
    public GameObject defeatSign;


    //
    // TODO: Add moving background
    //

    public void SpawnPlatform() {
        Instantiate(platform, new Vector3(0f, -7f, 0f), Quaternion.identity);
    }

    void Awake() {
        LoadLevelAssets();
    }

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        CheckPlayerPosition();
    }

    public float deathDistance = 2.6f;

    void CheckPlayerPosition() {

        if ( player == null ) {
            return;
        }

        if (player.transform.position.x > deathDistance || player.transform.position.x < -deathDistance) {
            OnDeath();
        } 

        if (player.transform.position.y < -5.3f) {
            OnVictory();
        } else if (player.transform.position.y > 6.5f) {
            OnDeath();
        }
    }

    public void LoadLevelAssets() {
        var bgImage = Resources.Load<Sprite>("Textures/Backgrounds/Level" + gameController.levelNumber + "BG");
        background.GetComponent<SpriteRenderer>().sprite = bgImage; 

        var firstPlatformImage = Resources.Load<Sprite>("Textures/Platforms/Level" + gameController.levelNumber + "/first_platform");
        firstPlatform.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = firstPlatformImage; 

        var leftPlatformImage = Resources.Load<Sprite>("Textures/Platforms/Level" + gameController.levelNumber + "/Platform_left");
        platform.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = leftPlatformImage; 
 
        var rightPlatformImage = Resources.Load<Sprite>("Textures/Platforms/Level" + gameController.levelNumber + "/Platform_right");
        platform.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = rightPlatformImage; 
    }

    void OnDeath() {
        canvas.SetActive(true); 
        Destroy(player);
        defeatSign.SetActive(true);        
    }

    void OnVictory() {
        canvas.SetActive(true); 
        Destroy(player);
        victorySign.SetActive(true);        
    }
}
