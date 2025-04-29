using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector3 targetPosition;

    public float smoothSpeed = 5f; // Smoothing speed for swipe transition
    public float minSwipeDistance = 50f; // Minimum swipe threshold
    public float forwardSpeed = 5f; // Constant forward movement

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleTouchInput();
        SmoothSwipeMove();
        MoveForward();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipeDirection();
                    break;
            }
        }
    }

    void DetectSwipeDirection()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude < minSwipeDistance)
            return;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0)
            {
                Debug.Log("Swiped Right");
                Move(Vector3.right * 2f);
            }
            else
            {
                Debug.Log("Swiped Left");
                Move(Vector3.left * 2f);
            }
        }
        else
        {
            if (swipeDelta.y > 0)
            {
                Debug.Log("Swiped Up");
                Move(Vector3.up * 2f);
            }
            else
            {
                Debug.Log("Swiped Down");
                Move(Vector3.down * 2f);
            }
        }
    }

    void Move(Vector3 direction)
    {
        targetPosition += direction;
    }

    void SmoothSwipeMove()
    {
        // Only update X and Y, let Z be handled by MoveForward
        Vector3 current = transform.position;
        Vector3 desired = new Vector3(targetPosition.x, targetPosition.y, current.z);
        transform.position = Vector3.Lerp(current, desired, smoothSpeed * Time.deltaTime);
    }

    void MoveForward()
    {
        transform.position += new Vector3(0, 0, forwardSpeed) * Time.deltaTime;
    }
}
