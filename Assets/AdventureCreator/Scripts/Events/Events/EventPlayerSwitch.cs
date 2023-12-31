﻿namespace AC
{

	public class EventPlayerSet : EventBase
	{

		public override string[] EditorNames { get { return new string[] { "Character/Set Player" }; } }
		protected override string EventName { get { return "OnSetPlayer"; } }
		protected override string ConditionHelp { get { return "Whenever the active Player is set."; } }


		public override void Register ()
		{
			EventManager.OnPlayerSpawn += OnSetPlayer;
		}


		public override void Unregister ()
		{
			EventManager.OnPlayerSpawn -= OnSetPlayer;
		}


		private void OnSetPlayer (Player player)
		{
			Run (new object[] { player.gameObject });
		}


		protected override ParameterReference[] GetParameterReferences ()
		{
			return new ParameterReference[]
			{
				new ParameterReference (ParameterType.GameObject, "Player"),
			};
		}


#if UNITY_EDITOR

		protected override bool HasConditions (bool isAssetFile) { return false; }

#endif

	}

}