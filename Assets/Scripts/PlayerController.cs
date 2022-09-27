using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Vector3 direction = Vector3.right;
    private List<Transform> segments;
    public AudioClip collectSound;
    public AudioClip hitSound;
    public AudioSource playerSounds;
    public Transform segmentPrefab;
    public PlaySceneUI ui;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    int score = 0;
    int highScore;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);


    }

    private void Update()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("High Score", highScore);
            PlayerPrefs.Save();
        }



        scoreText.text = "Score: " + score;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
    }
    private void FixedUpdate()
    {

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + direction.x),
            this.transform.position.y,
            Mathf.Round(this.transform.position.z + direction.z));
        transform.LookAt(transform.position + direction);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        this.transform.position = Vector3.zero;


        ui.restrartButton.gameObject.SetActive(true);
        ui.returnMainMenuButton.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            Grow();
            playerSounds.PlayOneShot(collectSound);
            score++;
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
            playerSounds.PlayOneShot(hitSound);
            score = 0;
        }
    }
}
