using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool swipeDetected;
    Vector3 currentVelocity;
    Vector3 targetPosition;
    public float smoothSpeed = 5f; // Adjust for smoother movement
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startTouchPosition = touch.position;

            if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                DetectSwipeDirection();
            }

        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

    }

    void DetectSwipeDirection()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude < 50) // Minimum swipe distance threshold
            return;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0)
            {
                Debug.Log("Swiped Right");
                OnSwipe(new Vector3(2, 0, 0));
            }
            else
            {
                Debug.Log("Swiped Left");
                OnSwipe(new Vector3(-2, 0, 0));
            }

        }
        else
        {
            if (swipeDelta.y > 0)
                Debug.Log("Swiped Up");
            else
                Debug.Log("Swiped Down");
        }
    }

    void OnSwipe(Vector3 pos)
    {
        targetPosition = transform.position + pos;
    }
}
