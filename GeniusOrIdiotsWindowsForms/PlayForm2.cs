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
        int сorrectAnswersCount = 0;
        int stepCount = 0;
        int randomIndex = 0;
        double questionsCount = 6; // количество вопросов задаваемых пользователю
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
            randomIndex = new Random().Next(0, questions.Count);

            labelQuestion.Text = questions[randomIndex];
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxQuestion.Text.Trim() == answers[randomIndex])
            {
                сorrectAnswersCount++;
            }
            textBoxQuestion.Text = "";
            questions.RemoveAt(randomIndex);
            answers.RemoveAt(randomIndex);
            randomIndex = new Random().Next(0, questions.Count);

            if ( stepCount < questionsCount)
            {
                labelQuestion.Text = questions[randomIndex];                                
            }
            else
            {
                labelCAC.Visible = true;
                labelDiagnosis.Visible = true;
                textBoxQuestion.Enabled = false;
                labelQuestion.Visible = false;
                string diagnosis = DefinitDiagnosis(сorrectAnswersCount, questionsCount);
                label1.Text = "Вы ответили на все вопросы!";
                labelCAC.Text = $"Количество верных ответов - {сorrectAnswersCount}";
                labelDiagnosis.Text = $"Ваш диагноз - {diagnosis}";
                answer.Enabled = false;
            }
            stepCount++;

        }
        static string DefinitDiagnosis(int сorrectAnswersCount, double questionsCount)
        {

            double range = questionsCount / 6;
            string diagnoz = "";
            if (сorrectAnswersCount < range)
                diagnoz = "бедолага";
            else if (сorrectAnswersCount < 2 * range)
                diagnoz = "дурак";
            else if (сorrectAnswersCount < 3 * range)
                diagnoz = "дурик";
            else if (сorrectAnswersCount < 4 * range)
                diagnoz = "жить будешь";
            else if (сorrectAnswersCount < 5 * range)
                diagnoz = "тип";
            else
                diagnoz = "тынг тип!!!";
            return diagnoz;
        }

        private void менюToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 play = new Form1();
            play.Show();
            Hide();
        }
    }
}
