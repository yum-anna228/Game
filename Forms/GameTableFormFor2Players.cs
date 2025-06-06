﻿using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;
using NLog;

namespace Game
{
    public partial class GameTableFormFor2Players : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private System.Windows.Forms.Timer _uiUpdateTimer;
        private readonly GameDbContext _db;
        private Guid _gameSessionId;
        private Guid _playerInGameId;
        private DurakGameLogic _gameLogic;
        private bool _deckFinished = false;

        public GameTableFormFor2Players(GameDbContext db)
        {
            try
            {
                // Получаем сохранённую культуру
                var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
                var culture = new CultureInfo(cultureName);
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;

                if (db == null)
                {
                    MessageBox.Show("Ошибка: База данных не инициализирована");
                    throw new ArgumentNullException(nameof(db));
                }

                InitializeComponent();
                _db = db;

                StartUIUpdateTimer();
                LoadPlayerCards();
                ShowTrump();
                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в конструкторе формы:\n{ex.Message}\n\n{ex.StackTrace}");
                logger.Error(ex, "Ошибка при создании GameTableFormFor2Players");
            }
        }

        public void SetPlayerInGame(Guid sessionId, Guid playerInGameId)
        {
            _gameSessionId = sessionId;
            _playerInGameId = playerInGameId;
            var session = _db.GameSessions.Find(sessionId);
            if (session == null)
            {
                MessageBox.Show("Ошибка: Сессия не найдена");
                return;
            }
            _gameLogic = new DurakGameLogic(_db, _gameSessionId);
            _deckFinished = false;
            LoadPlayerCards();
            ShowTrump();
            UpdateStatus();
        }

