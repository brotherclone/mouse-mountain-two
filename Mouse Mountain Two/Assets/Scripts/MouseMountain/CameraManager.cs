using MouseMountain;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    public Camera currentCamera;
    private GameObject _followerFocalPoint;
    public float maxTrackingDistance = 10;
    public float currentTrackingDistance = 5;
    public float trackingSpeed = 20;
    public float trackingUpdateSpeed = 10;
    public float hideDistance = 1.5f;
    private string _moveAxis = "Mouse ScrollWheel";
    public enum CameraMode
    {
        FollowingSelected,
        PlayerControl,
        Unknown,
        ResetToBoardCenter,
        ResetToPreviousObjectOnBoardCenter
    }
    
    public CameraMode currentCameraMode;
    private Transform camInnerTransform;

    public void Start()
    {
        _followerFocalPoint = new GameObject();
        currentCameraMode = CameraMode.Unknown;
    }
    
    private void LateUpdate()
    {
        switch (currentCameraMode)
        {
            case CameraMode.FollowingSelected:
                var trackedTransform = GameManager.Instance.selectedObject.transform;
                var trackedPosition = trackedTransform.position;
                var fwd = trackedTransform.forward;
                _followerFocalPoint.transform.position = trackedPosition + fwd * (maxTrackingDistance * 0.25f);
                currentTrackingDistance += Input.GetAxisRaw(_moveAxis) * trackingSpeed * Time.deltaTime;
                currentTrackingDistance = Mathf.Clamp(currentTrackingDistance, 0, maxTrackingDistance);
                var cameraTransform = currentCamera.transform;
                cameraTransform.position = Vector3.MoveTowards(cameraTransform.position,
                    trackedPosition + Vector3.up * currentTrackingDistance -
                    fwd * (currentTrackingDistance + maxTrackingDistance * 0.5f), trackingUpdateSpeed * Time.deltaTime);
                cameraTransform.LookAt(_followerFocalPoint.transform);
                //ToDo: add hide
            break;
            case CameraMode.PlayerControl:
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");
                var camTransform = currentCamera.transform;
                camInnerTransform = camTransform.transform;
                var position = camInnerTransform.position;
                position+= camTransform.right * (horizontal * trackingSpeed * Time.deltaTime);
                position+= camTransform.forward * (vertical * trackingSpeed * Time.deltaTime);
                camInnerTransform.position = position;
                break;
            case CameraMode.ResetToPreviousObjectOnBoardCenter:
                // Reset to the tracked object but like... higher. First esc
                break;
            case CameraMode.ResetToBoardCenter:
                // ToDo: Placeholder
                _followerFocalPoint.transform.position = GameManager.Instance.hexGrid.transform.position;
                currentCamera.transform.LookAt(_followerFocalPoint.transform);
                break;
            default:
                // Reset to a default?
                break;
        }
    }
}