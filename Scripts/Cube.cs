using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 forward;
    public GameObject flare;
    

    // Start is called before the first frame update
    void Start()
    {
        forward = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate( Time.deltaTime * forward);

    }
    public void EnableExplosion()
    {
        //flare.SetActive(true);
        flare.GetComponent<ParticleSystem>().Play();
        
    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(1f);
    }

    
}
