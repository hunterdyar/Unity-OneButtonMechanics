using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
	public class SceneLoader : MonoBehaviour
	{
		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}