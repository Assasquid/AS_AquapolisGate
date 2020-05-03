using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int baseHealth = 20;
    [SerializeField] int heatlhDecrease = 1;
    [SerializeField] ParticleSystem baseDestroyed;
    public bool isAlive = true;
    
    [SerializeField] TextMeshProUGUI baseHealthText;

    [SerializeField] AudioClip baseDestroyedSFX;

    void Start()
    {
        baseHealthText.text = baseHealth.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        ProcessDamage();
        if (baseHealth <= 0)
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
        AudioSource.PlayClipAtPoint(baseDestroyedSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }

    private void ProcessDamage()
    {
        baseHealth -= heatlhDecrease; // playerHealth -= playerHealth - heatlhDecrease;
        baseHealthText.text = baseHealth.ToString();
    }
}
