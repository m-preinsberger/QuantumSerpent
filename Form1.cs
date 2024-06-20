using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// Namespace for the Quantum Serpent game, containing all classes related to the game
namespace QuantumSerpent
{
    // Main form class for the Quantum Serpent game, inheriting from Form
    public partial class MainForm : Form
    {
        // Declaration of variables and UI elements used in the game
        private System.Windows.Forms.Timer gameTimer; // Timer to control game updates
        private PictureBox gameBoard; // PictureBox acting as the game board
        private Label statusLabel; // Label to display game status
        private List<Player> players = new List<Player>(); // List of players in the game
        private List<Food> foodItems = new List<Food>(); // List of food items on the game board
        private Bitmap offscreenBitmap; // Bitmap for double buffering to reduce flicker
        private Graphics offscreenGraphics; // Graphics object for drawing on the offscreen bitmap
        private bool isGameOver = false; // Flag to indicate if the game is over
        private string gameMode; // String to store the selected game mode
        private int aiPlayerCount; // Number of AI players in the game
        private Random random; // Random object for generating random values
        private int fps; // Frames per second for the game timer
        private int appleCount; // Number of apples (food items) to spawn
        private int foodGrowMultiplier; // Multiplier for how much the player grows after eating food
        private float moveSpeed = 2.0f; // Speed at which players move
        private Dictionary<string, int> playerScores = new Dictionary<string, int>(); // Dictionary to keep track of player scores
        private System.Windows.Forms.Timer countdownTimer; // Timer for countdown before game starts
        private int timeRemaining; // Time remaining for the countdown
        private List<Player> deadPlayers = new List<Player>();

        // Constructor for MainForm, initializes game settings based on selected mode and AI players
        public MainForm(string selectedGameMode, int aiPlayers)
        {
            gameMode = selectedGameMode; // Set the game mode based on the selected option
            aiPlayerCount = aiPlayers; // Set the number of AI players
            random = new Random(); // Initialize the random object
            InitializeComponent(); // Initialize the form components
            InitializeGame(); // Call the method to initialize game settings and start the game
        }

        // Initializes game settings, players, and starts the game timer
        private void InitializeGame()
        {
            var settings = GameSettingsManager.Load(); // Load game settings from a configuration file or object

            // Load game settings from the settings object
            fps = settings.FPS;
            appleCount = settings.AppleCount;
            foodGrowMultiplier = settings.FoodGrowMultiplier;
            gameTimer.Interval = 1000 / fps; // Set the game timer interval based on the desired FPS

            // Reset game state for a new game
            players.Clear();
            foodItems.Clear();
            playerScores.Clear();

            // Start countdown if Fat Serpent mode is enabled
            if (settings.IsFatSerpentMode)
            {
                StartCountdown(settings.FatSerpentTimeFrame);
            }

            // Initialize players based on the selected game mode
            if (gameMode == "Singleplayer")
            {
                InitializeSinglePlayer(settings); // Initialize a single player game
            }
            else if (gameMode == "Multiplayer")
            {
                InitializeMultiPlayer(settings); // Initialize a multiplayer game
            }

            // Add AI players to the game based on the number specified in settings
            for (int i = 0; i < settings.AIPlayers; i++)
            {
                var aiPlayer = new AIPlayer(
                    $"AIPlayer{i + 1}",
                    Color.Red,
                    Color.Green,
                    GenerateSafeSpawnPoint(new Point(0, 0), gameBoard.Size), // Generate a safe spawn point for AI
                    Direction.Right,
                    settings.InitialPlayerLength,
                    GetWorldInfo // Pass the WorldInfo function
                );

                players.Add(aiPlayer);
                playerScores[aiPlayer.Name] = 0; // Add AI player to the playerScores dictionary
            }

            // Generate initial food items on the game board
            for (int i = 0; i < appleCount; i++)
            {
                foodItems.Add(GenerateRandomFood()); // Add a new food item at a random location
            }

            // Start the game timer to begin game updates
            gameTimer.Start();
        }

        // Generates a random food item on the game board
        private Food GenerateRandomFood()
        {
            int x = random.Next(0, gameBoard.Width - 20); // Generate a random X position within the game board bounds
            int y = random.Next(0, gameBoard.Height - 20); // Generate a random Y position within the game board bounds
            return new Apple(new Point(x, y)); // Return a new Apple object at the generated position
        }

