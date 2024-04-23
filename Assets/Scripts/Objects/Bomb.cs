using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SlashingEffect")
        {
            AudioManager.instance.PlaySFX("Explosion");

            GameObject effect = Instantiate(ExplosionEffect, transform.position, ExplosionEffect.transform.rotation);
                Destroy(gameObject);
                float duration = effect.GetComponent<ParticleSystem>().main.duration;
                Destroy(effect, duration);
                FindObjectOfType<GameManager>().GameOver();
        }
    }

}
