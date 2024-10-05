using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int score;

    public Text scoreText;
    public AudioSource audioSource = null;
    public AudioClip audioClip = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movement * speed * Time.deltaTime);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            score--;
            audioSource.PlayOneShot(audioClip);
            updateScore();
        }
    }

    void updateScore()
    {
        scoreText.text = "Enemies left: " + score;
        if(score == 0) {
            SceneManager.LoadScene("WinScene");
        }
    }
}
