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
    public partial class PlayForm : Form
    {
        public PlayForm()
        {
            InitializeComponent();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int questionsCount = 5;

            string[] fileQuestions = File.ReadAllLines("..\\..\\..\\questions.txt");
            List<string> questions = new List<string>() { };
            for (int i = 0; i < fileQuestions.Length; i++) // проходимся по строкам
            {
                questions.Add(fileQuestions[i]);
            }

            string[] fileAnswers = File.ReadAllLines("..\\..\\..\\answers.txt");
            List<string> answers = new List<string>() { };
            for (int i = 0; i < fileAnswers.Length; i++)
            {
                answers.Add(fileAnswers[i]);
            }
            int сorrectAnswersCount = 0;

            for (int i = 1; i <= questionsCount; i++) // сам тест 
            {
                int randomIndex = new Random().Next(0, questions.Count);                
                questionLabel.Text = $"{i})  {questions[randomIndex]}";

                //string userAnswer = Console.ReadLine();
                //if (answers[randomIndex] == userAnswer)
                //{
                //    сorrectAnswersCount++;
                //}

                questions.RemoveAt(randomIndex);
                answers.RemoveAt(randomIndex);

            }
        }
    }
}
