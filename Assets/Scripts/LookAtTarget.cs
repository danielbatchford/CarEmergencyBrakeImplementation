using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

public float HEIGHT;
public float DISTANCE_OFFSET;

public GameObject target;

void Start(){
    transform.LookAt(target.transform);
}

void LateUpdate(){
    float targetDV = target.GetComponent<PlayerBehaviour>().v;
    transform.position = new Vector3(transform.position.x + targetDV * Time.deltaTime, HEIGHT, DISTANCE_OFFSET);
    transform.LookAt(target.transform);

    }

}