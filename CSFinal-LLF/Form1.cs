using System.Diagnostics;
using System.Numerics;

namespace CSFinal_LLF
{
    public partial class Form1 : Form
    {

        //=========================== GLOBAL ===========================
        static Random rnd = new(); //Allows us to randomize stuff

        //Disable all of the buttons within the Navigation Box
        static public void DisableNavButtons()
        {
            /*OBTAIN THE NAVIGATION BOX: */
            //Go through the groupboxes inside the Form
            foreach (GroupBox group in ActiveForm.Controls.OfType<GroupBox>())
            {
                //Is the GroupBox the Navigation Box?
                if (group.Name == "NavBox")
                {
                    //Go through each Button in the Navigation Box
                    foreach (Button button in group.Controls.OfType<Button>())
                    {
                        //Disable Button
                        button.Enabled = false;
                    }
                }
            }
        }
        //Enable Select buttons within the Navigation Box
        static public void EnableNavButtons(bool[] Directions)
        {
            foreach (GroupBox group in ActiveForm.Controls.OfType<GroupBox>())
            {
                if (group.Name == "NavBox")
                {
                    DisableNavButtons();

                    foreach (Button button in group.Controls.OfType<Button>())
                    {
                        /*Forward*/
                        if (Directions[0] && button.Name == "UpBtn")
                        {
                            //Enable this Button
                            button.Enabled = true;
                        }
                        /*Back*/
                        if (Directions[1] && button.Name == "DownBtn")
                        {
                            //Enable this Button
                            button.Enabled = true;
                        }
                        /*Right*/
                        if (Directions[2] && button.Name == "RightBtn")
                        {
                            //Enable this Button
                            button.Enabled = true;
                        }
                        /*Left*/
                        if (Directions[3] && button.Name == "LeftBtn")
                        {
                            //Enable this Button
                            button.Enabled = true;
                        }
                    }
                }
            }
        }

        //Updates the Screen based on the room
        public static void UpdateRoomDisplay()
        {
            //Set the background image determined by the player's Perspective and Doors in the Room
            ActiveForm.BackgroundImage = User.DetermineImage();
            //stretch the background to the form
            ActiveForm.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //Updates the Compass UI
        public void UpdateCompassDisplay()
        {
            //finds all TextBoxes in the Active Form
            foreach (TextBox box in ActiveForm.Controls.OfType<TextBox>())
            {
                //Is player orientation text Box?
                if (box.Name == "DirectionFaceTxt")
                {
                    //Set the Text to the string Converted from the Current Orientation vector.
                    box.Text = Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(User.Orientation.currOrientation), false);
                }
            }
        }

        /*vvvvvvvvvvvvvv FORM 1 CONSTRUCTOR !!! DO NOT TOUCH !!! vvvvvvvvvvvvvv*/  // It will break EVERYTHING Because Forms is cool like that :) //
        public Form1()
        {
            InitializeComponent();
        }

        /*^^^^^^^^^^^^^ FORM 1 CONSTRUCTOR !!! DO NOT TOUCH !!! ^^^^^^^^^^^^^^*/


        /*=========================== COMPONENTS ===========================*/
        //COMPASS COMPONENT - World Direction
        class Compass
        {
            //Directions               [ NORTH  SOUTH   EAST  WEST  ]
            public bool[] Directions = { false, false, false, false };

            //CONVERT DIRECTION VECTOR ----> DIRECTION INDEX
            static public int ConvertDireIntoIndex(Vector2 Direction)
            {

                //North
                if (Direction.X == -1)
                {
                    return 0;
                }
                //South
                else if (Direction.X == 1)
                {
                    return 1;
                }
                // East
                else if (Direction.Y == 1)
                {
                    return 2;
                }
                // West
                else if (Direction.Y == -1)
                {
                    return 3;
                }
                //DEFAULT TO NORTH
                else
                {
                    return 0;
                }
            }
            //CONVERT DIRECTION INDEX ----> DIRECTION VECTOR
            public static Vector2 ConvertIndexIntoDire(int DireIndex)
            {
                return DireIndex switch
                {
                    0 => new Vector2(-1, 0), //NORTH

                    1 => new Vector2(1, 0),  //SOUTH

                    2 => new Vector2(0, 1),  //EAST

                    3 => new Vector2(0, -1), //WEST

                    _ => new Vector2(-1, 0), //DEFAULT: NORTH
                };
            }

