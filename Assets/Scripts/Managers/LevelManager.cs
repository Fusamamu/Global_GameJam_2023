using System;
using System.Collections;
using System.Collections.Generic;
using FSM;
using JetBrains.Annotations;
using UnityEngine;

namespace GlobalGameJam
{
    [Serializable]
    public struct LevelInfo
    {
        public string Detail;
        
        public int DiceCount;

        public List<Seeds> SeedBatch;
    }

    [Serializable]
    public struct Seeds
    {
        public List<SeedNode> SeedNodes;
    }
    
    public class LevelManager : MonoBehaviour, IService
    {
        public bool StartPlayerState;
        
        public bool Use;

        public static int CurrentLevel = 0;

        public bool UseDebugLevel;
        public int DebugLevel;
        
        public int CurrentBatch;
        public int CurrentBatchCount;

        public List<LevelInfo> LevelInfos = new List<LevelInfo>();

        public Seeds GetSeeds()
        {
            return 
                LevelInfos[CurrentLevel]
                .SeedBatch[CurrentBatch];
        }
        
        public int BatchCount()
        {
            return  LevelInfos[CurrentLevel]
                .SeedBatch.Count;
        }

        public int SeedCount()
        {
            return LevelInfos[CurrentLevel]
                .SeedBatch[CurrentBatch]
                .SeedNodes.Count;
        }

        public StateMachine LevelStateMachine;

        [field: SerializeField] public string TutorialState { get; private set; } = "TutorialState";

        [field: SerializeField] public string PlayerState    { get; private set; } = "PlayerState";
        [field: SerializeField] public string GetSeedState   { get; private set; } = "GetSeedState";
        [field: SerializeField] public string PlaceSeedState { get; private set; } = "PlaceSeedState";
        [field: SerializeField] public string LevelPassState { get; private set; } = "LevelPassStats";
        [field: SerializeField] public string GameOverState  { get; private set; } = "GameOverState";
 
        [SerializeField] private UIManager            UIManager;
        [SerializeField] private DiceManager          DiceManager;
        [SerializeField] private SeedPlacementManager SeedPlacementManager;
        
