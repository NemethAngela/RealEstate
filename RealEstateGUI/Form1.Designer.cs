namespace RealEstateGUI
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
            listBoxEladok = new ListBox();
            labelEladoNeve = new Label();
            labelEladoTelefonszama = new Label();
            buttonHirdetesekBetoltese = new Button();
            labelHirdetesekSzama = new Label();
            textBoxNev = new TextBox();
            textBoxTel = new TextBox();
            textBoxHSz = new TextBox();
            SuspendLayout();
            // 
            // listBoxEladok
            // 
            listBoxEladok.FormattingEnabled = true;
            listBoxEladok.ItemHeight = 15;
            listBoxEladok.Location = new Point(12, 12);
            listBoxEladok.Name = "listBoxEladok";
            listBoxEladok.Size = new Size(186, 409);
            listBoxEladok.TabIndex = 0;
            listBoxEladok.SelectedIndexChanged += listBoxEladok_SelectedIndexChanged;
            // 
            // labelEladoNeve
            // 
            labelEladoNeve.AutoSize = true;
            labelEladoNeve.Location = new Point(243, 25);
            labelEladoNeve.Name = "labelEladoNeve";
            labelEladoNeve.Size = new Size(67, 15);
            labelEladoNeve.TabIndex = 1;
            labelEladoNeve.Text = "Eladó neve:";
            // 
            // labelEladoTelefonszama
            // 
            labelEladoTelefonszama.AutoSize = true;
            labelEladoTelefonszama.Location = new Point(243, 65);
            labelEladoTelefonszama.Name = "labelEladoTelefonszama";
            labelEladoTelefonszama.Size = new Size(112, 15);
            labelEladoTelefonszama.TabIndex = 2;
            labelEladoTelefonszama.Text = "Eladó telefonszáma:";
            // 
            // buttonHirdetesekBetoltese
            // 
            buttonHirdetesekBetoltese.Location = new Point(243, 105);
            buttonHirdetesekBetoltese.Name = "buttonHirdetesekBetoltese";
            buttonHirdetesekBetoltese.Size = new Size(515, 23);
            buttonHirdetesekBetoltese.TabIndex = 3;
            buttonHirdetesekBetoltese.Text = "Hirdetések betöltése";
            buttonHirdetesekBetoltese.UseVisualStyleBackColor = true;
            buttonHirdetesekBetoltese.Click += buttonHirdetesekBetoltese_Click;
            // 
            // labelHirdetesekSzama
            // 
            labelHirdetesekSzama.AutoSize = true;
            labelHirdetesekSzama.Location = new Point(243, 155);
            labelHirdetesekSzama.Name = "labelHirdetesekSzama";
            labelHirdetesekSzama.Size = new Size(102, 15);
            labelHirdetesekSzama.TabIndex = 4;
            labelHirdetesekSzama.Text = "Hirdetések száma:";
            // 
            // textBoxNev
            // 
            textBoxNev.Location = new Point(386, 17);
            textBoxNev.Name = "textBoxNev";
            textBoxNev.Size = new Size(100, 23);
            textBoxNev.TabIndex = 5;
            // 
            // textBoxTel
            // 
            textBoxTel.Location = new Point(386, 57);
            textBoxTel.Name = "textBoxTel";
            textBoxTel.Size = new Size(100, 23);
            textBoxTel.TabIndex = 6;
            // 
            // textBoxHSz
            // 
            textBoxHSz.Location = new Point(386, 147);
            textBoxHSz.Name = "textBoxHSz";
            textBoxHSz.Size = new Size(100, 23);
            textBoxHSz.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxHSz);
            Controls.Add(textBoxTel);
            Controls.Add(textBoxNev);
            Controls.Add(labelHirdetesekSzama);
            Controls.Add(buttonHirdetesekBetoltese);
            Controls.Add(labelEladoTelefonszama);
            Controls.Add(labelEladoNeve);
            Controls.Add(listBoxEladok);
            Name = "Form1";
            Text = "Ingatlanok";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxEladok;
        private Label labelEladoNeve;
        private Label labelEladoTelefonszama;
        private Button buttonHirdetesekBetoltese;
        private Label labelHirdetesekSzama;
        private TextBox textBoxNev;
        private TextBox textBoxTel;
        private TextBox textBoxHSz;
    }
}