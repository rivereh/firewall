using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GravityGun : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 10f;
    float throwForce = 5f;
    float lerpSpeed = 100f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (!PV.IsMine)
            return;

        if (grabbedRB)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, lerpSpeed * Time.deltaTime));

            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }

            // objectHolder.transform.position = objectHolder.transform.position + cam.transform.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {   
                    if(hit.collider.gameObject.GetComponent<PhotonView>() != null)
                    {
                        hit.collider.gameObject.GetComponent<PhotonView>().TransferOwnership(PV.Owner);
                    }

                    if (hit.rigidbody)
                    {
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                        if (grabbedRB)
                        {
                            grabbedRB.isKinematic = true;
                        }
                    }
                }
            }
        }
    }
}
