using Godot;
using System;

namespace Interactables
{
    public partial class InteractableTest : StaticBody3D, IInteractable
    {
        public Action MyInteraction { get; set; }
        [Export]public bool unique { get; set; }

        public string TextOnInteract { get; set; }
        public override void _Ready()
        {
            MyInteraction += OnInteract;
        }

        public override void _ExitTree()
        {
            MyInteraction -= OnInteract;
        }
        public void OnInteractionFinish()
        {
            MyInteraction -= OnInteract;
        }
        public void OnInteract()
        {
            if(unique)
            {
                GD.Print("I have been invoked only this time");
                OnInteractionFinish();
                return;
            }
            GD.Print("I have been invoked");

        }
    }
}
