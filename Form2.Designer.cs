namespace ReceptsApp
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 26;
            listBox1.Location = new Point(12, 4);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(522, 706);
            listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(540, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(515, 661);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(942, 671);
            button1.Name = "button1";
            button1.Size = new Size(113, 44);
            button1.TabIndex = 3;
            button1.Text = "Вийти";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 727);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Font = new Font("Bookman Old Style", 13.8F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form2";
            Text = "Рецепт";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox textBox1;
        private Button button1;
    }
}