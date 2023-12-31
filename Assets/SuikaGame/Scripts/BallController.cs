﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaGame
{
    public class BallController : MonoBehaviour
    {
        [SerializeField]
        BallManager _ballManager;

        [SerializeField]
        float _sideSpeed = 0.8f;

        [SerializeField]
        float _downSpeed = 1.2f;

        [SerializeField]
        float _fallSpeed = 0.5f;

        Ball _controlledBall;

        // Start is called before the first frame update
        void Start()
        {
            Ball firstBallPrefab = _ballManager.ReferRandomBallPrefab();
            _controlledBall = Instantiate(firstBallPrefab, transform.position, Quaternion.identity, transform);

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _controlledBall.transform.position -= Vector3.right * _sideSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _controlledBall.transform.position += Vector3.right * _sideSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _controlledBall.transform.position += Vector3.down * _downSpeed * Time.deltaTime;
            }
            // 等速落下
            _controlledBall.transform.position += Vector3.down * _fallSpeed * Time.deltaTime;
        }

        public void TryReleaseBall(Ball releaseBall)
        {
            if (IsControlled(releaseBall))
            {
                releaseBall.Release();
                Ball ballPrefab = _ballManager.ReferRandomBallPrefab();
                _controlledBall = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform);
            }
        }

        public bool IsControlled(Ball target)
        {
            return (_controlledBall == target); 
        }
    }
}