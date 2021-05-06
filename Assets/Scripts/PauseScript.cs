using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour
{

	//　ポーズした時に表示するUI
	[SerializeField]
	private GameObject pauseUI;
	public GameObject player;
    private void Start()
    {
		player.GetComponent<PlayerController>().enabled = true;

	}
	void Update()
	{
		if (Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 7")) 
		{
			player.GetComponent<PlayerController>().enabled = false;
			
			//　ポーズUIのアクティブ、非アクティブを切り替え
			pauseUI.SetActive(!pauseUI.activeSelf);

			//　ポーズUIが表示されてる時は停止
			if (pauseUI.activeSelf)
			{
				Time.timeScale = 0f;
				//　ポーズUIが表示されてなければ通常通り進行
			}
			else
			{
				Time.timeScale = 1f;
				player.GetComponent<PlayerController>().enabled = true;
			}
		}
		Debug.Log(player.GetComponent<PlayerController>().enabled);
    }
}
