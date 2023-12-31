﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaGame
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField]
        Ball[] _ballPrefabs;

        public void CombineBalls(Ball ballA, Ball ballB, int id)
        {
            Destroy(ballA.gameObject);
            Destroy(ballB.gameObject);
            int nextId = id + 1;
            if (nextId < _ballPrefabs.Length)
            {
                Vector3 pos = (ballA.transform.position + ballB.transform.position) * 0.5f;
                Ball ball = Instantiate(_ballPrefabs[nextId], pos, Quaternion.identity);
                ball.Release(); // 自由落下させる
            }
        }

        public Ball ReferRandomBallPrefab()
        {
            int index = Random.Range(0, _ballPrefabs.Length);
            return _ballPrefabs[index]; 
        }

    }
}