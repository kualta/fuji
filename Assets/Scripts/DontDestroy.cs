using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public bool dontDestroyOnLoad;


    void Awake() {

        if ( dontDestroyOnLoad ) {
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
