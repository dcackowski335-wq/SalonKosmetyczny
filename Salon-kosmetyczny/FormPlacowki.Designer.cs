namespace Salon_kosmetyczny
{
    partial class FormPlacowki
    {

        private System.ComponentModel.IContainer components = null;

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
            dataGridViewPlacowki = new DataGridView();
            buttonOdswiez = new Button();
            label1 = new Label();
            labelIlosc = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlacowki).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPlacowki
            // 
            dataGridViewPlacowki.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlacowki.Location = new Point(98, 111);
            dataGridViewPlacowki.Name = "dataGridViewPlacowki";
            dataGridViewPlacowki.Size = new Size(567, 197);
            dataGridViewPlacowki.TabIndex = 0;
            // 
            // buttonOdswiez
            // 
            buttonOdswiez.Location = new Point(341, 340);
            buttonOdswiez.Name = "buttonOdswiez";
            buttonOdswiez.Size = new Size(75, 23);
            buttonOdswiez.TabIndex = 1;
            buttonOdswiez.Text = "Odśwież";
            buttonOdswiez.UseVisualStyleBackColor = true;
            buttonOdswiez.Click += buttonOdswiez_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 64);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 2;
            label1.Text = "Lista placówek";
            // 
            // labelIlosc
            // 
            labelIlosc.AutoSize = true;
            labelIlosc.Location = new Point(233, 64);
            labelIlosc.Name = "labelIlosc";
            labelIlosc.Size = new Size(105, 15);
            labelIlosc.TabIndex = 4;
            labelIlosc.Text = "Liczba placówek: 0";
            // 
            // FormPlacowki
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelIlosc);
            Controls.Add(label1);
            Controls.Add(buttonOdswiez);
            Controls.Add(dataGridViewPlacowki);
            Name = "FormPlacowki";
            Text = "FormPlacowki";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlacowki).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewPlacowki;
        private Button buttonOdswiez;
        private Label label1;
        private Label labelIlosc;
    }
}