using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType {
    shellExplosionEffect,
    tankExplosionEffect
}

public class ExplosionService : MonoSingletonGeneric<ExplosionService>
{
    [SerializeField]
    private ParticleSystem tankExplosion, shellExplosion;

    protected override void Awake() {
        base.Awake();
    }

    public ParticleSystem CreateEffect(EffectType type) {
        ParticleSystem explosionEffect = null;

        switch (type) {
            case EffectType.shellExplosionEffect:
                explosionEffect = Instantiate(shellExplosion);
                break;
            case EffectType.tankExplosionEffect:
                explosionEffect = Instantiate(tankExplosion);
                break;
        }

        return explosionEffect;
    }
}
