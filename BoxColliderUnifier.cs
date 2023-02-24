using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderUnifier : MonoBehaviour
{
    [SerializeField] private PhysicMaterial _colliderMaterial;
    private bool doneUnify = false;
    private void Awake()
    {
        if(gameObject.transform.GetComponentInChildren<BoxCollider>() != null)
        {
            DoUnify();
            doneUnify = true;
        }
    }

    private void Start()
    {
        if(!doneUnify) 
        {
            DoUnify();
        }
        GetComponent<BoxCollider>().material = _colliderMaterial;
    }

    private void DoUnify()
    {
        gameObject.GetComponentInChildren<BoxCollider>().enabled= false;
        for (int i = 1; i < gameObject.transform.childCount; i++)//encapsulates every other child bounds
        {
            gameObject.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
        }
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        Bounds newBounds = new Bounds(Vector3.zero, Vector3.zero);//new bounds
        newBounds = gameObject.transform.GetChild(0).GetComponent<Renderer>().bounds;//we get the first child bounds
        for (int i = 1; i < gameObject.transform.childCount; i++)//encapsulates every other child bounds
        {
            newBounds.Encapsulate(gameObject.transform.GetChild(i).GetComponent<Renderer>().bounds);
        }
        collider.center = newBounds.center - gameObject.transform.position;//center and size to collider
        collider.size = newBounds.size;
    }
}
