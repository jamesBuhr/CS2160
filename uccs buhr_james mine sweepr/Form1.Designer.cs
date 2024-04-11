namespace uccs_buhr_james_mine_sweepr
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            setSizeToolStripMenuItem = new ToolStripMenuItem();
            x4ToolStripMenuItem = new ToolStripMenuItem();
            x10ToolStripMenuItem = new ToolStripMenuItem();
            x15ToolStripMenuItem = new ToolStripMenuItem();
            x20ToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            instructionsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, helpToolStripMenuItem, aboutToolStripMenuItem, restartToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setSizeToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // setSizeToolStripMenuItem
            // 
            setSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { x4ToolStripMenuItem, x10ToolStripMenuItem, x15ToolStripMenuItem, x20ToolStripMenuItem });
            setSizeToolStripMenuItem.Name = "setSizeToolStripMenuItem";
            setSizeToolStripMenuItem.Size = new Size(180, 22);
            setSizeToolStripMenuItem.Text = "set size ";
            // 
            // x4ToolStripMenuItem
            // 
            x4ToolStripMenuItem.Name = "x4ToolStripMenuItem";
            x4ToolStripMenuItem.Size = new Size(180, 22);
            x4ToolStripMenuItem.Text = "5x5";
            x4ToolStripMenuItem.Click += x4ToolStripMenuItem_Click;
            // 
            // x10ToolStripMenuItem
            // 
            x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
            x10ToolStripMenuItem.Size = new Size(180, 22);
            x10ToolStripMenuItem.Text = "10 x 10";
            x10ToolStripMenuItem.Click += x10ToolStripMenuItem_Click;
            // 
            // x15ToolStripMenuItem
            // 
            x15ToolStripMenuItem.Name = "x15ToolStripMenuItem";
            x15ToolStripMenuItem.Size = new Size(180, 22);
            x15ToolStripMenuItem.Text = "15 x 15";
            x15ToolStripMenuItem.Click += x15ToolStripMenuItem_Click;
            // 
            // x20ToolStripMenuItem
            // 
            x20ToolStripMenuItem.Name = "x20ToolStripMenuItem";
            x20ToolStripMenuItem.Size = new Size(180, 22);
            x20ToolStripMenuItem.Text = "20 x 20";
            x20ToolStripMenuItem.Click += x20ToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { instructionsToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(42, 20);
            helpToolStripMenuItem.Text = "help";
            // 
            // instructionsToolStripMenuItem
            // 
            instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            instructionsToolStripMenuItem.Size = new Size(136, 22);
            instructionsToolStripMenuItem.Text = "instructions";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(53, 20);
            aboutToolStripMenuItem.Text = "about ";
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(55, 20);
            restartToolStripMenuItem.Text = "Restart";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem instructionsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem setSizeToolStripMenuItem;
        private ToolStripMenuItem x10ToolStripMenuItem;
        private ToolStripMenuItem x15ToolStripMenuItem;
        private ToolStripMenuItem x20ToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem x4ToolStripMenuItem;
    }
}