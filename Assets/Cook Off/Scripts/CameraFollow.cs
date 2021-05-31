using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CookOff
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform midPoint;
        [SerializeField] private Transform leftHand, rightHand;
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private bool smooth;
        [SerializeField, Range(0, 1)] private float smoothSpeed = 0.125f;

        private void TransformUpdate()
        {
            Vector3 left = leftHand.position;
            Vector3 right = rightHand.position;
            float x = -(left.x - right.x) / 2+left.x;
            float y = -(left.y - right.y) / 2+left.y;
            float z = -(left.z - right.z) / 2 +left.z;
            midPoint.position = new Vector3(x, y, z);
            // Debug.Log($"left pos {left}, right pos {right}, new mid {new Vector3(x, y, z)}, actual mid{midPoint.localPosition}");
        }

        private void Update()
        {
            TransformUpdate();
            //if (!smooth) transform.position = midPoint.position + offsetPosition;
            //else
            //{
            //    Vector3 desiredPos = midPoint.position + offsetPosition;
            //    Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            //    transform.position = smoothedPos;
            //}
            transform.LookAt(midPoint);
        }
    }
}