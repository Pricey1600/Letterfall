using UnityEngine;

public class CameraResize : MonoBehaviour
{

    private void Awake()
    {
        Camera.main.aspect = 1.7777f;
    }
}
