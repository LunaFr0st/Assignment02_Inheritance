using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Director : MonoBehaviour
    {
        public int weighting;

        public float movementSpeed = 10f;
        public float jumpHeight = 20f;
        public bool isMovingLeft = true;
        public bool isJumping = false;
        public float rayDist = 1f;
        private Ray leftRay;
        private Ray rightRay;
        private Ray frontRay;
        private Ray backRay;
        private BoxCollider box;
        private SpriteRenderer spriteRend;
        [Range(0, 1)]
        [SerializeField]
        private float hue, saturation, value;

        public virtual void Update()
        {
            Move();
        }
        public void Move()
        {
            RecalculateRays();
            Vector3 pos = transform.position;
            bool isLeftHitting = Physics.Raycast(leftRay, rayDist);
            bool isRightHitting = Physics.Raycast(rightRay, rayDist);

            bool isFrontHitting = Physics.Raycast(frontRay, rayDist);
            bool isBackHitting = Physics.Raycast(backRay, rayDist);

            if (isLeftHitting && !isRightHitting)
            {
                isMovingLeft = false;
                spriteRend.flipX = true;
            }
            else if (isRightHitting && !isLeftHitting)
            {
                isMovingLeft = true;
                spriteRend.flipX = false;
            }
            if (isFrontHitting || isBackHitting)
            {
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
            Vector3 dir = Vector3.zero;
            if (isMovingLeft)
                dir += Vector3.left;
            else
                dir += Vector3.right;

            if (isJumping)
            {
                dir += Vector3.up * jumpHeight;
            }
            pos += dir * movementSpeed * Time.deltaTime;
            

            transform.position = pos;
            
        }
        public virtual void Damage(int combo = 0)
        {

        }

        private void Awake()
        {
            box = GetComponent<BoxCollider>();
            spriteRend = GetComponent<SpriteRenderer>();
        }
        private void OnDrawGizmos()
        {
            box = GetComponent<BoxCollider>();
            RecalculateRays();
            Gizmos.color = Color.HSVToRGB(hue, saturation, value);
            Gizmos.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayDist);
            Gizmos.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayDist);
            Gizmos.DrawLine(frontRay.origin, frontRay.origin + frontRay.direction * rayDist);
            Gizmos.DrawLine(backRay.origin, backRay.origin + backRay.direction * rayDist);
        }
        private void RecalculateRays()
        {
            Vector3 halfSize = box.bounds.size * 0.5f;
            Vector3 leftPos = transform.position - Vector3.left * halfSize.x + Vector3.down * (halfSize.y - 0.5f);
            Vector3 rightPos = transform.position - Vector3.right * halfSize.x + Vector3.down * (halfSize.y - 0.5f);
            Vector3 frontPos = transform.position - Vector3.left * halfSize.x + Vector3.left * (halfSize.y - 0.2f);
            Vector3 backPos = transform.position - Vector3.right * halfSize.x + Vector3.right * (halfSize.y - 0.2f);
            leftRay = new Ray(leftPos, Vector3.down);
            rightRay = new Ray(rightPos, Vector3.down);
            frontRay = new Ray(frontPos, Vector3.left);
            backRay = new Ray(backPos, Vector3.right);
        }


    }
}

