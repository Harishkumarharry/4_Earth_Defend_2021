using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    [Tooltip("Add particle system which needs to play when player crashes")] [SerializeField] ParticleSystem crashParticle;

    void OnTriggerEnter(Collider other)
    {
        CrashSequence();
    }

    void CrashSequence()
    {
        crashParticle.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerContols>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneLevel);
    }

}
