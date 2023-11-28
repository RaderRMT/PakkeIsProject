using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WaterAndFloating;

public class PlayerController : MonoBehaviour {

    private const string PADDLE_LEFT_ANIM = "PaddleLeft";
    private const string PADDLE_RIGHT_ANIM = "PaddleRight";
    
    public enum Direction {
        LEFT,
        RIGHT,
    }
    
    public MonoBehaviour MonoBehaviourRef;
    public Camera PlayerCamera;
    public string PlayerName { get; set; }
    public RawImage PlayerIndexImage;
    public RawImage PlayerPositionRawImage;
    public List<SkinnedMeshRenderer> Meshes;

    [Header("Player")]
    public int Health;
    public float NoHealthStunDuration;

    [Header("Kayak")]
    public Rigidbody KayakRigidbody;
    public float TimeBetweenSamplePoints;
    public float MaximumVelocity;
    
    [Header("Water stuff")]
    public Waves Waves;
    public List<Floater> Floaters;

    [Header("Paddle stuff")]
    public float TimeToPlayParticlesAfterPaddle;
    public float PaddleCooldown;
    public float PaddleForce;
    public float AngleAddedPerPaddle;
    public float PaddleRotationForce;
    public int PaddleForceCurveSamplePoints;
    public AnimationCurve ForceCurve;
    public ParticleSystem LeftPaddleParticle;
    public ParticleSystem RightPaddleParticle;
    
    [Header("Animators")]
    public Animator PaddleAnimator;
    public Animator CharacterAnimator;

    // paddle cooldowns
    private float _leftPaddleCooldown;
    private float _rightPaddleCooldown;

    // particle cooldown
    private float _particleTimer;
    private Direction _particleSide;
    
    // held paddle buttons
    private bool _isPaddling;

    private float _targetOffsetAngle;

    // velocity slowdown stuff
    private float _previousMaximumVelocity;
    private float _velocityTimer;

    // keep track of the max health for the stun when no health
    private int _maxHealth;
    
    // rotation stuff
    private Direction _rotationDirection;
    private bool _isRotating;
    private float _rotationForce;

    private bool _canMove = false;

    private void Start() {
        _maxHealth = Health;
        
        foreach (Floater floater in Floaters) {
            floater.Waves = Waves;
        }
    }

    private void Update() {
        UpdateVelocityOverrideTimer();
        CheckHealth();
        
        ClampVelocity();
        UpdatePaddleCooldowns();
        HandlePaddle();
        HandleRotation();
        ManageParticlePaddle();
        UpdateRotation();
    }

    private void CheckHealth() {
        if (Health != 0) {
            return;
        }

        if (_velocityTimer > 0) {
            return;
        }

        if (MaximumVelocity != 0) {
            Slowdown(0, NoHealthStunDuration);
        } else {
            Health = _maxHealth;
        }
    }

    private void UpdateVelocityOverrideTimer() {
        if (_velocityTimer <= 0) {
            return;
        }

        _velocityTimer -= Time.deltaTime;
        if (_velocityTimer > 0) {
            return;
        }

        // restore max velocity if the timer expired
        MaximumVelocity = _previousMaximumVelocity;
    }

    public void Slowdown(float maximumVelocity, float duration) {
        float oldVelocity;

        if (_velocityTimer > 0) {
            if (maximumVelocity > MaximumVelocity) {
                return;
            }

            oldVelocity = _previousMaximumVelocity;
        } else {
            oldVelocity = MaximumVelocity;
        }

        MaximumVelocity = maximumVelocity;
        _previousMaximumVelocity = oldVelocity;
        _velocityTimer = duration;
    }

    private void UpdateRotation() {
        Quaternion targetRotation = Quaternion.AngleAxis(KayakRigidbody.gameObject.transform.rotation.y + _targetOffsetAngle, Vector3.up);
        
        KayakRigidbody.gameObject.transform.rotation = Quaternion.Lerp(
                KayakRigidbody.gameObject.transform.rotation,
                targetRotation,
                PaddleRotationForce
        );
    }

    public void Turn(Direction direction, bool isPressed, float force) {
        _rotationDirection = direction;
        _isRotating = isPressed;
        _rotationForce = force;
    }

