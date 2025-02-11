namespace FD
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
            Path1 = new TextBox();
            listBox1 = new ListBox();
            moveToRight = new Button();
            moveToLeft = new Button();
            listBox2 = new ListBox();
            Path2 = new TextBox();
            copyTo = new Button();
            back = new Button();
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Path1
            // 
            Path1.Enabled = false;
            Path1.Location = new Point(14, 40);
            Path1.Name = "Path1";
            Path1.Size = new Size(213, 27);
            Path1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(14, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(208, 324);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            // 
            // moveToRight
            // 
            moveToRight.Location = new Point(243, 179);
            moveToRight.Name = "moveToRight";
            moveToRight.Size = new Size(78, 29);
            moveToRight.TabIndex = 2;
            moveToRight.Text = ">";
            moveToRight.UseVisualStyleBackColor = true;
            moveToRight.Click += moveToRight_Click;
            // 
            // moveToLeft
            // 
            moveToLeft.Location = new Point(243, 214);
            moveToLeft.Name = "moveToLeft";
            moveToLeft.Size = new Size(78, 29);
            moveToLeft.TabIndex = 3;
            moveToLeft.Text = "<";
            moveToLeft.UseVisualStyleBackColor = true;
            moveToLeft.Click += moveToLeft_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(338, 73);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(208, 324);
            listBox2.TabIndex = 4;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBox2.MouseDoubleClick += listBox2_MouseDoubleClick;
            // 
            // Path2
            // 
            Path2.Enabled = false;
            Path2.Location = new Point(333, 40);
            Path2.Name = "Path2";
            Path2.Size = new Size(213, 27);
            Path2.TabIndex = 5;
            // 
            // copyTo
            // 
            copyTo.Location = new Point(14, 404);
            copyTo.Name = "copyTo";
            copyTo.Size = new Size(211, 34);
            copyTo.TabIndex = 6;
            copyTo.Text = "Copy";
            copyTo.UseVisualStyleBackColor = true;
            copyTo.Click += copyTo_Click;
            // 
            // back
            // 
            back.Location = new Point(333, 404);
            back.Name = "back";
            back.Size = new Size(211, 34);
            back.TabIndex = 7;
            back.Text = "BACK";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // button5
            // 
            button5.ForeColor = Color.Firebrick;
            button5.Location = new Point(16, 440);
            button5.Name = "button5";
            button5.Size = new Size(530, 60);
            button5.TabIndex = 8;
            button5.Text = "DESTROY";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 9;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 19);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 10;
            label2.Text = "Dest";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 504);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(back);
            Controls.Add(copyTo);
            Controls.Add(Path2);
            Controls.Add(listBox2);
            Controls.Add(moveToLeft);
            Controls.Add(moveToRight);
            Controls.Add(listBox1);
            Controls.Add(Path1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            Text = "FDestoryer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Path1;
        private ListBox listBox1;
        private Button moveToRight;
        private Button moveToLeft;
        private ListBox listBox2;
        private TextBox Path2;
        private Button copyTo;
        private Button back;
        private Button button5;
        private Label label1;
        private Label label2;
    }
}
