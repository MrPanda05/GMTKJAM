using Godot;
using System;


namespace Interactables
{
	public partial class BasicInteraction : Node3D
	{
		private InteractableArea area;

        public override void _Ready()
        {
            area = GetNode<InteractableArea>("InteractableArea");
            area.OnInteract += PrintSomething;
        }

        public void PrintSomething()
        {
            GD.Print("Love cum");
        }
    }
}
