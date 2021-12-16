
	using UnityEngine;

	public class GameStartInput : MonoBehaviour
	{
		private GameStateController _gameStateController;

		void Awake()
		{
			_gameStateController = GetComponent<GameStateController>();
		}
		public void Update()
		{
			//just press the button to start the game, or to restart after gameOver.
			if (_gameStateController.IsState(GameState.start) && Input.GetButtonDown("Jump"))
			{
				_gameStateController.ChangeState(GameState.playing);
			}else if (_gameStateController.IsState(GameState.gameOver) && Input.GetKeyDown(KeyCode.R))
			{
				_gameStateController.ChangeState(GameState.restart);
			}
		}
	}
