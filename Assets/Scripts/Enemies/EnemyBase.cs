using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour,IDamageable
    {
        public Collider collider;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;
        public int particlesEmit = 20;
        public float startLife = 10f;
        public float timeToDestroy = 3f;
        public bool lookAtPlayer = false;
        [SerializeField]private float _currentLife;
        [SerializeField]private AnimationBase _animationBase;
        [Header("Animation")] 
            public float durationAnimation = 0.2f;
            public Ease easeAnimation = Ease.OutBack;
            public bool startAnimation = true;
        [Header("Events")] 
            public UnityEvent onKillEvent;
        private Player _player;
        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
        }

        public virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }

            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }
        }

        protected virtual void Init()
        {
            ResetLife();
            if (startAnimation)
            {
                StartAnimation();
            }
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }
        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (collider != null)
            {
                collider.enabled = false;
            }
            Destroy(gameObject,timeToDestroy);
            AnimationPlayByTrigger(TypeAnimation.Death);
            onKillEvent?.Invoke();
        }

        public void OnDamage(float damage)
        {
            if (flashColor != null)
            {
                flashColor.Flash();
            }
            if (particleSystem != null)
            {
                particleSystem.Emit(particlesEmit);
            }

            transform.position -= transform.forward;
            _currentLife -= damage;
            if (_currentLife <= 0)
            {
                Kill();
            }
        }
        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage); 
        }
        public void Damage(float damage,Vector3 direction)
        {
            Debug.Log("Damage");
            OnDamage(damage); 
            transform.DOMove(transform.position - direction,0.1f);
        }
        #region Animations

            private void StartAnimation()
            {
                transform.DOScale(0,durationAnimation).SetEase(easeAnimation).From();
            }
            public void AnimationPlayByTrigger(TypeAnimation typeAnimation)
            {
                _animationBase.AnimationPlayByTrigger(typeAnimation);
            }

        #endregion

        private void OnCollisionEnter(Collision other)
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.healthBase.Damage(1);
            }
        }
    }
}
