﻿using System;
using System.Collections.Generic;
using Tools.HideIf;
using UnityEngine;

namespace Fight.Data
{
    [System.Flags]
    public enum WeaponType
    {
        Harpoon = 1 << 0,
        Net = 1 << 1
    }
    
    [Serializable]
    public struct ShootArcMovementParameters
    {
        public float BaseApexHeightForDistance1;
        public float ArcMovementSpeed;
        [Range(0,1)] public float PercentOfFlyTimeToReachApex;
        public AnimationCurve BaseToApexCurve;
        public AnimationCurve ApexToTargetCurve;
    }
    
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        public WeaponType Type;
        public float LaunchForce;
        public int Damage = 1;
        public float Cooldown;
        public float Lifetime = 4f;
        public float LaunchTime = 0.5f;
        public ShootArcMovementParameters ArcMovementParameters;
        [HideInInspector] public List<GameObject> ForbiddenColliders;

        [Header("Camera values"), SerializeField, Range(0,3)] public float CameraBaseShakeAmount = 1f;
        [SerializeField, Range(0,1)] public float CameraStabilizedShakeAmount = 0f;

        public WeaponData()
        {
            ForbiddenColliders = new List<GameObject>();
        }
    }
}