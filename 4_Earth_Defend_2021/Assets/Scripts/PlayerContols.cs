using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContols : MonoBehaviour
{
    [Header("General Rocket Setup Setting")]
    [Tooltip("Control the up and down speed of the ship")] [SerializeField] float controlSpeed = 10f;
    [Tooltip("How far the ship can go in x-axis")] [SerializeField] float xRange = 16f;
    [Tooltip("How far the ship can go in y-axis")] [SerializeField] float yRange = 12f;

    [Header("Laser gun array")]
    [Tooltip("Add all player Lasers")] [SerializeField] GameObject[] lasers;

    [Header("Screen Position based tuning")]
    [Tooltip("Tuning of ship on the x-Axis")]
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float controlPitchFactor = -0.5f;

    [Header("Player Position based tuning")]
    [Tooltip("Tuning of ship on the y-Axis")]
    [SerializeField] float positionYawFactor = 1.5f;

    [Tooltip("Tuning of ship on the z-Axis")]
    [SerializeField] float controlRollFactor = 2f;

    float xMovement, yMovement;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        float xOffset = xMovement * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);// restrict the player so that it will stay in the camera frame.

        float yOffset = yMovement * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = transform.localPosition.y * controlPitchFactor;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float rollDueToControlThrow = transform.localPosition.x * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;// rotate in x axis.
        float yaw = yawDueToPosition;// rotate in y axis.
        float roll = rollDueToControlThrow;// rotate in z axis.
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }

    void SetActiveLasers(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}
