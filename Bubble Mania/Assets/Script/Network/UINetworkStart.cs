using Unity.Netcode;
using Unity.Services.Relay;
using UnityEngine;
using UnityEngine.UI;

public class UINetworkStart : MonoBehaviour
{

    [SerializeField] private Button HostBtn;
    [SerializeField] private Button ClientBtn;
    void Start()
    {
        HostBtn.onClick.AddListener(HostStart);
        ClientBtn.onClick.AddListener(ClientJoin);
    }

    private void HostStart()
    {
        try
        {
            RelayService.Instance.CreateAllocationAsync(1);
            NetworkManager.Singleton.StartHost();
        }
        catch(RelayServiceException e)
        {
            Debug.Log(e.Message);
        }
       
    }

    private void ClientJoin()
    {
        NetworkManager.Singleton.StartClient();
    }
}
