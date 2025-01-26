using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;
    public int max_energy_amount;
    public GameObject bubbleAmmo;
    public GameObject stingerAmmo;
    public Transform projectileSpawnPoint;
    public enum Guns
    {
        bubble, 
    }
    private int energy_amount;
    private GameObject Chosen_ammo;
    private int energycost;
    private float shootInterval;
    private float _lastShootTime;
    private int ammo_amount;
    public GameObject ChosenAmmo
    {
        get
        {
            return Chosen_ammo;
        }

        set
        {
            Chosen_ammo = value;
        }
    }
    public int AmmoAmount
    {
        get
        {
            return ammo_amount;
        }

        set
        {
            ammo_amount = value;
        }
    }
    
    private void Start()
    {
        
        energy_amount = max_energy_amount;
        instance = this;
        Switch(Guns.bubble);
        

    }
    private void Update()
    {
        gunchange();
        if (ChosenAmmo != null)
        { 
            if (!Input.GetMouseButton(0))
            return;

         if (!(Time.time > shootInterval + _lastShootTime))
            return;
            ShootProjectile();
        }

        _lastShootTime = Time.time;
    }

   

   


    private void ShootProjectile()
    {
        if (energycost < energy_amount)
        { 
         Chosen_ammo.GetComponent<projectile>().barrel_direction = transform;
         var p = Instantiate(Chosen_ammo, projectileSpawnPoint.position, Quaternion.identity);
         //ammo_amount -= 1;
         Drain_Energy(energycost);
         
        }


    }

    public void gunchange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
            Switch(Guns.bubble);
        }
    }
    public Guns currentgun { get; private set; }

    public void Switch(Guns gun)
    {
        currentgun = gun;
        
         if (currentgun == Guns.bubble)
         {
            Chosen_ammo = bubbleAmmo;
            shootInterval = 0.5f;
            energycost = 0;
         }
    }
    public void Drain_Energy(int amount)
    {
        energy_amount -= amount;
    }
    
        
        
    


}