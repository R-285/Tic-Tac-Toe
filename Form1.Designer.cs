namespace XO
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.размерПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x19ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.тактикаКомпьютераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.оборонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.атакаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.первыйХодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.человекаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.компьютераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(286, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.выходToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// новаяИграToolStripMenuItem
			// 
			this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
			this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.новаяИграToolStripMenuItem.Text = "Новая игра";
			this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.выходToolStripMenuItem.Text = "Выход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
			// 
			// настройкиToolStripMenuItem
			// 
			this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерПоляToolStripMenuItem,
            this.тактикаКомпьютераToolStripMenuItem,
            this.первыйХодToolStripMenuItem});
			this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
			this.настройкиToolStripMenuItem.ShowShortcutKeys = false;
			this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.настройкиToolStripMenuItem.Text = "Настройки";
			// 
			// размерПоляToolStripMenuItem
			// 
			this.размерПоляToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x10ToolStripMenuItem,
            this.x19ToolStripMenuItem,
            this.x30ToolStripMenuItem,
            this.x40ToolStripMenuItem});
			this.размерПоляToolStripMenuItem.Name = "размерПоляToolStripMenuItem";
			this.размерПоляToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.размерПоляToolStripMenuItem.Text = "Размер поля";
			// 
			// x10ToolStripMenuItem
			// 
			this.x10ToolStripMenuItem.CheckOnClick = true;
			this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
			this.x10ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.x10ToolStripMenuItem.Text = "10 x 10";
			this.x10ToolStripMenuItem.Click += new System.EventHandler(this.x10ToolStripMenuItem_Click);
			// 
			// x19ToolStripMenuItem
			// 
			this.x19ToolStripMenuItem.Checked = true;
			this.x19ToolStripMenuItem.CheckOnClick = true;
			this.x19ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.x19ToolStripMenuItem.Name = "x19ToolStripMenuItem";
			this.x19ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.x19ToolStripMenuItem.Text = "19 x 19";
			this.x19ToolStripMenuItem.Click += new System.EventHandler(this.x19ToolStripMenuItem_Click);
			// 
			// x30ToolStripMenuItem
			// 
			this.x30ToolStripMenuItem.CheckOnClick = true;
			this.x30ToolStripMenuItem.Name = "x30ToolStripMenuItem";
			this.x30ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.x30ToolStripMenuItem.Text = "30 x 30";
			this.x30ToolStripMenuItem.Click += new System.EventHandler(this.x30ToolStripMenuItem_Click);
			// 
			// x40ToolStripMenuItem
			// 
			this.x40ToolStripMenuItem.Name = "x40ToolStripMenuItem";
			this.x40ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.x40ToolStripMenuItem.Text = "40 x 40";
			this.x40ToolStripMenuItem.Click += new System.EventHandler(this.x40ToolStripMenuItem_Click);
			// 
			// тактикаКомпьютераToolStripMenuItem
			// 
			this.тактикаКомпьютераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оборонаToolStripMenuItem,
            this.атакаToolStripMenuItem});
			this.тактикаКомпьютераToolStripMenuItem.Name = "тактикаКомпьютераToolStripMenuItem";
			this.тактикаКомпьютераToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.тактикаКомпьютераToolStripMenuItem.Text = "Тактика компьютера";
			// 
			// оборонаToolStripMenuItem
			// 
			this.оборонаToolStripMenuItem.CheckOnClick = true;
			this.оборонаToolStripMenuItem.Name = "оборонаToolStripMenuItem";
			this.оборонаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.оборонаToolStripMenuItem.Text = "Оборона";
			this.оборонаToolStripMenuItem.Click += new System.EventHandler(this.оборонаToolStripMenuItem_Click);
			// 
			// атакаToolStripMenuItem
			// 
			this.атакаToolStripMenuItem.Checked = true;
			this.атакаToolStripMenuItem.CheckOnClick = true;
			this.атакаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.атакаToolStripMenuItem.Name = "атакаToolStripMenuItem";
			this.атакаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.атакаToolStripMenuItem.Text = "Атака";
			this.атакаToolStripMenuItem.Click += new System.EventHandler(this.атакаToolStripMenuItem_Click);
			// 
			// первыйХодToolStripMenuItem
			// 
			this.первыйХодToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.человекаToolStripMenuItem,
            this.компьютераToolStripMenuItem});
			this.первыйХодToolStripMenuItem.Name = "первыйХодToolStripMenuItem";
			this.первыйХодToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.первыйХодToolStripMenuItem.Text = "Первый ход";
			// 
			// человекаToolStripMenuItem
			// 
			this.человекаToolStripMenuItem.Checked = true;
			this.человекаToolStripMenuItem.CheckOnClick = true;
			this.человекаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.человекаToolStripMenuItem.Name = "человекаToolStripMenuItem";
			this.человекаToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.человекаToolStripMenuItem.Text = "Человек";
			this.человекаToolStripMenuItem.Click += new System.EventHandler(this.человекаToolStripMenuItem_Click);
			// 
			// компьютераToolStripMenuItem
			// 
			this.компьютераToolStripMenuItem.CheckOnClick = true;
			this.компьютераToolStripMenuItem.Name = "компьютераToolStripMenuItem";
			this.компьютераToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.компьютераToolStripMenuItem.Text = "Компьютер";
			this.компьютераToolStripMenuItem.Click += new System.EventHandler(this.компьютераToolStripMenuItem_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(286, 286);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(286, 310);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XO";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem размерПоляToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x19ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x30ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem тактикаКомпьютераToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem атакаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem оборонаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem первыйХодToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem компьютераToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem человекаToolStripMenuItem;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem x40ToolStripMenuItem;
	}
}