        private void StartUIUpdateTimer()
        {
            _uiUpdateTimer = new System.Windows.Forms.Timer();
            _uiUpdateTimer.Interval = 1000;
            _uiUpdateTimer.Tick += (s, e) =>
            {
                this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    LoadPlayerCards();
                    UpdateTable();
                    UpdateStatus();
                });
            };
            _uiUpdateTimer.Start();
        }

        private void LoadPlayerCards()
        {
            if (flowLayoutPanelYourCards == null)
            {
                logger.Warn("flowLayoutPanelYourCards == null");
                return;
            }

            var cards = _db.Cards
                .Where(c => c.PlayerInGameId == _playerInGameId && c.GameSessionId == _gameSessionId)
                .Take(6)
                .ToList();

            flowLayoutPanelYourCards.Controls.Clear();
            foreach (var card in cards)
            {
                var btn = new Button
                {
                    Text = $"{card.Suit}{card.Rank}",
                    Width = 80,
                    Height = 120,
                    Font = new Font("Arial", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = card
                };
                btn.Click += CardButton_Click;
                flowLayoutPanelYourCards.Controls.Add(btn);
            }
        }

        private async void CardButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var card = btn?.Tag as Card;
            if (card == null) return;
            var player = _db.PlayerInGames.Find(_playerInGameId);
            if (player == null) return;
            try
            {
                if (player.IsAttacker)
                {
                    await _gameLogic.MakeAttackAsync(_playerInGameId, card);
                    logger.Info($"Игрок атакует картой: {card.Suit}{card.Rank}");
                }
                else if (player.IsDefender)
                {
                    var attackCards = _db.Cards
                        .Where(c => c.TurnId.HasValue &&
                                    c.GameSessionId == _gameSessionId &&
                                    c.PlayerInGameId != _playerInGameId)
                        .ToList();
                    if (!attackCards.Any())
                    {
                        MessageBox.Show("Нет карт для отбития");
                        return;
                    }
                    var lastAttackCard = attackCards.Last();
                    if (_gameLogic.CanBeat(lastAttackCard, card))
                    {
                        await _gameLogic.MakeDefenceAsync(_playerInGameId, card, lastAttackCard);
                        logger.Info($"Игрок отбивается картой: {card.Suit}{card.Rank} против {lastAttackCard.Suit}{lastAttackCard.Rank}");
                    }
                    else
                    {
                        MessageBox.Show($"Нельзя отбить {lastAttackCard.Suit}{lastAttackCard.Rank} картой {card.Suit}{card.Rank}");
                        return;
                    }
                }
                await _db.SaveChangesAsync();
                LoadPlayerCards();
                UpdateTable();
                UpdateStatus();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка при обработке хода");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateTable()
        {
            if (flowLayoutPanelTable == null)
            {
                logger.Warn("flowLayoutPanelTable == null");
                return;
            }

            var playedCards = _db.Cards
                .Where(c => c.TurnId.HasValue && c.GameSessionId == _gameSessionId)
                .ToList();

            flowLayoutPanelTable.Controls.Clear();
            foreach (var card in playedCards)
            {
                var label = new Label
                {
                    Text = $"{card.Suit}{card.Rank}",
                    Width = 80,
                    Height = 120,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                flowLayoutPanelTable.Controls.Add(label);
            }
        }

        private async void btnNextTurn_Click(object sender, EventArgs e)
        {
            await SwitchTurnAsync();
            LoadPlayerCards();
            UpdateTable();
            UpdateStatus();
        }

        private Guid GetNextPlayerId()
        {
            return _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .FirstOrDefault(p => p.Id != _playerInGameId)?.Id ?? Guid.Empty;
        }

        private void ShowTrump()
        {
            if (lblTrumpSuit == null)
            {
                logger.Warn("lblTrumpSuit == null");
                return;
            }

            var session = _db.GameSessions.Find(_gameSessionId);
            if (session != null)
            {
                lblTrumpSuit.Text = $"Козырь: {session.TrumpSuit}";
                logger.Debug($"Козырь: {session.TrumpSuit}");
            }
        }

        private async void btnBit_Click(object sender, EventArgs e)
        {
            var playedCards = _db.Cards.Where(c => c.TurnId.HasValue).ToList();
            if (playedCards.Count == 0) return;
            foreach (var card in playedCards)
            {
                card.TurnId = null;
            }
            _db.Cards.UpdateRange(playedCards);
            await _db.SaveChangesAsync();
            await SwitchTurnAsync();
        }

        private async void btnTake_Click(object sender, EventArgs e)
        {
            var playedCards = _db.Cards.Where(c => c.TurnId.HasValue).ToList();
            if (playedCards.Count == 0) return;
            foreach (var card in playedCards)
            {
                card.TurnId = null;
                card.PlayerInGameId = _playerInGameId;
            }
            _db.Cards.UpdateRange(playedCards);
            await _db.SaveChangesAsync();
            LoadPlayerCards();
            UpdateTable();
        }

        private async Task SwitchTurnAsync()
        {
            var players = _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .ToList();
            if (players.Count != 2)
            {
                MessageBox.Show("Неверное количество игроков");
                return;
            }
            var attacker = players.FirstOrDefault(p => p.IsAttacker);
            var defender = players.FirstOrDefault(p => p.IsDefender);
            if (attacker == null || defender == null)
            {
                MessageBox.Show("Не определены роли игроков");
                return;
            }
            attacker.IsAttacker = false;
            defender.IsAttacker = true;
            attacker.IsDefender = true;
            defender.IsDefender = false;
            _db.PlayerInGames.UpdateRange(players);
            await _db.SaveChangesAsync();
            await DrawCardsIfNeeded();
            await CheckWinCondition();
        }

        private void UpdateStatus()
        {
            if (lblStatus == null)
            {
                logger.Warn("lblStatus == null");
                return;
            }

            var player = _db.PlayerInGames.Find(_playerInGameId);
            if (player != null)
            {
                lblStatus.Text = player.IsAttacker ? "Вы атакуете" : "Вы защищаетесь";
            }
        }

        private async Task DrawCardsIfNeeded()
        {
            var playerCards = _db.Cards
                .Where(c => c.PlayerInGameId == _playerInGameId)
                .ToList();
            int cardsNeeded = 6 - playerCards.Count;
            if (cardsNeeded <= 0) return;
            var availableCards = _db.Cards
                .Where(c => c.PlayerInGameId == null || c.PlayerInGameId == Guid.Empty)
                .Take(cardsNeeded)
                .ToList();
            foreach (var card in availableCards)
            {
                card.PlayerInGameId = _playerInGameId;
            }
            _db.Cards.UpdateRange(availableCards);
            await _db.SaveChangesAsync();
            LoadPlayerCards();
            UpdateStatus();
            await CheckWinCondition();
        }

        private async Task CheckWinCondition()
        {
            if (_deckFinished) return;
            var players = await _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .ToListAsync();
            if (players.Count != 2) return;
            var player1 = players[0];
            var player2 = players[1];
            var player1Cards = await _db.Cards
                .CountAsync(c => c.PlayerInGameId == player1.Id && c.TurnId == null);
            var player2Cards = await _db.Cards
                .CountAsync(c => c.PlayerInGameId == player2.Id && c.TurnId == null);
            var remainingDeckCount = await _db.Cards
                .CountAsync(c => c.PlayerInGameId == null);

            if (remainingDeckCount == 0)
            {
                if (player1Cards == 0 && player2Cards == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Ничья! Оба игрока не имеют карт.");
                    });
                    _deckFinished = true;
                    return;
                }
                if (player1Cards > player2Cards)
                {
                    await HandleGameEnd(player1.Id == _playerInGameId);
                    return;
                }
                else if (player2Cards > player1Cards)
                {
                    await HandleGameEnd(player2.Id == _playerInGameId);
                    return;
                }
            }
        }

        private async Task HandleGameEnd(bool isWinner)
        {
            string message = isWinner ? "🎉 Ура! Вы выиграли!" : "😭 К сожалению, вы проиграли.";
            logger.Info($"Игрок {_playerInGameId} {(isWinner ? "выиграл" : "проиграл")}");

            await UpdatePlayerStatistics(isWinner);
            this.Invoke((MethodInvoker)delegate
            {
                using (var winLoseForm = new WinningForm(message, _db))
                {
                    winLoseForm.ShowDialog(this);
                }
            });
            _deckFinished = true;
        }

        private async Task UpdatePlayerStatistics(bool isWinner)
        {
            var userInGame = _db.PlayerInGames.Find(_playerInGameId);
            if (userInGame == null)
            {
                logger.Warn("Не найден PlayerInGame");
                return;
            }
            var user = _db.Users.Find(userInGame.UserId);
            if (user == null)
            {
                logger.Warn("Пользователь не найден");
                return;
            }
            var stats = await _db.PlayerStatistics
                .FirstOrDefaultAsync(s => s.UserId == user.Id);
            if (stats == null)
            {
                stats = new PlayerStatistics
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    GamesWon = isWinner ? 1 : 0,
                    GamesLost = isWinner ? 0 : 1,
                    GamesDraw = 0
                };
                _db.PlayerStatistics.Add(stats);
                logger.Info($"Создана новая статистика для пользователя {user.Id}");
            }
            else
            {
                if (isWinner)
                {
                    stats.GamesWon++;
                    logger.Info($"Победа игрока {user.Id}, всего побед: {stats.GamesWon}");
                }
                else
                {
                    stats.GamesLost++;
                    logger.Info($"Поражение игрока {user.Id}, всего поражений: {stats.GamesLost}");
                }
                _db.PlayerStatistics.Update(stats);
            }
            await _db.SaveChangesAsync();
        }

        private async void btn_Home_Click(object sender, EventArgs e)
        {
            using (var notificationForm = new NotificationForm())
            {
                notificationForm.ShowDialog(this);
                if (notificationForm.ConfirmExit)
                {
                    logger.Warn("Игрок нажал 'Выход' — игра завершается как поражение");
                    await HandleGameEnd(false);
                    this.Close();
                }
            }
        }

        private void btn_ruls_Click(object sender, EventArgs e)
        {
            logger.Debug("Игрок открыл правила игры");
            var rulesForm = new RuleForm();
            rulesForm.ShowDialog(this);
        }
    }
}