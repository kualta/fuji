using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameController gameController;
    public LevelController levelController;
    public bool initialPlatform;


    //
    // FIXME: Shitty names for rigidbodis, shitty code all put into Start()!
    // 

    public Rigidbody2D rbL;
    public Rigidbody2D rbR;
    public float speed;

    void Start() {

        //
        // FIXME: Shitty spaghetti! refactoring required
        // 
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        RandomizePosition();
        speed = gameController.levelNumber;
        rbL = GetComponent<Rigidbody2D>();

        //
        // Shitty hack for the first platform, FIXME!
        //
        if (transform.childCount > 1) {
            rbR = GetComponent<Rigidbody2D>();
            rbR.velocity = Vector2.up * speed;
        }

        rbL.velocity = Vector2.up * speed;
    }

    void Update() {
        //Move();
        CheckPosition();
    }

    void Move() {
        //transform.Translate(Vector3.up * Time.deltaTime * gameController.levelNumber, Space.World);
        //rbL.MovePosition(Vector3.up * Time.deltaTime * gameController.levelNumber);
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
