using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    //public int sceneIndex;

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quitapp()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
