using System;
using System.Collections;
using System.Collections.Generic;
using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.AI;
using VContainer;
using Random = UnityEngine.Random;

namespace LoonaTest.Game.GameActors.Penguins
{
    public class PenguinIdleAction : IAction
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly PenguinBehaviour _penguinBehaviour;
        private readonly GameField _gameField;
        private readonly PenguinsSettings _penguinsSettings;
        private readonly List<Func<IEnumerator>> activities;

        [Inject]
        public PenguinIdleAction(NavMeshAgent navMeshAgent, PenguinBehaviour penguinBehaviour, GameField gameField,
            PenguinsSettings penguinsSettings)
        {
            _navMeshAgent = navMeshAgent;
            _penguinBehaviour = penguinBehaviour;
            _gameField = gameField;
            _penguinsSettings = penguinsSettings;
            activities = new List<Func<IEnumerator>> {WalkingInRandomPoint, StayingAtCurrentPlace};
        }

        public void Act(object data = null)
        {
            var randomActivity = activities[Random.Range(0, activities.Count)];
            _penguinBehaviour.StartActivity(randomActivity());
        }

        private IEnumerator WalkingInRandomPoint()
        {
            var randomPos = _gameField.GetRandomFieldXZPos();
            _navMeshAgent.SetDestination(randomPos.GetXYZWithZeroY());
            _navMeshAgent.speed = Random.Range(_penguinsSettings.idleWalkingSpeedFrom, _penguinsSettings.idleWalkingSpeedTo);

            while (_navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
            {
                yield return null;
            }

            _penguinBehaviour.SwitchState(PenguinState.Idle);
        }

        private IEnumerator StayingAtCurrentPlace()
        {
            yield return new WaitForSeconds(Random.Range(_penguinsSettings.idleWaitingTimeFrom, _penguinsSettings.idleWaitingTimeTo));
            _penguinBehaviour.SwitchState(PenguinState.Idle);
        }
    }
}