            //CONVERT DIRECTION INDEX ----> DIRECTION STRING
            public static string ConvertIndexToString(int DireIndex, bool isCharacter)
            {
                //THE COMPASS WANTS A FULL NAME OF THE DIRECTION
                if (!isCharacter)
                {

                    //Translate Direction Index into a String
                    return DireIndex switch
                    {
                        0 => "North",
                        1 => "South",
                        2 => "East",
                        3 => "West",
                        _ => "Invalid Direction Input",//Debug
                    };
                }

                //THE COMPASS WANTS THE CHARACTER OF THE DIRECTION
                else
                {
                    //Translate Direction Index into a String
                    return DireIndex switch
                    {
                        0 => "N",
                        1 => "S",
                        2 => "E",
                        3 => "W",
                        _ => "Invalid Direction Input",//Debug
                    };
                }
            }
        }

        //Personal Compass - Relative Orientation
        class P_Compass : Compass
        {

            //Initial Oreintation of the Compass
            private Vector2 init_Orientaion;
            //Current Facing Direction
            public Vector2 currOrientation;

            //CONSTRUCTOR
            public P_Compass(Vector2 orientation)
            {
                init_Orientaion = orientation;
                currOrientation = init_Orientaion;
            }
            //Calulates the Perspective Relative to the Object
            public Vector2 CalculateOrientation(int TurnsTaken)
            {
                //new vector that saves teh result after calulations
                Vector2 result = new Vector2();
                /*DEBUG: SEE THE AMOUNT OF TURNS ARE TAKEN FOR THE ROTATION CACULATION
                Debug.WriteLine("CalculateOrientation(int TurnsTaken): TURNS TAKE:" + TurnsTaken);*/
                if (Math.Abs(TurnsTaken) == 1)
                {

                    //Form the Amount of Turns Taken into Radians [ Yep, we're doing Unit Circle stuff :) ]
                    float Radians = TurnsTaken * (float)Math.PI / 2;

                    // X and Y Vectors Needed For Calculation
                    Vector2 XVect = new Vector2((float)Math.Cos(Radians), (float)(Math.Sin(Radians))) * currOrientation.X;
                    Vector2 YVect = new Vector2((float)(-1 * Math.Sin(Radians)), (float)Math.Cos(Radians)) * currOrientation.Y;
                    //Add the Calculated vectors for the resulting Vector
                    result = XVect + YVect;
                    /*DEBUG: SEE THE RESULT OF THE CACULATION
                    Debug.WriteLine("|___ 90* TURN IS: " + result);*/

                    return result;
                }
                else
                {
                    result = currOrientation;  //ELSE: give the result the current orientation - so we can mirror it

                    //REFLECT THE RESULTED CALCULATION
                    return ReflectVector(result);
                }
            }
            //Mirrors the Given Vector
            private static Vector2 ReflectVector(Vector2 StartVector)
            {
                Vector2 Mirror = new(0, 0); //make a Blank vector

                //REFLECT THE GIVEN VECTOR
                Mirror.X += StartVector.X * -1;
                Mirror.Y += StartVector.Y * -1;

                //return the mirrored vector
                return Mirror;
            }
            //sets the new Orientation based on the given Orientation [Usually paired with the CalculateOrientation() function]
            public static void SetNewOrientation(Vector2 newOrientation)
            {
                /*DEBUG: SHOWS THE ORIENTATION WE HAVE BEFORE CHANGING IT
                Debug.WriteLine("SetNewOrientation() Adjusting Current Orientation of: " + User.Orientation.currOrientation);*/

                //Add the Two Calculated Vectors
                User.Orientation.currOrientation = newOrientation;

                /*DEBUG: DISPLAY THE CALUE OF THE NEW ORIENTATION
                Debug.WriteLine("|___ GIVES VALUE: " + User.Orientation.currOrientation);*/
            }
        }

        //MOVEMENT COMPONENET
        class MovementComponent
        {
            //INITIALIZE
            private Vector2 InitLocation;
            public Vector2 CurrLocation;

            //CONSTRUCTOR
            public MovementComponent(Vector2 StartLoc)
            {
                //Set Location
                InitLocation = StartLoc;
                CurrLocation = InitLocation;
            }
            //Manages the Movement of an Object
            public void Move(Vector2 Direction)
            {
                //Check If that Location is Valid
                if (!CheckBounds(NextRoom(Direction)))
                {
                    MessageBox.Show("I can't Go that Direction");
                }
                else
                {
                    CurrLocation += Compass.ConvertIndexIntoDire(Compass.ConvertDireIntoIndex(Direction));
                    /*DEBUG:DISPLAYS THE DIRECTION THE PLAYER MOVES IN
                     Debug.WriteLine("PLAYER MOVE: " + Compass.ConvertIndexIntoDire(Compass.ConvertDireIntoIndex(Direction)));*/
                }
            }
            //Get the vector of an Adjacent Room
            public Vector2 NextRoom(Vector2 direction)
            {

                return CurrLocation + direction;
            }

