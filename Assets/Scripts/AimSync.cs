using UnityEngine;
using Photon.Pun;

public class AimSync : MonoBehaviour, IPunObservable
{
    public Transform aimTarget; // the one MultiAim looks at

    Vector3 netPos;
    Quaternion netRot;

    PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            // smooth to prevent jitter
            aimTarget.position = Vector3.Lerp(aimTarget.position, netPos, Time.deltaTime * 10f);
            aimTarget.rotation = Quaternion.Lerp(aimTarget.rotation, netRot, Time.deltaTime * 10f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(aimTarget.position);
            stream.SendNext(aimTarget.rotation);
        }
        else
        {
            netPos = (Vector3)stream.ReceiveNext();
            netRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
