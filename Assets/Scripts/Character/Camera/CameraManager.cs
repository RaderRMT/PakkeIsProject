using System.Collections;
using Character.Camera.State;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using WaterAndFloating;
using CameraData = Character.Data.CameraData;

namespace Character.Camera
{
    public class CameraManager : MonoBehaviour
    {
        [Header("Start Menu Game")] public float TimerBeforeCanMovingAtStart = 3f;
        [field: SerializeField] public CameraStateBase CurrentStateBase { get; private set; }
        [field: SerializeField, Header("Properties"), Space(5)] public GameObject CinemachineCameraTarget { get; private set; }
        [field: SerializeField] public GameObject CinemachineCameraTargetFollow { get; private set; }
        [field: SerializeField] public GameObject CinemachineCameraFollowCombat { get; private set; }
        [field: SerializeField] public Animator CameraAnimator { get; private set; }
        [field: SerializeField] public Rigidbody RigidbodyKayak { get; private set; }
        [field: SerializeField, Header("Virtual Camera")] public CinemachineBrain Brain { get; private set; }
        [field: SerializeField] public CinemachineVirtualCamera VirtualCameraFreeLook { get; private set; }
        [field: SerializeField] public CinemachineVirtualCamera VirtualCameraCombat { get; private set; }
        [field: SerializeField] public CinemachineVirtualCamera VirtualCameraLookAt { get; private set; }
        [field: SerializeField] public Waves Waves { get; private set; }
        [field: SerializeField] public NoiseSettings MyNoiseProfileWhenNavigating { get; private set; }
        [field: SerializeField] public NoiseSettings MyNoiseProfileWarning { get; private set; }


        [Space(5), Header("Camera Data")] public CameraData Data;

        public CharacterManager CharacterManager { get; private set; }
        public InputManagement Input { get; private set; }
        public Cinemachine3rdPersonFollow CinemachineCombat3RdPersonFollow { get; private set; }

        [ReadOnly] public bool CanRotateCamera = true;

        [Header("Evenet")] public UnityEvent OnPlayerStart;
        [SerializeField] private float _timeToLaunchEvent;

        //camera
        [HideInInspector] public float CameraAngleOverride = 0.0f;
        [HideInInspector] public Vector3 CameraTargetBasePos;
        [HideInInspector] public float RotationZ = 0;
        [HideInInspector] public bool CanMoveCameraManually;
        //cinemachine yaw&pitch
        [HideInInspector] public float CinemachineTargetYaw;
        [HideInInspector] public float CinemachineTargetPitch;
        //inputs
        [HideInInspector] public float LastInputX;
        [HideInInspector] public float LastInputY;
        //other
        [HideInInspector] public bool StartDeath = false;
        [HideInInspector] public bool WaterFlow = false;
        //combat values
        [HideInInspector] public Vector3 CombatBaseShoulderOffset;


        private void Awake()
        {
            CameraStartGameState startGameState = new CameraStartGameState();
            CurrentStateBase = startGameState;

            CinemachineCombat3RdPersonFollow = VirtualCameraCombat.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            CombatBaseShoulderOffset = CinemachineCombat3RdPersonFollow.ShoulderOffset;
        }

        private void Start()
        {
            CharacterManager = CharacterManager.Instance;
            Input = CharacterManager.InputManagementProperty;



            CurrentStateBase.Initialize();
            CurrentStateBase.EnterState(this);
        }

        private void Update()
        {
            float velocityXZ = Mathf.Abs(RigidbodyKayak.velocity.x) + Mathf.Abs(RigidbodyKayak.velocity.z);

            CurrentStateBase.UpdateState(this);
            CurrentStateBase.ResetShoulderOffset();

            if (CharacterManager.Instance.SprintInProgress == false
                   && velocityXZ < CharacterManager.Instance.KayakControllerProperty.Data.KayakValues.MaximumFrontVelocity + 1)
                FieldOfView(VirtualCameraFreeLook, velocityXZ);
        }
        private void FixedUpdate()
        {
            CurrentStateBase.FixedUpdate(this);
        }

        private void LateUpdate()
        {
            CurrentStateBase.LateUpdate(this);
        }

        public void SwitchState(CameraStateBase stateBaseCharacter)
        {
            CurrentStateBase = stateBaseCharacter;
            stateBaseCharacter.EnterState(this);
        }

        private void FieldOfView(CinemachineVirtualCamera virtualCamera, float velocityXZ)
        {
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView,
                Data.BaseFOV + (velocityXZ * Data.MultiplierFovCamera),
                Data.LerpFOV);
        }

