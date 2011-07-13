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
    public class Field {
        Game parent;
        public Texture2D h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, hj, hq, hk;
        public Texture2D d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, dj, dq, dk;
        public Texture2D s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, sj, sq, sk;
        public Texture2D c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, cj, cq, ck;
        public Texture2D backOfCard;
        public List<Card> shuffledDeck, col0, col1, col2, col3, col4, col5, col6, ace1, ace2, ace3, ace4, currentCards;
        private Vector2 deckV, ace1V, ace2V, ace3V, ace4V, col1V, col2V, col3V, col4V, col5V, col6V, currentV;

        public Field(Game in_parent) {
            parent = in_parent;
            this.Load();
        }

        public void Load() {
            /*
             * Hearts
             */
            h1 = parent.Content.Load<Texture2D>("Cards/Hearts/h1");
            h2 = parent.Content.Load<Texture2D>("Cards/Hearts/h2");
            h3 = parent.Content.Load<Texture2D>("Cards/Hearts/h3");
            h4 = parent.Content.Load<Texture2D>("Cards/Hearts/h4");
            h5 = parent.Content.Load<Texture2D>("Cards/Hearts/h5");
            h6 = parent.Content.Load<Texture2D>("Cards/Hearts/h6");
            h7 = parent.Content.Load<Texture2D>("Cards/Hearts/h7");
            h8 = parent.Content.Load<Texture2D>("Cards/Hearts/h8");
            h9 = parent.Content.Load<Texture2D>("Cards/Hearts/h9");
            h10 = parent.Content.Load<Texture2D>("Cards/Hearts/h10");
            hj = parent.Content.Load<Texture2D>("Cards/Hearts/hj");
            hq = parent.Content.Load<Texture2D>("Cards/Hearts/hq");
            hk = parent.Content.Load<Texture2D>("Cards/Hearts/hk");

            /*
             * Diamonds
             */
            d1 = parent.Content.Load<Texture2D>("Cards/Diamonds/d1");
            d2 = parent.Content.Load<Texture2D>("Cards/Diamonds/d2");
            d3 = parent.Content.Load<Texture2D>("Cards/Diamonds/d3");
            d4 = parent.Content.Load<Texture2D>("Cards/Diamonds/d4");
            d5 = parent.Content.Load<Texture2D>("Cards/Diamonds/d5");
            d6 = parent.Content.Load<Texture2D>("Cards/Diamonds/d6");
            d7 = parent.Content.Load<Texture2D>("Cards/Diamonds/d7");
            d8 = parent.Content.Load<Texture2D>("Cards/Diamonds/d8");
            d9 = parent.Content.Load<Texture2D>("Cards/Diamonds/d9");
            d10 = parent.Content.Load<Texture2D>("Cards/Diamonds/d10");
            dj = parent.Content.Load<Texture2D>("Cards/Diamonds/dj");
            dq = parent.Content.Load<Texture2D>("Cards/Diamonds/dq");
            dk = parent.Content.Load<Texture2D>("Cards/Diamonds/dk");

            /*
             * Spades
             */
            s1 = parent.Content.Load<Texture2D>("Cards/Spades/s1");
            s2 = parent.Content.Load<Texture2D>("Cards/Spades/s2");
            s3 = parent.Content.Load<Texture2D>("Cards/Spades/s3");
            s4 = parent.Content.Load<Texture2D>("Cards/Spades/s4");
            s5 = parent.Content.Load<Texture2D>("Cards/Spades/s5");
            s6 = parent.Content.Load<Texture2D>("Cards/Spades/s6");
            s7 = parent.Content.Load<Texture2D>("Cards/Spades/s7");
            s8 = parent.Content.Load<Texture2D>("Cards/Spades/s8");
            s9 = parent.Content.Load<Texture2D>("Cards/Spades/s9");
            s10 = parent.Content.Load<Texture2D>("Cards/Spades/s10");
            sj = parent.Content.Load<Texture2D>("Cards/Spades/sj");
            sq = parent.Content.Load<Texture2D>("Cards/Spades/sq");
            sk = parent.Content.Load<Texture2D>("Cards/Spades/sk");

            /* 
             * Clubs
             */
            c1 = parent.Content.Load<Texture2D>("Cards/Clubs/c1");
            c2 = parent.Content.Load<Texture2D>("Cards/Clubs/c2");
            c3 = parent.Content.Load<Texture2D>("Cards/Clubs/c3");
            c4 = parent.Content.Load<Texture2D>("Cards/Clubs/c4");
            c5 = parent.Content.Load<Texture2D>("Cards/Clubs/c5");
            c6 = parent.Content.Load<Texture2D>("Cards/Clubs/c6");
            c7 = parent.Content.Load<Texture2D>("Cards/Clubs/c7");
            c8 = parent.Content.Load<Texture2D>("Cards/Clubs/c8");
            c9 = parent.Content.Load<Texture2D>("Cards/Clubs/c9");
            c10 = parent.Content.Load<Texture2D>("Cards/Clubs/c10");
            cj = parent.Content.Load<Texture2D>("Cards/Clubs/cj");
            cq = parent.Content.Load<Texture2D>("Cards/Clubs/cq");
            ck = parent.Content.Load<Texture2D>("Cards/Clubs/ck");

            /*
             * Misc
             */
            backOfCard = parent.Content.Load<Texture2D>("Cards/cardBack");
        }

        public void Init() {
            this.shuffledDeck = new List<Card>();
            this.col0 = new List<Card>();
            this.col1 = new List<Card>();
            this.col2 = new List<Card>();
            this.col3 = new List<Card>();
            this.col4 = new List<Card>();
            this.col5 = new List<Card>();
            this.col6 = new List<Card>();
            this.ace1 = new List<Card>();
            this.ace2 = new List<Card>();
            this.ace3 = new List<Card>();
            this.ace4 = new List<Card>();
            this.currentCards = new List<Card>();
            this.ShuffleDeck();
        }

        public void ShuffleDeck() {
            Console.WriteLine("shuffle deck");
            var cards = Enumerable.Range(0, 51);
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid());
            foreach (int item in shuffledcards) {
                this.shuffledDeck.Add(parent.normalDeck[item]);
            }
            this.DESTROY();
        }

        public void Draw() {
            var draw = parent.spriteBatch;

            foreach (var item in shuffledDeck) {
                draw.Draw(item.Texture, item.CurrentPos, Color.White);
            }
        }

        public void DESTROY() {
            for (var x = 0; x < this.shuffledDeck.Count; x++) {
                shuffledDeck.ElementAtOrDefault<Card>(x).CurrentPos = new Vector2(x * 75, 0);
            }
        }
    }
}
