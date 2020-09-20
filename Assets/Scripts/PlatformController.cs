using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameController gameController;
    public LevelController levelController;
    public bool initialPlatform;


    void Start() {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        RandomizePosition();
    }

    void Update() {
        Move();
        CheckPosition();
    }

    void Move() {
        transform.Translate(Vector3.up * Time.deltaTime * gameController.levelNumber, Space.World);
    }

    void RandomizePosition() {
        transform.position += new Vector3(Random.Range(-2f, 1.5f), 0f, 0f);
    }

    public bool spawnedAnother = false;
    void CheckPosition() {

        if ( !spawnedAnother && !initialPlatform ) {
            if (transform.position.y > -4.6) {
                levelController.SpawnPlatform();
                spawnedAnother = true;
            }
        }

        if (transform.position.y > 7f) {
            Destroy(this.gameObject);
        }
    }
}
