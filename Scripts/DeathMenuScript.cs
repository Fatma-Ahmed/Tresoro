using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour {
    public Text scoreText;
	void Start () {
        gameObject.SetActive(false);
    }
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score : " + ((int)score).ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
