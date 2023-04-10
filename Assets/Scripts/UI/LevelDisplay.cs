using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelDisplay : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        string sceneName = SceneManager.GetActiveScene().name;
        textMeshPro.text = sceneName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
