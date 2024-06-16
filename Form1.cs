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

        // Konstruktor mit zwei Parametern
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

            if (gameMode == "Singleplayer")
            {
                InitializeSinglePlayer(settings);
            }
            else if (gameMode == "Multiplayer")
            {
                InitializeMultiPlayer(settings);
            }

            // Add AI players
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
        }

        private void InitializeMultiPlayer(GameSettings settings)
        {
            // Initialize Player 1
            players.Add(new Player(
                settings.Player1Name,
                settings.Player1HeadColor,
                settings.Player1BodyColor,
                new Point(100, 200), // Start position for Player 1
                Direction.Right,
                settings.InitialPlayerLength
            ));

            // Initialize Player 2 at a different start position
            players.Add(new Player(
                settings.Player2Name,
                settings.Player2HeadColor,
                settings.Player2BodyColor,
                new Point(400, 400), // Adjusted start position for Player 2
                Direction.Left,
                settings.InitialPlayerLength
            ));
        }

        private Point GenerateSafeSpawnPoint(Point otherPlayerPos, Size boardSize)
        {
            int safeDistance = 200;
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
                }
            }
        }

        private void EndGame(string message)
        {
            if (!isGameOver)
            {
                isGameOver = true;
                MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gameTimer.Stop();
                this.Close();
                ShowStartForm();
            }
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
    }
}
