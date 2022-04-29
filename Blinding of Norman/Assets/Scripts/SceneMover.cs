using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    public void Load(int num)
    {
        SceneManager.LoadScene(num);
    }
}
