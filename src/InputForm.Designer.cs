namespace _8_Puzzle_Simulator
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            AcceptButton = new Button();
            RandomButton = new Button();
            label = new Label();
            SuspendLayout();
            // 
            // AcceptButton
            // 
            AcceptButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AcceptButton.Location = new Point(349, 372);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(94, 45);
            AcceptButton.TabIndex = 0;
            AcceptButton.Text = "Accept";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Visible = false;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // RandomButton
            // 
            RandomButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RandomButton.Location = new Point(32, 372);
            RandomButton.Name = "RandomButton";
            RandomButton.Size = new Size(146, 45);
            RandomButton.TabIndex = 1;
            RandomButton.Text = "Random Goal";
            RandomButton.UseVisualStyleBackColor = true;
            RandomButton.Click += RandomButton_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(301, 21);
            label.Name = "label";
            label.Size = new Size(229, 41);
            label.TabIndex = 2;
            label.Text = "Enter Goal State";
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(800, 450);
            Controls.Add(label);
            Controls.Add(RandomButton);
            Controls.Add(AcceptButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InputForm";
            Text = "InputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AcceptButton;
        private Button RandomButton;
        private Label label;
    }
}