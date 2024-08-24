using Godot;
using System;

namespace Interactables
{
    public interface IInteractable
    {
        public bool unique { get; set; }//true mean it will only run once
        Action MyInteraction { get; set; }
        public string TextOnInteract { get; set; }

        void OnInteract();
        void OnInteractionFinish();
    }
}