            //Test If the Object is in Bounds of the Canvas
            public bool CheckBounds(Vector2 RoomLocation)
            {
                //Check if the new location is out of bounds of the Map
                if (RoomLocation.Y > Dungeon.MaxWidth)
                {
                    return false;
                }
                else if (CurrLocation.Y < 0)
                {
                    return false;
                }
                else if (CurrLocation.X > Dungeon.MaxHeight)
                {
                    return false;
                }
                else if (CurrLocation.X < 0)
                {
                    return false;
                }

                //Doesn't meet the bounds: The move is good!
                return true;
            }

            //Displays the Location in Debug Window
            public void PrintLocation() => Debug.WriteLine("Current Location: " + CurrLocation);
        }

        /*=========================== CLASSES ===========================*/
        //ROOMS//
        class Room
        {
            //Keeps track of what Doors are on the Room
            public Compass OpenedDoors;
            //Location of the Room
            public Vector2 Location { get; private set; }
            //String that reads out what directions the Doors 
            public string directionString = "";
            //CONSTRUCTOR
            public Room(Vector2 Position)
            {
                //Add a compass
                OpenedDoors = new();
                Location = Position;
            }

            //Open a Door in a specific Direction
            public void OpenDoor(int Direction)
            {
                //Check if the given direction is Valid
                if (Direction <= OpenedDoors.Directions.Length)
                {
                    //set the Door in the specific to True
                    OpenedDoors.Directions[Direction] = true;
                }
            }
            //Counts the Doors in the room
            public int CountDoors()
            {
                int doorsFound = 0;
                for (int i = 0; i <= OpenedDoors.Directions.Length - 1; i++)
                {
                    if (OpenedDoors.Directions[i])
                    {
                        doorsFound++;
                    }
                }
                return doorsFound;
            }
        }

        //THE MAP
        class Map
        {
            //INITALIZE VARIABLES
            public int MaxHeight;
            public int MaxWidth;
            //keeps Track if the Key has been Spawned in a room.
            public bool KeySpawned = false;
            //The Room that Dungeon Starts
            public Vector2 StartRoom { get; private set; }
            //Map Boundaries
            public List<List<Room>> MapCanvas = new();

            //CONSTRUCTOR
            public Map(int height, int width)
            {
                //set Canvas Height
                MaxHeight = height - 1;
                //SetCanvas Width
                MaxWidth = width - 1;
                //Put the Starting Location in the Middle of the Canvas
                StartRoom = new Vector2(2, 2);
                //Goes through the Given height
                for (int h = 0; h < height; h++)
                {
                    //Make a new Row of Rooms
                    List<Room> RoomRow = new();
                    //Makes a new Room based on how wide the Map is.
                    for (int w = 0; w < width; w++)
                    {
                        //Make a new Room
                        Room newRoom = new(new Vector2(h, w));
                        //Add that Room to the Current Row of Rooms
                        RoomRow.Add(newRoom);
                    }
                    //Add the Row of Rooms made into the Map Canvas
                    MapCanvas.Add(RoomRow);
                }
            }

            /*==========FUNCTIONS=========*/

            //Print the Map
            public void printMap()
            {
                //Go through each TextBox within the Active Form
                foreach (TextBox box in Form1.ActiveForm.Controls.OfType<TextBox>())
                {
                    //If the text box is the Mini Map:
                    if (box.Name == "MiniMapBox")
                    {
                        //Make sure the mini-map is empty for a new update
                        box.Text = "";

                        //go through each Row inside of the MapCanvas Matrix
                        foreach (List<Room> row in MapCanvas)
                        {
                            //string to place all the rooms into one row
                            string rowStr = "";
                            foreach (Room room in row)
                            {
                                //Check if Room is connected By doors - AKA has any Opened Doors
                                if (room.OpenedDoors.Directions.Contains<bool>(true))
                                {
                                    //IF the room has the same Location as the Player
                                    if (Form1.User.Movement.CurrLocation == room.Location)
                                    {
                                        //display player on the Map
                                        rowStr += "Player ";
                                    }
                                    //print Room location index
                                    else
                                    {
                                        //Out
                                        rowStr += room.Location + " ";


                                    }
                                }
                                //DOOR HAS NO CONNECTING ROOM [IS A BLANK ROOM]:
                                else
                                {
                                    rowStr += " ////// ";
                                }
                            }
                            //Add the formed Row into the MiniMap
                            box.AppendText(rowStr + "\n");
                            //seperate rows into seperate lines
                            box.Lines = box.Text.Split('\n');
                        }
                    }
                }
            }
        }
        //Create a Dungeon
        static Map Dungeon = new(5, 5);


