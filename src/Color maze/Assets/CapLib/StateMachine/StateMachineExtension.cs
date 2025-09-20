using System;
using UnityEngine.Assertions;

namespace CapLib.StateMachine
{
	public static class StateMachineExtension
	{
		public static IStateMachine<TStateKey, TState> AddState<TStateKey, TState>(
			this IStateMachine<TStateKey, TState> stateMachine,
			TStateKey key, TState state)
			where TState : IState
		{
			var result = stateMachine.TryAddState(key, state);
			Assert.IsTrue(result, $"Can not add state: {key}.");
			return stateMachine;
		}

		public static IStateMachine<TStateKey, TState> AddState<TStateKey, TState>(
			this IStateMachine<TStateKey, TState> stateMachine,
			TStateKey key, TState state, Action cannotAddCallback)
			where TState : IState
		{
			if (stateMachine.TryAddState(key, state) == false)
				cannotAddCallback?.Invoke();

			return stateMachine;
		}

		public static void Enter<TStateKey, TState>(
			this IStateMachine<TStateKey, TState> stateMachine, TStateKey key)
			where TState : IState
		{
			var result = stateMachine.TryEnter(key);
			Assert.IsTrue(result, $"Can not enter to state: {key}.");
		}

		public static void Enter<TStateKey, TState>(
			this IStateMachine<TStateKey, TState> stateMachine, TStateKey key,
			Action canNotEnterCallback)
			where TState : IState
		{
			if (stateMachine.TryEnter(key) == false)
				canNotEnterCallback?.Invoke();
		}
	}
}