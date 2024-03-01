namespace _8_Puzzle_Simulator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MoveButton = new Button();
            label2 = new Label();
            comboBox = new ComboBox();
            SolveButton = new Button();
            SuspendLayout();
            // 
            // MoveButton
            // 
            MoveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MoveButton.Location = new Point(339, 367);
            MoveButton.Name = "MoveButton";
            MoveButton.Size = new Size(110, 41);
            MoveButton.TabIndex = 0;
            MoveButton.Text = "Move";
            MoveButton.UseVisualStyleBackColor = true;
            MoveButton.Visible = false;
            MoveButton.Click += MoveButton_Click;
            MoveButton.KeyPress += MainForm_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(57, 9);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 1;
            label2.Text = "Goal State";
            // 
            // comboBox
            // 
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "", "Depth-First Search (DFS)", "Uniform-Cost Search (UCS)", "Best-First Search (BFS)", "A* Algorithm" });
            comboBox.Location = new Point(574, 319);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(214, 28);
            comboBox.TabIndex = 2;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox.KeyPress += MainForm_KeyPress;
            // 
            // SolveButton
            // 
            SolveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SolveButton.Location = new Point(678, 367);
            SolveButton.Name = "SolveButton";
            SolveButton.Size = new Size(110, 41);
            SolveButton.TabIndex = 3;
            SolveButton.Text = "Solve";
            SolveButton.UseVisualStyleBackColor = true;
            SolveButton.Visible = false;
            SolveButton.Click += SolveButton_Click;
            // 
            // MainForm
            // 
            AcceptButton = MoveButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(800, 450);
            Controls.Add(SolveButton);
            Controls.Add(comboBox);
            Controls.Add(label2);
            Controls.Add(MoveButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Main Form";
            Click += form_Click;
            KeyPress += MainForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button MoveButton;
        private Label label2;
        private ComboBox comboBox;
        private Button SolveButton;
    }
}