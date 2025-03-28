using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{


    public GunBase gunBase1;
    public GunBase gunBase2;

    public Transform gunPosition;

    private GunBase _currentGun1;
    private GunBase _currentGun2;

    private int _IndexGun;

    protected override void Init()
    {
        base.Init();

        CreateGun1();
        CreateGun2();
        _IndexGun = 1;

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

    private void CreateGun1()
    {
       
        _currentGun1 = Instantiate(gunBase1, gunPosition);

        _currentGun1.transform.localPosition = _currentGun1.transform.localEulerAngles = Vector3.zero;
        Debug.Log("GunBase Instanciada");
    }

    private void CreateGun2()
    {

        _currentGun2 = Instantiate(gunBase2, gunPosition);

        _currentGun2.transform.localPosition = _currentGun2.transform.localEulerAngles = Vector3.zero;
        Debug.Log("GunBase Instanciada");
    }

    private void StartShoot()
    {
        if(_IndexGun == 1)
        {
            _currentGun1.StartShoot();
            Debug.Log("Start Shoot");
        }
        if (_IndexGun == 2)
        {
            _currentGun2.StartShoot();
            Debug.Log("Start Shoot");
        }

    }

    private void CancelShoot()
    {
        if(_IndexGun == 1)
        {
            _currentGun1.StopShoot();
            Debug.Log("Cancel Shoot");
        }
        if (_IndexGun == 2)
        {
            _currentGun2.StopShoot();
            Debug.Log("Cancel Shoot");
        }
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _IndexGun = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _IndexGun = 2;
        }


    }
}
