using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using WaterAndFloating;

public class PlayerController : MonoBehaviour {

    private const string PADDLE_LEFT_ANIM = "PaddleLeft";
    private const string PADDLE_RIGHT_ANIM = "PaddleRight";
    
    public enum Direction {
        LEFT,
        RIGHT,
    }
    
    public MonoBehaviour MonoBehaviourRef;

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
    private bool _leftPaddleHeld;
    private bool _rightPaddleHeld;

    private float _targetAngle;

    private void Start() {
        Waves.PlayerTransform = transform;
        
        foreach (Floater floater in Floaters) {
            floater.Waves = Waves;
        }
    }

    private void Update() {
        ClampVelocity();
        UpdatePaddleCooldowns();
        HandlePaddle();
        ManageParticlePaddle();
        UpdateRotation();
    }

    private void UpdateRotation() {
        Quaternion targetRotation = Quaternion.AngleAxis(_targetAngle, Vector3.up);
        
        KayakRigidbody.gameObject.transform.rotation = Quaternion.Lerp(
                KayakRigidbody.gameObject.transform.rotation,
                targetRotation,
                PaddleRotationForce
        );
    }

    public void PaddleLeft(InputAction.CallbackContext context) {
        if (context.started) {
            _leftPaddleHeld = true;
        } else if (context.canceled) {
            _leftPaddleHeld = false;
        }
    }

    public void PaddleRight(InputAction.CallbackContext context) {
        if (context.started) {
            _rightPaddleHeld = true;
        } else if (context.canceled) {
            _rightPaddleHeld = false;
        }
    }

    private void HandlePaddle() {
        if (_leftPaddleHeld && _rightPaddleHeld) {
            HandlePaddleForward();
        } else if (_leftPaddleHeld) {
            Paddle(Direction.LEFT);
        } else if (_rightPaddleHeld) {
            Paddle(Direction.RIGHT);
        }
    }

    private void HandlePaddleForward() {
        float targetAngle = _targetAngle;
        
        if (_leftPaddleCooldown <= 0) {
            Paddle(Direction.LEFT);
        } else if (_rightPaddleCooldown <= 0) {
            Paddle(Direction.RIGHT);
        }

        _targetAngle = targetAngle;
    }

    private void Paddle(Direction direction) {
        if (direction == Direction.LEFT && _leftPaddleCooldown <= 0) {
            _leftPaddleCooldown = PaddleCooldown;
            _rightPaddleCooldown = PaddleCooldown / 2;
            _targetAngle += AngleAddedPerPaddle;
        } else if (direction == Direction.RIGHT && _rightPaddleCooldown <= 0) {
            _rightPaddleCooldown = PaddleCooldown;
            _leftPaddleCooldown = PaddleCooldown / 2;
            _targetAngle -= AngleAddedPerPaddle;
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
}
