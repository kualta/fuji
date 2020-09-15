using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameController gameController;
    public bool initialPlatform;


    void Start() {
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

    void CheckPosition() {
        if (transform.position.y > 7f) {
            Destroy(this.gameObject);
        }
    }
}
