namespace GiftShopView
{
    partial class FGift
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxElements = new System.Windows.Forms.GroupBox();
            this.Upd = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Ref = new System.Windows.Forms.Button();
            this.Del = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(150, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(242, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(150, 38);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(242, 20);
            this.textBoxPrice.TabIndex = 1;
            // 
            // groupBoxElements
            // 
            this.groupBoxElements.Controls.Add(this.Upd);
            this.groupBoxElements.Controls.Add(this.Add);
            this.groupBoxElements.Controls.Add(this.dataGridView);
            this.groupBoxElements.Controls.Add(this.Ref);
            this.groupBoxElements.Controls.Add(this.Del);
            this.groupBoxElements.Location = new System.Drawing.Point(32, 64);
            this.groupBoxElements.Name = "groupBoxElements";
            this.groupBoxElements.Size = new System.Drawing.Size(360, 186);
            this.groupBoxElements.TabIndex = 2;
            this.groupBoxElements.TabStop = false;
            this.groupBoxElements.Text = "Элементы";
            // 
            // Upd
            // 
            this.Upd.Location = new System.Drawing.Point(267, 118);
            this.Upd.Name = "Upd";
            this.Upd.Size = new System.Drawing.Size(77, 28);
            this.Upd.TabIndex = 4;
            this.Upd.Text = "Обновить";
            this.Upd.UseVisualStyleBackColor = true;
            this.Upd.Click += new System.EventHandler(this.Upd_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(267, 16);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(77, 28);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(235, 155);
            this.dataGridView.TabIndex = 0;
            // 
            // Ref
            // 
            this.Ref.Location = new System.Drawing.Point(267, 50);
            this.Ref.Name = "Ref";
            this.Ref.Size = new System.Drawing.Size(77, 28);
            this.Ref.TabIndex = 2;
            this.Ref.Text = "Изменить";
            this.Ref.UseVisualStyleBackColor = true;
            this.Ref.Click += new System.EventHandler(this.Ref_Click);
            // 
            // Del
            // 
            this.Del.Location = new System.Drawing.Point(267, 84);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(77, 28);
            this.Del.TabIndex = 3;
            this.Del.Text = "Удалить";
            this.Del.UseVisualStyleBackColor = true;
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(203, 256);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(77, 27);
            this.Save.TabIndex = 3;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(299, 256);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(77, 27);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Обновить";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(42, 41);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(36, 13);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Цена:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(42, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Название:";
            // 
            // FGift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 289);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBoxElements);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Name = "FGift";
            this.Text = "Подарочное изделие";
            this.groupBoxElements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.Load += new System.EventHandler(this.FGift_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxElements;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Upd;
        private System.Windows.Forms.Button Del;
        private System.Windows.Forms.Button Ref;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelName;
    }
}