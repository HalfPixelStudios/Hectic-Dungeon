using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Range(0f, 10f)] public float camera_speed;
    public GameObject target;
    public float shakeAmt;
    public float shakeTime;
    public float shakeInterval;
    private float intervalDelta=0;
    private float shakeDelta = 0;
    

    void Start() {

    }

    void Update()
    {
        float t = camera_speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x,t),Mathf.Lerp(transform.position.y, target.transform.position.y,t),transform.position.z);

        //Camera pans towards mouse
        //Vector2 mouse_pos = Input.mousePosition;
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, mouse_pos.x, t), Mathf.Lerp(transform.position.y, mouse_pos.y, t), transform.position.z);

        if (shakeDelta > 0)
        {
            if (intervalDelta >=shakeInterval)
            {
                shake();
                intervalDelta= 0;
            }

            intervalDelta += Time.deltaTime;
            shakeDelta -= Time.deltaTime;

        }
        else
        {
            intervalDelta = 0;
        }


    }

    public void startShake(float shake,float shakeTime)
    {
        shakeAmt = shake;
        shakeDelta = shakeTime;

    }

    void shake()
    {
        if(shakeAmt>0) 
        {
            float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
            Vector3 pp = transform.position;
            pp.y+= quakeAmt; // can also add to x and/or z
            pp.x += quakeAmt;
            transform.position = pp;
        }
    }
}
