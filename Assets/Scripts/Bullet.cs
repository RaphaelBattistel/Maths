using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Movement
    {
        Linear, // Partie 2
        Physics // Partie 6
    }

    [SerializeField] Movement movement = Movement.Linear;
    [SerializeField] Vector2 velocity;

    private float radius;

    private void Awake()
    {
        // Mise en cache du rayon en fonction de la taille du visuel. Aucune modification requise.
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        radius = renderer.bounds.extents.x;
    }

    // Partie 2
    // Objectif : 
    // Initialiser la vélocité de la balle en fonction de l'angle de visée et de la puissance de tir. Voir "Aim.CheckFire".
    //
    // Voir "Bullet.UpdateMovementLinear" et "Aim.CheckFire"
    public void Initialize(Vector3 velocity)
    {

    }

    private void Update()
    {
        switch (movement)
        {
            case Movement.Linear: UpdateMovementLinear(); break;
            case Movement.Physics: UpdateMovementPhysics(); break;
        }

        CheckTargetCollision();
        CheckGroundCollision();
    }

    // Partie 2
    // Objectif :
    // Implémenter le déplacement d’une balle en ligne droite(vélocité constante).
    // Pour cette étape, ne pas prendre en compte les accélérations de gravité et de vent.
    //
    // Voir "Bullet.Initialize" et "Aim.CheckFire"
    private void UpdateMovementLinear()
    {
        
        transform.position = (Vector2)transform.position + velocity * Time.deltaTime;
    }

    // Partie 6
    // Objectif :
    // Implémenter le déplacement d’une balle en prenant en compte les accélérations de gravité et de vent : 
    //     • Gravité : accélération verticale de 9,81 u/s
    //     • Vent : accélération horizontale. Magnitude réglable en éditeur.
    private void UpdateMovementPhysics()
    {

    }

    // Partie 4
    // Objectif : 
    // Implémenter la collision de la balle avec la cible.
    // Lorsque la balle touche la cible, un message est affiché en console et la balle est détruite.
    // Le test d’intersection entre deux cercles est équivalent à un test d’inclusion d’un point dans un cercle dont le rayon est la somme des rayons des deux cercles testés.
    private void CheckTargetCollision()
    {
        Target target = Target.Instance;
        float targetRadius = target.Radius;
        float combinedRadius = targetRadius + radius;
        Vector2 bulletTotarget = target.transform.position - transform.position;



        bool hasHit = false;
        if(combinedRadius >= bulletTotarget.magnitude)
        {
            hasHit = true;
        }
        if (hasHit)
        {
            target.OnHit();
            GameObject.Destroy(gameObject);
        }
    }

    // Partie 5
    // Implémenter la collision de la balle avec le sol.
    // Voir "Ground.IsUnderGround".
    private void CheckGroundCollision()
    {
        Ground ground = Ground.Instance;

        bool hasHit = ground.IsUnderGround(transform.position);
        if (hasHit)
        {
            ground.OnHit();
            GameObject.Destroy(gameObject);
        }
    }
}
