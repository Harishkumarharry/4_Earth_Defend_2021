using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDestroyVFX;
    [SerializeField] GameObject enemyHitVFX;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    [Tooltip("Score for scoreBoard when player destroys a enemy.")] [SerializeField] int enemyScore;

    [SerializeField] int hitPoint = 2;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameObject.AddComponent<Rigidbody>().useGravity = false;
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoint < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        HitVfx();
        hitPoint--;
        scoreBoard.IncreaseScore(enemyScore);
    }

    void HitVfx()
    {
        GameObject vfx = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyDestroyVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(this.gameObject);
    }
    
}
