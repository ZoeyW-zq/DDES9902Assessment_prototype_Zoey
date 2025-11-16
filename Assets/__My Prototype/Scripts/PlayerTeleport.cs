using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class PlayerTeleporter : MonoBehaviour
{
    [Header("References")]
    public TeleportationProvider teleportationProvider; 
    public Transform destination;                       

    
    public void Teleport()
    {
        if (teleportationProvider == null || destination == null)
        {
            Debug.LogWarning("ButtonTeleporter: teleportationProvider or destination not set");
            return;
        }

        var request = new TeleportRequest
        {
            destinationPosition = destination.position,
            destinationRotation = destination.rotation
        };

        teleportationProvider.QueueTeleportRequest(request);
    }
}
