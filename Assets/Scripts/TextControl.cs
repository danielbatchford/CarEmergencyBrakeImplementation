using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{

    GameObject player;
    Text text;

    private float vel;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerBehaviour>("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Velocity: "+ vals[0]; + "\n"+"Distance To Collision: "+ vals[1] + "\n"+"Stopping Distance: "+ vals[2] + "\n"+"Under Emergency Braking: "+vals[3];
    }
}
