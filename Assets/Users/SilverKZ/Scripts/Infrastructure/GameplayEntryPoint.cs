using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
    }

    private void Awake()
    {
        _pauseHandler.Handle();
    }
}
