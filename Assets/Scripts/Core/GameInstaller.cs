using System.Collections.Generic;
using System.ComponentModel;
using Input;
using InteractionSystem;
using Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private List<GameObject> instances;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private InteractComponent interactComponent;

        public override void InstallBindings()
        {
            BindCore();
            Container.BindInstances(instances);
        }

        private void BindCore()
        {
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<InteractComponent>().FromInstance(interactComponent);
            Container.Bind<InputHandler>().AsSingle().NonLazy();
            Container.Bind<PlayerMovement>().FromInstance(playerMovement);
            Container.Bind<Game>().AsSingle();
        }
    }
}