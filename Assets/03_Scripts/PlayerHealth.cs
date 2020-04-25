using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 20;
    [SerializeField] int heatlhDecrease = 1;
    [SerializeField] ParticleSystem baseDestroyed;
    public bool isAlive = true;

    private void OnTriggerEnter(Collider other)
    {
        ProcessDamage();
        if (playerHealth <= 0)
        {
            isAlive = false;
            DestroyBase();
        }
    }

    private void DestroyBase()
    {
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
        var vfx = Instantiate(baseDestroyed, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(gameObject);
    }

    private void ProcessDamage()
    {
        playerHealth = playerHealth - heatlhDecrease;
    }
}
