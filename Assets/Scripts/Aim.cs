using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float angularspeed = 1.0f;
    private Vector3 playerToAim;

    void Update()
    {
        ApplyInputs();
        RefreshPosition();
        CheckFire();
    }

    // Partie 1 (voir ApplyInputs et RefreshPosition)
    // Objectif :
    // Par défaut, la visée est vers le haut (90°). Le joueur contrôle la visée avec les touches directionnelles :
    //     • Gauche: La visée pivote autour du personnage dans le sens anti-horaire (vers la gauche) avec un maximum de 180°.
    //     • Droite : la visée pivote autour du personnage dans le sens horaire (vers la droite) avec un minimum de 0°.
    //     • Haut : la puissance du tir augmente progressivement avec un maximum de 1.
    //     • Bas : la puissance du tir diminue progressivement avec un minimum de 0.
    //
    // Les variations d'angle et de puissance se feront avec des vitesses constantes (vitesse angulaire, vitesse de variation de puissance).
    // Par exemple pour l’angle : angle_t1 = angle_t0 + angularSpeed * dt
    //
    // Penser à borner les valeurs :
    //     • Angle : Entre 0° et 180°
    //     • Puissance : Entre 0 et 1
    //
    // Voir "Aim.RefreshPosition"
    void ApplyInputs()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            Debug.Log("Turn anti-clockwise");
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Debug.Log("Turn clockwise");
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            Debug.Log("Increase power");
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            Debug.Log("Decrease power");
        }
    }

    // Partie 1
    // Objectif : 
    // Afficher le réticule de visée au bon emplacement relativement au personnage.
    //     • La visée est représentée par un réticule placé autour du personnage en fonction de l'angle de visée.
    //     • La puissance du tir est représentée par la distance entre le personnage et ce réticule.
    //
    // Le réticule de visée ne doit être enfant d’aucun autre GameObject dans la hiérarchie de la scène.
    //
    // Voir "Aim.ApplyInputs"
    void RefreshPosition()
    {
        Vector3 playerPosition = Player.Instance.transform.position;
        playerToAim = transform.position - playerPosition;

        //angle_t1 = angle_t0 + angularSpeed * dt
        Mathf.Clamp(Vector2.SignedAngle(playerToAim, transform.position), 0, 180);

        Debug.DrawRay(playerPosition, playerToAim);
    }

    // Partie 2
    // Objectif : 
    // Initialiser la vélocité de la balle en fonction de l'angle de visée et de la puissance de tir.
    //
    // Voir "Bullet.Initialize" et "Bullet.UpdateMovementLinear"
    void CheckFire()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 playerPosition = Player.Instance.transform.position;
            Bullet bullet = GameObject.Instantiate<Bullet>(bulletPrefab, playerPosition, Quaternion.identity);
            bullet.Initialize(Vector3.up);
            Debug.Log("FIRE !");
        }
    }
}
