using System;
using System.Collections.Generic;

namespace Game
{
    public class DeckService
    {
        private readonly string _trumpSuit;

        public DeckService(string trumpSuit)
        {
            _trumpSuit = trumpSuit;
        }

        /// <summary>
        /// Создаёт полную колоду карт
        /// </summary>
        public List<Card> CreateDeck(Guid sessionId, List<Guid> playerIds)
        {
            var suits = new[] { "♠", "♥", "♦", "♣" };
            var ranks = new[] { "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

            var deck = new List<Card>();
            int index = 0;

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card
                    {
                        Id = Guid.NewGuid(),
                        Suit = suit,
                        Rank = rank,
                        IsTrump = suit == _trumpSuit,
                        GameSessionId = sessionId,
                        PlayerInGameId = playerIds[index % playerIds.Count], // Раздача поочерёдно
                        TurnId = null
                    };

                    deck.Add(card);
                    index++;
                }
            }

            return Shuffle(deck);
        }

        /// <summary>
        /// Перемешивает колоду
        /// </summary>
        private List<Card> Shuffle(List<Card> deck)
        {
            var random = new Random();
            return deck.OrderBy(x => random.Next()).ToList();
        }
    }
}