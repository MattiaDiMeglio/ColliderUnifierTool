using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderUnifier : MonoBehaviour
{
    [SerializeField] private PhysicMaterial _colliderMaterial;
    private void Awake()
    {
        if(gameObject.transform.GetComponentInChildren<BoxCollider>() != null)
        {
            DoUnify();
        }
    }

    private void DoUnify()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();//we add a new collider
        Bounds newBounds = gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds;//we get the first child bounds
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        //gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        for (int i = 1; i < gameObject.transform.childCount; i++)//encapsulates every other child bounds
        {
            newBounds.Encapsulate(gameObject.transform.GetChild(i).GetComponent<Renderer>().bounds);
            gameObject.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;

        }
        collider.size = new Vector3(newBounds.size.x/gameObject.transform.localScale.x, 
            newBounds.size.y / gameObject.transform.localScale.y, newBounds.size.z / gameObject.transform.localScale.z);
        collider.center = newBounds.center - gameObject.transform.position;
        collider.center = new Vector3(collider.center.x / gameObject.transform.localScale.x,
            collider.center.y / gameObject.transform.localScale.y, collider.center.z / gameObject.transform.localScale.z); //(collider.size/2);//center and size to collider
        collider.material = _colliderMaterial;
    }
}
