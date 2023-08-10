using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class DoorToNextLevel : MonoBehaviour
    {
        private bool _doorOpen;
        [SerializeField] private string _nextSceneName;
        [SerializeField] private Sprite _doorOpenSprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private GameObject goToDestroy;
        [SerializeField] private TMP_Text _healthPotionAlertText;
        [SerializeField] private TMP_Text getPower;
        [SerializeField] private string getPowerText;
        [SerializeField] private int healthPotionToCollect;

        private ScoreDisplay _scoreDisplay;

        private void Start()
        {
            _scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<ScoreDisplay>();
            _doorOpen = false;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (_doorOpen == true)
                {
                    if (_scoreDisplay.score < healthPotionToCollect)
                    {
                        _healthPotionAlertText.text =
                            "You need " + healthPotionToCollect + " health potions to pass the door! !";
                    }
                    else if (_scoreDisplay.score >= healthPotionToCollect)
                    {
                        LoadingScreenController.Instance.LoadNextScene(_nextSceneName);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (goToDestroy == null)
            {
                getPower.text = getPowerText;
                _doorOpen = true;
                _spriteRenderer.sprite = _doorOpenSprite;
            }
        }
    }
}
