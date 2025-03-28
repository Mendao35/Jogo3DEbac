using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
 

    public GunBase gunBase;
    public Transform gunPosition;

    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartShoot();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            CancelShoot();
        }
        //inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        //inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
    }  

    private void CreateGun()
    {
       
        _currentGun = Instantiate(gunBase, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        Debug.Log("GunBase Instanciada");
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
        _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartShoot();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            CancelShoot();
        }
    }
}
