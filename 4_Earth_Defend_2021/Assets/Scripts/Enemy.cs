using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyDestroyVFX;
    [SerializeField] Transform parent;

    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(EnemyDestroyVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

}
