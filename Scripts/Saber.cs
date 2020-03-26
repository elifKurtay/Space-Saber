using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public GameObject white;
    public GameObject obstacle;
    public GameObject saber;
    public GameObject spawner;
    public GameObject start;
    public GameObject tutorial;
    public GameObject player;

    public Text scoreText;
    private float score;
    private float points;
    private float pers;
    private bool tut;

    void Start()
    {
        score = 0f;
        pers = 1f;
        points = 0f;
        UpdateScore();
    }
    
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        pers = spawner.GetComponent<Spawner>().objs;
        if (pers == 0.0)
        {
            points = 0f;
        }
        else
        {
            points = Mathf.Floor((score / pers) * 100f);
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        if (!tut)
        {
            scoreText.text = "Score: " + points + "%";
        }
        else
            scoreText.text = "";
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            Color saberColor = saber.GetComponent<MeshRenderer>().material.color;
            Color starColor = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;

            //MAIN MENU
            if (hit.collider.gameObject.tag == "start")
            {
                player.GetComponent<Movement>().MoveForward();
                spawner.GetComponent<Spawner>().StartGame(true);
                tut = false;
                score = 0f;
                points = 0f;
                UpdateScore();
                //Destroy(hit.transform.gameObject);
            } 
            else if ( hit.collider.gameObject.tag == "tutorial")
            {
                player.GetComponent<Movement>().MoveForward();
                spawner.GetComponent<Spawner>().StartGame(false);
                score = 0f;
                points = 0f;
                UpdateScore();
                tut = true;
                //Destroy(hit.transform.gameObject);
            }

            
            //DURING GAME
            if (starColor == white.GetComponent<MeshRenderer>().material.color)
            {
                hit.transform.gameObject.GetComponent<Cube>().EnableExplosion();
                Destroy(hit.transform.gameObject);
                AddScore(1);
            }
            else if (starColor == obstacle.GetComponent<MeshRenderer>().material.color)
            {
                Destroy(hit.transform.gameObject);
                AddScore(-1);
            }
            else
            {
                if (saberColor != null && saberColor == starColor)
                {
                    hit.transform.gameObject.GetComponent<Cube>().EnableExplosion();
                    Wait();
                    Destroy(hit.transform.gameObject);
                    AddScore(1);
                }
                
            }
        }
        
        previousPos = transform.position;
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1f);
    }


}
