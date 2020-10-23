using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Joystick joystick;
    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Debug.Log(horizontalInput + " " + verticalInput);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * 1.5f * Time.deltaTime);

        //transform.position += transform.forward * 1.5f * verticalInput * Time.deltaTime;
        //transform.Rotate(Vector3)
    }
}
