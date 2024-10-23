using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceaneController : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
