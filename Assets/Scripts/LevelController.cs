using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameController gameController;
    public GameObject platform;

    void Start() {
        StartCoroutine(SpawnPlatform());
    }


    IEnumerator SpawnPlatform() {
        Instantiate(platform, new Vector3(0f, -7f, 0f), Quaternion.identity);

        yield return new WaitForSeconds(2 / gameController.levelNumber);
        StartCoroutine(SpawnPlatform());
    }
}
