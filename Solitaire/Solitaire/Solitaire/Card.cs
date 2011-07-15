using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Solitaire {
    public class Card {
        Game parent;
        Rectangle rectPos;
        

        // Properties
        public bool Flipped { get; set; }
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 lastPos { get; set; }
        public string Color { get; set; }
        public Vector2 CurrentPos { get; set; }
        public Pile CurrentPile { get; set; }

        // Default Constructor
        public Card(Game parent, string name, Texture2D texture, Vector2 pos, string color) {
            this.parent = parent;
            Name = name;
            Texture = texture;
            lastPos = pos;
            CurrentPos = pos;
            Color = color;

            this.rectPos = new Rectangle((int)CurrentPos.X, (int)CurrentPos.Y, Texture.Width, Texture.Width);
            Flipped = false;
        }
    }
}
