namespace GiftShopView
{
    partial class FCustomers
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
            this.Up = new System.Windows.Forms.Button();
            this.Del = new System.Windows.Forms.Button();
            this.Ref = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(276, 121);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(104, 29);
            this.Up.TabIndex = 4;
            this.Up.Text = "Обновить";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Upd_Click);
            // 
            // Del
            // 
            this.Del.Location = new System.Drawing.Point(275, 86);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(106, 29);
            this.Del.TabIndex = 3;
            this.Del.Text = "Удалить";
            this.Del.UseVisualStyleBackColor = true;
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // Ref
            // 
            this.Ref.Location = new System.Drawing.Point(274, 51);
            this.Ref.Name = "Ref";
            this.Ref.Size = new System.Drawing.Size(106, 29);
            this.Ref.TabIndex = 2;
            this.Ref.Text = "Изменить";
            this.Ref.UseVisualStyleBackColor = true;
            this.Ref.Click += new System.EventHandler(this.Ref_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(275, 16);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(106, 29);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 13);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(240, 236);
            this.dataGridView.TabIndex = 0;
            // 
            // FCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 259);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.Del);
            this.Controls.Add(this.Ref);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.dataGridView);
            this.Name = "FCustomers";
            this.Text = "Клиенты";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Del;
        private System.Windows.Forms.Button Ref;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}