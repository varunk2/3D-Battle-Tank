using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;
    public GameObject explosionPrefab;

    [SerializeField] protected MeshRenderer[] _meshRenderers;
    [SerializeField] protected Transform fireTransform;
    protected Rigidbody _rigidBody;
    //protected ParticleSystem _explosionParticles;
    protected float _tankSpeed;
    protected float _turnSpeed;
    protected float _startingHealth;
    protected float _currentHealth;
    protected float _damage;
    protected float _mass;


    public void Initialize(TankScriptableObject config) {
        _tankSpeed = config.speed;
        _turnSpeed = config.turnSpeed;
        _currentHealth = _startingHealth = config.health;
        _damage = config.damage;
        _mass = config.mass;

        foreach (MeshRenderer mesh in _meshRenderers) {
            mesh.material.color = config.tankColor;
        }

        SetHealthUI();
    }

    protected void Fire() {
        ShellController shell = ShellManager.Instance.GetShell();
        shell.transform.position = fireTransform.position;
        shell.transform.rotation = fireTransform.rotation;
        shell.LaunchShell();
    }

    public void TakeDamage() {

        _currentHealth -= _damage;
        SetHealthUI();

        if (_currentHealth <= 0f) {
            OnDeath();
        }

    }

    private void OnDeath() {

        Destroy(gameObject);

        ParticleSystem explosionParticles = ExplosionService.Instance.CreateEffect(EffectType.tankExplosionEffect);
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();

        StartCoroutine(DelayDeath(explosionParticles));
    }

    IEnumerator DelayDeath(ParticleSystem explosionParticles) {
        yield return new WaitForSeconds(explosionParticles.main.duration);
        Destroy(explosionParticles.gameObject);
    }

    public void SetHealthUI() {

        slider.value = _currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, _currentHealth / _startingHealth);

    }
}
