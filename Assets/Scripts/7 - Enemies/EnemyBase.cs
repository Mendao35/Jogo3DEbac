using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animations;
using TMPro;

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

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI lifeText; //Amostrar Vida

    private void Awake()
    {
        Init();
    }

    protected void ResetLife()
    {
        _currentLife = startLife;
        UpdateLifeText(); //Atualiza texto da vida
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

        _currentLife = Mathf.Clamp(_currentLife, 0, startLife); // Garante que não fique negativo
        UpdateLifeText(); //Atualiza texto da vida

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    private void UpdateLifeText() //Void para atualizar texto da vida
    {
        if (lifeText != null)
        {
            lifeText.text = _currentLife.ToString("F0"); // Mostra vida como número inteiro
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
