namespace uccs_buhr_james_mine_sweepr
{


    public partial class Form1 : Form
    {
        static Random random = new Random();

        static int numberOfRows = 11;
        static int numberOfColumns = 10;
        int numberOfBombs;

        public Cell[,] grid;
        List<(int col, int row)> bombLocations = new List<(int, int)> { };

        int verticalOffset = 32;
        int horizontalOffset = 32;
        bool firstClick = true;

        // 10% bombs of of the grid 


        public Form1()
        {
            InitializeComponent();
            InitializeGrid();

        }

        public void InitializeGrid()
        {

            grid = new Cell[numberOfColumns, numberOfRows];
            numberOfBombs = numberOfRows * numberOfColumns / 10;

            for (int col = 0; col < grid.GetLength(0); col++)
            {
                for (int row = 0; row < grid.GetLength(1); row++)
                {
                    Cell cell = new Cell();
                    cell.BackColor = ((random.Next(2) % 2) == 0) ? Color.DarkGoldenrod : Color.DeepPink;
                    //cell.BackColor = Color.Gray;
                    cell.cellClicked += onCellClicked;






                    cell.Flaged = false;
                    cell.BombFound = false;
                    cell.col = col;
                    cell.row = row;
                    cell.IsBomb = false;
                    cell.BombProximityAmount1 = 0;

                    cell.Location = new Point(verticalOffset + (col * cell.Height), row * cell.Width);
                    this.Controls.Add(cell);
                    grid[col, row] = cell;





                }

            }





        }



        public void onCellClicked(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            int col = ((Cell)sender).col;
            int row = ((Cell)sender).row;

            // cheak if first click
            if (firstClick) { firstclick(cell); }
            //clearCellAssociededColor(cell, col, row);
            clearCellAssociededBombs(cell, col, row);

            if (cell.IsBomb)
            {
                lostGame();
            }
        }






        private void clearCellAssociededColor(Cell cell, int col, int row)
        {
            //cheak right less then the max length  
            if (col < grid.GetLength(0) - 1)
            {
                // if the same color 
                if (cell.BackColor == grid[col + 1, row].BackColor)
                {
                    //click on next
                    if (col + 1 <= numberOfColumns)
                    {
                        grid[col + 1, row].PreformClick();
                    }
                }
            }
            // cheak left greater then 0 
            if (col - 1 >= 0)
            {
                // is left block same color 
                if (cell.BackColor == grid[col - 1, row].BackColor)
                {
                    // preform click 

                    grid[col - 1, row].PreformClick();
                }

            }

            // cheak down , if at the end of array of grid
            if (row < grid.GetLength(1) - 1)
            {
                // cheak is next same color
                if (cell.BackColor == grid[col, row + 1].BackColor)
                {
                    //preform click 
                    grid[col, row + 1].PreformClick();
                }
            }

            // cheak if at the top row 
            if (row - 1 >= 0)
            {

                // is the next block same color 
                if (cell.BackColor == grid[col, row - 1].BackColor)
                {

                    grid[col, row - 1].PreformClick();

                }

            }
        }


        private void clearCellAssociededBombs(Cell cell, int col, int row)
        {
            Cell nextcell;
            //cheak right less then the max length  
            if (col < grid.GetLength(0) - 1)
            {
                // if the same color 
                nextcell = grid[col + 1, row];
                if (nextcell.BombProximityAmount1 == 0)
                {
                    //click on next
                    if (col + 1 <= numberOfColumns)
                    {
                        nextcell.PreformClick();
                    }
                }
                else if (!nextcell.IsBomb)
                {
                    if ((nextcell.BombProximityAmount1 != 0))
                    {
                        nextcell.Reveal();
                    }

                }
            }

            // cheak left greater then 0 
            if (col - 1 >= 0)
            {
                nextcell = grid[col - 1, row];

                // is left block same color 
                if (nextcell.BombProximityAmount1 == 0)
                {
                    // preform click 

                    nextcell.PreformClick();
                }
                else if (!nextcell.IsBomb)
                {
                    if ((nextcell.BombProximityAmount1 != 0))
                    {
                        nextcell.Reveal();
                    }

                }

            }


            // cheak down , if at the end of array of grid
            if (row < grid.GetLength(1) - 1)
            {
                nextcell = grid[col, row + 1];
                // cheak is next same color
                if (nextcell.BombProximityAmount1 == 0)
                {
                    //preform click 
                    nextcell.PreformClick();
                }
                else if (!nextcell.IsBomb)
                {
                    if ((nextcell.BombProximityAmount1 != 0))
                    {
                        nextcell.Reveal();
                    }

                }
            }

            // cheak if at the top row 

            if (row - 1 >= 0)
            {
                nextcell = grid[col, row - 1];
                // is the next block same color 
                if (nextcell.BombProximityAmount1 == 0)
                {

                    nextcell.PreformClick();

                }
                else if (!nextcell.IsBomb)
                {
                    if ((nextcell.BombProximityAmount1 != 0))
                    {
                        nextcell.Reveal();
                    }

                }

            }



        }




        /// <summary>
        /// on first click generate bombs on grid
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void firstclick(Cell cell)
        {
            firstClick = false;
            placeBombs(cell.col, cell.row);

        }

