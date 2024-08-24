using Commons.Singletons;
using Godot;
using System;

namespace Interactables
{
	public partial class InfoInteractable : StaticBody3D, IInteractable
	{
        public bool unique { get ; set ; }
        public Action MyInteraction { get; set; }
        [Export] public string TextOnInteract { get; set; }

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
		{
            MyInteraction += OnInteract;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

        public void OnInteract()
        {
            DialogueManager.Instance.ShowPlayerText(TextOnInteract);
        }

        public void OnInteractionFinish()
        {
            
        }
    }
}
