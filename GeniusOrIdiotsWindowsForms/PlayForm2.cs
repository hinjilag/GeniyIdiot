using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniusOrIdiotsWindowsForms
{
    public partial class PlayForm2 : Form
    {
        List<string> questions;
        List<string> answers;
        int correctAnswersCount = 0;
        int stepCount = 0;

        public PlayForm2()
        {
            InitializeComponent();
        }
        private void PlayForm2_Load(object sender, EventArgs e)
        {
            string[] fileQuestions = File.ReadAllLines("..\\..\\..\\questions.txt");
            questions = new List<string>() { };
            for (int i = 0; i < fileQuestions.Length; i++) // проходимся по строкам
            {
                questions.Add(fileQuestions[i]);
            }
            string[] fileAnswers = File.ReadAllLines("..\\..\\..\\answers.txt");
            answers = new List<string>() { };
            for (int i = 0; i < fileAnswers.Length; i++)
            {
                answers.Add(fileAnswers[i]);
            }

            int randomIndex = new Random().Next(0, questions.Count);
            labelQuestion.Text = questions[randomIndex];
            if (textBoxQuestion.Text == answers[randomIndex])
            {
                correctAnswersCount++;
            }
            questions.RemoveAt(randomIndex);
            answers.RemoveAt(randomIndex);
            stepCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBoxQuestion.Text = "";
            int randomIndex = new Random().Next(0, questions.Count);
            if ( stepCount < 2)
            {
                labelQuestion.Text = questions[randomIndex];
                if (textBoxQuestion.Text.Trim() == answers[randomIndex])
                {
                    correctAnswersCount++;
                }
                questions.RemoveAt(randomIndex);
                answers.RemoveAt(randomIndex);
            }
            else
            {
                labelCAC.Visible = true;
                labelDiagnosis.Visible = true;
                labelCAC.Text = $"Количество верных ответов - {correctAnswersCount}";
                labelDiagnosis.Text = $"Ваш диагноз";

            }
            stepCount++;

        }
    }
}
