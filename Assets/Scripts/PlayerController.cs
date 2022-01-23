using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 6.0f;

    //GameObjects
    public GameObject welcomeTextObject;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject gameTime;

    //Audio
    public AudioClip musicClipOne;
    public AudioSource musicSource;
    public AudioClip musicClipTwo;
    public AudioSource musicSource2;
    public AudioClip musicClipThree;
    public AudioSource musicSource3;
    public AudioClip musicClipFour;
    public AudioSource musicSource4;
    AudioSource audioSource;

    //Flags
    private int Flag1;
    private int FlagMove;


    void Start()
    {
        musicSource.clip = musicClipOne;
        musicSource.Play();
        audioSource = GetComponent<AudioSource>();

        rigidbody2d = GetComponent<Rigidbody2D>();

        welcomeTextObject.SetActive(true);
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);

        Flag1 = 0;
        FlagMove = 0;
    }


    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //Will also start timer
        if (Input.GetKeyDown(KeyCode.B))
        {
            welcomeTextObject.SetActive(false);
            gameTime.GetComponent<COuntingstuff>().startTimer();
            musicSource.clip = musicClipOne;
            musicSource.Stop();

            musicSource2.clip = musicClipTwo;
            musicSource2.Play();

            FlagMove = 1;
        }

        if (Input.GetKey(KeyCode.R))
        {
            if ((Flag1 == 1) || (Flag1 == 2))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void FixedUpdate()
    {
        if ((Flag1 == 0) && (FlagMove == 1))
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
    }


    public void CheckWin(int isWin)
    {
        if ((isWin == 1) && (Flag1 != 2))
        {
            winTextObject.SetActive(true);

            musicSource2.clip = musicClipTwo;
            musicSource2.Stop();
            musicSource3.clip = musicClipThree;
            musicSource3.Play();

            Flag1 = 1;
        }

        if ((isWin == 2) && (Flag1 != 1))
        {
            loseTextObject.SetActive(true);

            musicSource2.clip = musicClipTwo;
            musicSource2.Stop();
            musicSource4.clip = musicClipFour;
            musicSource4.Play();

            Flag1 = 2;
        }
    }

    public void ChangeSpeed(bool amount)
    {
        if (amount == true)
        {
            speed = 3.0f;
        }

        if (amount == false)
        {
            speed = 6.0f;
        }

    }
}
