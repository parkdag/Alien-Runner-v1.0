using UnityEngine;

public class SkyBoxRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.2f;
    
        void Update()
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        }
}
