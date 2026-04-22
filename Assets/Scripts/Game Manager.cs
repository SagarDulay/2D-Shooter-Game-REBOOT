using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Weapon weaponOption1;
    private Weapon weaponOption2;
    void Start()
    {
        weaponOption1 = new RangedWeapon(newFireRate:5.5f, newDamage:10);
        weaponOption2 = new MeleeWeapon();

        FindAnyObjectByType<Player>().EquipWeapon(weaponOption1);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FindAnyObjectByType<Player>().EquipWeapon(weaponOption1);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            FindAnyObjectByType<Player>().EquipWeapon(weaponOption2);
        }
    }
}
