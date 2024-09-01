using Commons.Singletons;
using Godot;
using System;


namespace Interactables
{
	public partial class JumpscareTrigger : Node3D
	{
		private int count = 0;

		[Export] private InteractableArea area;

		public Action OnJumpScareReady;
		public override void _Ready()
		{
			area.OnInteract += Ints;
		}

		public void Ints()
		{
			count++;
			if(count >= 1 && count < 2)
			{
				DialogueManager.Instance.ShowPlayerText("W-what? w-why is not openning? it is stuck again? I hate this house...");
			}
			if(count >= 2)
			{
				TriggerJumpscare();
            }
		}
		public void TriggerJumpscare()
		{
			area.DisableSelf();
			OnJumpScareReady?.Invoke();

        }
	}
}
