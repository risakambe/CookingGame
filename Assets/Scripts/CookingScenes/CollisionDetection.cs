using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Transform[] potatopositions;
    public GameObject peeledpotato;
    public Vector3 maskinitpos;
    public GameObject mask;
    int collisionCounter=0;
    public gameManager gamemanager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCounter++;
        Instantiate(peeledpotato, potatopositions[collisionCounter].position, Quaternion.identity);
        mask.transform.position = maskinitpos;
        gamemanager.finish(collisionCounter);
    }

}