        public void CameraDistance(CinemachineVirtualCamera virtualCamera)
        {
            float velocityXZ = Mathf.Abs(RigidbodyKayak.velocity.x) + Mathf.Abs(RigidbodyKayak.velocity.z);

            var Dist = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance;
            virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = Mathf.Lerp(Dist, Data.BaseDistance - (velocityXZ * Data.MultiplierCameraGettingCloser), Data.LerpCameraGettingCloser);
        }
        public void CameraDistanceFreeLook(CinemachineVirtualCamera virtualCamera)
        {
            var Dist = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance;

            Dist = Mathf.Lerp(Dist,
                Data.BaseDistance - ((((Data.BottomClamp + Data.TopClamp) / 2) - CinemachineTargetPitch) * Data.MultiplierFreeCamDistance),
                Data.LerpCameraGettingCloser);

            virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = Mathf.Clamp(Dist,
                Data.BaseDistance - Data.BaseDistance + 3,
                Data.BaseDistance + Data.BaseDistance - 3);
        }

        public void MoveTargetInFreeLook()
        {
            var targetPos = CinemachineCameraTarget.transform.position;

            if (CinemachineTargetPitch < ((Data.BottomClamp + Data.TopClamp) / 3))
            {
                targetPos.y = Mathf.Lerp(targetPos.y, (Data.BasePosition.y - Data.NavigationPositionYMin) - (((Data.BottomClamp + Data.TopClamp) / 2) - CinemachineTargetPitch) / ((Data.BottomClamp + Data.TopClamp) / 2), Time.deltaTime * 4);
                targetPos.y = Mathf.Clamp(targetPos.y, Data.NavigationPositionYMin, Data.BasePosition.y);
            }
            CinemachineCameraTarget.transform.position = targetPos;
        }
        public void ResetTargetPos()
        {
            var targetPos = CinemachineCameraTarget.transform.position;

            targetPos.y = Mathf.Lerp(targetPos.y, Data.BasePosition.y, Time.deltaTime * 2);

            CinemachineCameraTarget.transform.position = targetPos;
        }

        #region Methods
        public void ApplyRotationCamera()
        {
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(
                CinemachineTargetPitch, //pitch
                CinemachineTargetYaw, //yaw
                RotationZ); //z rotation
        }
        public void ApplyRotationCameraInCombat()
        {
            CinemachineCameraFollowCombat.transform.rotation = Quaternion.Euler(
                CinemachineTargetPitch, //pitch
                CinemachineTargetYaw, //yaw
                RotationZ); //z rotation
        }
        public void ApplyRotationCameraWhenCharacterDeath()
        {
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(
                CinemachineTargetPitch + CameraAngleOverride, //pitch
                CinemachineTargetYaw, //yaw
                RotationZ); //z rotation
        }

        public void SmoothResetRotateZ()
        {
            RotationZ = Mathf.Lerp(RotationZ, 0,  Time.deltaTime * 0.5f);
        }

        public void ResetNavigationValue()
        {
            VirtualCameraFreeLook.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = Data.BaseDistance;
            StartDeath = false;
        }
        public void SmoothResetDistanceValue()
        {
            Cinemachine3rdPersonFollow camFollow = VirtualCameraFreeLook.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            camFollow.CameraDistance = Mathf.Lerp(camFollow.CameraDistance, Data.BaseDistance, Time.deltaTime * 2);
        }


        public void LastInputValue()
        {
            //last input value
            LastInputX = CurrentStateBase.ClampAngle(LastInputX, -5.0f, 5.0f);
            LastInputY = CurrentStateBase.ClampAngle(LastInputY, -1.0f, 1.0f);
            LastInputX = Mathf.Lerp(LastInputX, 0, Data.LerpTimeLastInputX);
            LastInputY = Mathf.Lerp(LastInputY, 0, Data.LerpTimeLastInputY);

            //apply value to camera
            CinemachineTargetYaw += LastInputX;
            CinemachineTargetPitch += LastInputY;

        }

        public void MakeTargetFollowRotationWithKayak()
        {
            Vector3 rotation = CinemachineCameraTargetFollow.transform.rotation.eulerAngles;
            Vector3 kayakRotation = RigidbodyKayak.gameObject.transform.eulerAngles;
            CinemachineCameraTargetFollow.transform.rotation = Quaternion.Euler(new Vector3(rotation.x, kayakRotation.y, rotation.z));
        }