        public void Initialized()
        {
            if (!Use) return;

            UIManager            = ServiceLocator.Instance.Get<UIManager>();
            DiceManager          = ServiceLocator.Instance.Get<DiceManager>();
            SeedPlacementManager = ServiceLocator.Instance.Get<SeedPlacementManager>();
                
            LevelStateMachine = new StateMachine();
            
            LevelStateMachine.AddState(TutorialState, 
                new State(onEnter: _state =>
                {
                    StartCoroutine(StartTutorial());

                }, onLogic: _state =>
                {
                    
                },onExit: _state =>
                {
                    ServiceLocator.Instance.Get<DataManager>().Score = 0;
                    UIManager.GetUI<ScoreUI>().SetScore(0);
                }));
            
            LevelStateMachine.AddState(PlayerState, 
                new State(onEnter: _state =>
                {
                    if (UseDebugLevel)
                    {
                        CurrentLevel = DebugLevel;

                        UseDebugLevel = false;
                        
                        ServiceLocator.Instance.Get<GridDataManager>().StartLevel(CurrentLevel, () =>
                        {
                            var _uiManage = ServiceLocator.Instance.Get<UIManager>();
                            
                            _uiManage.GetUI<LevelUI>()
                                .SetLevelText(CurrentLevel)
                                .SetDetailText("Let's start slow")
                                .Show();

                            CurrentBatch      = 0;
                            CurrentBatchCount = BatchCount();
                        
                            _uiManage
                                .GetUI<LevelUI>()
                                .DiceCountText
                                .SetText(CurrentBatchCount.ToString());
                        
                            _uiManage.GetUI<ScoreUI>().Show();
                        
                            ServiceLocator.Instance.Get<CameraManager>().ChangeBackgroundColor();
                        
                            LevelStateMachine.RequestStateChange(GetSeedState);
                        });
                        
                        return;
                        
                    }
                    
                    
                    
                    if (SceneLoader.IsRestartCurrentLevel)
                    {
                        SceneLoader.IsRestartCurrentLevel = false;
                        
                        ServiceLocator.Instance.Get<GridDataManager>().StartLevel(CurrentLevel, () =>
                        {
                            var _currentLevelInfo = LevelInfos[CurrentLevel];
                            var _levelDetail      = _currentLevelInfo.Detail;
                            
                            var _uiManage = ServiceLocator.Instance.Get<UIManager>();
                            
                            _uiManage.GetUI<LevelUI>()
                                .SetLevelText(CurrentLevel)
                                .SetDetailText(_levelDetail)
                                .Show();

                            CurrentBatch      = 0;
                            CurrentBatchCount = BatchCount();
                        
                            _uiManage
                                .GetUI<LevelUI>()
                                .DiceCountText
                                .SetText(CurrentBatchCount.ToString());
                        
                            _uiManage.GetUI<ScoreUI>().Show();
                        
                            ServiceLocator.Instance.Get<CameraManager>().ChangeBackgroundColor();
                        
                            LevelStateMachine.RequestStateChange(GetSeedState);
                        });
                        
                        return;
                    }
                       
                    
                    ServiceLocator.Instance.Get<GridDataManager>().StartChangeNextLevel(() =>
                    {
                        
                        var _currentLevelInfo = LevelInfos[CurrentLevel];
                        var _levelDetail      = _currentLevelInfo.Detail;
                        
                        var _uiManage = ServiceLocator.Instance.Get<UIManager>();
                        
                        _uiManage.GetUI<LevelUI>()
                            .SetLevelText(CurrentLevel)
                            .SetDetailText(_levelDetail)
                            .Show();

                        CurrentBatch      = 0;
                        CurrentBatchCount = BatchCount();
                        
                        _uiManage
                            .GetUI<LevelUI>()
                            .DiceCountText
                            .SetText(CurrentBatchCount.ToString());
                        
                        _uiManage.GetUI<ScoreUI>().Show();
                        
                        ServiceLocator.Instance.Get<CameraManager>().ChangeBackgroundColor();
                        
                        LevelStateMachine.RequestStateChange(GetSeedState);
                    });
                    
                }, onLogic: _state =>
                {
                    
                },onExit: _state =>
                {
                    
                }));
            
            LevelStateMachine.AddState(GetSeedState, 
                new State(onEnter: _state =>
                {
                    if (!UIManager.GetUI<SeedSelectionUI>().IsShow)
                    {
                        UIManager.GetUI<LevelUI>().PressSpaceBarUI.SetActive(true);
                    }
                    
                    DiceManager.Enable();
                    DiceManager.OnDiceStopRolling += UIManager.GetUI<SeedSelectionUI>().Show;

                    Dice.OnDiceSelected += OnDiceSelectedHandler;

                }, onLogic: _state =>
                {
                  //  Debug.Log("Get Seed State");
                    
                },onExit: _state =>
                {
                    DiceManager.Disable();
                    DiceManager.OnDiceStopRolling -= UIManager.GetUI<SeedSelectionUI>().Show;
                    
                    Dice.OnDiceSelected -= OnDiceSelectedHandler;
                }));
          
            LevelStateMachine.AddState(PlaceSeedState, 
                new State(onEnter: _state =>
                {
                    SeedPlacementManager.Enable();
                    SeedPlacementManager.OnSeedPlaced += OnSeedPlacementHandler;

                    SeedNode.OnAllPlantGrown += GoToLevelPassState;

                }, onLogic: _state =>
                {
                    
                   // Debug.Log("Place Seed State");
                    
                },onExit: _state =>
                {
                    SeedPlacementManager.Disable();
                    SeedPlacementManager.OnSeedPlaced -= OnSeedPlacementHandler;
                    
                    SeedNode.OnAllPlantGrown -= GoToLevelPassState;
                }));

            
#region Pass Level
            LevelStateMachine.AddState(LevelPassState, 
                new State(onEnter: _state =>
                {
                    var _uiManage = ServiceLocator.Instance.Get<UIManager>();
                        
                    _uiManage.GetUI<LevelUI>().Hide();
                    _uiManage.GetUI<ScoreUI>().Hide();

                    _uiManage
                        .GetUI<TutorialUI>()
                        .CompleteUIElement
                        .SetText("Congratulation!")
                        .Show();

                    WaitForSeconds(4, () =>
                    {
                        if (CurrentLevel == LevelInfos.Count - 1)
                        //if (CurrentLevel == 1)
                        {
                            LevelStateMachine.RequestStateChange(GameOverState);
                            return;
                        }
                        
                        LevelStateMachine.RequestStateChange(PlayerState);
                    });

                }, onLogic: _state =>
                {
                    
                    
                    
                },onExit: _state =>
                {
                  
                    var _uiManage = ServiceLocator.Instance.Get<UIManager>();
                        
                    _uiManage.GetUI<LevelUI>().Hide();

                    _uiManage
                        .GetUI<TutorialUI>()
                        .CompleteUIElement
                        .Hide();
                }));
            
  #endregion
            
            LevelStateMachine.AddState(GameOverState, 
                new State(onEnter: _state =>
                {
                    UIManager.GetUI<GameOverUI>().Show();

                }, onLogic: _state =>
                {
                    
                },onExit: _state =>
                {
                  
                }));
            
            if(StartPlayerState || SceneLoader.IsRestartCurrentLevel)
                LevelStateMachine.SetStartState(PlayerState);
            else
                LevelStateMachine.SetStartState(TutorialState);
            
            LevelStateMachine.Init();
        }

