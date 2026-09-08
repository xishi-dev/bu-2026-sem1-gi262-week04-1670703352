using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Solution
{
    public class ZombieParade : Character
    {
        // ใช้ LinkedList ในการจัดการส่วนของงูเพื่อประสิทธิภาพในการเพิ่ม/ลบ
        private LinkedList<GameObject> Parade = new LinkedList<GameObject>();

        public GameObject bodyPrefab; // Prefab ของส่วนลำตัวงู
        public float moveInterval = 0.5f; // ช่วงเวลาในการเคลื่อนที่ (0.5 วินาที)

        private Vector3 moveDirection;

        private InputAction growAction;

        private void Start()
        {
            growAction = InputSystem.actions.FindAction("Grow");
            moveDirection = Vector3.up;
            isAlive = true;
            // เริ่ม Coroutine สำหรับการเคลื่อนที่

            Parade.AddFirst(gameObject);

            StartCoroutine(MoveParade());

        }

        private void Update()
        {
            if (growAction != null && growAction.triggered)
            {
                Grow();
            }
        }

        private Vector3 RandomizeDirection()
        {
            List<Vector3> possibleDirections = new List<Vector3>
            {
                Vector3.up,
                Vector3.down,
                Vector3.left,
                Vector3.right
            };

            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }

        // Coroutine สำหรับการเคลื่อนที่ทีละช่อง
        IEnumerator MoveParade()
        {
            //0. สร้างหัวงู

            while (isAlive)
            {
                // 1. ดึงส่วนแรกของงูออกมา
                LinkedListNode<GameObject> firstNode = Parade.First;
                GameObject firstPart = firstNode.Value;

                // 2. ดึงส่วนสุดท้ายของงูออกมา
                LinkedListNode<GameObject> lastNode = Parade.Last;
                GameObject lastPart = lastNode.Value;

                // 3. ลบส่วนสุดท้ายออกจาก LinkedList
                Parade.RemoveLast();

                // 4. ตรวจสอบสิ่งกีดขวาง
                bool isCollision = true;

                int toX = 0;
                int toY = 0;

                while (isCollision)
                {
                    moveDirection = RandomizeDirection();

                    toX = (int)(
                        firstPart.transform.position.x +
                        moveDirection.x
                    );

                    toY = (int)(
                        firstPart.transform.position.y +
                        moveDirection.y
                    );

                    isCollision = IsCollision(toX, toY);
                }

                // 5. กำหนดตำแหน่งและทิศทางของส่วนที่ถูกย้ายมาใหม่
                // ให้ไปอยู่ที่ตำแหน่งของส่วนหัวงู (ซึ่งเพิ่งเคลื่อนที่ไปเมื่อครู่)

                //6. เคลื่อนที่
                lastPart.transform.position =
                    new Vector3(toX, toY, 0);

                // 7. เพิ่มส่วนนั้นกลับเข้าไปเป็นส่วนที่สองของ LinkedList
                // (ซึ่งก็คือส่วนแรกของลำตัว)
                Parade.AddFirst(lastPart);

                // รอตามเวลาที่กำหนดก่อนการเคลื่อนที่ครั้งต่อไป
                yield return new WaitForSeconds(moveInterval);
            }
        }

        private bool IsCollision(int x, int y)
        {
            // 4. ตรวจสอบสิ่งกีดขวาง
            if (HasPlacement(x, y))
            {
                return true;
            }

            return false;
        }

        void Move(Vector2 direction, GameObject targetMove)
        {
            int toX = (int)direction.x;
            int toY = (int)direction.y;
            Debug.Log("Move to: " + toX + "," + toY);
        }


        // ฟังก์ชันสำหรับเพิ่มส่วนของงู (Grow)
        private void Grow()
        {
            GameObject newPart = Instantiate(bodyPrefab);

            // กำหนดตำแหน่งเริ่มต้นของส่วนใหม่ให้อยู่ที่เดียวกับส่วนสุดท้ายของงู
            GameObject lastPart = Parade.Last.Value;
            newPart.transform.position = lastPart.transform.position;

            //newPart.transform.rotation = lastPart.transform.rotation;

            // เพิ่มส่วนใหม่เข้าไปใน Linked List
            Parade.AddLast(newPart);
        }

    }
}