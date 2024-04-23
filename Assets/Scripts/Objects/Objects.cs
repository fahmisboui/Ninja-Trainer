using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    [SerializeField] GameObject slicedObject;
    [SerializeField] GameObject slishingVfx;
    [SerializeField] int scorePoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SlashingEffect")
        {

            AudioManager.instance.PlaySFX("Slicing");
            Vector3 localPosition = transform.localPosition;

            Destroy(gameObject);
            GameObject sliceClone = Instantiate(slicedObject, transform.parent);
            sliceClone.transform.localPosition = localPosition;
            GameObject effect = Instantiate(slishingVfx, transform.position, slishingVfx.transform.rotation);
            float effectDuration = slishingVfx.GetComponent<ParticleSystem>().main.duration;
            Destroy(effect, effectDuration);
            Rigidbody2D[] rbSlice = sliceClone.transform.GetComponentsInChildren<Rigidbody2D>();

            foreach (Rigidbody2D rb in rbSlice)
            {
                Vector2 forceDirection = Random.insideUnitCircle.normalized;
                rb.AddForce(forceDirection * 2, ForceMode2D.Impulse);
            }
            Destroy(sliceClone,3f);
            FindObjectOfType<GameManager>().UpdateScore(scorePoints);
        }

        if (collision.tag == "Detector")
        {
            FindObjectOfType<GameManager>().RemainingLives();
        }
  
    }

   


}