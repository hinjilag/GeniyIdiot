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

    public partial class deleteForm : Form
    {

        List<string> questions = File.ReadAllLines("..\\..\\..\\questions.txt").ToList();
        List<string> answers = File.ReadAllLines("..\\..\\..\\answers.txt").ToList();
        public deleteForm()
        {
            InitializeComponent();
        }

        private void deleteForm_Load(object sender, EventArgs e)
        {
            label1.Text = string.Join(Environment.NewLine, questions);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxDelQeus.Text.Trim() != "")
            {
                string searchText = textBoxDelQeus.Text.Trim();
                bool found = false;

                // создаем копию списка для перебора                
                List<int> indexesToRemove = new List<int>();

                // сначала находим все индексы для удаления
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i] == searchText)
                    {
                        indexesToRemove.Add(i);
                        found = true;
                    }
                }

                // удаляем с конца, чтобы индексы не сдвигались
                indexesToRemove.Sort((a, b) => b.CompareTo(a)); // сортируем по убыванию
                foreach (int index in indexesToRemove)
                {
                    if (index < questions.Count && index < answers.Count)
                    {
                        questions.RemoveAt(index);
                        answers.RemoveAt(index);
                    }
                }

                

                if (found)
                {
                    label3.Visible = true;
                    label3.Text = "Вопрос успешно удален";
                    label3.ForeColor = Color.Green;

                    // Обновляем отображение вопросов
                    label1.Text = string.Join(Environment.NewLine, questions);

                    // Сохраняем изменения в файлы
                    try
                    {
                        File.WriteAllLines("..\\..\\..\\questions.txt", questions);
                        File.WriteAllLines("..\\..\\..\\answers.txt", answers);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
                    }
                }
                else
                {
                    label3.Visible = true;
                    label3.Text = "Такого вопроса нет!";
                    label3.ForeColor = Color.Red;
                }
            }
            else
            {
                label3.Visible = true;
                label3.Text = "Введите текст вопроса!";
                label3.ForeColor = Color.Red;
            }
        }
    }
}
