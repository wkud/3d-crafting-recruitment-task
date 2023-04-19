using System;
using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform ItemHoldAnchor;
    private StarterAssetsInputs _input;
    
    [Header("Picking Up Items")]
    [SerializeField]
    private Transform cameraRoot;
    [SerializeField]
    private LayerMask pickUpItemLayers;
    [SerializeField] 
    private float pickUpRange;
    
    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _input.onPickUp += OnItemPickedUp;
        _input.onDrop += OnDrop;
    }

    private void OnDestroy()
    {
        _input.onPickUp -= OnItemPickedUp;
        _input.onDrop -= OnDrop;
    }

    private void OnItemPickedUp()
    {
        var ray = new Ray(cameraRoot.position, cameraRoot.forward);
        if(Physics.Raycast(ray, out var hit, pickUpRange, pickUpItemLayers))
        {
            Debug.Log($"Item {hit.collider.gameObject.name} has been picked up");
        }
    }

    private void OnDrop()
    {
        throw new NotImplementedException();
    }

    private void OnDrawGizmos() // drawing gizmos for debugging purposes
    {
        Gizmos.color = Color.green;
        var ray = new Ray(cameraRoot.position, cameraRoot.forward);
        var rayEnd = ray.origin + ray.direction.normalized * pickUpRange;
        Gizmos.DrawLine(ray.origin, rayEnd);
        
        // Gizmos.DrawWireSphere(cameraRoot.position, 1f);
    }
}