        //PATHING SYSTEM - Forms branch of Rooms from Room Openings
        class PathingSystem
        {
            //Manages Pathing Direction
            P_Compass Direction;
            //Add Movement Component
            MovementComponent Movement = new(Dungeon.StartRoom);

            //Amount of rooms Generated
            static int BranchAmount = 4;
            //current count of Rooms
            int RoomCount = 0;


            //CONSTRUCTOR
            public PathingSystem(Vector2 init_direction)
            {
                //set direction it points in
                Direction = new(init_direction);
                //FORM BRANCH
                ConstructBranch();
            }
            //Randomly chooses a new location
            Vector2 RandomDirection()
            {
                //Gets Direction using a random index from the possible Compass Directions
                return Compass.ConvertIndexIntoDire(rnd.Next(Direction.Directions.Length));
            }

            void MoveRoom(Vector2 newDirection)
            {
                //Get the Room the branch is currently in
                Room CurrentRoom = Dungeon.MapCanvas[(int)Movement.CurrLocation.X][(int)Movement.CurrLocation.Y];


                //Make an Open Door in that Direction
                CurrentRoom.OpenDoor(Compass.ConvertDireIntoIndex(newDirection));
                /*DEBUG: WRITE WHAT DOOR WAS OPENED AND THE ROOM ENTERED 
                Debug.WriteLine("Opened " + Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(newDirection), false) + " at " + CurrentRoom.Location);
                DEBUG: DISPLAY THE DIRECTION ENTERED FROM
                Debug.WriteLine("CURRENT DIRECTION " + newDirection);*/

                //Move that Direction
                Movement.Move(newDirection);
                CurrentRoom = Dungeon.MapCanvas[(int)Movement.CurrLocation.X][(int)Movement.CurrLocation.Y];

                Vector2 reflectedVector;

                //for some reason 0 is saved as "-0" when I reflect the vector... So here's the fix for that.
                if (newDirection.X != 0)
                {
                    int newX = -1 * (int)newDirection.X;
                    reflectedVector = new Vector2(newX, 0);
                }
                else
                {
                    int newY = -1 * (int)newDirection.Y;

                    reflectedVector = new Vector2(0, newY);
                }



                //Open the Door where you enter in the new Room
                CurrentRoom.OpenDoor(Compass.ConvertDireIntoIndex(reflectedVector));
                /*DEBUG: WRITE WHAT DOOR IS CONNECTED TO THE DOOR ENTERED FROM
                Debug.WriteLine("Opened " + Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(reflectedVector), false) + " at " + CurrentRoom.Location);

                Debug.WriteLine("NEW DIRECTION " + reflectedVector);*/

            }
            //Function that handles the Branch Contruction
            void ConstructBranch()
            {
                //Move the Initial Direction
                MoveRoom(Direction.currOrientation);
                //Increment rooms in Branch
                RoomCount++;

                //Loop until we reach the Max rooms in the branch
                while (RoomCount != BranchAmount)
                {
                    // Pick a Random Direction to Move in
                    Vector2 newDirection = RandomDirection();
                    /*-- REROLL IF: */
                    // New Direction means going back the way the Path entered the Room OR Movement would hit the Canvas.
                    while (newDirection == -Direction.currOrientation || !Movement.CheckBounds(Movement.CurrLocation + newDirection))
                    {
                        newDirection = RandomDirection();
                    }

                    // Move to Room in that Location 
                    MoveRoom(newDirection);

                    //Count The Rooms.
                    RoomCount++;
                }
            }

        }
        //Make Pathing Systems 
        static PathingSystem N_Branch = new(Compass.ConvertIndexIntoDire(0)); //Branches North
        static PathingSystem S_Branch = new(Compass.ConvertIndexIntoDire(1)); //Branches South
        static PathingSystem E_Branch = new(Compass.ConvertIndexIntoDire(2)); //Brances East
        static PathingSystem W_Branch = new(Compass.ConvertIndexIntoDire(3)); //Branches West


