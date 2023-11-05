using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        BallController _ballController;

        [SerializeField]
        GameObject _gameOverPanel;

        internal void GameOver()
        {
            _gameOverPanel.SetActive(true);
            _ballController.gameObject.SetActive(false);
        }
    }
}