using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
	public class UIScoreDisplayer : MonoBehaviour
	{
		private TMP_Text _text;

		[SerializeField]
		private ScoreManager _scoreManager;

		private void Awake()
		{
			_text = GetComponent<TMP_Text>();
			if (_scoreManager == null)
			{
				_scoreManager = GameObject.FindObjectOfType<ScoreManager>();
			}
		}

		void Update()
		{
			_text.text = "Score: " + _scoreManager.GetScore().ToString();
		}
	}
}