    private void HandleRotation() {
        if (!_canMove) {
            return;
        }
        
        if (!_isRotating) {
            return;
        }

        if (_rotationDirection == Direction.LEFT) {
            _targetOffsetAngle -= _rotationForce * AngleAddedPerPaddle * Time.deltaTime;
        } else if (_rotationDirection == Direction.RIGHT) {
            _targetOffsetAngle += _rotationForce * AngleAddedPerPaddle * Time.deltaTime;
        }
    }

    public void PaddleForward(bool isPressed) {
        _isPaddling = isPressed;
    }

    private void HandlePaddle() {
        if (!_canMove) {
            return;
        }
        
        if (!_isPaddling) {
            return;
        }

        if (_leftPaddleCooldown <= 0) {
            Paddle(Direction.LEFT);
        } else if (_rightPaddleCooldown <= 0) {
            Paddle(Direction.RIGHT);
        }
    }

    private void Paddle(Direction direction) {
        if (direction == Direction.LEFT && _leftPaddleCooldown <= 0) {
            _leftPaddleCooldown = PaddleCooldown;
            _rightPaddleCooldown = PaddleCooldown / 2;
        } else if (direction == Direction.RIGHT && _rightPaddleCooldown <= 0) {
            _rightPaddleCooldown = PaddleCooldown;
            _leftPaddleCooldown = PaddleCooldown / 2;
        } else {
            return;
        }
        
        MonoBehaviourRef.StartCoroutine(PaddleForceCurve());

        string paddleAnimation;
        if (direction == Direction.RIGHT) {
            paddleAnimation = PADDLE_RIGHT_ANIM;
        } else {
            paddleAnimation = PADDLE_LEFT_ANIM;
        }
        
        PaddleAnimator.SetTrigger(paddleAnimation);
        CharacterAnimator.SetTrigger(paddleAnimation);
        
        PlayPaddleParticle(direction);
    }
    
    private void PlayPaddleParticle(Direction side) {
        _particleTimer = TimeToPlayParticlesAfterPaddle;
        _particleSide = side;
    }
    
    private void ClampVelocity() {
        Vector3 velocity = KayakRigidbody.velocity;

        float velocityX = velocity.x;
        velocityX = Mathf.Clamp(velocityX, -MaximumVelocity, MaximumVelocity);

        float velocityZ = velocity.z;
        velocityZ = Mathf.Clamp(velocityZ, -MaximumVelocity, MaximumVelocity);

        KayakRigidbody.velocity = new Vector3(velocityX, velocity.y, velocityZ);
    }

    private void ManageParticlePaddle() {
        if (_particleTimer < 0) {
            return;
        }

        _particleTimer -= Time.deltaTime;
        if (_particleTimer > 0) {
            return;
        }

        _particleTimer = -1;

        ParticleSystem particles;
        if (_particleSide == Direction.RIGHT) {
            particles = RightPaddleParticle;
        } else {
            particles = LeftPaddleParticle;
        }

        particles.Play();
    }

    private void UpdatePaddleCooldowns() {
        _leftPaddleCooldown -= Time.deltaTime;
        _rightPaddleCooldown -= Time.deltaTime;
    }
    
    private IEnumerator PaddleForceCurve() {
        for (int i = 0; i <= PaddleForceCurveSamplePoints; i++) {
            float x = 1f / PaddleForceCurveSamplePoints * i;
            float force = ForceCurve.Evaluate(x) * PaddleForce;
            
            Vector3 forceToApply = KayakRigidbody.gameObject.transform.forward * force;
            KayakRigidbody.AddForce(forceToApply);

            yield return new WaitForSeconds(TimeBetweenSamplePoints);
        }
    }

    public void InitPlayer(string playerName, Texture playerIndexTexture, Material playerMaterial) {
        PlayerName = playerName;
        PlayerIndexImage.texture = playerIndexTexture;

        foreach (SkinnedMeshRenderer mesh in Meshes) {
            mesh.material = playerMaterial;
        }
    }

    public void DisableMovements() {
        _canMove = false;
    }

    public void EnableMovements() {
        _canMove = true;
    }
}
