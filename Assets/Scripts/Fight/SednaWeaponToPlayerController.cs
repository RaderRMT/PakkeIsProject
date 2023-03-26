﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Fight
{
    public class SednaWeaponToPlayerController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _dieParticle;
        public Transform PlayerTransform;

        private void Update()
        {
            if (Vector3.Distance(transform.position, PlayerTransform.position) < 5f)
            {
                transform.DOScale(Vector3.zero, 0.7f).OnComplete(Die);
            }
        }

        public void Die()
        {
            _dieParticle.Play();
            _dieParticle.transform.parent = null;
            Destroy(gameObject);
        }
    }
}