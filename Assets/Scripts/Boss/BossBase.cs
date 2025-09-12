using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using NaughtyAttributes;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Boss
{
    public enum BossAction
    {
        Init,
        Idle,
        Walk, 
        Attack,
        Death
    }
    public class BossBase : MonoBehaviour
    {
        public float speed = 5f;
        public List<Transform> waypoints;
        public HealthBase healthBase;
        [Header("Animation")] 
            public float durationAnimation = 0.5f;
            public Ease easeAnimation = Ease.OutBack;
        [Header("Attack")] 
            public int amountAttack = 5;
            public float timeBetweenAttacks = 0.5f;
        private StateMachine<BossAction> _stateMachine;

        private void Awake()
        {
            Init();
            OnValidate();
            if (healthBase != null)
            {
                healthBase.onKill += OnBossKill;
            }
        }
        private void OnValidate()
        {
            if (healthBase == null)
            {
                healthBase = GetComponent<HealthBase>();
            }
        }

        private void Init()
        {
            _stateMachine = new StateMachine<BossAction>();
            _stateMachine.Init();
            _stateMachine.RegisterStates(BossAction.Init, new BossStateInit());
            _stateMachine.RegisterStates(BossAction.Walk, new BossStateWalk());
            _stateMachine.RegisterStates(BossAction.Attack, new BossStateAttack());
            _stateMachine.RegisterStates(BossAction.Death, new BossStateDeath());
        }

        private void OnBossKill(HealthBase healthBase)
        {
            SwitchState(BossAction.Death);
        }
        #region Attack

            public void StartAttack(Action endCallback = null)
            {
                StartCoroutine(CoroutineStartAttack(endCallback));
            }

            IEnumerator CoroutineStartAttack(Action endCallback)
            {
                int attacks = 0;
                while (attacks < amountAttack)
                {
                    attacks++;
                    transform.DOScale(1.1f,0.1f).SetLoops(2,LoopType.Yoyo);
                    yield return new WaitForSeconds(timeBetweenAttacks);
                }
                endCallback?.Invoke();
            }

        #endregion
        #region Movement
            public void GoToRandomPoint(Action onArrive = null)
            {
                StartCoroutine(CoroutineGoToPoint(waypoints[Random.Range(0,waypoints.Count)],onArrive));
            }

            IEnumerator CoroutineGoToPoint(Transform point, Action onArrive = null)
            {
                while (Vector3.Distance(transform.position,point.position) > 1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        point.transform.position, Time.deltaTime * speed);
                    yield return new WaitForEndOfFrame();
                }
                onArrive?.Invoke();
            }

        #endregion
        #region Animation

            public void StartAnimation()
            {
                transform.DOScale(0,durationAnimation).SetEase(easeAnimation).From();
            }

        #endregion
        #region Debug
            [Button]
            private void SwitchInit()
            {
                SwitchState(BossAction.Init);
            }
            [Button]
            private void SwitchWalk()
            {
                SwitchState(BossAction.Walk);
            }
            [Button]
            private void SwitchAttack()
            {
                SwitchState(BossAction.Attack);
            }

        #endregion
        #region State Machine

            public void SwitchState(BossAction state)
            {
                _stateMachine.SwitchStates(state,this);
            }

        #endregion
    }
}