        private void OnDiceSelectedHandler()
        {
            if(DiceManager.AllDicesSelected())
                UIManager.GetUI<SeedSelectionUI>().Hide();
            
            GoToPlaceSeedState();
        }

        private void OnSeedPlacementHandler(SeedNode _node)
        {
            // StartCoroutine(CheckStopGrow(() =>
            // {
            //         
            //     GoToGetSeedState();
            // }));

            StartCoroutine(Wait(_node, () =>
            {
                if (!ServiceLocator.Instance.Get<GridDataManager>().IsAllPlantNodesGrown())
                {
                    if (CurrentBatchCount == 0 && DiceManager.IsAllDicesSelected())
                    {
                        var _levelUI = UIManager.GetUI<ExtraInfoUI>();
                        
                        _levelUI.Show();
                        
                        return;
                    }
                }
                
                GoToGetSeedState();
            }));
        }

        private IEnumerator Wait(SeedNode _node, Action _onComplete)
        {
            yield return new WaitUntil(() => !_node.Growing);
            
            _onComplete?.Invoke();
        }

        private IEnumerator CheckStopGrow(Action _onComplete)
        {
            bool _stopGrow = false;
            
            while (!_stopGrow)
            {
                var _allSeeds = FindObjectsOfType<SeedNode>();
                
                foreach (var _seed in _allSeeds)
                {
                    if (_seed.Growing)
                    {
                        _stopGrow = false;
                    }
                    else
                    {
                        _stopGrow = true;
                    }
                
                    yield return null;
                }
            }
            
            _onComplete?.Invoke();
        }

        private void GoToPlaceSeedState()
        {
            LevelStateMachine.RequestStateChange(PlaceSeedState);
        }

        private void GoToGetSeedState()
        {
            LevelStateMachine.RequestStateChange(GetSeedState);
        }

        public void GoToLevelPassState()
        {
            LevelStateMachine.RequestStateChange(LevelPassState);
        }

        private void WaitForSeconds(float _seconds, Action _onComplete)
        {
            StartCoroutine(Wait(_seconds, _onComplete));
        }

