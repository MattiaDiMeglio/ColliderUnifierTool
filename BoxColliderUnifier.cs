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
        BoxCollider childCollider = null;
        Bounds newBounds = gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds;//we get the first child bounds
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        //gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        for (int i = 1; i < gameObject.transform.childCount; i++)//encapsulates every other child bounds
        {
            newBounds.Encapsulate(gameObject.transform.GetChild(i).GetComponent<Renderer>().bounds);
            childCollider = gameObject.transform.GetChild(i).GetComponent<BoxCollider>();
            if (childCollider != null)
                childCollider.enabled = false;
        }
         //we divide the size of the bounds by the parent scale
        collider.size = new Vector3(newBounds.size.x/gameObject.transform.localScale.x, 
            newBounds.size.y / gameObject.transform.localScale.y, newBounds.size.z / gameObject.transform.localScale.z);
        //we calculate the center
        collider.center = newBounds.center - gameObject.transform.position;
        //and divide it by the scale
        collider.center = new Vector3(collider.center.x / gameObject.transform.localScale.x,
            collider.center.y / gameObject.transform.localScale.y, collider.center.z / gameObject.transform.localScale.z);
        collider.material = _colliderMaterial;//we add the material to the collider
    }
}
