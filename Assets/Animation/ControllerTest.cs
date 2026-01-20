using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ControllerTest : MonoBehaviour
{

    Animator anim;
    PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponentInParent<PhotonView>();
        if (!PV.IsMine)
            return;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
            return;
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 normalizedInput = input.normalized;
        // Debug.Log(normalizedInput);
        anim.SetBool("isWalking", normalizedInput != Vector3.zero);
        anim.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift));
    }
}