        /// <summary>
        /// generates the random locations on grid for bombs not to overlap, and not at the location clicked 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// 
        private void generateBombs(int clickedCol, int clickedRow)
        {
            int bombRow;
            int bombCol;

            // generate row and col numbers for the bombs
            for (int i = 0; i < numberOfBombs; i++)
            {
                // Generate the locations of col, row
                bombRow = generateRandomNumber(numberOfRows);
                bombCol = generateRandomNumber(numberOfColumns);


                // If location generated is the same as the clicked location regenerate location.

                for (int col = clickedCol - 1; col <= clickedCol + 1; col++)
                {
                    // // around the bomb of -1 (to the above of the bomb) to 1 (to the below of the bomb) on the column where 1 is the the row number 
                    for (int row = clickedRow - 1; row <= clickedRow + 1; row++)
                    {
                        while ((row == bombRow && col == bombCol) || bombLocations.Contains((row, col)) ||

                              row < 0 ||
                              row > grid.GetLength(1) - 1 ||
                              col < 0 ||
                              col > grid.GetLength(0) - 1
                            )

                        {
                            bombRow = generateRandomNumber(numberOfRows);
                            bombCol = generateRandomNumber(numberOfColumns);
                        }


                        // Check the list of bomb overlaps with existing bomb


                        // Add the location to the list 
                    }
                }
                bombLocations.Add((bombRow, bombCol));
            }
        }

        private void setbombs()
        {
            foreach (var location in bombLocations)
            {
                // Set the bomb cell's properties

                grid[location.col, location.row].IsBomb = true;
                // grid[location.col, location.row].BackColor = Color.Red;
                grid[location.col, location.row].BackColor = Color.Blue;
            }
        }
        /// <summary>
        /// generate a number from 0 - upper limmit 
        /// return number 
        /// </summary>
        /// <param name="limmit"></param>
        /// <returns></returns>
        private int generateRandomNumber(int limmit)
        {
            //generat a number from 0 - upper limmit return limmit. 
            return new Random().Next(0, limmit - 1);

        }

        private void SetAdjency()
        {

            foreach (var location in bombLocations)
            {
                // around the bomb of -1 (to the left of the bomb) to 1 (to the right of the bomb) on the column where 1 is the the colum number 
                for (int col = location.col - 1; col <= location.col + 1; col++)
                {
                    // // around the bomb of -1 (to the above of the bomb) to 1 (to the below of the bomb) on the column where 1 is the the row number 
                    for (int row = location.row - 1; row <= location.row + 1; row++)
                    {


                        // Skip the bomb cell itself:  if the col and the row values both = 1
                        if (col == location.col && row == location.row)
                        {
                            grid[col, row].BombProximityAmount1++;
                            continue;
                        }

                        // else if the colum is with in the bounds of the matrix ()  && the row is also with-in the matrix 
                        else if ((col >= 0 && col < grid.GetLength(0)) && (row >= 0 && row < grid.GetLength(1)))
                        {
                            // forming a 3 x 3 premimiter around the bomb

                            // Update adjacent cells

                            //itterat the adjency numbers
                            grid[col, row].BombProximityAmount1++;

                            //grid[col, row].BackColor = Color.Yellow;
                        }
                    }
                }

            }


        }



        private void placeBombs(int col, int row)
        {
            generateBombs(col, row);
            SetAdjency();
            setbombs();

        }



        private void OnCellRightClicked(object sender, MouseEventArgs e)
        {
            var cell = sender as Cell;
            if (cell != null && e.Button == MouseButtons.Right)
            {
                // Handle the right-click event on the cell
                // This is where you would add logic to do something when the cell is right-clicked
                // For example, you might update a count of flagged cells or check for a win condition
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }


        ///records
        ///

        // Restart game
        ///

        private void endGame()
        {
            removeBoard();

        }

        private void lostGame()
        {

            MessageBox.Show("You lost the game!");
            removeBoard();
        }

        private void winCondishion()
        {

            MessageBox.Show("You Won");
            removeBoard();
        }



        private void removeBoard()
        {
            Cell cell;
            for (int col = 0; col < grid.GetLength(0); col++)
            {
                for (int row = 0; row < grid.GetLength(1); row++)
                {
                    cell = grid[col, row];
                    if (cell != null)
                    {
                        cell.cellClicked -= onCellClicked; // Unsubscribe from the event
                        this.Controls.Remove(cell); // Remove the cell from the form's controls
                        cell.Dispose(); // Dispose of the cell
                        grid[col, row] = null; // Clear the reference from the grid
                    }
                }
            }

            bombLocations.Clear();
            firstClick = true;

        }

        private void restartGame()
        {
            endGame();
            InitializeGrid();

        }

        private void restartButton(object sender, EventArgs e)
        {
            restartGame();
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (numberOfRows != 5 && numberOfColumns != 4)
            {
                numberOfRows = 5;
                numberOfColumns = 4;
                restartGame();
            }

        }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (numberOfRows != 11 && numberOfColumns != 10)
            {
                numberOfRows = 11;
                numberOfColumns = 10;
                restartGame();
            }

        }

        private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (numberOfRows != 16 && numberOfColumns != 15)
            {
                numberOfRows = 16;
                numberOfColumns = 15;
                restartGame();
            }


        }

        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (numberOfRows != 21 && numberOfColumns != 20)
            {
                numberOfRows = 21;
                numberOfColumns = 20;
                restartGame();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartGame();
        }



        /// Exit
        /// 

        ///Help instructions 
        ///


        /// statis
        /// 
        ///how long in seconond the user has been playing 
        ///


        // bord size 10X 10x 
        // 10 bombs 


        ///about section:  <summary>
        /// about section: 
        /// 
        ///         // who coded this ?
        ///         //james buhr 


    }
}