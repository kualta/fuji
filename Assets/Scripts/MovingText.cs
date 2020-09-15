using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{

    void Start() {
        StartCoroutine(ShrinkObject());
    }

    IEnumerator ShrinkObject() {
        for (int i = 0; i < 20; i++) {
            transform.localScale *= .99f;
            yield return new WaitForSeconds(.05f);
        }
        StartCoroutine(ExpandObject());
    }

    IEnumerator ExpandObject() {
        for (int i = 0; i < 20; i++) {
            transform.localScale /= .99f;
            yield return new WaitForSeconds(.05f);
        }
        StartCoroutine(ShrinkObject());
    }
}
