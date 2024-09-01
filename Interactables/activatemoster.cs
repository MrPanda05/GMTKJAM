using Godot;
using System;

namespace Interactables
{
	public partial class activatemoster : Node3D
	{
		[Export] private InteractableArea area;

		[Export] private InteractableArea bedNode, bathDoor, jumpscareTrigger;
        public override void _Ready()
        {
			area.OnInteract += ActivateBixo;
        }
        public void ActivateBixo()
		{
			if (area.unique) return;
			bedNode.EnableSelf();
			bathDoor.DisableSelf();
            jumpscareTrigger.EnableSelf();
            area.unique = true;
			area.DisableSelf();
		}
	}
}
