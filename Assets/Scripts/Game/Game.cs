using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UICaller _uiCaller;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private TimeSwitcher _timeSwitcher;
    [SerializeField] private HarvestDispatcher _dispatcher;
    [SerializeField] private Blade _blade;

    private void OnEnable()
    {
        _uiCaller.LevelWasSelected += StartGame;
        _uiCaller.LevelResetButtonClicked += ResetLevel;
        _uiCaller.HomeButtonClicked += OnHomePage;
        _dispatcher.StoragesLoaded += OnGameOver;
    }

    private void OnDisable()
    {
        _uiCaller.LevelWasSelected -= StartGame;
        _uiCaller.LevelResetButtonClicked -= ResetLevel;
        _uiCaller.HomeButtonClicked -= OnHomePage;
        _dispatcher.StoragesLoaded -= OnGameOver;
    }

    private void OnGameOver()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallLoseScreen();
    }

    private void OnHomePage()
    {
        _levelLoader.UnloadLevel();
        _blade.Reset();
    }

    private void ResetLevel()
    {
        _levelLoader.ReloadLevel();
        _uiCaller.CloseAllScreens();
        _timeSwitcher.StartTime();
        _blade.Reset();
    }

    private void StartGame(int levelIndex)
    {
        _uiCaller.CloseAllScreens();
        _levelLoader.LoadLevel(levelIndex);
        _timeSwitcher.StartTime();
        _blade.Reset();
    }
}