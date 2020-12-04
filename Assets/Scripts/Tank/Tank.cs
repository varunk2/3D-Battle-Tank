using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    public Joystick joystick;
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;
    public GameObject explosionPrefab;

    private Rigidbody _rigidBody;
    private ParticleSystem _explosionParticles;
    private float _tankSpeed;
    private float _turnSpeed;
    private float _startingHealth;
    private float _currentHealth;
    private float _damage;
    private float _mass;

    [SerializeField] private MeshRenderer[] _meshRenderers;

    public void Intialize(TankScriptableObject config) {
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
    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();

        _explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();

        _explosionParticles.gameObject.SetActive(false);

    }
    private void Update() {
        _rigidBody.mass = _mass;

        Movement();
        Turn();
    }
    private void Movement() {
        if (joystick.Vertical > 0.2f || joystick.Vertical < -0.2f) {
            Vector3 movement = transform.forward * joystick.Vertical * _tankSpeed * Time.deltaTime;

            _rigidBody.MovePosition(_rigidBody.position + movement);
        }
    }
    private void Turn() {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f) {
            float turn = joystick.Horizontal * _turnSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0f, turn, 0f);

            _rigidBody.MoveRotation(_rigidBody.rotation * rotation);
        }
    }
    public void TakeDamage() {

        _currentHealth -= _damage;
        SetHealthUI();

        if (_currentHealth <= 0f) {
            OnDeath();
        }

    }
    private void OnDeath() {

        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();
        gameObject.SetActive(false);
        StartCoroutine(DelayDeath());
    }
    IEnumerator DelayDeath() {
        yield return new WaitForSeconds(_explosionParticles.main.duration);
        gameObject.SetActive(false);
    }
    private void SetHealthUI() {

        slider.value = _currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, _currentHealth / _startingHealth);

    }
}
