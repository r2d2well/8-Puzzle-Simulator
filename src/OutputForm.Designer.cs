namespace _8_Puzzle_Simulator
{
    partial class OutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputForm));
            SearchLabel = new Label();
            nextButton = new Button();
            LengthLabel = new Label();
            NodeLabel = new Label();
            TimeLabel = new Label();
            VisitedLabel = new Label();
            SuspendLayout();
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            SearchLabel.Location = new Point(237, 37);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(184, 41);
            SearchLabel.TabIndex = 0;
            SearchLabel.Text = "Search Label";
            // 
            // nextButton
            // 
            nextButton.Location = new Point(644, 385);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(144, 53);
            nextButton.TabIndex = 2;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // LengthLabel
            // 
            LengthLabel.AutoSize = true;
            LengthLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LengthLabel.Location = new Point(563, 137);
            LengthLabel.Name = "LengthLabel";
            LengthLabel.Size = new Size(119, 28);
            LengthLabel.TabIndex = 3;
            LengthLabel.Text = "Path Length:";
            // 
            // NodeLabel
            // 
            NodeLabel.AutoSize = true;
            NodeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NodeLabel.Location = new Point(326, 281);
            NodeLabel.Name = "NodeLabel";
            NodeLabel.Size = new Size(147, 28);
            NodeLabel.TabIndex = 4;
            NodeLabel.Text = "Node Number: ";
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TimeLabel.Location = new Point(12, 137);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(173, 28);
            TimeLabel.TabIndex = 5;
            TimeLabel.Text = "Time To Complete:";
            // 
            // VisitedLabel
            // 
            VisitedLabel.AutoSize = true;
            VisitedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            VisitedLabel.Location = new Point(563, 203);
            VisitedLabel.Name = "VisitedLabel";
            VisitedLabel.Size = new Size(137, 28);
            VisitedLabel.TabIndex = 6;
            VisitedLabel.Text = "Nodes Visited:";
            // 
            // OutputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(800, 450);
            Controls.Add(VisitedLabel);
            Controls.Add(TimeLabel);
            Controls.Add(NodeLabel);
            Controls.Add(LengthLabel);
            Controls.Add(nextButton);
            Controls.Add(SearchLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OutputForm";
            Text = "OutputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SearchLabel;
        private Button nextButton;
        private Label LengthLabel;
        private Label NodeLabel;
        private Label TimeLabel;
        private Label VisitedLabel;
    }
}