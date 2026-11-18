using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UICaller _uiCaller;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private TimeSwitcher _timeSwitcher;
    [SerializeField] private HarvestDispatcher _dispatcher;
    [SerializeField] private TruckSpawner _truckSpawner;
    [SerializeField] private Blade _blade;
    [SerializeField] private int[] _trucksRequired;

    private int _deliveredTrucksCount;

    private void OnEnable()
    {
        _uiCaller.LevelWasSelected += StartGame;
        _uiCaller.LevelResetButtonClicked += ResetLevel;
        _uiCaller.StartScreenOpened += OnHomePage;
        _uiCaller.NextLevelButtonClicked += OnNextLevel;
        _dispatcher.StoragesLoaded += OnGameOver;
        _truckSpawner.OnTruckDelivered += OnTruckDelivered;
    }

    private void OnDisable()
    {
        _uiCaller.LevelWasSelected -= StartGame;
        _uiCaller.LevelResetButtonClicked -= ResetLevel;
        _uiCaller.StartScreenOpened -= OnHomePage;
        _uiCaller.NextLevelButtonClicked -= OnNextLevel;
        _dispatcher.StoragesLoaded -= OnGameOver;
        _truckSpawner.OnTruckDelivered += OnTruckDelivered;
    }

    private void OnGameOver()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallLoseScreen();
    }

    private void OnVictory()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallVictoryScreen();
    }

    private void OnTruckDelivered()
    {
        _deliveredTrucksCount++;

        CheckVictory();
    }

    private void CheckVictory()
    {
        int target = _trucksRequired[_levelLoader.CurrentLevelIndex];

        if (_deliveredTrucksCount >= target)
            OnVictory();
    }

    private void OnNextLevel()
    {
        if (!_levelLoader.TryLoadNextLevel())
        {
            _uiCaller.CallStartScreen();
        }
        else
        {
            _deliveredTrucksCount = 0;
            _levelLoader.UnloadLevel();
            _levelLoader.LoadLevel(_levelLoader.CurrentLevelIndex);
            _timeSwitcher.StartTime();
            _blade.Reset();
        }
    }

    private void OnHomePage()
    {
        _timeSwitcher.StartTime();
        _levelLoader.UnloadLevel();
        _blade.Reset();
    }

    private void ResetLevel()
    {
        _deliveredTrucksCount = 0;
        _levelLoader.ReloadLevel();
        _timeSwitcher.StartTime();
        _blade.Reset();
    }

    private void StartGame(int levelIndex)
    {
        _deliveredTrucksCount = 0;
        _levelLoader.LoadLevel(levelIndex);
        _timeSwitcher.StartTime();
        _blade.Reset();
    }
}