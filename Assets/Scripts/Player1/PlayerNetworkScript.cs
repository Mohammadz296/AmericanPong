using UnityEngine;
using Unity.Netcode;
public class PlayerNetworkScript : NetworkBehaviour
{

    PlayeController player;
    public override void OnNetworkSpawn()
    {
        player = GetComponent<PlayeController>();
        
    }
    void Update()
    {
        if (!IsOwner)
            player.NotLocal();
        else
            player.IsLocal();
    } 
}
