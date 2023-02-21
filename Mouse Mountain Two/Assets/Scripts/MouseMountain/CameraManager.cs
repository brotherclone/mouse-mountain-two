using System;
using System.Collections;
using System.Collections.Generic;
using MouseMountain;
using UnityEngine;

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
        Unknown
    }

    public CameraMode currentCameraMode;

    private void Start()
    {
        _followerFocalPoint = new GameObject();
        currentCameraMode = CameraMode.Unknown;
    }

    private void LateUpdate()
    {
        if (currentCameraMode == CameraMode.FollowingSelected)
        {
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
        }
    }
}