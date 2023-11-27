using System.Linq;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public Transform KayakTransform;
    private AttackItem _heldAttackItem;

    public void SetAttackItem(AttackItem attackItem) {
        if (_heldAttackItem != null) {
            return;
        }
        
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
        attackItem.transform.LookAt(controller.gameObject.transform.position);

        attackItem.GetComponent<AttackItem>().Init(gameObject);
        
        _heldAttackItem = null;
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
