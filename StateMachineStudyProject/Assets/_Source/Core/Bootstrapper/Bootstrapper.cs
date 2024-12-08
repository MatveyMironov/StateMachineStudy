using GameSystem;
using PlayerSystem;
using UnityEngine;
using WeaponSystem;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private InputListener inputListener;

        [SerializeField] private Color finalColor;

        [Header("Red Zone State")]
        [SerializeField] private GameObject redZone;

        [Header("Fase State")]
        [SerializeField] private Renderer playerRenderer;
        [SerializeField] private float fadedColorAlpha;

        [Header("Gun State")]
        [SerializeField] private Transform muzzle;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float bulletSpeed;

        private void Awake()
        {
            CombatState[] combatStates = new CombatState[3];
            combatStates[0] = new GunState(muzzle, bulletPrefab, bulletSpeed);
            combatStates[1] = new RedZoneState(redZone);
            combatStates[2] = new FadeState(playerRenderer, fadedColorAlpha);

            CombatStateMachine combatStateMachine = new(combatStates);

            GameState playState = new PlayState(inputListener);
            GameState pauseState = new PauseState();
            GameState finalState = new FinalState(playerRenderer, finalColor, redZone);
            GameStateMachine gameStateMachine = new(playState, pauseState, finalState);

            inputListener.Setup(playerMovement, combatStateMachine, gameStateMachine);

            gameStateMachine.EnterPlayState();
        }
    }
}