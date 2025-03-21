using Zenject;

using PlayerInput;

using Player;

using Timer;

using Spawner;

using Score;

using Boosters;

using GamePause;

using Weapons;

using UnityEngine;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerControl _playerControl;

        [SerializeField] private PlayerHitBox _player;

        [SerializeField] private WaveSpawner _waveSpawner;

        [SerializeField] private WavesConfig _wavesConfig;

        [SerializeField] private KeyBoardPauseButton _pauseButton;

        [SerializeField] private SceneLoader _sceneLoader;

        [SerializeField] private AmmoConfig _ammoConfig;

        [SerializeField] private WeaponSwitcher _weaponSwitch;

        [SerializeField] private BoostersAudio _boostersAudio;

        public override void InstallBindings()
        {
            BindPlayerInput();

            BindPlayer();

            BindGameTimer();

            BindSpawner();

            BindGameScore();

            BindPause();

            BindSceneLoader();

            BindWeapons();

            BindBoostersAudio();

            BindUpdatesContainer();
        }

        private void BindUpdatesContainer()
        {
            Container
                .BindInterfacesAndSelfTo<UpdatesContainer>()
                .AsSingle();
        }

        private void BindWeapons()
        {
            Container
                .Bind<WeaponSwitcher>()
                .FromInstance(_weaponSwitch)
                .AsSingle();

            Container
                .Bind<AmmoConfig>()
                .FromScriptableObject(_ammoConfig)
                .AsSingle();

            Container
                .Bind<Ammo>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .FromInstance(_sceneLoader)
                .AsSingle();
        }

        private void BindPause()
        {
            Container
                .Bind<KeyBoardPauseButton>()
                .FromInstance(_pauseButton)
                .AsSingle();
        }

        private void BindBoostersAudio()
        {
            Container
                .Bind<BoostersAudio>()
                .FromInstance(_boostersAudio)
                .AsSingle();
        }

        private void BindGameScore()
        {
            GameScore gameScore = new GameScore(0, 0);

            Container
                .Bind<GameScore>()
                .FromInstance(gameScore)
                .AsSingle();
        }

        private void BindSpawner()
        {
            Container
                .Bind<WavesConfig>()
                .FromScriptableObject(_wavesConfig)
                .AsSingle();

            Container
                .BindInterfacesTo<WaveSpawner>()
                .FromInstance(_waveSpawner)
                .AsSingle();

            Container
                .BindFactory<IWave, WaveFactory>()
                .FromFactory<WavesFactory>();
        }

        private void BindGameTimer()
        {
            Container
                .BindInterfacesAndSelfTo<GameTimer>()
                .AsSingle();
        }

        private void BindPlayer()
        {
            Container
                .Bind<PlayerHitBox>()
                .FromInstance(_player)
                .AsSingle();
        }

        private void BindPlayerInput()
        {
            Container
                .Bind<PlayerControl>()
                .FromInstance(_playerControl)
                .AsSingle();
        }
    }
}