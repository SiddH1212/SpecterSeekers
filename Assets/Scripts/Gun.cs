using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public OVRInput.RawButton shootButton;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxLineDistance = 5;
    public float lineShowTimer = 0.3f;
    public LayerMask layerMask;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject impact;

    void Update()
    {
        if(OVRInput.GetDown(shootButton))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray,out RaycastHit hit, maxLineDistance, layerMask);

        Vector3 endpoint = Vector3.zero;

        if(hasHit)
        {
            endpoint = hit.point;
            Ghost ghost = hit.transform.GetComponentInParent<Ghost>();
            if(ghost)
            {
                // hit.collider.enabled = false;
                ghost.Kill();
            }
            else
            {
                Quaternion impactRotation = Quaternion.LookRotation(-hit.normal);
                GameObject rayImpact = Instantiate(impact, hit.point, impactRotation);
                Destroy(rayImpact, 1);
            }
        }
        else
        {
            endpoint = shootingPoint.position + shootingPoint.forward*maxLineDistance;
        }

        LineRenderer line = Instantiate(linePrefab); 
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);
        line.SetPosition(1,endpoint);
        audioSource.PlayOneShot(audioClip);
        Destroy(line, lineShowTimer);
    }
}
