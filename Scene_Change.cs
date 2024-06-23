using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public int scene_index = 0;
    private Button button;
    //dont use yet
    public bool saveScore = false;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(loadScene);
    }
    private void loadScene()
    {
        if (saveScore)
        {
            Game_Manager.loadWithScore = true;
            Game_Manager.previousScore = (int)GameObject.Find("Cat").GetComponent<Movement>().score;
        }
        SaveSystem.SavePlayer();
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(scene_index);
    }
}
