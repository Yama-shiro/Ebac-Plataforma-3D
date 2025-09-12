using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
    [RequireComponent(typeof(Collider))]
    public class CollectableBase : MonoBehaviour
    {
        public TypeSfx typeSfx;
        public CollectablesType collectablesType;
        public string compareTag = "Player";
        public ParticleSystem particleSystem;
        public float timeToHide = 3f;
        public GameObject graphicItem;
        public Collider[] colliders;

        [Header("Sounds")] 
            public AudioSource audioSource;

        private void Awake()
        {
            /*if (particleSystem != null)
            {
                particleSystem.transform.SetParent(null);
            }  */
            colliders = GetComponents<Collider>();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            PlaySfx();
            if (colliders != null)
            {
                foreach (var i in colliders)
                {
                    i.enabled = false;
                }
            }
            if (graphicItem != null)
            {
                graphicItem.SetActive(false);
            }

            Invoke(nameof(HideObject), timeToHide);
            OnCollect();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }
            CollectableManager.Instance.AddByType(collectablesType);
        }

        private void PlaySfx()
        {
            SfxPool.Instance.Play(typeSfx);
        }
    }
}
