using UnityEngine;
using UnityEngine.UI;

public class DollyZoomEffectWithUI : MonoBehaviour
{
    public Transform target;       // The subject to keep in focus
    public Camera camera;          // The camera performing the dolly zoom

    public Slider movementSlider;  // Slider to control camera movement
    public Slider fovSlider;       // Slider to control FOV

    private float initialDistance; // Initial distance from the target
    private float initialFOV;      // Initial field of view

    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main; // Use the main camera if not assigned
        }

        // Initialize the initial values
        initialDistance = Vector3.Distance(transform.position, target.position);
        initialFOV = camera.fieldOfView;

        // Initialize slider values
        movementSlider.minValue = -10f;
        movementSlider.maxValue = 10f;
        movementSlider.value = 0f;

        fovSlider.minValue = 10f;
        fovSlider.maxValue = 100f;
        fovSlider.value = initialFOV;
    }

    void Update()
    {
        // Adjust camera position based on the movement slider
        float move = movementSlider.value;
        transform.position = target.position - transform.forward * (initialDistance + move);

        // Adjust FOV based on the FOV slider
        camera.fieldOfView = fovSlider.value;

        // Keep the camera looking at the target
        transform.LookAt(target);
    }
}
