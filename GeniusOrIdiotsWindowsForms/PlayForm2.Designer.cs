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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.answer = new System.Windows.Forms.Button();
            this.labelDiagnosis = new System.Windows.Forms.Label();
            this.labelCAC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuestion.Location = new System.Drawing.Point(235, 188);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(89, 29);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "готов?";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(240, 255);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(353, 30);
            this.textBoxQuestion.TabIndex = 4;
            // 
            // answer
            // 
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answer.Location = new System.Drawing.Point(287, 314);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(238, 51);
            this.answer.TabIndex = 5;
            this.answer.Text = "ответить";
            this.answer.UseVisualStyleBackColor = true;
            this.answer.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDiagnosis
            // 
            this.labelDiagnosis.AutoSize = true;
            this.labelDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiagnosis.Location = new System.Drawing.Point(235, 136);
            this.labelDiagnosis.Name = "labelDiagnosis";
            this.labelDiagnosis.Size = new System.Drawing.Size(140, 25);
            this.labelDiagnosis.TabIndex = 6;
            this.labelDiagnosis.Text = "Ваш диагноз";
            this.labelDiagnosis.Visible = false;
            // 
            // labelCAC
            // 
            this.labelCAC.AutoSize = true;
            this.labelCAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCAC.Location = new System.Drawing.Point(235, 70);
            this.labelCAC.Name = "labelCAC";
            this.labelCAC.Size = new System.Drawing.Size(339, 25);
            this.labelCAC.TabIndex = 7;
            this.labelCAC.Text = "Количество правильных ответов";
            this.labelCAC.Visible = false;
            // 
            // PlayForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCAC);
            this.Controls.Add(this.labelDiagnosis);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.labelQuestion);
            this.Name = "PlayForm2";
            this.Text = "PlayForm2";
            this.Load += new System.EventHandler(this.PlayForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button answer;
        private System.Windows.Forms.Label labelDiagnosis;
        private System.Windows.Forms.Label labelCAC;
    }
}