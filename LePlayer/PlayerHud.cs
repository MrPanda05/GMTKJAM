using Godot;
using System;

namespace LePlayer
{
	public partial class PlayerHud : Control
	{
		private Head head;

        [Export]
        private Label interactLabel, monologueLabel;

        public override void _Ready()
        {
            interactLabel.Visible = false;
            monologueLabel.Visible = false;
            head = GetNode<Head>("../Head");
            head.IsOnInteractable += ActivateLabel;
            head.OnInteractionLeft += DeactivateLabel;
        }
        public void ActivateLabel()
        {
            interactLabel.Visible = true;
        }
        public void DeactivateLabel()
        {
            interactLabel.Visible = false;
        }
    }
}
