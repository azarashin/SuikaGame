using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaGame
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        int _id = 0;

        bool _isHit;
        GameManager _manager;

        private void Start()
        {
            _manager = FindObjectsByType<GameManager>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0]; 
            _isHit = false; 
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if(ball != null && !ball._isHit && _id == ball._id)
            {
                _isHit=true;
                _manager.CombineBalls(this, ball, _id); 
            }
        }

    }
}