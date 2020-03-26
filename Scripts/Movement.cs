using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Material blue;
    public Material red;
    public Material green;
    public GameObject spawner;

    bool isJump = false;
    public GameObject saber;

    public AnimationClip[] animations;
    private AnimationClip up;
    private AnimationClip down;
    private int left;
    private int right;

    private void Start()
    {
        up = animations[0];
        down = animations[4];
        left = 8;
        right = 9;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.transform.position.x < -0.75)
        {
            //change saber color to blue
            //saber.ChangeColor(1);
            saber.GetComponent<MeshRenderer>().material = blue;
            
            up = animations[1];
            down = animations[3];
            left = -1;
            right = 6;
        }
        else if (this.transform.position.x < 0.75)
        {
            //change saber color to red
            //saber.ChangeColor(2);
            saber.GetComponent<MeshRenderer>().material = red;
            up = animations[0];
            down = animations[4];
            left = 8;
            right = 9;
        }
        else if (this.transform.position.x < 2.5)
        {
            //change saber color to green
            //saber.ChangeColor(3);
            saber.GetComponent<MeshRenderer>().material = green;
            up = animations[2];
            down = animations[5];
            left = 7;
            right = -1;
        }
    }

    private void LateUpdate()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime);

        //JUMPING
        if (transform.position.y <= 1.12)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            if (OVRInput.Get(OVRInput.Button.Up))
            {
                if (!isJump)
                {
                    isJump = true;
                    gameObject.GetComponent<Animation>().clip = up;
                    StartCoroutine("jumpMotion");
                }
            }
        }
        
        //move left
        if (OVRInput.Get(OVRInput.Button.Left))
        {
            
            if (left > 0)
            {
                if (!isJump)
                {
                    isJump = true;
                    gameObject.GetComponent<Animation>().clip = animations[left];
                    StartCoroutine("jumpMotion");
                }
            }
        }
        //move right
        if (OVRInput.Get(OVRInput.Button.Right))
        {
            if (right > 0)
            {
                if (!isJump)
                {
                    isJump = true;
                    gameObject.GetComponent<Animation>().clip = animations[right];
                    StartCoroutine("jumpMotion");
                }
            }
        }
         

        //squad
        if (OVRInput.Get(OVRInput.Button.Down))
        {
            if (!isJump)
            {
                isJump = true;
                gameObject.GetComponent<Animation>().clip = down;
                StartCoroutine("jumpMotion");
            }

        }

        //moving to menu
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            
            if (!isJump && gameObject.GetComponent<Transform>().position.z > -10)
            {
                isJump = true;
                gameObject.GetComponent<Animation>().clip = animations[11];
                spawner.GetComponent<Spawner>().Pause();
                StartCoroutine("jumpMotion");
            }
            else if (!isJump && gameObject.GetComponent<Transform>().position.z < -10)
            {
                isJump = true;
                gameObject.GetComponent<Animation>().clip = animations[10];
                spawner.GetComponent<Spawner>().Unpause();
                StartCoroutine("jumpMotion");
            }
            
        }

        // pausing
        if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
            }
            else
                Time.timeScale = 1f;
        }
    }
    
    IEnumerator jumpMotion()
    {
        gameObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.3f);
        isJump = false;
    }

    public void MoveForward()
    {
        gameObject.GetComponent<Animation>().clip = animations[10];
        StartCoroutine("jumpMotion");
    }

    

    /* script jumping
     * //GetComponent<Rigidbody>().AddForce(Vector3.up * 2, ForceMode.Impulse);
                //move = new Vector3(0f, 0.5f, 0f);
                //if ((transform.position + move).y <= 2)
                //{
                //    transform.Translate(move);
                //}

                //move = new Vector3(0, 40f, 0);
                ////transform.position += move *  Time.deltaTime;
                //move += gravity * Time.deltaTime * (-1);
                //Vector3 position = transform.position + move * Time.deltaTime;
                //if (position.y < topY)
                //{
                //    position.y = topY;
                //}
                //transform.position = position;
                //move.y = 0;
                //else if ( transform.position.y > 1.1)
        //{
        //    move += gravity * Time.deltaTime;
        //    Vector3 position = transform.position + move * Time.deltaTime;
        //    if (position.y < groundY)
        //    {
        //        position.y = groundY;
        //    }
        //    transform.position = position;
        //    move.y = 0;
        //}
        */
}
