using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameController gameController;
    public LevelController levelController;

    public Rigidbody2D rbL;
    public Rigidbody2D rbR;

    public float speed;

    void Start() {

        // First platform has only one child 
        if (transform.childCount > 1) {
            Init(firstPlatform: false);
        } else {
            Init(firstPlatform: true);
        }

        RandomizePosition();
    }

    void Update() {
        CheckPosition();
    }

    void RandomizePosition() {
        transform.position += new Vector3(Random.Range(-2f, 1.5f), 0f, 0f);
    }

    public bool spawnedAnother = false;
    void CheckPosition() {

        // To keep constant distance between platforms on each difficulty level,
        // they spawn next platform when reach lower point of the screen.
        if ( !spawnedAnother ) {
            if (transform.position.y > -4.6) {
                levelController.SpawnPlatform();
                spawnedAnother = true;
                Debug.Log("Spawned another!");
            }
        }

        // If the platform is outside the game area, destroy it.
        if (transform.position.y > 7f) {
            Destroy(this.gameObject);
        }
    }

    private void Init(bool firstPlatform) {

        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        if ( !levelController ) {
            Debug.LogError("LevelController not found!");
        }

        if ( !gameController ) {
            Debug.LogError("GameController not found!");
        }

        speed = gameController.levelNumber;

        if ( firstPlatform ) {

            rbL = GetComponent<Rigidbody2D>();
            rbL.velocity = Vector2.up * speed;

        } else {

            rbL = GetComponent<Rigidbody2D>();
            rbR = GetComponent<Rigidbody2D>();

            rbR.velocity = Vector2.up * speed;
            rbL.velocity = Vector2.up * speed;

        }
    }
}
