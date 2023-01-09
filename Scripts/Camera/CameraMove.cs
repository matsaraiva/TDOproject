using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float _speed = 5f;
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(_speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-_speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -_speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, _speed * Time.deltaTime, 0));
        }
    }
}
