using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
    [SerializeField]
    private GameObject brickParticle;
    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        CM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}