using Godot;
using System;
using System.Collections.Generic;

namespace Commons.Components
{
    public partial class SoundPool3d : Node
    {
        private List<AudioStreamPlayer3D> sounds = new List<AudioStreamPlayer3D>();
        private RandomNumberGenerator random = new RandomNumberGenerator();
        private int lastIndex = -1;

        public override void _Ready()
        {
            foreach (var child in GetChildren())
            {
                if (child is AudioStreamPlayer3D audioStreamPlayer)
                {
                    sounds.Add(audioStreamPlayer);
                }
            }
        }

        public void PlaySingleSound()
        {
            sounds[0].Play();
        }
        public void PlayRandomSound()
        {

            int index;
            do
            {
                index = random.RandiRange(0, sounds.Count - 1);
            }
            while (index == lastIndex);
            lastIndex = index;
            sounds[index].Play();
        }
    }
}