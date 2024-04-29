using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float paddleSpeed = 5f;
    public float boundaryY = 4f;

    void Update()
    {
        if (gameObject.CompareTag("LeftPaddle"))
        {
            MovePaddle(KeyCode.W, KeyCode.S);
        }
        else if (gameObject.CompareTag("RightPaddle"))
        {
            MovePaddle(KeyCode.UpArrow, KeyCode.DownArrow);
        }
    }

    void MovePaddle(KeyCode positiveKey, KeyCode negativeKey)
    {
        float move = 0f;

        if (Input.GetKey(positiveKey))
        {
            move = 1f;
        }
        else if (Input.GetKey(negativeKey))
        {
            move = -1f;
        }

        float newY = Mathf.Clamp(transform.position.y + move * paddleSpeed * Time.deltaTime, -boundaryY, boundaryY);
        transform.position = new Vector2(transform.position.x, newY);
    }
}