        // Initializes a single player game with settings from the GameSettings object
        private void InitializeSinglePlayer(GameSettings settings)
        {
            var player1StartPos = new Point(100, 200); // Define a starting position for player 1
            players.Add(new Player(
                settings.Player1Name, // Player name from settings
                settings.Player1HeadColor, // Head color from settings
                settings.Player1BodyColor, // Body color from settings
                player1StartPos, // Starting position
                Direction.Right, // Initial direction
                settings.InitialPlayerLength // Initial length
            ));
            playerScores[settings.Player1Name] = 0; // Initialize player 1's score to 0
        }

        // Initializes a multiplayer game with settings from the GameSettings object
        private void InitializeMultiPlayer(GameSettings settings)
        {
            // Add player 1 with specified settings
            players.Add(new Player(
                settings.Player1Name, // Name of player 1 from settings
                settings.Player1HeadColor, // Head color for player 1 from settings
                settings.Player1BodyColor, // Body color for player 1 from settings
                new Point(100, 200), // Starting position for player 1
                Direction.Right, // Initial direction for player 1
                settings.InitialPlayerLength // Initial length for player 1
            ));
            playerScores[settings.Player1Name] = 0; // Initialize player 1's score to 0

            // Add player 2 with specified settings
            players.Add(new Player(
                settings.Player2Name, // Name of player 2 from settings
                settings.Player2HeadColor, // Head color for player 2 from settings
                settings.Player2BodyColor, // Body color for player 2 from settings
                new Point(400, 400), // Starting position for player 2
                Direction.Right, // Initial direction for player 2
                settings.InitialPlayerLength // Initial length for player 2
            ));
            playerScores[settings.Player2Name] = 0; // Initialize player 2's score to 0
        }

        // Generates a spawn point for a player that is a safe distance away from another player
        private Point GenerateSafeSpawnPoint(Point otherPlayerPos, Size boardSize)
        {
            int safeDistance = 100; // Minimum safe distance from another player
            Point newSpawnPoint; // Variable to hold the new spawn point
            Random rand = new Random(); // Random object for generating random positions
            do
            {
                // Generate a random position within the game board bounds, ensuring it's a safe distance from the edges
                int x = rand.Next(safeDistance, boardSize.Width - safeDistance);
                int y = rand.Next(safeDistance, boardSize.Height - safeDistance);
                newSpawnPoint = new Point(x, y);
            } while (Math.Abs(newSpawnPoint.X - otherPlayerPos.X) < safeDistance &&
                     Math.Abs(newSpawnPoint.Y - otherPlayerPos.Y) < safeDistance); // Repeat until a safe distance is achieved

            return newSpawnPoint; // Return the generated safe spawn point
        }

        // Event handler for painting the game board
        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            if (players == null) return; // Exit if there are no players

            // Clear the offscreen bitmap to prepare for a new frame
            offscreenGraphics.Clear(Color.LightGray);

            // Draw each player on the game board
            foreach (var player in players)
            {
                // Draw each body part of the player
                foreach (var part in player.BodyParts)
                {
                    offscreenGraphics.FillRectangle(new SolidBrush(player.BodyColor), new Rectangle(part, new Size(20, 20)));
                }
                // Draw the player's head with a different color
                offscreenGraphics.FillRectangle(new SolidBrush(player.HeadColor), new Rectangle(player.BodyParts[0], new Size(20, 20)));
            }

            // Draw each food item on the game board
            foreach (var food in foodItems)
            {
                food.Draw(offscreenGraphics); // Call the Draw method of each food item
            }

            // Draw player scores on the game board
            var font = new Font("Arial", 16); // Font for displaying scores
            var brush = new SolidBrush(Color.Black); // Brush for drawing text
            float yPosition = 10; // Initial Y position for the first score

            // Display each player's score
            foreach (var player in players)
            {
                offscreenGraphics.DrawString($"{player.Name}: {playerScores[player.Name]}", font, brush, new PointF(10, yPosition));
                yPosition += 30; // Increment Y position for the next score
            }

            // Copy the offscreen bitmap to the screen to display the frame
            e.Graphics.DrawImage(offscreenBitmap, 0, 0);
        }

        // Event handler for the game timer tick, which is called at every interval of the game timer
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Check if there are no players or if the game has ended, and exit the method if so
            if (players == null || isGameOver) return;

            // Collect positions of all food items and obstacles (player body parts) for collision detection
            var foodPositions = foodItems.Select(food => food.Position).ToList();
            var obstacles = players.SelectMany(player => player.BodyParts).ToList();

