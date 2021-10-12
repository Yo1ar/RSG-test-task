using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Components
{
    public class CanvasComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _deathsScreen;
        [SerializeField] private GameObject _pauseScreen;
        private bool _isPlayAgainScreenActive;
        

        public void OnPauseMenuInput(InputAction.CallbackContext context)
        {
            SwitchPauseMenuActivity();
        }

        public void ShowDeathsScreen()
        {
            _pauseScreen.SetActive(false);
            
            PauseGame();
            _deathsScreen.SetActive(true);
        }

        public void ReloadLevel()
        {
            ResumeGame();
            SceneManager.LoadScene("SampleScene");
            
        }

        public void SwitchPauseMenuActivity()
        {
            if (_deathsScreen.activeSelf) return;
            
            _isPlayAgainScreenActive = !_isPlayAgainScreenActive;
            if (_isPlayAgainScreenActive)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();

            }

            _pauseScreen.SetActive(_isPlayAgainScreenActive);
        }

        private void PauseGame()
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        private void ResumeGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}