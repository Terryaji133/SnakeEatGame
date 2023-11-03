using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 direction;
    public float speed;

    public Transform bodyPrefab;
    public List<Transform> bodies = new List<Transform>();
    public ScoreUI scoreUI;
    public Clip clip;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = speed;
        bodies.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            gameObject.SetActive(true);
        }
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W) && (direction != Vector3.down))
            {
                direction = Vector3.up;
            }
            if (Input.GetKeyDown(KeyCode.S) && (direction != Vector3.up))
            {
                direction = Vector3.down;
            }
            if (Input.GetKeyDown(KeyCode.A) && (direction != Vector3.right))
            {
                direction = Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.D) && (direction != Vector3.left))
            {
                direction = Vector3.right;
            }
        }

        if (scoreUI.GetScore() >= 20)
        {
            Time.timeScale = 0.3f;
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            for (int i = bodies.Count - 1; i > 0; i--)
            {
                bodies[i].position = bodies[i - 1].position;
            }

            transform.Translate(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            bodies.Add(Instantiate(bodyPrefab, transform.position, Quaternion.identity));
            scoreUI.AddScore();

            clip.PlayEatSound();

            if (scoreUI.GetScore() >= 20)
            {
                Time.timeScale = 0.3f;
            }
        }
        else if (collision.CompareTag("Obstacle"))
        {
            RestartGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = speed;
    }

    void RestartGame()
    {
        transform.position = Vector3.zero;
        direction = Vector3.zero;

        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }

        bodies.Clear();
        bodies.Add(transform);
        scoreUI.ReastScore();
        Time.timeScale = speed;
    }

}
