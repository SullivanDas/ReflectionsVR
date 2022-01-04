using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Rifle : GunBase
{
    [SerializeField] private InputActionProperty shootAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot(Vector3 dir)
    {

    }

    private void CalculateRay(GameObject self, Vector3 pos, Vector3 dir, int currentBounce)
    {
        if(currentBounce == Data.Bounces)
        {
            return;
        }

        bool didReflect = false;
        RaycastHit[] hits = Physics.RaycastAll(pos, dir, Data.Range); 

        foreach(RaycastHit hit in hits)
        {
            IDamageable damageable = (IDamageable)Helper.CheckForInterface<IDamageable>(hit.collider.gameObject);
            if (damageable != null)
            {
                damageable.Damgage(Data.Damage);
            }

            if(hit.collider.tag == "Bouncable" && hit.collider.gameObject != self)
            {
                didReflect = true;
                Vector3 currentDir = (hit.point - pos);
                Vector3 newDir = (currentDir - (2 * Vector3.Dot(currentDir, hit.normal) * hit.normal));
                CalculateRay(hit.collider.gameObject, hit.point, newDir, currentBounce++);
                break;
            }
        }
        if (!didReflect)
        {
            //shoot to range
        }
    }
}
