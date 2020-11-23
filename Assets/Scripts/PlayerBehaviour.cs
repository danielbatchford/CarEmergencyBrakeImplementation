using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float INIT_VEL;
    public float THROTTLE_INC;
    public float THROTTLE_SCALE;
    public float DRAG_COEFF;
    public float v;

    private float currentThrottle;

   


    // Start is called before the first frame update
    void Start()
    {
        this.v = INIT_VEL;
        this.currentThrottle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //simulate throttle pedal
        if(Input.GetKey("space")){
            currentThrottle = Mathf.Min(currentThrottle + THROTTLE_INC, 1);
        }
        else{
            currentThrottle = Mathf.Max(currentThrottle - THROTTLE_INC, 0);
        }


        //apply throttle to velocity
        this.v += THROTTLE_SCALE * currentThrottle - DRAG_COEFF * (this.v * this.v);

        Debug.Log(currentThrottle);


        transform.Translate(new Vector3(this.v,0.0f,0.0f)*Time.deltaTime);
    }
    
}
