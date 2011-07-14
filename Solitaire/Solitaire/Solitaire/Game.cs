using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Solitaire {

    public class Game : Microsoft.Xna.Framework.Game {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        Field cards;
        public Card[] normalDeck;
        protected Card lastClicked;
        public MouseState mouseState, pMouseState;
        private bool mouseDrag;
        

        public Game() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mouseDrag = false;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 410;
            graphics.ApplyChanges();
            mouseState = new MouseState();
            pMouseState = new MouseState();
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent() {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.NewGame();
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            pMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && pMouseState.LeftButton == ButtonState.Released) MouseClick();
            if (mouseState.LeftButton == ButtonState.Pressed && pMouseState.LeftButton == ButtonState.Pressed) this.mouseDrag = true;
                else this.mouseDrag = false;

            cards.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Begin();
            cards.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void createCards() {
            /*
             * Hearts
             */
            normalDeck[0] = new Card(this, "Hearts Ace", cards.h1, new Vector2(0, 0), "red");
            normalDeck[1] = new Card(this, "Hearts 2", cards.h2, new Vector2(0, 0), "red");
            normalDeck[2] = new Card(this, "Hearts 3", cards.h3, new Vector2(0, 0), "red");
            normalDeck[3] = new Card(this, "Hearts 4", cards.h4, new Vector2(0, 0), "red");
            normalDeck[4] = new Card(this, "Hearts 5", cards.h5, new Vector2(0, 0), "red");
            normalDeck[5] = new Card(this, "Hearts 6", cards.h6, new Vector2(0, 0), "red");
            normalDeck[6] = new Card(this, "Hearts 7", cards.h7, new Vector2(0, 0), "red");
            normalDeck[7] = new Card(this, "Hearts 8", cards.h8, new Vector2(0, 0), "red");
            normalDeck[8] = new Card(this, "Hearts 9", cards.h9, new Vector2(0, 0), "red");
            normalDeck[9] = new Card(this, "Hearts 10", cards.h10, new Vector2(0, 0), "red");
            normalDeck[10] = new Card(this, "Hearts Jack", cards.hj, new Vector2(0, 0), "red");
            normalDeck[11] = new Card(this, "Hearts Queen", cards.hq, new Vector2(0, 0), "red");
            normalDeck[12] = new Card(this, "Hearts King", cards.hk, new Vector2(0, 0), "red");

            /* 
             * Diamonds
             */
            normalDeck[13] = new Card(this, "Diamonds Ace", cards.d1, new Vector2(0, 0), "red");
            normalDeck[14] = new Card(this, "Diamonds 2", cards.d2, new Vector2(0, 0), "red");
            normalDeck[15] = new Card(this, "Diamonds 3", cards.d3, new Vector2(0, 0), "red");
            normalDeck[16] = new Card(this, "Diamonds 4", cards.d4, new Vector2(0, 0), "red");
            normalDeck[17] = new Card(this, "Diamonds 5", cards.d5, new Vector2(0, 0), "red");
            normalDeck[18] = new Card(this, "Diamonds 6", cards.d6, new Vector2(0, 0), "red");
            normalDeck[19] = new Card(this, "Diamonds 7", cards.d7, new Vector2(0, 0), "red");
            normalDeck[20] = new Card(this, "Diamonds 8", cards.d8, new Vector2(0, 0), "red");
            normalDeck[21] = new Card(this, "Diamonds 9", cards.d9, new Vector2(0, 0), "red");
            normalDeck[22] = new Card(this, "Diamonds 10", cards.d10, new Vector2(0, 0), "red");
            normalDeck[23] = new Card(this, "Diamonds Jack", cards.dj, new Vector2(0, 0), "red");
            normalDeck[24] = new Card(this, "Diamonds Queen", cards.dq, new Vector2(0, 0), "red");
            normalDeck[25] = new Card(this, "Diamonds King", cards.dk, new Vector2(0, 0), "red");

            /*
             * Spades
             */
            normalDeck[26] = new Card(this, "Spades Ace", cards.s1, new Vector2(0, 0), "black");
            normalDeck[27] = new Card(this, "Spades 2", cards.s2, new Vector2(0, 0), "black");
            normalDeck[28] = new Card(this, "Spades 3", cards.s3, new Vector2(0, 0), "black");
            normalDeck[29] = new Card(this, "Spades 4", cards.s4, new Vector2(0, 0), "black");
            normalDeck[30] = new Card(this, "Spades 5", cards.s5, new Vector2(0, 0), "black");
            normalDeck[31] = new Card(this, "Spades 6", cards.s6, new Vector2(0, 0), "black");
            normalDeck[32] = new Card(this, "Spades 7", cards.s7, new Vector2(0, 0), "black");
            normalDeck[33] = new Card(this, "Spades 8", cards.s8, new Vector2(0, 0), "black");
            normalDeck[34] = new Card(this, "Spades 9", cards.s9, new Vector2(0, 0), "black");
            normalDeck[35] = new Card(this, "Spades 10", cards.s10, new Vector2(0, 0), "black");
            normalDeck[36] = new Card(this, "Spades Jack", cards.sj, new Vector2(0, 0), "black");
            normalDeck[37] = new Card(this, "Spades Queen", cards.sq, new Vector2(0, 0), "black");
            normalDeck[38] = new Card(this, "Spades King", cards.sk, new Vector2(0, 0), "black");

            /*
             * Clubs
             */
            normalDeck[39] = new Card(this, "Clubs Ace", cards.c1, new Vector2(0, 0), "black");
            normalDeck[40] = new Card(this, "Clubs 2", cards.c2, new Vector2(0, 0), "black");
            normalDeck[41] = new Card(this, "Clubs 3", cards.c3, new Vector2(0, 0), "black");
            normalDeck[42] = new Card(this, "Clubs 4", cards.c4, new Vector2(0, 0), "black");
            normalDeck[43] = new Card(this, "Clubs 5", cards.c5, new Vector2(0, 0), "black");
            normalDeck[44] = new Card(this, "Clubs 6", cards.c6, new Vector2(0, 0), "black");
            normalDeck[45] = new Card(this, "Clubs 7", cards.c7, new Vector2(0, 0), "black");
            normalDeck[46] = new Card(this, "Clubs 8", cards.c8, new Vector2(0, 0), "black");
            normalDeck[47] = new Card(this, "Clubs 9", cards.c9, new Vector2(0, 0), "black");
            normalDeck[48] = new Card(this, "Clubs 10", cards.c10, new Vector2(0, 0), "black");
            normalDeck[49] = new Card(this, "Clubs Jack", cards.cj, new Vector2(0, 0), "black");
            normalDeck[50] = new Card(this, "Clubs Queen", cards.cq, new Vector2(0, 0), "black");
            normalDeck[51] = new Card(this, "Clubs King", cards.ck, new Vector2(0, 0), "black");
        }

        public void NewGame() {
            this.cards = new Field(this);
            this.normalDeck = new Card[52];
            this.createCards();
            cards.Init();
            cards.SetupGame();
        }

        protected void MouseClick() {
            foreach (var item in normalDeck) {
                //change to something else...
            }
        }

        protected void MouseDrag() {

        }
    }
}
