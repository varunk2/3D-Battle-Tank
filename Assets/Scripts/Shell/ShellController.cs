using System.Collections;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public LayerMask tankMask;
    //public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;
    public float minLaunchForce = 15f;

    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(ShellLife());
    }

    IEnumerator ShellLife() {
        yield return new WaitForSeconds(maxLifeTime);
        ExplodeShell();
    }
    public void LaunchShell() {
        _rigidbody.velocity = minLaunchForce * transform.forward;
    }

    private void OnTriggerEnter(Collider other) {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

        for (int i = 0; i < colliders.Length; i++) {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            TankController target = targetRigidbody.GetComponent<TankController>();

            if (!target)
                continue;

            target.TakeDamage();
        }

        ExplodeShell();

        Destroy(gameObject);
    }

    private void ExplodeShell() {
        ParticleSystem explosionParticles = ExplosionService.Instance.CreateEffect(EffectType.shellExplosionEffect);
        //explosionParticles.transform.parent = null;
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();

        StartCoroutine(ExplosionEffect(explosionParticles));
    }

    IEnumerator ExplosionEffect(ParticleSystem explosionParticles) {
        yield return new WaitForSeconds(explosionParticles.main.duration);
        Destroy(explosionParticles.gameObject);
    }
}
