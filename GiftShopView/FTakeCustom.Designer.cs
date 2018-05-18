namespace GiftShopView
{
    partial class FTakeCustom
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
            this.comboBoxFacilitator = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.labelImplementer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxFacilitator
            // 
            this.comboBoxFacilitator.FormattingEnabled = true;
            this.comboBoxFacilitator.Location = new System.Drawing.Point(88, 12);
            this.comboBoxFacilitator.Name = "comboBoxFacilitator";
            this.comboBoxFacilitator.Size = new System.Drawing.Size(208, 21);
            this.comboBoxFacilitator.TabIndex = 0;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(88, 39);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(93, 27);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(203, 39);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(93, 27);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // labelImplementer
            // 
            this.labelImplementer.AutoSize = true;
            this.labelImplementer.Location = new System.Drawing.Point(5, 15);
            this.labelImplementer.Name = "labelImplementer";
            this.labelImplementer.Size = new System.Drawing.Size(77, 13);
            this.labelImplementer.TabIndex = 3;
            this.labelImplementer.Text = "Исполнитель:";
            // 
            // FTakeCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 81);
            this.Controls.Add(this.labelImplementer);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.comboBoxFacilitator);
            this.Name = "FTakeCustom";
            this.Text = "Отдать заказ на работу";
            this.Load += new System.EventHandler(this.FTakeCustom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFacilitator;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label labelImplementer;
    }
}