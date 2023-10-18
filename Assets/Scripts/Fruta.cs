using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fruta : MonoBehaviour
{
    [SerializeField] private int cherries = 0;
    [SerializeField] private TextMeshProUGUI cherryText;
    [SerializeField] public TMP_Text healthDisplay;
    [SerializeField] private GameObject gameOver;
    [SerializeField] public int health;

    private enum State { idle, walk, Jump, cair, hurt }
    private State state = State.idle;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
         


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D box)
    {
        if(box.tag == "Coletável") 
        {
            Destroy(box.gameObject);

            cherries += 1;

            cherryText.text = cherries.ToString();
            Debug.Log(cherryText.text);
        }
    }
    private void HandleHealth()
    {
        health --;
        healthDisplay.text = "Vida: " + health;
        if (health <= 0)
        {
            AbrirGameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (state == State.cair)
            {
               
            }
            else
            {
                
                HandleHealth();
                
            }
        }
    }
    public void AbrirGameOver()
    {
        gameOver.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
    }
}
