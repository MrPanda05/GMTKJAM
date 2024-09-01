using Commons.Singletons;
using Godot;
using LePlayer;
using System;

namespace Interactables
{
	public partial class InteractableTrigger : Node3D
	{
		private InteractableArea area;

		private bool hasBeenInteracted;
		public override void _Ready()
		{
			area = GetNode<InteractableArea>("InteractableArea");
		}
		public void OnInteractableAreaBodyEntered(Player body)
		{
			if (hasBeenInteracted) return;

			if (area.unique)
			{
				hasBeenInteracted = true;
			}

			DialogueManager.Instance.ShowPlayerText(area.TextOnInteract);
		}

    }
}
