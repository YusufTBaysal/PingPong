using System.Collections;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovment : MonoBehaviour
{
    public Text rightText;
    public Text leftText;
    int rightgoal = 0;
    int leftgoal = 0;
    private Vector3 initialPosition;
    public GameObject panel;

    private Rigidbody2D rb;
    public float speed = 200.0f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        initialPosition = transform.position;

        AddStartingForce();
        rightText.text = "" + rightgoal;
        leftText.text = "" + leftgoal;
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f):
                                        Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * this.speed);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RightGoal"))
        {
            leftgoal++;
            leftText.text = "" + leftgoal;
            panel.SetActive(true);
            StartCoroutine(ResetWithDelay(2.0f));
        }
        else
        {
            rightgoal++;
            rightText.text = "" + rightgoal;
            panel.SetActive(true);
            StartCoroutine(ResetWithDelay(2.0f));
        }
    }

    IEnumerator ResetWithDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        StartCoroutine(Wait(2.0f));
    }

    public void ResetBallPosition()
    {
        transform.position = initialPosition;  
    }

    IEnumerator Wait(float delay)
    {
        panel.SetActive(false);
        yield return new WaitForSeconds(delay);
        ResetBallPosition();
    }
}
