using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour {

    public Transform KayakTransform;
    private AttackItem _heldAttackItem;

    public RawImage HeldItemImage;

    private void Start() {
        HeldItemImage.texture = null;
    }

    public void SetAttackItem(AttackItem attackItem) {
        if (_heldAttackItem != null) {
            return;
        }

        HeldItemImage.texture = attackItem.Sprite;
        HeldItemImage.color = Color.white;
        _heldAttackItem = attackItem;
    }
    
    public void UseHeldItem() {
        if (_heldAttackItem == null) {
            return;
        }

        PlayerController controller = FindClosestPlayer();
        if (controller == null) {
            return;
        }

        GameObject attackItem = Instantiate(_heldAttackItem.gameObject);
        attackItem.transform.position = KayakTransform.position;
        attackItem.transform.LookAt(controller.KayakRigidbody.transform.position);

        attackItem.GetComponent<AttackItem>().Init(gameObject);
        
        _heldAttackItem = null;
        HeldItemImage.texture = null;
        HeldItemImage.color = Color.clear;
    }

    private PlayerController FindClosestPlayer() {
        PlayerController[] playerControllers = FindObjectsByType<PlayerController>(FindObjectsSortMode.None)
            .Where(p => p.KayakRigidbody.transform.position != KayakTransform.position)
            .OrderBy(p => Vector3.Distance(p.KayakRigidbody.transform.position, KayakTransform.position))
            .ToArray();

        PlayerController target = playerControllers.FirstOrDefault(p => p.KayakRigidbody.transform.position.z > KayakTransform.position.z);
        if (target != null) {
            return target;
        }

        if (playerControllers.Length != 0) {
            return playerControllers[0];
        }

        return null;
    }

    public bool HasItem() {
        return _heldAttackItem != null;
    }
}
