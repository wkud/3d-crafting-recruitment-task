using System;
using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform ItemHoldAnchor;
    private StarterAssetsInputs _input;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _input.onPickUp += OnPickUp;
        _input.onDrop += OnDrop;
    }

    private void OnDestroy()
    {
        _input.onPickUp -= OnPickUp;
        _input.onDrop -= OnDrop;
    }

    private void OnPickUp()
    {
        throw new NotImplementedException();
    }

    private void OnDrop()
    {
        throw new NotImplementedException();
    }
}