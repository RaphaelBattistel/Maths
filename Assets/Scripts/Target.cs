using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target Instance;

    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] private float duration;
    [SerializeField] private float speed;

    private float radius;
    public float Radius => radius;

    private void Awake()
    {
        // Mise en cache du rayon en fonction de la taille du visuel. Aucune modification requise.
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        radius = renderer.bounds.extents.x;

        Instance = this;
    }

    private void Update()
    {
        UpdateMovement();
    }

    // Partie 3
    // Objectif : Implémenter l'animation cyclique de la cible, allant de "start" à "end" à vitesse constante.
    // A la fin d'un cycle d'animation, la cible revient immédiatement a sa position d'origine.
    //
    // La vitesse de déplacement (et non la durée de l'animation) doit être réglable en éditeur.
    // La durée d'un cycle d'animation peut être déterminée à partir de la vitesse et de la longueur à parcourir : duration = startToEnd.magnitude / speed
    private void UpdateMovement()
    {
        Vector3 startToFinish = end.position - start.position;
        Vector3 positionToFinish = end.position - transform.position;
        float t = positionToFinish.magnitude / startToFinish.magnitude;
        duration = startToFinish.magnitude / speed;

        transform.position = Vector3.Lerp(start.position, end.position, t);

        //utiliser la fonction Repet de Mathf
    }

    // Appelé par "Bullet.CheckTargetCollision"
    public void OnHit()
    {
        Debug.Log("Target Hit \\o/");
    }


}
