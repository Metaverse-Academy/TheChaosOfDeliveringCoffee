using UnityEngine;

public class CameraRangeDetecetSys : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject Target;
    private bool IsTargetvisible;

    void Update()
    {

        Vector3 cameraRange = MainCamera.WorldToViewportPoint(Target.transform.position);
        bool IsTargetFrontOfCamera = cameraRange.z > 0;
        bool IsTargetInsideRange = cameraRange.x > 0 && cameraRange.x < 1 && cameraRange.y > 0 && cameraRange.y < 1;

        IsTargetvisible = IsTargetFrontOfCamera && IsTargetInsideRange;
        if (IsTargetvisible)
        {

            Debug.Log("is inside the camera");


        }


    }
}
