using System;
using UnityEngine;

[Serializable]
public abstract class AttackItem : MonoBehaviour {

    public Texture Sprite;
    public float Speed;

    private GameObject _thrower;

    private void Update() {
        transform.position += transform.forward * (Speed * Time.deltaTime);
    }

    public void Init(GameObject thrower) {
        _thrower = thrower;
    }

    protected abstract void Use(PlayerController playerController);

    private void OnTriggerEnter(Collider other) {
        PlayerController controller = other.gameObject.GetComponentInParent<PlayerController>();
        if (controller == null) {
            return;
        }
        
        if (controller.PlayerName == _thrower.name) {
            return;
        }

        AudioSource.PlayClipAtPoint(controller.HitSound, controller.KayakRigidbody.transform.position, controller.Volume);
        
        Use(controller);
        controller.PlayHitAnimation();
        
        Destroy(gameObject);
    }
}
