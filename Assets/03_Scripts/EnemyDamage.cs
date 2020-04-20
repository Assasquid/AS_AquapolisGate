using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitEffect.Play();
    }

    void KillEnemy()
    {
        var vfx = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }

}
