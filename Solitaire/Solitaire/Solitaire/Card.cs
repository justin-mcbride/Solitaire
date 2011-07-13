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
        string name, color;
        Texture2D tex;
        Vector2 lastGoodPos, currentPos;

        // Properties
        public string Name { get { return this.name; } set { this.name = value; } }
        public Texture2D Texture { get { return this.tex; } set { this.tex = value; } }
        public Vector2 lastPos { get { return this.lastGoodPos; } set { this.lastGoodPos = value; } }
        public string Color { get { return this.color; } set { this.color = value; } }
        public Vector2 CurrentPos { get { return this.currentPos; } set { this.currentPos = value; } }

        // Default Constructor
        public Card(Game parent, string name, Texture2D texture, Vector2 pos, string color) {
            this.parent = parent;
            this.name = name;
            this.tex = texture;
            this.lastGoodPos = pos;
            this.color = color;
            this.currentPos = pos;
        }
    }
}
