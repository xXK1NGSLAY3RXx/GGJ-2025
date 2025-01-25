using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;

    private GameObject Chosen_ammo;

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
    [HideInInspector]
    public bool ready_to_switch;
    private int energycost;
    private float shootInterval;
    private float _lastShootTime;
    public float force_gun_power;
    public float force_gun_range;
    [HideInInspector]
    public GameObject CPG_gun_target1;
    [HideInInspector]
    public GameObject CPG_gun_target2;
    [HideInInspector]
    public Vector3 CPG_gun_temp_pos;

    private int ammo_amount;
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

    //public GameObject Rifle;
    //private int Rifle_ammo_amount = 1000;
   
    public GameObject grenade;
    private int Grenade_ammo_amount = 20;
    public GameObject sticky;
    private int sticky_ammo_amount = 30;
    public GameObject CPG;
    private int CPG_ammo_amount = 2;
    public GameObject zipline;
    private int zipline_ammo_amount = 10;
    

    public Transform projectileSpawnPoint;
    public Animator animator;
    private LayerMask mask;

    private void Start()
    {

        instance = this;
        Switch(Guns.ForceGun);
        mask = LayerMask.GetMask("MoveAble");

    }

    private void FixedUpdate()
    {
        if (currentgun == Guns.changePosGun)
        {
            if (ready_to_switch == true)
            {

              if (Input.GetMouseButton(1))
              {
                ChangePos(true);

              }
            }


        }

       

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

        //Debug.Log(CPG_gun_target1);
        //Debug.Log(CPG_gun_target2);
        //Debug.Log(ready_to_switch);
        if (ChosenAmmo == null && currentgun == Guns.ForceGun)
        {

          

            if (!(Time.time > shootInterval + _lastShootTime))
                return;

            if (energycost < Drone.instance.EnergyAmount)
            {
                animator.SetInteger("Num", 0);
                if (Input.GetMouseButton(0))
                {
                    applypushforce();
                    Drone.instance.Drain_Energy(energycost);
                }

                if (Input.GetMouseButton(1))
                {
                    applypullforce();
                    Drone.instance.Drain_Energy(energycost);
                }
            }


        }








        _lastShootTime = Time.time;


    }

   

    private void applypushforce()
    {

            animator.SetInteger("Num", 1);
            var circlecast = Physics2D.CircleCast( new Vector2(projectileSpawnPoint.position.x,projectileSpawnPoint.position.y), 2f, transform.right, force_gun_range,mask);
            circlecast.rigidbody.linearVelocity = transform.right * force_gun_power;
            



    }
    private void applypullforce()
    {

            animator.SetInteger("Num", 2);
        var circlecast = Physics2D.CircleCast(new Vector2(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y), 2f, transform.right, force_gun_range,mask);
            circlecast.rigidbody.linearVelocity = -transform.right * force_gun_power;
            


    }


    private void ShootProjectile()
    {
        if (energycost < Drone.instance.EnergyAmount)
        { 
         Chosen_ammo.GetComponent<Projectile>().barrel_direction = transform;
         var p = Instantiate(Chosen_ammo, projectileSpawnPoint.position, Quaternion.identity);
         ammo_amount -= 1;
         Drone.instance.Drain_Energy(energycost);
        }


    }

    public void gunchange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
            Switch(Guns.ForceGun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2");
            Switch(Guns.changePosGun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3");
            Switch(Guns.ZipLine);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4");
            Switch(Guns.sticky);
        }
        


    }

    public enum Guns
    {
        Rifle, GrenadeLauncher, ForceGun, ZipLine ,changePosGun,sticky,
    }

    public Guns currentgun { get; private set; }

    public void Switch(Guns gun)
    {
        currentgun = gun;

       
         //if (currentgun == Guns.GrenadeLauncher)
         //{
         //   Chosen_ammo = grenade;
         //   ammo_amount = Grenade_ammo_amount;
         //   energycost = 3;
         //}
         if (currentgun == Guns.ForceGun)
         {
            Chosen_ammo = null;
            shootInterval = 0.5f;
            energycost = 2;
         }
         else if (currentgun == Guns.changePosGun)
         {
            ChosenAmmo = CPG;
            ammo_amount = CPG_ammo_amount;
            energycost = 0;
         }
        
         else if (currentgun == Guns.ZipLine)
         {
            ChosenAmmo = zipline;
            AmmoAmount = zipline_ammo_amount;
            energycost = 5;
         }

        else if (currentgun == Guns.sticky)
        {
            ChosenAmmo = sticky;
            AmmoAmount = sticky_ammo_amount;
            energycost = 2;
        }



        if(currentgun != Guns.ForceGun)
        shootInterval = Chosen_ammo.GetComponent<Projectile>().shootInterval;



    }

    public void ChangePos(bool state)
    {
        if (state == true)
        {
            CPG_gun_temp_pos = CPG_gun_target1.transform.position;
            CPG_gun_target1.transform.position = CPG_gun_target2.transform.position;
            CPG_gun_target2.transform.position = CPG_gun_temp_pos;
            CPG_gun_target1 = null;
            CPG_gun_target2 = null;
            ready_to_switch = false;
            Drone.instance.Drain_Energy(2);

        }
        else if (state == false)
        {
            CPG_gun_target1 = null;
            CPG_gun_target2 = null;
            
        }
        
        
    }


}