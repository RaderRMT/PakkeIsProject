using System;
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
        HeldItemImage.color = new Color(1, 1, 1, 1);
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
        HeldItemImage.color = new Color(1, 1, 1, 0);
    }

    private PlayerController FindClosestPlayer() {
        return FindObjectsByType<PlayerController>(FindObjectsSortMode.None)
                .Where(p => p.transform.position != transform.position)
                .OrderBy(p => Vector3.Distance(p.transform.position, transform.position))
                .FirstOrDefault();
    }

    public bool HasItem() {
        return _heldAttackItem != null;
    }
}
