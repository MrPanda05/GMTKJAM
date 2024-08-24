using Commons.Singletons;
using Godot;
using System;


namespace Interactables
{
	public partial class KeyInteractable : StaticBody3D, IInteractable
	{
        public bool unique { get ; set ; }
        public Action MyInteraction { get; set; }
        [Export] public string TextOnInteract { get; set; }


        private Key myKey;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
		{
            myKey = GetParent().GetParent() as Key;
            MyInteraction += OnInteract;

        }

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

        public void OnInteract()
        {
            PlayerInvetorySingletoon.Instance.AddKey(myKey.GetMyId());
            GD.Print($"Got key of ID: {myKey.GetMyId()}");
            OnInteractionFinish();
            DialogueManager.Instance.ShowPlayerText(TextOnInteract);
            myKey.QueueFree();

        }

        public void OnInteractionFinish()
        {
            MyInteraction -= OnInteract;

        }
    }
}
