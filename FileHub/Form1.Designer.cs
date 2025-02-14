namespace FileHub
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
            delete = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Path1
            // 
            Path1.Enabled = false;
            Path1.Location = new Point(18, 50);
            Path1.Margin = new Padding(4);
            Path1.Name = "Path1";
            Path1.Size = new Size(265, 31);
            Path1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(18, 91);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(259, 404);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            // 
            // moveToRight
            // 
            moveToRight.Location = new Point(304, 224);
            moveToRight.Margin = new Padding(4);
            moveToRight.Name = "moveToRight";
            moveToRight.Size = new Size(98, 36);
            moveToRight.TabIndex = 2;
            moveToRight.Text = ">";
            moveToRight.UseVisualStyleBackColor = true;
            moveToRight.Click += moveToRight_Click;
            // 
            // moveToLeft
            // 
            moveToLeft.Location = new Point(304, 268);
            moveToLeft.Margin = new Padding(4);
            moveToLeft.Name = "moveToLeft";
            moveToLeft.Size = new Size(98, 36);
            moveToLeft.TabIndex = 3;
            moveToLeft.Text = "<";
            moveToLeft.UseVisualStyleBackColor = true;
            moveToLeft.Click += moveToLeft_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Location = new Point(422, 91);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(259, 404);
            listBox2.TabIndex = 4;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBox2.MouseDoubleClick += listBox2_MouseDoubleClick;
            // 
            // Path2
            // 
            Path2.Enabled = false;
            Path2.Location = new Point(416, 50);
            Path2.Margin = new Padding(4);
            Path2.Name = "Path2";
            Path2.Size = new Size(265, 31);
            Path2.TabIndex = 5;
            // 
            // copyTo
            // 
            copyTo.Location = new Point(18, 505);
            copyTo.Margin = new Padding(4);
            copyTo.Name = "copyTo";
            copyTo.Size = new Size(264, 42);
            copyTo.TabIndex = 6;
            copyTo.Text = "Copy";
            copyTo.UseVisualStyleBackColor = true;
            copyTo.Click += copyTo_Click;
            // 
            // back
            // 
            back.Location = new Point(416, 505);
            back.Margin = new Padding(4);
            back.Name = "back";
            back.Size = new Size(264, 42);
            back.TabIndex = 7;
            back.Text = "BACK";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // delete
            // 
            delete.ForeColor = Color.Firebrick;
            delete.Location = new Point(20, 550);
            delete.Margin = new Padding(4);
            delete.Name = "delete";
            delete.Size = new Size(662, 75);
            delete.TabIndex = 8;
            delete.Text = "DESTROY";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 9;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 10;
            label2.Text = "Dest";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 630);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(back);
            Controls.Add(copyTo);
            Controls.Add(Path2);
            Controls.Add(listBox2);
            Controls.Add(moveToLeft);
            Controls.Add(moveToRight);
            Controls.Add(listBox1);
            Controls.Add(Path1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "FileHub";
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
        private Button delete;
        private Label label1;
        private Label label2;
    }
}
