using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Cube : MonoBehaviourPun
{
    public void OnSendButtonClick()
    {
        // Týklama iþlemi gerçekleþtiðinde bu iþlev çaðrýlacak.

        // Göndermek istediðiniz mesajý oluþturun veya ayarlayýn.
        string message = "Merhaba, diðer oyuncular!";

        // Mesajý diðer oyunculara göndermek için PhotonView'ýn RPC iþlemini kullanabilirsiniz.
        PhotonView photonView = GetComponent<PhotonView>();
        if (photonView != null)
        {
            photonView.RPC("ReceiveMessage", RpcTarget.All, message);
        }
    }

    [PunRPC]
    private void ReceiveMessage(string message)
    {
        // Mesajý almak ve iþlemek için bu iþlevi kullanabilirsiniz.
        Debug.Log("Alýnan Mesaj: " + message);
    }
}
