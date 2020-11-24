using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosionController : MonoBehaviour
{
    public LayerMask tankMask;
    // Reference to particles that will play on explosion.
    public ParticleSystem explosionParticles;

    // Reference to the audio that will play on explosion.
    public AudioSource explosionAudio;

    // The amount of damage done if the explosion is centered on a tank.
    public float maxDamage = 100f;

    // The amount of force added to a tank at the center of the explosion.
    public float explosionForce = 1000f;

    // Time in seconds before a shell is removed.
    public float maxLifeTime = 2f;

    // The maximum distance away from the explosion tanks can be and are still affected.
    public float explosionRadius = 5f;


    void Start()
    {
        Destroy(gameObject, maxLifeTime); 
    }

    private void OnTriggerEnter(Collider other) {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

        for (int i = 0; i < colliders.Length; i++) {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            //targetHealth.TakeDamage(damage);
            targetHealth.TakeDamage();
        }

        explosionParticles.transform.parent = null;

        explosionParticles.Play();
        explosionAudio.Play();

        Destroy(explosionParticles.gameObject, 1f);
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition) {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;

        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
