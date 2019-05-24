using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour {

    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript[] weapons;
    private Collider2D coliderCompontent;
    private SpriteRenderer rendererComponent;

    private void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        // Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();

        coliderCompontent = GetComponent<Collider2D>();

        rendererComponent = GetComponent<SpriteRenderer>();
    }

    // 1 - Disable everything
    private void Start()
    {
        hasSpawn = false;

        // Disable everything
        // -- collider
        coliderCompontent.enabled = false;
        // -- moving
        moveScript.enabled = false;
        // -- shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {

        // 2 - Check if the enemy has spawned.
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponScript weapon in weapons)
            {

                // Auto-fire
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

            // 4 - Out of the camera ? Destroy the game object.
            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
		
	}

    // 3 - Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        // -- collider
        coliderCompontent.enabled = true;
        // -- moving
        moveScript.enabled = true;
        // -- shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
            SoundEffectsHelper.Instance.MakeEnemyShotSound();
        }
    }
}
