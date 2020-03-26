using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject spawner;
    public GameObject start;
    public GameObject tutorial;
    void Start()
    {
       spawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            start.SetActive(false);
            tutorial.SetActive(false);
            spawner.SetActive(true);
        }
    }
}
