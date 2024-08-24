using Godot;
using Interactables;
using System;

namespace LePlayer
{
	public partial class Head : Node3D
	{
		private RayCast3D raycast;
		private TextureRect textureRect;

		public Action IsOnInteractable;
		public Action OnInteractionLeft;
		public override void _Ready()
		{
			raycast = GetNode<RayCast3D>("Camera3D/RayCast3D");
			textureRect = GetNode<TextureRect>("../PlayerHud/TextureRect");

		}

		public override void _Process(double delta)
		{
			//GD.Print(raycast.GetCollider());
			if(raycast.GetCollider() is IInteractable pingas)
			{
				textureRect.Modulate = new Color(255, 0, 0);
				IsOnInteractable?.Invoke();

                if (Input.IsActionJustPressed("Interact"))
				{
					pingas.MyInteraction?.Invoke();
				}
			}
			else
			{
                textureRect.Modulate = new Color(0, 255, 0);
				OnInteractionLeft?.Invoke();
            }
		}
	}
}