            // Iterate through each player to update their state
            foreach (var player in players)
            {
                // If the player is an AI, use AI logic to move
                if (player is AIPlayer aiPlayer)
                {
                    aiPlayer.MoveAI();
                }
                else
                {
                    // For human players, move based on their current direction
                    MovePlayer(player);
                }

                // Update the position of the player's last body part
                player.UpdateLastBodyPartPosition();

                // Check if the player has consumed any food and handle growth and scoring
                CheckFoodConsumption(player);

                // Check for collisions with other players or the game board boundaries
                var collisionResult = CollisionHelper.CheckCollisions(player, players, gameBoard.Size);
                if (collisionResult.Type != CollisionHelper.CollisionType.None)
                {
                    // If a collision occurs, end the game and display a message
                    deadPlayers.Add(player);
                    removeDeadPlayers();
                    if (players.Count == 0)
                    {
                        EndGame(collisionResult.Message);
                    }
                    return;
                }

            }

            // Invalidate the game board to trigger a repaint and update the game's visual state
            gameBoard.Invalidate();
            statusLabel.Text = "Status: Running"; // Update the status label to indicate the game is running
        }
        private void removeDeadPlayers()
        {
            foreach (var player in deadPlayers)
            {
                foreach (var part in player.BodyParts)
                {
                    Apple apple = new Apple(part);
                    apple.Respawn = false;
                    foodItems.Add(apple);
                }
                players.Remove(player);
            }
            deadPlayers.Clear();
        }   

        // Moves the player based on their current direction
        private void MovePlayer(Player player)
        {
            // Update the position of each body part to follow the one in front of it
            for (int i = player.BodyParts.Count - 1; i > 0; i--)
            {
                player.BodyParts[i] = player.BodyParts[i - 1];
            }

            // Move the head of the player in the direction they are facing
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

            // Ensure the player's head does not move outside the game board boundaries
            var head = player.BodyParts[0];
            player.BodyParts[0] = new Point(
                Math.Max(0, Math.Min(gameBoard.Width - 20, head.X)),
                Math.Max(0, Math.Min(gameBoard.Height - 20, head.Y))
            );
        }

        // Checks if the player has consumed any food and updates the game state accordingly
        private void CheckFoodConsumption(Player player)
        {
            // Create a rectangle around the player's head for collision detection with food
            Rectangle playerHeadRect = new Rectangle(player.BodyParts[0], new Size(20, 20));

            // Iterate through the food items in reverse to safely remove items while iterating
            for (int i = foodItems.Count - 1; i >= 0; i--)
            {
                Food food = foodItems[i];
                Rectangle foodRect = new Rectangle(food.Position, new Size(20, 20));

                // Check for collision between the player's head and a food item
                if (playerHeadRect.IntersectsWith(foodRect))
                {
                    // Increase the player's body size and score for each food item consumed
                    for (int j = 0; j < foodGrowMultiplier; j++)
                    {
                        player.AddBodyPart();
                    }

                    // Remove the consumed food item and replace it with a new one
                    foodItems.RemoveAt(i);
                    if (food.Respawn)
                    {
                        foodItems.Add(GenerateRandomFood());
                    }

                    // Update the player's score based on their body length
                    playerScores[player.Name] = player.BodyParts.Count;
                }
            }
        }

        // Ends the game and shows the end message
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

        // Method to show the start form. If it's already open, it brings it to the front.
        private void ShowStartForm()
        {
            var startForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            if (startForm == null)
            {
                startForm = new StartForm();
                startForm.Show(); // If the StartForm is not open, create and show it.
            }
            else
            {
                startForm.Show(); // If the StartForm is already open, just bring it to the front.
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["StartForm"]?.Show();
        }

        // Handles key down events to change the direction of players based on the pressed key.
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (players == null) return; // If there are no players, do nothing.

            // Change the direction of the first player based on WASD keys, ensuring they can't reverse directly.
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
                // For multiplayer, change the direction of the second player based on arrow keys.
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


        private (IEnumerable<Point> avoid, IEnumerable<Food> food, int maxWidth, int maxHeight) GetWorldInfo()
        {
            var avoid = players.SelectMany(p => p.BodyParts).ToList();
            var food = foodItems.ToList();
            int maxWidth = gameBoard.Width;
            int maxHeight = gameBoard.Height;
            return (avoid, food, maxWidth, maxHeight);
        }
    }
}

