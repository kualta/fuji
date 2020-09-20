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

    void Awake() {
        LoadLevelAssets();
    }

    void Start() {
        StartCoroutine(SpawnPlatform());
        player = GameObject.Find("Player");
    }

    void Update() {
        CheckPlayerPosition();
    }

    public float deathDistance = 2.6f;

    void CheckPlayerPosition() {
        if (player.transform.position.x > deathDistance || player.transform.position.x < -deathDistance) {
            OnDeath();
        } 

        if (player.transform.position.y < -5.3f) {
            OnVictory();
        } else if (player.transform.position.y > 6.5f) {
            OnDeath();
        }
    }

    void LoadLevelAssets() {

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


    IEnumerator SpawnPlatform() {
        Instantiate(platform, new Vector3(0f, -7f, 0f), Quaternion.identity);

        yield return new WaitForSeconds(2 / gameController.levelNumber);
        StartCoroutine(SpawnPlatform());
    }
}
