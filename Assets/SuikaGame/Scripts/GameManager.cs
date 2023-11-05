using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        Ball[] _ballPrefabs;

        [SerializeField]
        BallController _ballController;

        [SerializeField]
        GameObject _gameOverPanel; 

        public void CombineBalls(Ball ballA, Ball ballB, int id)
        {
            int nextId = id + 1;
            Vector3 pos = (ballA.transform.position + ballB.transform.position) * 0.5f;
            Destroy(ballA.gameObject);
            Destroy(ballB.gameObject);
            if (nextId < _ballPrefabs.Length)
            {
                Instantiate(_ballPrefabs[nextId], pos, Quaternion.identity);
            }
        }
        internal void GameOver()
        {
            _gameOverPanel.SetActive(true); 
            _ballController.gameObject.SetActive(false); 
        }
    }
}