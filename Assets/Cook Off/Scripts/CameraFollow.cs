using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CookOff
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private Transform leftHand, rightHand;
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private bool smooth;
        [SerializeField, Range(0, 1)] private float smoothSpeed = 0.125f;
        private void FixedUpdate()
        {
            Vector3 position = target.position;
            position.x = leftHand.position.x + (rightHand.position.x - leftHand.position.x) / 2;
            target.position = position;
            if (!smooth) transform.position = target.position + offsetPosition;
            else
            {
                Vector3 desiredPos = target.position + offsetPosition;
                Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
                transform.position = smoothedPos;
            }
            transform.LookAt(target);
        }
    }
}