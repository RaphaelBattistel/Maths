using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static Ground Instance;

    [SerializeField] private Transform left;
    [SerializeField] private Transform middle;
    [SerializeField] private Transform right;

    private void Awake()
    {
        // Aucune modification requise.
        Instance = this;
    }

    // Partie 5
    // Objectif : Implémenter la collision de la balle avec le sol. Voir "Bullet.CheckGroundCollision".
    public bool IsUnderGround(Vector3 point)
    {
        Vector2 leftToMiddle = middle.position - left.position;
        Vector2 perpendiculareLeftMiddle = Vector2.Perpendicular(leftToMiddle);

        Vector2 middleToRight = right.position - middle.position;
        Vector2 perpendiculareMiddleRight = Vector2.Perpendicular(middleToRight);

        Vector2 middleToBullet = point - middle.position; 



        float scalaireLMtoPoint = middleToBullet.x * perpendiculareLeftMiddle.x + middleToBullet.y * perpendiculareLeftMiddle.y;
        float scalaireMRtoPoint = middleToBullet.x * perpendiculareMiddleRight.x + middleToBullet.y * perpendiculareMiddleRight.y;

        if (scalaireLMtoPoint<0 && scalaireMRtoPoint < 0) 
        {
            return true;
        }
        return false;
    }

    // Appelé par "Bullet.CheckGroundCollision"
    public void OnHit()
    {
        Debug.Log("Groung Hit :')");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(left.position, middle.position);
        Gizmos.DrawLine(middle.position, right.position);
     

    }
}
