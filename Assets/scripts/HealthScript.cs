using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour {

    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;
    public Text healthText;
    private int hpe = 0;

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    void Start()
    {
        hpe = hp;

        // Initialise the health counter text
        if (healthText != null)
        {
            healthText.text = "Health: " + hp.ToString();
        }

    }

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
	// Use this for initialization
    public void Damage(int damageCount)
    {
        hp -= damageCount;
        hpe += damageCount;
        if (healthText != null)
        {
            healthText.text = "Health: " + hpe.ToString();
        }

        if (hp <= 0)
        {
            // 'Splosion!
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            SoundEffectsHelper.Instance.MakeExplosionSound();

            // Dead!
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if ((shot.isEnemyShot == false) && (isEnemy == true))
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject);   // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
    
}
