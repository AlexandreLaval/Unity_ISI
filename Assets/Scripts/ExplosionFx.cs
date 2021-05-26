using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFx : MonoBehaviour
{

    ParticleSystem sys;

    void Start()
    {
        sys = GetComponent<ParticleSystem>();
        DeathWithParticle();
    }

    void DeathWithParticle()
    {
        Destroy(this.gameObject, 2f);
    }
}
