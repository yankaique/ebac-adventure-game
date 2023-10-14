using Animation;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        public float startLife;

        [SerializeField] private float _currentLife;

        [Header("Animations")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithAnimation = true;
        [SerializeField] private AnimationBase _animationBase;

        private void Awake()
        {
            Init();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            ResetLife();

            if(startWithAnimation) { 
                BornAnimation();
            }
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if(collider != null)
            {
                collider.enabled = false;
            }
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float damage)
        {
            _currentLife -= damage;

            if(_currentLife <= 0 )
            {
                Kill();
            }
        }

        #region Animation
            private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                OnDamage(5);
            }
        }

        public void Damage(float damage)
        {
            OnDamage(damage);
        }
    }
}
