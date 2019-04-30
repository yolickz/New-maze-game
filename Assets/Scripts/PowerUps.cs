using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    bool PowerActive = false;
    bool SpeedUpActive = false;
    bool timeUp = false;
    public GameObject wall;
    Collider Collider;
    Movement M;

    //Movement move = new Movement();

    // Use this for initialization
    void Start()
    {
        Collider = GetComponent<Collider>();
        M = GetComponent<Movement>();
        //Collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePowerUp();
        SpeedUp();
    }

    IEnumerator Speed()
    {
        yield return new WaitForSeconds(3);

        SpeedUpActive = false;
    }

    IEnumerator phasing()
    {        
        yield return new WaitForSeconds(1.0f);
        //Debug.Log("Phasing ending");
        timeUp = true;
        PowerActive = false;
    }


    void SpeedUp()
    {
        if (SpeedUpActive == true)
        {
            M.moveSpeed = 30;

            StartCoroutine(Speed());
        }
        else
        {
            M.moveSpeed = 14;
        }
    }

    void ActivatePowerUp()
    {
        if (PowerActive == true)
        {
            Collider.isTrigger = true;
            StartCoroutine(phasing());
        }
        else
        {
            Collider.isTrigger = false;
        }
    }
   
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PowerUp(Clone)")
        {
            Destroy(col.gameObject);
            Debug.Log("Power up destroyed");
            PowerActive = true;
            //ActivatePowerUp();
        }
        else if (col.gameObject.name == "SpeedUp(Clone)")
        {
            Debug.Log("BIG FUCKING SPEED UP");
            Destroy(col.gameObject);
            Debug.Log("Power up destroyed");
            SpeedUpActive = true;
        }
        
    }

}