        //PLAYER
        class Player
        {
            //Add a Player Compass for player orientation
            public P_Compass Orientation { get; private set; }
            //Add Movement Component
            public MovementComponent Movement = new(Dungeon.StartRoom);

            //Direction Btns          [  UP  DOWN  RIGHT  LEFT ]
            static bool[] DireBtns = { false, true, false, false };

            //CONSTRUCTOR
            public Player(int InitOrientation)
            {
                //set the initial Orientation based on the Given Direction Index
                Orientation = new(Compass.ConvertIndexIntoDire(InitOrientation));
            }
            //Determines what type of room we are entering
            public Image DetermineImage()
            {

                //Reset the Player's Navigation buttons
                for (int i = 0; i < DireBtns.Length; i++)
                {
                    DireBtns[i] = false;
                }

                DireBtns[1] = true; //DEFAULT TO HAVING THE BACK BUTTON ENABLED

                //GET THE CURRENT ROOM THE PLAYER IS IN
                Room currentRoom = Dungeon.MapCanvas[(int)Movement.CurrLocation.X][(int)Movement.CurrLocation.Y];
                /*DEBUG: PRINT LOCATION
                Movement.PrintLocation();*/

                //SORT THE ROOMS BY HOW MANY DOORS THEY HAVE
                switch (currentRoom.CountDoors())
                {
                    //Room has 1 door: Dead End
                    case 1:
                        EnableNavButtons(DireBtns);
                        return Properties.Resources.End;

                    //Room has 2 Doors: Hall, Corner
                    case 2:
                        return ObserveRoom(2, currentRoom); //Player Observes the Room


                    //Room has 3 Doors: T-Shape
                    case 3:
                        return ObserveRoom(3, currentRoom); //Player Observes the Room

                    //Room Has 4 Doors: Open Room
                    case 4:
                        //All Directions in Player's Persective is True
                        for (int i = 0; i < DireBtns.Length; i++)
                        {
                            DireBtns[i] = true;
                        }
                        //Enable the Navigation Buttons
                        EnableNavButtons(DireBtns);

                        return Properties.Resources.OpenRoom;

                    //DEFAULT TO A DEAD END
                    default:
                        return Properties.Resources.End;
                }

            }
            //"Observes" the Layout of the room from a First-Person Perspective.
            static Image ObserveRoom(int DoorsInRoom, Room room)
            {
                /*DEBUG: MAKING SURE THE ROOM THE PLAYER IS OBSERVING IS CORRECT
                Debug.WriteLine("OBSERVING THE ROOM ON: ROOM - " + room.Location + " | WITH " + DoorsInRoom + " DOORS");*/

                // LOGIC USED FOR ROOMS WITH 2 OR 3 DOORS:
                switch (DoorsInRoom)
                {
                    //2-DOORED ROOMS [Hall or Corner]
                    case 2:
                        //=== HALL ===
                        //Room infront of Player?
                        if (room.OpenedDoors.Directions[Compass.ConvertDireIntoIndex(User.Orientation.currOrientation)])
                        {
                            //Enable Foward
                            DireBtns[0] = true;
                            //Enable the needed Buttons
                            EnableNavButtons(DireBtns);
                            //returns Image
                            return Properties.Resources.Hall;
                        }

                        //=== CORNER ===
                        //Check if the Door is on the Left
                        else if (room.OpenedDoors.Directions[Compass.ConvertDireIntoIndex(User.Orientation.CalculateOrientation(1))])
                        {
                            //Enable Left
                            DireBtns[3] = true;
                            //Enable the Needed buttons
                            EnableNavButtons(DireBtns);
                            //returns Image
                            return Properties.Resources.Corner_Left;
                        }
                        //The Door Must be on the Right
                        else
                        {
                            //Enable Right
                            DireBtns[2] = true;
                            //Enable the Needed buttons
                            EnableNavButtons(DireBtns);
                            //returns Image
                            return Properties.Resources.Corner_Right;
                        }


                    //3-DOOR ROOMS: [T-SHAPE ROOM]
                    case 3:
                        // ===T-Shape ===
                        //If there's no Door on the Direction the Player is Facing : Bottom of 'T'
                        if (!room.OpenedDoors.Directions[Compass.ConvertDireIntoIndex(User.Orientation.currOrientation)]) //forward-facing
                        {
                            //Enable Left
                            DireBtns[3] = true;
                            //Enable Right
                            DireBtns[2] = true;
                            //Enable the Needed buttons
                            EnableNavButtons(DireBtns);
                            //returns Image
                            return Properties.Resources.T_Bottom;
                        }
                        //Check if there's no Door on the Right
                        else if (!room.OpenedDoors.Directions[Compass.ConvertDireIntoIndex(User.Orientation.CalculateOrientation(-1))]) //Turning left-side
                        {
                            //Enable Foward
                            DireBtns[0] = true;
                            //Enable Left
                            DireBtns[3] = true;
                            //Enable the Needed buttons
                            EnableNavButtons(DireBtns);
                            //returns Image
                            return Properties.Resources.T_Left;
                        }
                        //There's No Left Side: Must be Right-side
                        else
                        {
                            //Enable Foward
                            DireBtns[0] = true;
                            //Enable Right
                            DireBtns[2] = true;
                            //Enable the Needed buttons
                            EnableNavButtons(DireBtns);
                            //returns Image
                            return Properties.Resources.T_Right;
                        }
                    //returns Image
                    default:
                        //Enable the Needed buttons
                        EnableNavButtons(DireBtns);
                        return Properties.Resources.End;
                }
            }
        }
        //Create a New Player (Facing North)
        static Player User = new(0);


