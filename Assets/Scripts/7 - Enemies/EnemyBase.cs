using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animations;

public class EnemyBase : MonoBehaviour, IDamageble
{
    public Collider collider;
    public FlashColorNew flashColor;
    public ParticleSystem particleSystem;
    public float startLife = 10f;
    
    [Header("Start Animation")]
    public float startAnimationDuration = 0.2f;
    public Ease startAnimationEase = Ease.InOutBack;
    public bool startWithBornAnimation = true;

    [SerializeField]
    private AnimationBase _animationBase;

    [SerializeField]
    private float _currentLife;


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
        BornAnimation();
    }

    protected virtual void Kill() 
    {
        OnKill();
    }

    protected virtual void OnKill() //Quando Morre
    {
        if(collider != null)
        {
            collider.enabled = false;
        }
        Destroy(gameObject, 3f);
        PlayAnimationByTrigger(AnimationType.DEATH);
    }

    public void OnDemage(float f)
    {
        if (flashColor != null)
        {
            flashColor.Flash();
        }

        if(particleSystem != null)
        {
            particleSystem.Emit(15);
        }

        _currentLife -= f;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    #region ANIMATION

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
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnDemage(5f);
        }
    }

    public void Demage(float demage)
    {
        OnDemage(demage);
    }
}
