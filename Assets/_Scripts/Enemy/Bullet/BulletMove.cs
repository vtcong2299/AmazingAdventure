using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class BulletMove : MonoBehaviour
    {
        public Vector3 oldPosition;
        public float speedBullet = 1f;
        private void Awake()
        {
            oldPosition = transform.position;
        }
        private void Update()
        {
            MoveBullet();
            ResetBullet();
        }
        private void ResetBullet()
        {
            if (Vector3.Distance(oldPosition, transform.position) >= 5)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "PlayerBody")
            {
                Destroy(gameObject);
            }
        }
        public void MoveBullet()
        {
            transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * speedBullet;
        }
    }
