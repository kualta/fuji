using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingText : MonoBehaviour
{
    public string[] Quotes;

    [SerializeField]
    internal TextMeshProUGUI textMesh;

    void Start() {
        RandomizeText();
        StartCoroutine(ShrinkObject());
    }

    public void RandomizeText() {
        textMesh.text = Quotes[Random.Range(0, Quotes.Length)];
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
