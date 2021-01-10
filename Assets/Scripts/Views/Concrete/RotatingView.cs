using UnityEngine;

namespace Views
{
    public class RotatingView : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingTransform;
        [SerializeField] private Vector3 _rotationSpeed;
        
        void Update()
        {
            var rotatingTransformLocalRotation = _rotatingTransform.eulerAngles;
            rotatingTransformLocalRotation += _rotationSpeed * Time.deltaTime;
            _rotatingTransform.eulerAngles = rotatingTransformLocalRotation;
        }
    }
}