        private IEnumerator Wait(float _seconds, Action _onComplete)
        {
            yield return new WaitForSeconds(_seconds);
            
            _onComplete?.Invoke();
        }

        private void Update()
        {
            LevelStateMachine?.OnLogic();
        }

        private IEnumerator StartTutorial()
        {
            var _uiManager = ServiceLocator.Instance.Get<UIManager>();
            
            yield return new WaitForSeconds(2);
            _uiManager.GetUI<LevelUI>().Show();
            yield return new WaitForSeconds(3);
            _uiManager.GetUI<LevelUI>().Hide();
            
            yield return new WaitForSeconds(2);
            
            var _taskUI     = _uiManager.GetUI<TutorialUI>().TaskUIElement;
            var _completeUI = _uiManager.GetUI<TutorialUI>().CompleteUIElement;
            
            _taskUI.Show();
            
            yield return new WaitForSeconds(4);
            
            _taskUI.Instruction.SetText($"<shake>The world is dying. You're the only one to preserve it by planting seeds.</shake>");
            
            yield return new WaitForSeconds(4f);
            
            _taskUI.Instruction.SetText($"<shake>Your aim is to connect potential saving-planet plants with roots from placing seeds all over the places</shake>");
            
            yield return new WaitForSeconds(4f);
            
            _taskUI.Instruction.SetText($"<shake>Now first, let's get a seed.</shake>");
            
            yield return new WaitForSeconds(2f);
            
            _taskUI.Instruction.SetText($"<shake>To do so, press [ SPACE BAR ] to randomly get a seed</shake>");

            var _diceManager = ServiceLocator.Instance.Get<DiceManager>();
            _diceManager.Enable();

            yield return new WaitUntil(() => _diceManager.StartRoll);
            yield return new WaitUntil(() => _diceManager.IsAllDicesStopRolling());

            yield return new WaitForSeconds(5);
            
            _taskUI.Instruction.SetText($"<shake>The citizen of the world appreciate your first step to save to the world.</shake>");
            
            _uiManager.GetUI<SeedSelectionUI>().Show();
            
            _completeUI.Show();
            yield return new WaitForSeconds(2);
            _completeUI.Hide();
            
            yield return new WaitForSeconds(2);
            _taskUI.Instruction.SetText($"<shake>Next step, Let's pick a seed from slots</shake>");

            var _seedPlacementManager = ServiceLocator.Instance.Get<SeedPlacementManager>();

            yield return new WaitUntil(() => _seedPlacementManager.IsHoldingSeed);
            
            _uiManager.GetUI<SeedSelectionUI>().Hide();

            _seedPlacementManager.Disable();
            
            _taskUI.Instruction.SetText($"<shake>Now, you have the power of the sun in the palm of your hand! (well technically, it's just a seed..)</shake>");
            
            _completeUI.Show();
            yield return new WaitForSeconds(3);
            _completeUI.Hide();
            
            yield return new WaitForSeconds(2);
            _taskUI.Instruction.SetText($"<shake>It's time you start saving the world. Place the seed [NEXT TO PLANT BASE] and see them grow.</shake>");

            _seedPlacementManager.Enable();
            
            yield return new WaitUntil(() => !_seedPlacementManager.IsHoldingSeed);
            yield return new WaitForSeconds(5);
            
            _completeUI.Show();
            yield return new WaitForSeconds(2);
            _completeUI.Hide();
            
            _taskUI.Instruction.SetText($"<shake>Ok that's the gist pick a seed, place and grow. Now go and the save the world.</shake>");
            
            yield return new WaitForSeconds(5);

            _taskUI.Hide();
            
            yield return new WaitForSeconds(5);

            LevelStateMachine.RequestStateChange(PlayerState);
        }

        private void OnDestroy()
        {
            SeedNode.OnAllPlantGrown -= GoToLevelPassState;
            Dice.OnDiceSelected -= OnDiceSelectedHandler;
        }
    }
}
