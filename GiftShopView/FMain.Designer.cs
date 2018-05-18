namespace GiftShopView
{
    partial class FMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.CreateCustom = new System.Windows.Forms.Button();
            this.TakeCustom = new System.Windows.Forms.Button();
            this.CustomReady = new System.Windows.Forms.Button();
            this.PayCustom = new System.Windows.Forms.Button();
            this.Upd = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.сотрудникиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники ";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.компонентыToolStripMenuItem.Text = "Элементы";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(763, 195);
            this.dataGridView.TabIndex = 1;
            // 
            // CreateCustom
            // 
            this.CreateCustom.Location = new System.Drawing.Point(769, 27);
            this.CreateCustom.Name = "CreateCustom";
            this.CreateCustom.Size = new System.Drawing.Size(142, 31);
            this.CreateCustom.TabIndex = 2;
            this.CreateCustom.Text = "Создать заказ";
            this.CreateCustom.UseVisualStyleBackColor = true;
            this.CreateCustom.Click += new System.EventHandler(this.CreateCustom_Click);
            // 
            // TakeCustom
            // 
            this.TakeCustom.Location = new System.Drawing.Point(769, 64);
            this.TakeCustom.Name = "TakeCustom";
            this.TakeCustom.Size = new System.Drawing.Size(142, 31);
            this.TakeCustom.TabIndex = 3;
            this.TakeCustom.Text = "Отдать на выполнение";
            this.TakeCustom.UseVisualStyleBackColor = true;
            this.TakeCustom.Click += new System.EventHandler(this.TakeCustom_Click);
            // 
            // CustomReady
            // 
            this.CustomReady.Location = new System.Drawing.Point(769, 101);
            this.CustomReady.Name = "CustomReady";
            this.CustomReady.Size = new System.Drawing.Size(142, 33);
            this.CustomReady.TabIndex = 4;
            this.CustomReady.Text = "Заказ готов";
            this.CustomReady.UseVisualStyleBackColor = true;
            this.CustomReady.Click += new System.EventHandler(this.CustomReady_Click);
            // 
            // PayCustom
            // 
            this.PayCustom.Location = new System.Drawing.Point(769, 140);
            this.PayCustom.Name = "PayCustom";
            this.PayCustom.Size = new System.Drawing.Size(142, 34);
            this.PayCustom.TabIndex = 5;
            this.PayCustom.Text = "Заказ оплачен";
            this.PayCustom.UseVisualStyleBackColor = true;
            this.PayCustom.Click += new System.EventHandler(this.PayCustom_Click);
            // 
            // Upd
            // 
            this.Upd.Location = new System.Drawing.Point(769, 180);
            this.Upd.Name = "Upd";
            this.Upd.Size = new System.Drawing.Size(142, 37);
            this.Upd.TabIndex = 6;
            this.Upd.Text = "Обновить список";
            this.Upd.UseVisualStyleBackColor = true;
            this.Upd.Click += new System.EventHandler(this.Upd_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 225);
            this.Controls.Add(this.Upd);
            this.Controls.Add(this.PayCustom);
            this.Controls.Add(this.CustomReady);
            this.Controls.Add(this.TakeCustom);
            this.Controls.Add(this.CreateCustom);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button CreateCustom;
        private System.Windows.Forms.Button TakeCustom;
        private System.Windows.Forms.Button CustomReady;
        private System.Windows.Forms.Button PayCustom;
        private System.Windows.Forms.Button Upd;
    }
}