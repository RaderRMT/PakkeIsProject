using Character;
using Fight;
using Fight.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayEventForHittable : MonoBehaviour, IHittable
{
    public Transform Transform { get; set; }

    [field: SerializeField] public UnityEvent OnHit { get; set; }
    [field: SerializeField] public WeaponType WeaponThatCanHit { get; set; }

    private void Awake()
    {
        Transform = this.transform;
    }

    public virtual void Hit(Projectile projectile, GameObject owner, int damage)
    {
        if (projectile.Data.Type != WeaponThatCanHit || CharacterManager.Instance.Abilities.CanDestroyIceberg == false)
        {
            Debug.Log($"{projectile.Data.Type} can't hit {gameObject.name}");
            return;
        }

        OnHit.Invoke();
    }
}
