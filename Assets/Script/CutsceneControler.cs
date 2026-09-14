using UnityEngine;
using UnityEngine.Playables;

public class CutsceneControler : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject canvas;

    private void Awake()
    {
        if (canvas != null) canvas.SetActive(false);
    }

    private void OnEnable()
    {
        if(director != null)
        {
            director.stopped += OnCutsceneFinish;
        }
    }

    private void OnDisable()
    {
        if (director != null)
        {
            director.stopped -= OnCutsceneFinish;
        }
    }

    void OnCutsceneFinish(PlayableDirector pd)
    {
        if (canvas != null)  canvas.SetActive(true);
    }

}
