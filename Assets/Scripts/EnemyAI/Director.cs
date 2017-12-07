using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Director : MonoBehaviour
    {
        public float movementSpeed = 5;
        public float jumpHeight = 20f;
        public bool isMovingLeft = true;
        public bool isJumping = false;
        public bool canJump = false;
        public bool allowedJump;
        public float rayDist = 1f;
        public float altRayDist = 1.25f;
        private Ray leftRay;
        private Ray rightRay;
        private Ray frontRay;
        private Ray backRay;

        private Ray upperFrontRay;
        private Ray upperBackRay;

        private BoxCollider box;
        private SpriteRenderer spriteRend;
        int layerMask = 1 << 9;
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

            bool isFrontHitting = Physics.Raycast(frontRay, rayDist, layerMask);
            bool isBackHitting = Physics.Raycast(backRay, rayDist, layerMask);

            bool isUpperFrontHitting = Physics.Raycast(upperFrontRay, (rayDist + 0.5f), layerMask);
            bool isUpperBackHitting = Physics.Raycast(upperBackRay, (rayDist + 0.5f), layerMask);

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
            if ((isFrontHitting || isBackHitting))
            {

                isMovingLeft = !isMovingLeft;
                spriteRend.flipX = !spriteRend.flipX;
                Debug.Log("I am hitting shitt" + gameObject.name);
            }
            if (isUpperBackHitting || isUpperFrontHitting)
            {
                canJump = false;
                isJumping = false;
            }
            else if (!(isUpperBackHitting || isUpperFrontHitting))
            {
                canJump = true;
            }

            Vector3 dir = Vector3.zero;
            if (isMovingLeft)
                dir += Vector3.left;
            else
                dir += Vector3.right;

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

            Gizmos.DrawLine(upperFrontRay.origin, upperFrontRay.origin + upperFrontRay.direction * (rayDist + 0.25f));
            Gizmos.DrawLine(upperBackRay.origin, upperBackRay.origin + upperBackRay.direction * (rayDist + 0.25f));
        }
        private void RecalculateRays()
        {
            Vector3 halfSize = box.bounds.size * 0.5f;
            Vector3 leftPos = transform.position - Vector3.left * halfSize.x + Vector3.down * (halfSize.y - 0.5f);
            Vector3 rightPos = transform.position - Vector3.right * halfSize.x + Vector3.down * (halfSize.y - 0.5f);
            Vector3 frontPos = transform.position - Vector3.left * halfSize.x + Vector3.left * (halfSize.y - 0.2f);
            Vector3 backPos = transform.position - Vector3.right * halfSize.x + Vector3.right * (halfSize.y - 0.2f);

            Vector3 upperFrontPos = (transform.position + new Vector3(0, 0.3f, 0)) - Vector3.left * halfSize.x + Vector3.left * (halfSize.y - 0.25f);
            Vector3 upperBackPos = (transform.position + new Vector3(0, 0.3f, 0)) - Vector3.right * halfSize.x + Vector3.right * (halfSize.y - 0.25f);

            leftRay = new Ray(leftPos, Vector3.down);
            rightRay = new Ray(rightPos, Vector3.down);
            frontRay = new Ray(frontPos, Vector3.left);
            backRay = new Ray(backPos, Vector3.right);

            upperFrontRay = new Ray(upperFrontPos, Vector3.left);
            upperBackRay = new Ray(upperBackPos, Vector3.right);
        }


    }
}

