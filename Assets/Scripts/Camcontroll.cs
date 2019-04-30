using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcontroll : MonoBehaviour
{
    public GameObject player;
    private Vector3 camMin = new Vector3(114.2f, 151, 52);
    private Vector3 camMax = new Vector3(205, 151, 98);
    private Vector3 offset;
    private Vector3 temp;
    private Vector3 tem;
    private int zpos = 20;
    private int xpos = 80;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        CamMinMax();
    }
    void FollowPlayer()
    {
        //UP
        if (player.transform.position.z > zpos && zpos >= 20)
        {            
            tem = new Vector3(0, 0, 0.4f);
            temp = transform.position + tem;            
            transform.position = temp;            
            zpos++;            
        }
        //DOWN
        if (player.transform.position.z < zpos-5 && zpos > 20)
        {               
            tem = new Vector3(0, 0, -0.4f);
            temp = transform.position + tem;
            transform.position = temp;
            zpos--;           
        }
        //RIGHT
        if(player.transform.position.x > xpos)
        {            
            tem = new Vector3(0.4f, 0, 0);
            temp = transform.position + tem;
            transform.position = temp;
            xpos++;            
        }
        //LEFT
        if (player.transform.position.x < xpos && xpos > 60)
        {
            tem = new Vector3(-0.4f, 0, 0);
            temp = transform.position + tem;
            transform.position = temp;
            xpos--;
        }

    }
    void CamMinMax()
    {
        //left
        if (camMin.x > transform.position.x)
        {
            temp = new Vector3(camMin.x, transform.position.y, transform.position.z);
            transform.position = temp;
        }
        //top
        if (camMax.z < transform.position.z)
        {
            temp = new Vector3(transform.position.x, transform.position.y, camMax.z);
            transform.position = temp;
        }
        //bottom
        if (camMin.z > transform.position.z)
        {
            temp = new Vector3(transform.position.x, transform.position.y, camMin.z);
            transform.position = temp;
        }
        //right
        if (camMax.x < transform.position.x)
        {
            temp = new Vector3(camMax.x, transform.position.y, transform.position.z);
            transform.position = temp;
        }

    }
}
