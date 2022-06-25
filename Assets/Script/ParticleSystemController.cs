using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Control Particle Effect 
/// </summary>
public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleEffectBlood;
    [SerializeField] ParticleSystem particleEffectCollector;

    private void Update()
    {
        if (PlayerController.IsDead)
        {
            playParticleEffectBlood();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<KeyController>() != null)
        {
            playParticleEffectCollector();
        }
    }

    public void playParticleEffectBlood()
    {
        particleEffectBlood.Play();
    }

    public void playParticleEffectCollector()
    {
        particleEffectCollector.Play();
    }

}
