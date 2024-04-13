using System.Collections.Generic;
using Input;
using Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private List<GameObject> instances;
        [SerializeField] private PlayerMovement playerMovement;

        public override void InstallBindings()
        {
            BindCore();
            Container.BindInstances(instances);
        }

        private void BindCore()
        {
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<InputHandler>().AsSingle().NonLazy();
            Container.Bind<PlayerMovement>().FromInstance(playerMovement);
            Container.Bind<Game>().AsSingle();
        }
    }
}