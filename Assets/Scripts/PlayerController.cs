using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum STATE {
        FLYING,
        STICKED
    }

    public STATE currentState;
    public Vector3 moveDirection;
    public float speed;

    void Start()
    {
        moveDirection = Vector3.zero;
        currentState = STATE.STICKED;
        speed = 1f;
    }

    void Update()
    {
        GetInput();
        Move(moveDirection);
    }

    void ChangeState(STATE state) {
        currentState = state;
        Debug.Log("Changed State: " + state);
    }

    void Move(Vector3 moveDir) {
        if (moveDir != Vector3.zero) {
            transform.Translate(moveDir.normalized * Time.deltaTime * speed);
        }
    }

    void HandleSwipe(Vector2 swipe) {
        if (currentState == STATE.STICKED) {
            moveDirection = new Vector3(swipe.x, swipe.y, 0f);
            ChangeState(STATE.FLYING);
        }
    }

    Vector2 startPosition;
    Vector2 endPosition;

    void GetInput() {
        if (Input.GetMouseButtonDown(0)) {
            startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            endPosition = Input.mousePosition;
            Vector2 swipe = endPosition - startPosition;

            HandleSwipe(swipe);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision");
        ChangeState(STATE.STICKED);
    }
}
