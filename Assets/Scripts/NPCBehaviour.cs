using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{

    public float VEL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        transform.Translate(new Vector3(VEL,0f,0f)*Time.deltaTime);
        
    }
}
