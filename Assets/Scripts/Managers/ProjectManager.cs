using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ProjectManager : MonoBehaviour
    {
        [SerializeField] private AudioManager         AudioManager;
        [SerializeField] private DataManager          DataManager;
        [SerializeField] private InputManager         InputManager;
        [SerializeField] private CameraManager        CameraManager;
        [SerializeField] private UIManager            UIManager;
        [SerializeField] private GizmosManager        GizmosManager;
        [SerializeField] private FeedbackManager      FeedbackManager;
        [SerializeField] private DiceManager          DiceManager;
        [SerializeField] private GridDataManager      GridDataManager;
        [SerializeField] private SeedPlacementManager SeedPlacementManager;
        [SerializeField] private PlayerManager        PlayerManager;
        [SerializeField] private LevelManager         LevelManager;

        private void Start()
        {
            ServiceLocator.Instance.Register(DataManager);
            ServiceLocator.Instance.Register(InputManager);
            ServiceLocator.Instance.Register(CameraManager);
            ServiceLocator.Instance.Register(UIManager);
            ServiceLocator.Instance.Register(AudioManager);
            ServiceLocator.Instance.Register(GizmosManager);
            ServiceLocator.Instance.Register(FeedbackManager);
            ServiceLocator.Instance.Register(DiceManager);
            ServiceLocator.Instance.Register(GridDataManager);
            ServiceLocator.Instance.Register(SeedPlacementManager);
            ServiceLocator.Instance.Register(PlayerManager);
            ServiceLocator.Instance.Register(LevelManager);
            
            ServiceLocator.Instance.Initialized();
        }
        
    }
}
