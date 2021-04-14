using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
	public void OnStartButtonClicked()
	{
		SceneManager.LoadScene("Enemymap2");
	}
}