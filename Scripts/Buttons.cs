using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public AnimationClip[] animations;
    public GameObject restart;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRestart(bool come)
    {
        var index = -1;
        if (come)
            index = 0;
        else
            index = 1;
        restart.GetComponent<Animation>().clip = animations[index];
        restart.GetComponent<Animation>().Play();
    }

    public void MoveMenuButton(bool come)
    {
        var index = -1;
        if (come)
            index = 2;
        else
            index = 3;
        menu.GetComponent<Animation>().clip = animations[index];
        menu.GetComponent<Animation>().Play();
    }
}
