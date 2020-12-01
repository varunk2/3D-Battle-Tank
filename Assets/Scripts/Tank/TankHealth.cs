using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;
    public GameObject explosionPrefab;
    public float startingHealth;
    public float damage;

    private ParticleSystem _explosionParticles;
    private float _currentHealth;
    private bool _dead;

    private void Awake() {

        _explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();

        _explosionParticles.gameObject.SetActive(false);

        _currentHealth = startingHealth;
        _dead = false;

        SetHealthUI();

    }

    public void TakeDamage() {

        _currentHealth -= damage;
        SetHealthUI();

        if(_currentHealth <= 0f) {
            OnDeath();
        }

    }

    private void OnDeath() {

        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();

        StartCoroutine(DelayDeath());
    }
    IEnumerator DelayDeath() {
        yield return new WaitForSeconds(_explosionParticles.main.duration);
        Destroy(_explosionParticles.gameObject);
        Destroy(gameObject);
    }

    private void SetHealthUI() {

        slider.value = _currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, _currentHealth/startingHealth);

    }

}
