using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    public float hareketHizi;
    public Rigidbody2D rb;
    public Color turkuazRenk, sariRenk, morRenk, pembeRenk;
    public String mevcutRenk;
    public SpriteRenderer sr;
    public Text scoreText;
    private int score;

    public Text panelScore;

    public Canvas panelCanvas;

 void Start()
{
    RandomColor();
}

   

    void Update()
    {
        // klavye kontrolleri

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.velocity = Vector2.up*hareketHizi;
        //}

        // dokunmatik kontroller

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.velocity = Vector2.up * hareketHizi;
        }

    }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag != mevcutRenk && other.tag != "changecolor" && other.tag != "star")
            {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Time.timeScale = 0;

            panelCanvas.gameObject.SetActive(true); // Canvas'ı etkinleştir

            panelScore.text=score.ToString();
            }

            if (other.tag=="changecolor")
            {
                RandomColor();
               
            }

        if (other.tag=="star")
        {
            Debug.Log("triggered");
            score++;
            scoreText.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }
    }

        void RandomColor(){
            int random = UnityEngine.Random.Range(0,4);

            switch (random)
            {
                case 0 :
                    mevcutRenk= "turkuaz";
                    sr.color = turkuazRenk;
                    break;
                case 1 :
                    mevcutRenk= "sari";
                    sr.color = sariRenk;
                break;

                case 2 :
                mevcutRenk= "mor";
                    sr.color = morRenk;
                break;
                case 3 :
                mevcutRenk= "pembe";
                    sr.color = pembeRenk;
                    break;

                default:
                Debug.Log("renk atanmadı");
                break;
                
            }
        }
    
}
