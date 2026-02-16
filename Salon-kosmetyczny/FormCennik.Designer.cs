namespace Salon_kosmetyczny
{
    partial class FormCennik
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
            comboBoxKategoria = new ComboBox();
            dataGridViewCennik = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCennik).BeginInit();
            SuspendLayout();
            // 
            // comboBoxKategoria
            // 
            comboBoxKategoria.FormattingEnabled = true;
            comboBoxKategoria.Location = new Point(283, 311);
            comboBoxKategoria.Name = "comboBoxKategoria";
            comboBoxKategoria.Size = new Size(149, 23);
            comboBoxKategoria.TabIndex = 0;
            comboBoxKategoria.Text = "Filtruj według kategorii";
            comboBoxKategoria.SelectedIndexChanged += comboBoxKategoria_SelectedIndexChanged;
            // 
            // dataGridViewCennik
            // 
            dataGridViewCennik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCennik.Location = new Point(86, 51);
            dataGridViewCennik.Name = "dataGridViewCennik";
            dataGridViewCennik.Size = new Size(585, 194);
            dataGridViewCennik.TabIndex = 1;
            // 
            // FormCennik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewCennik);
            Controls.Add(comboBoxKategoria);
            Name = "FormCennik";
            Text = "FormCennik";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCennik).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxKategoria;
        private DataGridView dataGridViewCennik;
    }
}