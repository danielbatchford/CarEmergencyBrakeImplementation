using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float INIT_VEL;

    public float THROTTLE_INC;
    public float THROTTLE_SCALE;

    public float BRAKE_INC;
    public float BRAKE_SCALE;

    public float DRAG_COEFF;
    public float v;

    public float VIEW_DISTANCE;

    public float EMERG_MARGIN;

    private float currentThrottle;
    private float currentBrake;

    private bool underEmergencyBraking;

    private float FRONT_CAR_LENGTH;

    void Start()
    {
        this.v = INIT_VEL;
        this.currentThrottle = 0;
        this.currentBrake = 0;
        this.underEmergencyBraking = false;

        this.FRONT_CAR_LENGTH = ComputeFrontCarLength();
    }

    void Update()
    {
        underEmergencyBraking = IsUnderEmergencyBraking();
        if(Input.GetKey("space") && !underEmergencyBraking){
            currentThrottle = Mathf.Min(currentThrottle + THROTTLE_INC, 1);

        }
        else{
            currentThrottle = Mathf.Max(currentThrottle - THROTTLE_INC, 0);

            if(underEmergencyBraking || Input.GetKey("b")){
                currentBrake = Mathf.Min(currentBrake + BRAKE_INC, 1);
            }
            else{
                currentBrake = Mathf.Max(currentBrake - BRAKE_INC, 0);
            }
        }
        v += (THROTTLE_SCALE * currentThrottle) - (BRAKE_SCALE * currentBrake * Mathf.Max(v,0)) - (DRAG_COEFF * (v * v));

        transform.Translate(new Vector3(v,0f,0f)*Time.deltaTime);
    }

    private bool IsUnderEmergencyBraking(){

        RaycastHit outRay;


        bool hit = Physics.Raycast(transform.position + new Vector3(FRONT_CAR_LENGTH * transform.localScale.x,0f,0f), transform.TransformDirection(Vector3.right), out outRay, VIEW_DISTANCE);
        if (!hit){
            return false;
        }
        Debug.DrawRay(transform.position + new Vector3(FRONT_CAR_LENGTH * transform.localScale.x,0f,0f), transform.TransformDirection(Vector3.right) * (outRay.distance - FRONT_CAR_LENGTH * transform.localScale.x), Color.yellow);

        float collisionDistance = outRay.distance;
        float simThrottle = currentThrottle;
        float simBrake = currentBrake;
        float vel = this.v;
        float brakingDistance = 0;


        float epsilon = 0.0005f; // temp
        float tries = 0;
        while (vel > epsilon && tries < 20000){
            tries++;
            simThrottle = Mathf.Max(simThrottle - THROTTLE_INC, 0);
            simBrake = Mathf.Min(simBrake + BRAKE_INC, 1);
            vel += (THROTTLE_SCALE * simThrottle) - (BRAKE_SCALE * simBrake * Mathf.Max(vel,0)) - (DRAG_COEFF * (vel * vel));
            brakingDistance += vel * Time.deltaTime; //check this
        }
        return (brakingDistance >= collisionDistance /* plus margin*/);

        
    }


    private float ComputeFrontCarLength(){
             BoxCollider collider = (BoxCollider) this.gameObject.GetComponent<Collider>();
             Debug.Log(collider.size.x / 2f);
             return collider.size.x / 2f;   
    }
}
