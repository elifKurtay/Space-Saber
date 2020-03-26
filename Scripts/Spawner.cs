using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public int objs;
    public GameObject music;
    public GameObject tutMusic;
    
    public GameObject player;
    public GameObject saber;
    public Text tutText;

    private bool isTutorial = false;
    
    private float timer;
    private bool gameInitialize = false;
    private bool isActive = true;
    private float speed = 3f;
    private int song = -1;

    // Start is called before the first frame update
    void Start()
    {
        objs = 0;
        timer = music.GetComponent<AudioSource>().clip.length;
        Debug.Log("Music 1 süresi: " + timer);

        timer = tutMusic.GetComponent<AudioSource>().clip.length;
        Debug.Log("Music 2 süresi: " + timer);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameInitialize)
        {

            if (timer > 2f)
            {
                if (isActive)
                {

                    isActive = false;
                    var point = 0;
                    var postion = 0;
                    if (isTutorial)
                    {
                        Debug.Log("inside");

                        if (timer > 213f)
                        {
                            tutText.text = "Reach the stars!";
                            postion = 1;
                            Debug.Log("first part");
                            point = Random.Range(3, 12);

                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;
                        }
                        else if (timer > 173f)
                        {
                            if (timer > 198f)
                            {
                                tutText.text = "Swipe & move right to reach green stars!";
                            }
                            else if (timer > 188f)
                            {
                                tutText.text = "Swipe left to return to red lane.";
                            }
                            else
                            {
                                tutText.text = "";
                            }

                            postion = Random.Range(1, 3);
                            Debug.Log("second part");
                            //red
                            if (postion == 1)
                            {
                                point = Random.Range(3, 12);
                            }
                            //green
                            else if (postion == 2)
                            {
                                point = Random.Range(6, 15);
                            }
                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;
                        }
                        else if (timer > 143f)
                        {
                            tutText.text = "Swipe & move all the way left to hit blue stars!";
                            postion = Random.Range(0, 3);
                            Debug.Log("third");
                            //blue
                            if (postion == 0)
                            {
                                point = Random.Range(0, 9);
                            }
                            //red
                            else if (postion == 1)
                            {
                                point = Random.Range(3, 12);
                            }
                            //green
                            else if (postion == 2)
                            {
                                point = Random.Range(6, 15);
                            }

                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;

                        }
                        else if (timer > 113f)
                        {
                            postion = Random.Range(0, 4);
                            tutText.text = "White stars can be hit from anywhere!";
                            //blue
                            if (postion == 0)
                            {
                                point = Random.Range(0, 9);
                            }
                            //red
                            else if (postion == 1)
                            {
                                point = Random.Range(3, 12);
                            }
                            //green
                            else if (postion == 2)
                            {
                                point = Random.Range(6, 15);
                            }
                            //white
                            else if (postion == 3)
                            {
                                point = Random.Range(0, 15);
                            }
                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;
                        }
                        else if (timer > 68f)
                        {
                            Debug.Log("fifth part");
                            tutText.text = "Swipe down to duck & Swipe up to jump to avoid obstacles!";
                            postion = 4;
                            speed = 4f;
                            point = Random.Range(7, 9);
                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;
                            
                        }
                        else if (timer > 33f)
                        {
                            speed = 3f;
                            tutText.text = "Tutorial complete, have fun!";
                            postion = Random.Range(0, 5);
                            Debug.Log("last part");
                            //blue
                            if (postion == 0)
                            {
                                point = Random.Range(0, 9);
                            }
                            //red
                            else if (postion == 1)
                            {
                                point = Random.Range(3, 12);
                            }
                            //green
                            else if (postion == 2)
                            {
                                point = Random.Range(6, 15);
                            }
                            //white
                            else if (postion == 3)
                            {
                                point = Random.Range(0, 15);
                            }
                            else
                            {
                                point = Random.Range(7, 9);
                            }
                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;
                            
                        }
                        else if (timer > 0f)
                        {
                            speed = 2f;
                            postion = Random.Range(0, 5);
                            Debug.Log("last part");
                            //blue
                            if (postion == 0)
                            {
                                point = Random.Range(0, 9);
                            }
                            //red
                            else if (postion == 1)
                            {
                                point = Random.Range(3, 12);
                            }
                            //green
                            else if (postion == 2)
                            {
                                point = Random.Range(6, 15);
                            }
                            //white
                            else if (postion == 3)
                            {
                                point = Random.Range(0, 15);
                            }
                            else
                            {
                                point = Random.Range(7, 9);
                            }
                            GameObject cube = Instantiate(cubes[postion], points[point]);
                            cube.transform.localPosition = Vector3.zero;
                        }

                    }
                    // NORMAL GAME
                    else
                    {
                        postion = Random.Range(0, 5);
                        tutText.text = "";
                        //blue
                        if (postion == 0)
                        {
                            point = Random.Range(0, 9);
                        }
                        //red
                        else if (postion == 1)
                        {
                            point = Random.Range(3, 12);
                        }
                        //green
                        else if (postion == 2)
                        {
                            point = Random.Range(6, 15);
                        }
                        //white
                        else if (postion == 3)
                        {
                            point = Random.Range(0, 15);
                        }
                        else
                        {
                            point = Random.Range(7, 9);
                        }
                        GameObject cube = Instantiate(cubes[postion], points[point]);
                        cube.transform.localPosition = Vector3.zero;
                    }

                    //timer -= Time.deltaTime;
                    StartCoroutine("DoCheck");

                    if(postion != 4)
                    { 
                        objs++;
                    }
                }
            }
            // else go to game over scene and back to main menu
            else
            {
                tutText.text = "Game Over";
            }
        }
        
    }

    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(speed);
        isActive = true;
        timer -= speed;
    }

    IEnumerator HoldUp()
    {
        yield return new WaitForSeconds(speed);
        
    }

    public void StartGame( bool start)
    {
        gameInitialize = true;
        isTutorial = !start;
        
        
        if (isTutorial)
        {
            speed = 5f;
            tutMusic.GetComponent<AudioSource>().Play();
            timer = tutMusic.GetComponent<AudioSource>().clip.length;
        }
        else
        {
            speed = 2f;
            song = Random.Range(0, 3);
            music.GetComponent<AudioSource>().Play();
            timer = music.GetComponent<AudioSource>().clip.length;
        }
        objs = 0;
    }

    public void Pause()
    {
        if (isTutorial)
        {
            tutMusic.GetComponent<AudioSource>().Pause();
        }
        else
        {
            if (song != -1)
            {
                music.GetComponent<AudioSource>().Pause();
            }
        }
    }

    public void Unpause()
    {
        if (isTutorial)
        {
            tutMusic.GetComponent<AudioSource>().UnPause();
        }
        else
        {
            if (song != -1)
            {
                music.GetComponent<AudioSource>().UnPause();
            }
        }
    }
}
