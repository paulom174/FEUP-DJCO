using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    private float rotZ;
    public float rotationSpeed = 30f;

    public int maxRotation = 15;

    // Update is called once per frame
    void Update()
    {
        if(rotZ > maxRotation || rotZ < -maxRotation) {
            rotationSpeed *= -1;
        }

        rotZ = Mathf.Clamp(rotZ, -maxRotation, maxRotation);

        rotZ += rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
