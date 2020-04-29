using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : InteractiveObject
{
    /// <summary>
    /// Using a constructor here to initialize displayText in the editor
    /// </summary> 
    [Tooltip("Name of the scene to be loaded")]
    [SerializeField]
    protected string sceneName;

    public LoadScene()
    {
        displayText = nameof(LoadScene);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void InteractiveWith()
    {
        // This plays a sound effect
        base.InteractiveWith();
        SceneManager.LoadScene(sceneName);
    }
}
