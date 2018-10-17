using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour {

    public float speed = 200f;

    private void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1, 0) * speed * Time.deltaTime);
        }
    }
}
