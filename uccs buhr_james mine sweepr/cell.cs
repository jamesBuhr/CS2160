namespace uccs_buhr_james_mine_sweepr
{
    public partial class Cell : UserControl
    {

        Panel backPanel;
        Color cellColor;
        int BombProximityAmount;
        bool flaged;
        bool isBomb;
        bool bombFound;

        Button cellButton;
        public EventHandler cellClicked;

        public
        int x, y;

        public int col { get => x; set => x = value; }
        public int row { get => y; set => y = value; }
        public Color CellColor { get => CellColor1; set => CellColor1 = value; }
        public Color CellColor1 { get => cellColor; set => cellColor = value; }

        public bool IsBomb { get => isBomb; set => isBomb = value; }
        public int BombProximityAmount1 { get => BombProximityAmount; set => BombProximityAmount = value; }
        public bool Flaged { get; set; }
        public bool BombFound { get => bombFound; set => bombFound = value; }



        public Cell()
        {
            InitializeComponent();

            createButtonAndPannel();

        }

        protected virtual void OnCellClicked(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            int row = cell.row;
            int col = cell.col;


            cellClicked?.Invoke(this, e);
        }





        private void createButtonAndPannel()
        {
            cellButton = new Button();
            cellButton.Size = new Size(this.Width, this.Height);

            cellButton.Click += OnButtonClick;
            cellButton.BackColor = Color.White;



            //cellButton.cellColor = cellButton.BackColor;

            this.Controls.Add(cellButton);


            backPanel = new Panel();
            //backPanel.BackColor = Color.White;

            backPanel.Size = new Size(this.Width, this.Height);
            this.Controls.Add(backPanel);


        }

        public void Reveal()
        {

            if (BombProximityAmount1 > 0)
            {
                cellButton.Text = BombProximityAmount1.ToString();
            }
        }

        private void cell_Load(object sender, EventArgs e)
        {

        }


        public void OnButtonClick(object sender, EventArgs e)
        {


            ((Button)sender).Visible = false;
            OnCellClicked(this, e);


        }

        public void PreformClick()
        {
            cellButton.PerformClick();


        }


    }
}
