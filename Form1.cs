using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuantumSerpent
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox gameBoard;
        private Label statusLabel;
        private List<Player> players = new List<Player>();
        private List<Food> foodItems = new List<Food>();
        private Bitmap offscreenBitmap;
        private Graphics offscreenGraphics;
        private bool isGameOver = false;
        private string gameMode;
        private int aiPlayerCount;
        private Random random;
        private int fps;
        private int appleCount;
        private int foodGrowMultiplier;
        private float moveSpeed = 2.0f;
        private Dictionary<string, int> playerScores = new Dictionary<string, int>();
        private System.Windows.Forms.Timer countdownTimer; // Timer for countdown
        private int timeRemaining; // Time remaining for the countdown

        public MainForm(string selectedGameMode, int aiPlayers)
        {
            gameMode = selectedGameMode;
            aiPlayerCount = aiPlayers;
            random = new Random();
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            var settings = GameSettingsManager.Load();

            fps = settings.FPS;
            appleCount = settings.AppleCount;
            foodGrowMultiplier = settings.FoodGrowMultiplier;
            gameTimer.Interval = 1000 / fps;

            players.Clear();
            foodItems.Clear();
            playerScores.Clear();
            if (settings.IsFatSerpentMode)
            {
                StartCountdown(settings.FatSerpentTimeFrame);
            }

            if (gameMode == "Singleplayer")
            {
                InitializeSinglePlayer(settings);
            }
            else if (gameMode == "Multiplayer")
            {
                InitializeMultiPlayer(settings);
            }

            for (int i = 0; i < settings.AIPlayers; i++)
            {
                players.Add(new AIPlayer(
                    $"AIPlayer{i + 1}",
                    Color.Yellow,
                    Color.Green,
                    GenerateSafeSpawnPoint(new Point(0, 0), gameBoard.Size),
                    Direction.Right,
                    settings.InitialPlayerLength
                ));
            }

            for (int i = 0; i < appleCount; i++)
            {
                foodItems.Add(GenerateRandomFood());
            }

            gameTimer.Start();
        }

        private Food GenerateRandomFood()
        {
            int x = random.Next(0, gameBoard.Width - 20);
            int y = random.Next(0, gameBoard.Height - 20);
            return new Apple(new Point(x, y));
        }

        private void InitializeSinglePlayer(GameSettings settings)
        {
            var player1StartPos = new Point(100, 200);
            players.Add(new Player(
                settings.Player1Name,
                settings.Player1HeadColor,
                settings.Player1BodyColor,
                player1StartPos,
                Direction.Right,
                settings.InitialPlayerLength
            ));
            playerScores[settings.Player1Name] = 0;
        }

        private void InitializeMultiPlayer(GameSettings settings)
        {
            players.Add(new Player(
                settings.Player1Name,
                settings.Player1HeadColor,
                settings.Player1BodyColor,
                new Point(100, 200),
                Direction.Right,
                settings.InitialPlayerLength
            ));
            playerScores[settings.Player1Name] = 0;

            players.Add(new Player(
                settings.Player2Name,
                settings.Player2HeadColor,
                settings.Player2BodyColor,
                new Point(400, 400),
                Direction.Left,
                settings.InitialPlayerLength
            ));
            playerScores[settings.Player2Name] = 0;
        }

        private Point GenerateSafeSpawnPoint(Point otherPlayerPos, Size boardSize)
        {
            int safeDistance = 100;
            Point newSpawnPoint;
            Random rand = new Random();
            do
            {
                int x = rand.Next(safeDistance, boardSize.Width - safeDistance);
                int y = rand.Next(safeDistance, boardSize.Height - safeDistance);
                newSpawnPoint = new Point(x, y);
            } while (Math.Abs(newSpawnPoint.X - otherPlayerPos.X) < safeDistance &&
                     Math.Abs(newSpawnPoint.Y - otherPlayerPos.Y) < safeDistance);

            return newSpawnPoint;
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            if (players == null) return;

            offscreenGraphics.Clear(Color.LightGray);
            foreach (var player in players)
            {
                foreach (var part in player.BodyParts)
                {
                    offscreenGraphics.FillRectangle(new SolidBrush(player.BodyColor), new Rectangle(part, new Size(20, 20)));
                }
                offscreenGraphics.FillRectangle(new SolidBrush(player.HeadColor), new Rectangle(player.BodyParts[0], new Size(20, 20)));
            }

            foreach (var food in foodItems)
            {
                food.Draw(offscreenGraphics);
            }

            // Draw the scores
            var font = new Font("Arial", 16);
            var brush = new SolidBrush(Color.Black);
            float yPosition = 10;

            foreach (var player in players)
            {
                offscreenGraphics.DrawString($"{player.Name}: {playerScores[player.Name]}", font, brush, new PointF(10, yPosition));
                yPosition += 30;
            }

            e.Graphics.DrawImage(offscreenBitmap, 0, 0);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (players == null || isGameOver) return;

            var foodPositions = foodItems.Select(food => food.Position).ToList();
            var obstacles = players.SelectMany(player => player.BodyParts).ToList();

            foreach (var player in players)
            {
                if (player is AIPlayer aiPlayer)
                {
                    aiPlayer.MoveAI(gameBoard.Size, foodPositions, obstacles);
                }
                else
                {
                    MovePlayer(player);
                }

                player.UpdateLastBodyPartPosition();

                CheckFoodConsumption(player);

                var collisionResult = CollisionHelper.CheckCollisions(player, players, gameBoard.Size);
                if (collisionResult.Type != CollisionHelper.CollisionType.None)
                {
                    EndGame(collisionResult.Message);
                    return;
                }
            }

            gameBoard.Invalidate();
            statusLabel.Text = "Status: Running";
        }

        private void MovePlayer(Player player)
        {
            for (int i = player.BodyParts.Count - 1; i > 0; i--)
            {
                player.BodyParts[i] = player.BodyParts[i - 1];
            }

            switch (player.Direction)
            {
                case Direction.Up:
                    player.BodyParts[0] = new Point(player.BodyParts[0].X, player.BodyParts[0].Y - (int)moveSpeed);
                    break;
                case Direction.Down:
                    player.BodyParts[0] = new Point(player.BodyParts[0].X, player.BodyParts[0].Y + (int)moveSpeed);
                    break;
                case Direction.Left:
                    player.BodyParts[0] = new Point(player.BodyParts[0].X - (int)moveSpeed, player.BodyParts[0].Y);
                    break;
                case Direction.Right:
                    player.BodyParts[0] = new Point(player.BodyParts[0].X + (int)moveSpeed, player.BodyParts[0].Y);
                    break;
            }

            var head = player.BodyParts[0];
            player.BodyParts[0] = new Point(
                Math.Max(0, Math.Min(gameBoard.Width - 20, head.X)),
                Math.Max(0, Math.Min(gameBoard.Height - 20, head.Y))
            );
        }

        private void CheckFoodConsumption(Player player)
        {
            Rectangle playerHeadRect = new Rectangle(player.BodyParts[0], new Size(20, 20));

            for (int i = foodItems.Count - 1; i >= 0; i--)
            {
                Food food = foodItems[i];
                Rectangle foodRect = new Rectangle(food.Position, new Size(20, 20));

                if (playerHeadRect.IntersectsWith(foodRect))
                {
                    for (int j = 0; j < foodGrowMultiplier; j++)
                    {
                        player.AddBodyPart();
                    }

                    foodItems.RemoveAt(i);
                    foodItems.Add(GenerateRandomFood());

                    playerScores[player.Name] = player.BodyParts.Count;
                }
            }
        }

        private void EndGame(string message)
        {
            if (!isGameOver)
            {
                isGameOver = true;
                MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveHighscores();
                gameTimer.Stop();
                this.Close();
                ShowStartForm();
            }
            if (countdownTimer != null)
            {
                int max;
                // If the game mode is Fat Serpent mode, the game ends when the countdown timer reaches 0
                //The player with the longest snake wins

                // Find the player with the longest snake
                var longestSnakePlayer = players.OrderByDescending(p => p.BodyParts.Count).First();
                max = longestSnakePlayer.BodyParts.Count;

                //Return a Messagebox with the winning message
                MessageBox.Show($"Fat Serpent mode ended. {longestSnakePlayer.Name} wins with a snake length of {max}!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                countdownTimer.Stop();
                gameTimer.Stop();
                this.Close();
                ShowStartForm();
            }
        }
        private void StartCountdown(int initialTime)
        {
            timeRemaining = initialTime;
            countdownLabel.Text = $"Time Remaining: {timeRemaining}s";
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second intervals
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            countdownLabel.Text = $"Time Remaining: {timeRemaining}s";

            if (timeRemaining <= 0)
            {
                countdownTimer.Stop();
                EndGame("Time's up! Fat Serpent mode ended.");
            }
        }

        private void SaveHighscores()
        {
            var highscores = GameSettingsManager.LoadHighscores();

            foreach (var player in players)
            {
                var existingHighscore = highscores.FirstOrDefault(h => h.PlayerName == player.Name);
                if (existingHighscore != null)
                {
                    if (playerScores[player.Name] > existingHighscore.Score)
                    {
                        // Update the score if the new score is higher
                        existingHighscore.Score = playerScores[player.Name];
                    }
                }
                else
                {
                    // Add new entry if the player does not exist in the highscores list
                    highscores.Add(new Highscore { PlayerName = player.Name, Score = playerScores[player.Name] });
                }
            }

            // Sort highscores in descending order before saving
            highscores = highscores.OrderByDescending(h => h.Score).ToList();
            GameSettingsManager.SaveHighscores(highscores);
        }

        private void ShowStartForm()
        {
            var startForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            if (startForm == null)
            {
                startForm = new StartForm();
                startForm.Show();
            }
            else
            {
                startForm.Show();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (players == null) return;

            switch (e.KeyCode)
            {
                case Keys.W:
                    if (players[0].Direction != Direction.Down)
                        players[0].Direction = Direction.Up;
                    break;
                case Keys.A:
                    if (players[0].Direction != Direction.Right)
                        players[0].Direction = Direction.Left;
                    break;
                case Keys.S:
                    if (players[0].Direction != Direction.Up)
                        players[0].Direction = Direction.Down;
                    break;
                case Keys.D:
                    if (players[0].Direction != Direction.Left)
                        players[0].Direction = Direction.Right;
                    break;
                case Keys.Up:
                    if (players.Count > 1 && players[1].Direction != Direction.Down)
                        players[1].Direction = Direction.Up;
                    break;
                case Keys.Left:
                    if (players.Count > 1 && players[1].Direction != Direction.Right)
                        players[1].Direction = Direction.Left;
                    break;
                case Keys.Down:
                    if (players.Count > 1 && players[1].Direction != Direction.Up)
                        players[1].Direction = Direction.Down;
                    break;
                case Keys.Right:
                    if (players.Count > 1 && players[1].Direction != Direction.Left)
                        players[1].Direction = Direction.Right;
                    break;
            }
        }


        private (IEnumerable<Position> avoid, IEnumerable<Food> food, (int, int)) GetWorldInfo()
        {
            var avoid = players.SelectMany(p => p.BodyParts).Select(p => new Position(p.X, p.Y)).ToList();
            var food = foodItems.ToList();
            return (avoid, food, (gameBoard.Width, gameBoard.Height));
        }
    }
}
