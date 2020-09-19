using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;

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
        speed = gameController.levelNumber;
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
        if (currentState == STATE.FLYING) {
            transform.Translate(moveDir.normalized * Time.deltaTime * speed * 3f, Space.World);
        } else if (currentState == STATE.STICKED) {
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World); 
        }
    }

    void HandleSwipe(Vector2 swipe) {
        Debug.DrawLine(transform.position, new Vector3(swipe.x, swipe.y, 0f)); 
        if (currentState == STATE.STICKED) {
            moveDirection = new Vector3(swipe.x, swipe.y, 0f);
           // gameObject.GetComponent<FixedJoint2D>().connectedBody = new Rigidbody2D();
           // gameObject.GetComponent<FixedJoint2D>().autoConfigureConnectedAnchor = true;
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

    void Stick() {
        ChangeState(STATE.STICKED);
        moveDirection = Vector3.zero;
        collisionFramesCount = 0;
    }

    int collisionFramesCount;
    void OnCollisionEnter2D(Collision2D collision) {
       // FixedJoint2D joint;
       // joint = gameObject.GetComponent<FixedJoint2D>();
       // joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
       // joint.autoConfigureConnectedAnchor = false;
        Stick();
    }

    void OnCollisionStay2D(Collision2D collision) {
        collisionFramesCount++;
        Debug.Log(collisionFramesCount);
        if (collisionFramesCount > 20) {
            Stick();
        }
    }
}
