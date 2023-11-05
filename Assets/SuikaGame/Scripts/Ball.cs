using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        int _id = 0;

        bool _isHit;
        GameManager _gameManager; 
        BallManager _ballManager;
        BallController _ballController;

        private void Start()
        {
            _gameManager = FindObjectsByType<GameManager>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];
            _ballManager = FindObjectsByType<BallManager>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];
            _ballController = FindObjectsByType<BallController>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];
            _isHit = false; 
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            // 衝突相手が他のボールか床だったらこのボールを操作できないようにする
            if (ball != null || collision.gameObject.CompareTag("Floor"))
            {
                _ballController.TryReleaseBall(this);
            }

            if (ball != null)
            {
                if (!ball._isHit && _id == ball._id)
                {
                    _isHit = true;
                    _ballManager.CombineBalls(this, ball, _id);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("DeadArea") && _ballController != null && !_ballController.IsControlled(this))
            {
                _gameManager.GameOver();
            }
        }

        public void Release()
        {
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            transform.parent = null;
            rigidbody.gravityScale = 1.0f;
        }
    }
}