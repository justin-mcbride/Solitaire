using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Pile {
        private Field parent;
        public List<Card> list;
        public Stack<Card> stack;
        public Queue<Card> queue;
        public int initialCardAmount { get; set;}
        public Rectangle rectPos;
        private string type;

        public Pile(Field parent, Rectangle pos) {
            this.parent = parent;
            initialCardAmount = 12;
            rectPos = pos;
            this.type = "stack";
            Init();
        }

        public Pile(Field parent, int initial, Rectangle pos) {
            this.parent = parent;
            initialCardAmount = initial;
            rectPos = pos;
            this.type = "stack";
            Init();
        }

        public Pile(Field parent, int initial, Rectangle pos, string type) {
            this.parent = parent;
            initialCardAmount = initial;
            rectPos = pos;
            this.type = type;
            Init();
        }

        public Pile(Field parent, string type) {
            this.parent = parent;
            this.type = type;
            Init();
        }

        private void Init() {
            stack = new Stack<Card>();
            list = new List<Card>();
            queue = new Queue<Card>();
        }
    }

    public class Field {
        Game parent;

        // Textures
        public Texture2D h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, hj, hq, hk;
        public Texture2D d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, dj, dq, dk;
        public Texture2D s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, sj, sq, sk;
        public Texture2D c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, cj, cq, ck;
        public Texture2D backOfCard, emptySlot;

        public Pile[] columns, aces;
        public Pile currentCards;
        public Pile shuffledDeck, outDeck;
        public Collection<Card> visibleCards;
        public Vector2 firstColumnPosition, deckPilePosition, firstAcePosition, imageDimensions;
        private int horizontalColumnSeparation, verticalCardSeparation;

        public Field(Game in_parent) {
            parent = in_parent;
            this.LoadCardPics();
        }

        public void LoadCardPics() {
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
            emptySlot = parent.Content.Load<Texture2D>("Cards/emptySlot");
            imageDimensions = new Vector2(backOfCard.Width, backOfCard.Height);

        }

        public void Init() {
            horizontalColumnSeparation = (int)imageDimensions.X + 10;
            verticalCardSeparation = 15;
            this.deckPilePosition = new Vector2(15, 15);
            this.firstColumnPosition = new Vector2(deckPilePosition.X, deckPilePosition.Y + imageDimensions.Y + 30);
            this.firstAcePosition = new Vector2(deckPilePosition.X + imageDimensions.X + 150, deckPilePosition.Y);
            this.shuffledDeck = new Pile(this, "queue");
            this.shuffledDeck.rectPos = new Rectangle((int)deckPilePosition.X, (int)deckPilePosition.Y, (int)imageDimensions.X, (int)imageDimensions.Y);
            columns = new Pile[7];
            aces = new Pile[4];
            for (int i = 0; i < 7; i++) {
                if (i == 0) {
                    columns[i] = new Pile(this, 1, new Rectangle((int)firstColumnPosition.X, (int)firstColumnPosition.Y, (int)imageDimensions.X, 0));
                }
                else {
                    columns[i] = new Pile(this, i + 1, new Rectangle((columns[i - 1].rectPos.X + horizontalColumnSeparation), columns[i - 1].rectPos.Y, columns[i - 1].rectPos.Width, columns[i - 1].rectPos.Height));
                }
            }

            for (int i = 0; i < 4; i++) {
                if (i == 0) {
                    aces[i] = new Pile(this, new Rectangle((int)firstAcePosition.X, (int)firstAcePosition.Y, (int)imageDimensions.X, 0));
                }
                else {
                    aces[i] = new Pile(this, new Rectangle((aces[i - 1].rectPos.X + horizontalColumnSeparation), aces[i - 1].rectPos.Y, aces[i - 1].rectPos.Width, aces[i - 1].rectPos.Height));
                }
            }
            this.currentCards = new Pile(this, 3, new Rectangle((int)deckPilePosition.X + horizontalColumnSeparation, (int)deckPilePosition.Y, (int)imageDimensions.X * 2, (int)imageDimensions.Y));
            this.ShuffleDeck();
        }

        public void ShuffleDeck() {
            var cards = Enumerable.Range(0, 51);
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid());
            foreach (int item in shuffledcards) {
                this.shuffledDeck.queue.Enqueue(parent.normalDeck[item]);
            }
        }

        public void SetupGame() {
            for (int i = 0; i < columns.Count<Pile>(); i++) {
                for (int j = 0; j < columns[i].initialCardAmount; j++) {
                    columns[i].stack.Push(shuffledDeck.queue.Dequeue());
                    if (j == columns[i].initialCardAmount) columns[i].stack.Peek().Flipped = true;
                }
            }
        }

        public void Update() {
            UpdateCardPositions();
        }

        public void UpdateCardPositions() {
            for (int i = 0; i < columns.Count<Pile>(); i++) {
                for (int j = 0; j < columns[i].stack.Count; j++) {
                    Card currentCard =  columns[i].stack.ElementAt<Card>(j);
                    currentCard.CurrentPos = new Vector2((firstColumnPosition.X + (i * horizontalColumnSeparation)), (firstColumnPosition.Y + (j * verticalCardSeparation)));
                }
            }

            //for (int i = 0; i < aces.Count<Pile>(); i++) {
            //    if (aces[i].stack.Count == 0) 
            //}
        }

        public void Draw() {
            var draw = parent.spriteBatch;
            if (shuffledDeck.queue.Count > 3) draw.Draw(backOfCard, shuffledDeck.rectPos, Color.White);
            else draw.Draw(emptySlot, shuffledDeck.rectPos, Color.White);

            for (int i = 0; i < aces.Count<Pile>(); i++) {
                if (aces[i].stack.Count == 0) draw.Draw(emptySlot, new Vector2(((int)firstAcePosition.X + (horizontalColumnSeparation * i)), firstAcePosition.Y), Color.White);
                else draw.Draw(aces[i].stack.ElementAt<Card>(i).Texture, new Vector2(((int)firstAcePosition.X + (horizontalColumnSeparation * i)), firstAcePosition.Y), Color.White);
            }

            foreach (var column in columns) {
                if (column.stack.Count == 0) draw.Draw(emptySlot, column.rectPos, Color.White);
                 else foreach (var card in column.stack) {
                     draw.Draw(card.Texture, card.CurrentPos, Color.White);
                }
            }
        }

        protected void AddVisibleLists() {
            visibleCards = new Collection<Card>();
            for (int i = 0; i < columns.Count<Pile>(); i++) {
                for (int j = 0; j < columns[i].stack.Count; j++) {
                    visibleCards.Add(columns[i].stack.ElementAt<Card>(j));
                }
            }
            for (int i = 0; i < aces.Count<Pile>(); i++) {
                for (int j = 0; j < aces[j].stack.Count; j++) {
                    visibleCards.Add(aces[i].stack.ElementAt<Card>(j));
                }
            }
            for (int i = 0; i < currentCards.stack.Count; i++) {
                visibleCards.Add(currentCards.stack.ElementAt<Card>(i));
            }
            foreach (var item in currentCards.stack) {
                visibleCards.Add(item);
            }
        }
    }
}
