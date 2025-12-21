namespace GeniusOrIdiotsWindowsForms
{
    partial class PlayForm2
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
            this.components = new System.ComponentModel.Container();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.answer = new System.Windows.Forms.Button();
            this.labelDiagnosis = new System.Windows.Forms.Label();
            this.labelCAC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuestion.Location = new System.Drawing.Point(313, 231);
            this.labelQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(282, 36);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "тут будут вопросы";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(320, 314);
            this.textBoxQuestion.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(469, 36);
            this.textBoxQuestion.TabIndex = 4;
            // 
            // answer
            // 
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answer.Location = new System.Drawing.Point(383, 386);
            this.answer.Margin = new System.Windows.Forms.Padding(4);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(317, 63);
            this.answer.TabIndex = 5;
            this.answer.Text = "ответить";
            this.answer.UseVisualStyleBackColor = true;
            this.answer.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDiagnosis
            // 
            this.labelDiagnosis.AutoSize = true;
            this.labelDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiagnosis.Location = new System.Drawing.Point(313, 166);
            this.labelDiagnosis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDiagnosis.Name = "labelDiagnosis";
            this.labelDiagnosis.Size = new System.Drawing.Size(176, 31);
            this.labelDiagnosis.TabIndex = 6;
            this.labelDiagnosis.Text = "Ваш диагноз";
            this.labelDiagnosis.Visible = false;
            // 
            // labelCAC
            // 
            this.labelCAC.AutoSize = true;
            this.labelCAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCAC.Location = new System.Drawing.Point(313, 86);
            this.labelCAC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCAC.Name = "labelCAC";
            this.labelCAC.Size = new System.Drawing.Size(422, 31);
            this.labelCAC.TabIndex = 7;
            this.labelCAC.Text = "Количество правильных ответов";
            this.labelCAC.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(377, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Отвечай на вопросы";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 28);
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem1
            // 
            this.менюToolStripMenuItem1.Name = "менюToolStripMenuItem1";
            this.менюToolStripMenuItem1.Size = new System.Drawing.Size(65, 24);
            this.менюToolStripMenuItem1.Text = "Меню";
            this.менюToolStripMenuItem1.Click += new System.EventHandler(this.менюToolStripMenuItem1_Click);
            // 
            // PlayForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCAC);
            this.Controls.Add(this.labelDiagnosis);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.labelQuestion);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayForm2";
            this.Text = "PlayForm2";
            this.Load += new System.EventHandler(this.PlayForm2_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button answer;
        private System.Windows.Forms.Label labelDiagnosis;
        private System.Windows.Forms.Label labelCAC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem1;
    }
}