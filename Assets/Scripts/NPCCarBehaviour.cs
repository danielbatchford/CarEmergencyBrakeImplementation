using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarBehaviour : MonoBehaviour
{
    private float v;


    // Start is called before the first frame update
    void Start()
    {
        this.v = Random.Range(0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(v,0.0f,0.0f));
    }
}