        /*===BUTTON EVENTS===*/
        //NAVIGATION BUTTONS [Foward/Right/Left/Back]
        private void UpBtn_Click(object sender, EventArgs e)
        {
            /* DISPLAY PLAYER'S CURRENT ORIENTATION
            Debug.WriteLine("PLAYER'S CURRENT FACE: " + Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(User.Orientation.currOrientation), true));*/

            //MOVE ROOM - FOWARDS
            User.Movement.Move(User.Orientation.currOrientation);

            //UPDATE SCREEN
            Dungeon.printMap(); //Print Dungeon to Mini-Map
            UpdateCompassDisplay(); //Update the Compass UI
            UpdateRoomDisplay(); // Update the Background
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            //TURNING -90  [Right]
            P_Compass.SetNewOrientation(User.Orientation.CalculateOrientation(-1));
            /* DEBUG: DISPLAY THE PLAYER ORIENTATION AFTER ROTATION
            Debug.WriteLine("PLAYER'S CURRENT FACE: " + Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(User.Orientation.currOrientation), true));
            */
            //MOVE ROOM - RIGHT
            User.Movement.Move(User.Orientation.currOrientation);

            //UPDATE SCREEN
            Dungeon.printMap(); //Print Dungeon to Mini-Map
            UpdateCompassDisplay(); //Update the Compass UI
            UpdateRoomDisplay(); // Update the Background

        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            //TURNING 90  [Left]
            P_Compass.SetNewOrientation(User.Orientation.CalculateOrientation(1));
            /* DEBUG: DISPLAY THE PLAYER ORIENTATION AFTER ROTATION
            Debug.WriteLine("PLAYER'S CURRENT FACE: " + Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(User.Orientation.currOrientation), true));
            */

            //MOVE ROOM - LEFT
            User.Movement.Move(User.Orientation.currOrientation);

            //UPDATE SCREEN
            Dungeon.printMap(); //Print Dungeon to Mini-Map
            UpdateCompassDisplay(); //Update the Compass UI
            UpdateRoomDisplay(); // Update the Background
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            //Turn around 180  [AKA 2*90 ]
            P_Compass.SetNewOrientation(User.Orientation.CalculateOrientation(-2));
            /* DEBUG: DISPLAY THE PLAYER ORIENTATION AFTER ROTATION
            Debug.WriteLine("PLAYER'S CURRENT FACE: " + Compass.ConvertIndexToString(Compass.ConvertDireIntoIndex(User.Orientation.currOrientation), true));
            */
            //MOVE ROOM - BACK
            User.Movement.Move(User.Orientation.currOrientation);


            //UPDATE SCREEN
            Dungeon.printMap(); //Print Dungeon to Mini-Map
            UpdateCompassDisplay(); //Update the Compass UI
            UpdateRoomDisplay(); // Update the Background
        }

        //START BUTTON
        private void StartBtn_Click(object sender, EventArgs e)
        {
            //HIDE THE LOGO AND START BUTTON
            LogoImage.Visible = false;
            StartBtn.Visible = false;

            //INITIALIZETHE GAME DIPLAY
            Dungeon.printMap(); //Print Dungeon to Mini-Map
            UpdateCompassDisplay(); //Update the Compass UI
            UpdateRoomDisplay(); // Update the Background
        }
    }
}