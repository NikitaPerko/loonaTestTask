using System.Collections;
using System.Collections.Generic;
using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace LoonaTest.Game.GameActors.PenguinBehaviour
{
    public class PenguinBehaviour
    {
        private readonly Penguin _penguin;
        private PenguinState _state = PenguinState.Idle;
        private readonly Dictionary<PenguinState, IAction> _penguinActions;
        private readonly List<Coroutine> _currentActivities = new List<Coroutine>();

        public PenguinBehaviour(NavMeshAgent navMeshAgent, Penguin penguin, GameField gameField,
            PenguinsSettings penguinsSettings)
        {
            _penguin = penguin;

            _penguinActions = new Dictionary<PenguinState, IAction>
            {
                {PenguinState.Idle, new PenguinIdleAction(navMeshAgent, this, gameField, penguinsSettings)},
                {PenguinState.Danger, new PenguinDangerAction()}
            };
        }

        private void StopCurrentActivities()
        {
            foreach (var activity in _currentActivities)
            {
                if (activity != null)
                {
                    _penguin.StopCoroutine(activity);
                }
            }

            _currentActivities.Clear();
        }

        public void StartActivity(IEnumerator activity)
        {
            _currentActivities.Add(_penguin.StartCoroutine(activity));
        }

        public void SwitchState(PenguinState state)
        {
            _state = state;
            StopCurrentActivities();
            Act();
        }

        private void Act()
        {
            _penguinActions[_state].Act();
        }
    }
}