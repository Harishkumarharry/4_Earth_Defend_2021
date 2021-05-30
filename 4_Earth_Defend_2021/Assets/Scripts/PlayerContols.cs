using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContols : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        float xOffset = xMovement * Time.deltaTime * controlSpeed;
        float yOffset = yMovement * Time.deltaTime * controlSpeed;

        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
