using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Cube : MonoBehaviourPun
{
    public void OnSendButtonClick()
    {
        // T�klama i�lemi ger�ekle�ti�inde bu i�lev �a�r�lacak.

        // G�ndermek istedi�iniz mesaj� olu�turun veya ayarlay�n.
        string message = "Merhaba, di�er oyuncular!";

        // Mesaj� di�er oyunculara g�ndermek i�in PhotonView'�n RPC i�lemini kullanabilirsiniz.
        PhotonView photonView = GetComponent<PhotonView>();
        if (photonView != null)
        {
            photonView.RPC("ReceiveMessage", RpcTarget.All, message);
        }
    }

    [PunRPC]
    private void ReceiveMessage(string message)
    {
        // Mesaj� almak ve i�lemek i�in bu i�levi kullanabilirsiniz.
        Debug.Log("Al�nan Mesaj: " + message);
    }
}
