using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    public static GameManager Instance => s_instance;

    [SerializeField]
    private SaveManager s_save;
    public static SaveManager Save => Instance.s_save;

    [SerializeField]
    private ResourceManager s_resource;
    public static ResourceManager Resource => Instance.s_resource;

    [SerializeField]
    private DataManager s_data;
    public static DataManager Data => Instance.s_data;

    [SerializeField]
    private SoundManager s_sound;
    public static SoundManager Sound => Instance.s_sound;

    [SerializeField]
    private SceneController s_scene;
    public static SceneController Scene => Instance.s_scene;

    [SerializeField]
    private UIManager s_ui;
    public static UIManager UI => Instance.s_ui;

    void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(this.gameObject);

            Init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Init()
    {
        s_save.Init();
        s_resource.Init();
        s_data.Init();
        s_sound.Init();
        s_scene.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Time.timeScale = 3f;
        }
    }
}
