using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _textMeshPro;
        [SerializeField] private int _enemiesKilled = 0;
        public int EemiesKilled => _enemiesKilled;


        private void Start()
        {
            foreach (TextMeshProUGUI text in _textMeshPro)
            {
                text.text = _enemiesKilled.ToString();
            }
        }

        public void AddScore()
        {
            _enemiesKilled++;
            foreach (TextMeshProUGUI text in _textMeshPro)
            {
                text.text = _enemiesKilled.ToString();
            }
        }
        
        public void ResetScore()
        {
            _enemiesKilled = 0;
        }
    }
}