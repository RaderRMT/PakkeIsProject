using Cinemachine;
using UnityEngine;

namespace Character.Camera.State
{
    public abstract class CameraStateBase
    {
        public enum CameraMode
        {
            Navigation = 0,
            Combat = 1,
        }

        protected bool CanResetShoulderOffset = true;
        protected float FreeAimMultiplier = 1f;

        protected CameraManager CamManager { get; private set; }

        protected CameraStateBase()
        {
            Initialize();
        }
        
        public void Initialize()
        {
            if (CharacterManager.Instance != null)
            {
                CamManager = CharacterManager.Instance.CameraManagerProperty;
            }
        }

        public abstract void EnterState(CameraManager camera);

        public abstract void UpdateState(CameraManager camera);

        public abstract void FixedUpdate(CameraManager camera);

        public abstract void SwitchState(CameraManager camera);

        protected void ClampRotationCameraValue(float min, float max)
        {
            CamManager.CinemachineTargetYaw = ClampAngle(CamManager.CinemachineTargetYaw, float.MinValue, float.MaxValue);
            CamManager.CinemachineTargetPitch = ClampAngle(CamManager.CinemachineTargetPitch, min, max);
        }
        public float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        public void ManageFreeCameraMove(ref float timerCameraReturnBehindBoat, CameraMode cameraMode)
        {
            //rotate freely with inputs
            if (CamManager.CanMoveCameraManually)
            {
                Vector2 aim = Vector2.zero;
                switch (cameraMode)
                {
                    case CameraMode.Navigation:
                        aim = CamManager.Input.Inputs.RotateCamera;
                        CamManager.CinemachineTargetPitch += CamManager.Data.JoystickFreeRotationY.Evaluate(aim.y) * FreeAimMultiplier;
                        break;

                    case CameraMode.Combat:
                        aim = CamManager.Input.Inputs.MovingAim; 
                        aim = new Vector2(aim.x, aim.y * -1);
                        CamManager.CinemachineTargetPitch += CamManager.Data.JoystickFreeRotationY.Evaluate(aim.y) * FreeAimMultiplier;
                        break;
                }

                //Controller
                CamManager.CinemachineTargetYaw += CamManager.Data.JoystickFreeRotationX.Evaluate(aim.x) * FreeAimMultiplier;
                //CameraManagerRef.CinemachineTargetPitch = CameraManagerRef.JoystickFreeRotationY.Evaluate(aim.y); (jsp pk ici �a fait de la merde)

                #region clavier souris
                //KBM
                //CameraManagerRef.CinemachineTargetYaw += CameraManagerRef.Input.Inputs.RotateCamera.x;
                //CameraManagerRef.CinemachineTargetPitch += CameraManagerRef.Input.Inputs.RotateCamera.y;
                #endregion

                //last inputs
                CamManager.LastInputX = aim.x != 0 ? aim.x : CamManager.LastInputX;
                CamManager.LastInputY = aim.y != 0 ? aim.y : CamManager.LastInputY;

                timerCameraReturnBehindBoat = 0;
            }
        }

        private float _uselessFloatForRef;
        public void ManageFreeCameraMove(CameraMode cameraMode)
        {
            ManageFreeCameraMove(ref _uselessFloatForRef, cameraMode);
        }

        public void SetFOV(CinemachineVirtualCamera virtualCamera ,float value)
        {
            virtualCamera.m_Lens.FieldOfView = value;
        }

        public void ResetShoulderOffset()
        {
            if (CanResetShoulderOffset == false)
            {
                return;
            }

            Vector3 currentOffset = Vector3.Lerp(CamManager.CinemachineCombat3RdPersonFollow.ShoulderOffset, CamManager.CombatBaseShoulderOffset, 0.01f);
            CamManager.CinemachineCombat3RdPersonFollow.ShoulderOffset = currentOffset;
        }
    }
}


