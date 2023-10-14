using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerHabilityArsenal : PlayerHabilityBase
{
    public List<UIGunUpdater> uiGunUpdaters;
    public TMP_Text gunUIText;

    [Header("First Gun Props")]
    public GunBase firstGunBase;
    public string firstGunName = "First Gun";

    [Header("Second Gun Props")]
    public GunBase secondGunBase;
    public string secondGunName = "Second Gun";

    public Transform gunPosition;
    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();
        CreateGun(firstGunBase, firstGunName);

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancellShoot();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            CreateGun(firstGunBase, firstGunName);
        }
        else if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            CreateGun(secondGunBase, secondGunName);
        }
    }

    private void CreateGun(GunBase gunBase, string gunName = "")
    {
        _currentGun = Instantiate(gunBase, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        gunUIText.text = gunName;
    }
    
    private void StartShoot()
    {
        _currentGun.StartShoot();
    }   
    
    private void CancellShoot()
    {
        _currentGun.StopShoot();
    }
}
