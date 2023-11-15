using Cinemachine;
using UnityEngine;

namespace Character.Camera.State
{
    public class CameraRespawnState : CameraStateBase
    {
        public override void EnterState(CameraManager camera)
        {
            CamManager.ShakeCameraWarning(0);
            CamManager.VirtualCameraFreeLook.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = CamManager.Data.CameraDistanceRespawn;
            CamManager.CameraAngleOverride = CamManager.Data.CameraAngleTopDownRespawn;
            ResetCameraBehindBoat();
            CharacterManager.Instance.InvincibilityTime = CharacterManager.Instance.Data.InvincibleTimeAfterUnbalance;
        }
        public override void UpdateState(CameraManager camera)
        {
            CamManager.SmoothResetRotateZ();
            Respawn();
            CamManager.ApplyRotationCameraWhenCharacterDeath();
        }
        public override void FixedUpdate(CameraManager camera)
        {

        }
        public override void LateUpdate(CameraManager camera)
        {

        }
        public override void SwitchState(CameraManager camera)
        {
            CharacterManager.Instance.RespawnLastCheckpoint = false;
            CharacterManager.Instance.OptionMenuManager.CanBeOpened = true;
        }


        private void ResetCameraBehindBoat()
        {
            //Start
            CamManager.MakeTargetFollowRotationWithKayak();

            //Middle
            Quaternion localRotation = CamManager.CinemachineCameraTarget.transform.localRotation;
            Vector3 cameraTargetLocalPosition = CamManager.CinemachineCameraTarget.transform.localPosition;

            CamManager.CinemachineCameraTarget.transform.localRotation = Quaternion.Slerp(localRotation, Quaternion.Euler(new Vector3(0, 0, localRotation.z)), 1f);
            cameraTargetLocalPosition.x = Mathf.Lerp(cameraTargetLocalPosition.x, 0, 1f);
            CamManager.CinemachineTargetEulerAnglesToRotation(cameraTargetLocalPosition);

            //End
            CamManager.ApplyRotationCamera();
        }


        private void Respawn()
        {
        }
    }
}
