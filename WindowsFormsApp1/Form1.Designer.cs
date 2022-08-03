namespace Курсач
{
    partial class MainForm
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comm = new System.Windows.Forms.TextBox();
            this.v1 = new System.Windows.Forms.TextBox();
            this.v2 = new System.Windows.Forms.TextBox();
            this.create = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Honeydew;
            this.picture.Location = new System.Drawing.Point(12, 147);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(517, 500);
            this.picture.TabIndex = 3;
            this.picture.TabStop = false;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search.Location = new System.Drawing.Point(776, 450);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(175, 108);
            this.search.TabIndex = 5;
            this.search.Text = "найти кратчайший путь";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(561, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(390, 337);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // comm
            // 
            this.comm.Enabled = false;
            this.comm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comm.Location = new System.Drawing.Point(12, 4);
            this.comm.Multiline = true;
            this.comm.Name = "comm";
            this.comm.Size = new System.Drawing.Size(517, 137);
            this.comm.TabIndex = 9;
            // 
            // v1
            // 
            this.v1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.v1.Location = new System.Drawing.Point(688, 400);
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(51, 35);
            this.v1.TabIndex = 10;
            this.v1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // v2
            // 
            this.v2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.v2.Location = new System.Drawing.Point(889, 400);
            this.v2.Name = "v2";
            this.v2.Size = new System.Drawing.Size(51, 35);
            this.v2.TabIndex = 11;
            this.v2.TextChanged += new System.EventHandler(this.v2_TextChanged);
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.Khaki;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.create.Location = new System.Drawing.Point(561, 450);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(196, 108);
            this.create.TabIndex = 12;
            this.create.Text = "построить тропы";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(632, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Матрица смежности";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(579, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "начало:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(794, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 16;
            this.label3.Text = "конец:";
            // 
            // clean
            // 
            this.clean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.clean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clean.Location = new System.Drawing.Point(561, 564);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(390, 83);
            this.clean.TabIndex = 17;
            this.clean.Text = "очистить всё";
            this.clean.UseVisualStyleBackColor = false;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 659);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.create);
            this.Controls.Add(this.v2);
            this.Controls.Add(this.v1);
            this.Controls.Add(this.comm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "поиск кратчайшего пути";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox comm;
        private System.Windows.Forms.TextBox v1;
        private System.Windows.Forms.TextBox v2;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clean;
    }
}