        public void MakeSmoothCameraBehindBoat()
        {
            Quaternion localRotation = CinemachineCameraTarget.transform.localRotation;
            Vector3 cameraTargetLocalPosition = CinemachineCameraTarget.transform.localPosition;

            CinemachineCameraTarget.transform.localRotation = Quaternion.Slerp(localRotation, Quaternion.Euler(new Vector3(Data.BaseRotation.x, Data.BaseRotation.y, localRotation.z)), Data.LerpRotationNotMoving);
            cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x, 0, Data.LerpPositionNotMoving);
            CinemachineTargetEulerAnglesToRotation(cameraTargetLocalPosition);
        }

        public void CinemachineTargetEulerAnglesToRotation(Vector3 targetLocalPosition)
        {
            CinemachineCameraTarget.transform.localPosition = targetLocalPosition;
            CinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;

            if (CinemachineCameraTarget.transform.rotation.eulerAngles.x > 180)
            {
                CinemachineTargetPitch = CinemachineCameraTarget.transform.rotation.eulerAngles.x - 360;
            }
            else
            {
                CinemachineTargetPitch = CinemachineCameraTarget.transform.rotation.eulerAngles.x;
            }
        }

        public void ShakeCameraWarning(float intensity)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = VirtualCameraFreeLook.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_NoiseProfile = MyNoiseProfileWarning;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        }
        public void ShakeCameraNavigating(float intensity)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = VirtualCameraFreeLook.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (cinemachineBasicMultiChannelPerlin.m_NoiseProfile != MyNoiseProfileWhenNavigating)
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
                cinemachineBasicMultiChannelPerlin.m_NoiseProfile = MyNoiseProfileWhenNavigating;
            }
            intensity = Mathf.Clamp(intensity, 0.5f, 1f);
            if (cinemachineBasicMultiChannelPerlin.m_AmplitudeGain < intensity)
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain += Time.deltaTime;
            }
            else
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            }
        }

        public void ResetCameraLocalPos()
        {
            Vector3 localPos = CinemachineCameraTarget.transform.localPosition;
            localPos.x = CameraTargetBasePos.x;
            localPos.y = CameraTargetBasePos.y;
            localPos.z = CameraTargetBasePos.z;
            CinemachineCameraTarget.transform.localPosition = localPos;
        }

        public void ResetCameraBehindBoat()
        {
            Quaternion localRotation = CinemachineCameraTarget.transform.localRotation;
            Vector3 cameraTargetLocalPosition = CinemachineCameraTarget.transform.localPosition;

            CinemachineCameraTarget.transform.localRotation = Quaternion.Slerp(localRotation, Quaternion.Euler(new Vector3(Data.BaseRotation.x, 0, localRotation.z)), 1f);
            cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x, 0, Data.LerpPositionNotMoving);
            CinemachineTargetEulerAnglesToRotation(cameraTargetLocalPosition);
        }
        #endregion
        public void InitializeCams(Transform transform)
        {
            //Transform kayakTransform = CharacterManager.KayakControllerProperty.transform;
            Transform stateDrivenCam = CameraAnimator.gameObject.transform;
            Cinemachine3rdPersonFollow cinemachine3rdPerson = VirtualCameraFreeLook.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

            stateDrivenCam.position = transform.position;
            stateDrivenCam.eulerAngles = transform.eulerAngles;

            CinemachineCameraFollowCombat.transform.localPosition = Data.CombatPosition;
            CinemachineCameraTarget.transform.localPosition = Data.BasePosition;

            Vector3 targetAngles = CinemachineCameraTarget.transform.localEulerAngles;
            targetAngles.x = Data.BaseRotation.x;
            targetAngles.y = Data.BaseRotation.y + transform.eulerAngles.y;
            targetAngles.z = Data.BaseRotation.z;
            CinemachineCameraTarget.transform.localEulerAngles = targetAngles;

            cinemachine3rdPerson.CameraDistance = Data.BaseDistance;
            cinemachine3rdPerson.ShoulderOffset = Vector3.zero;

            CinemachineTargetPitch = Data.BaseRotation.x;
            CinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
            CameraTargetBasePos = CinemachineCameraTarget.transform.localPosition;
        }

        public IEnumerator LaunchEventStart()
        {
            yield return new WaitForSeconds(_timeToLaunchEvent);
            OnPlayerStart.Invoke();
        }
    }
}
