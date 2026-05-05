using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MathGame
{
    public partial class MainForm : Form
    {
        private Random random = new Random();
        private int currentScore = 0;
        private int currentRound = 0;
        private int timeLeft = 0;
        private int correctAnswer = 0;

        // Настройки игры
        private const int MaxRounds = 10;
        private const int TimePerQuestion = 15; // Секунд на ответ
        private const int PointsForCorrect = 10;
        private const int PenaltyForWrong = 5;

        // Список рекордов (сортируется по убыванию)
        private List<int> highScores = new List<int>();

        public MainForm()
        {
            InitializeComponent();
            SetGameState(false);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentScore = 0;
            currentRound = 0;
            SetGameState(true);
            NextRound();
        }

        private void NextRound()
        {
            if (currentRound >= MaxRounds)
            {
                EndGame();
                return;
            }

            currentRound++;
            lblRound.Text = $"Раунд: {currentRound} / {MaxRounds}";
            lblScore.Text = $"Очки: {currentScore}";
            txtAnswer.Clear();
            txtAnswer.Focus();

            GenerateEquation();

            timeLeft = TimePerQuestion;
            UpdateTimerLabel();
            gameTimer.Start();
        }

        private void GenerateEquation()
        {
            int operation = random.Next(0, 4); // 0: +, 1: -, 2: *, 3: /
            int a, b;

            switch (operation)
            {
                case 0: // Сложение
                    a = random.Next(1, 50);
                    b = random.Next(1, 50);
                    correctAnswer = a + b;
                    lblEquation.Text = $"{a} + {b} = ?";
                    break;
                case 1: // Вычитание
                    a = random.Next(20, 100);
                    b = random.Next(1, a); // Чтобы ответ был положительным
                    correctAnswer = a - b;
                    lblEquation.Text = $"{a} - {b} = ?";
                    break;
                case 2: // Умножение
                    a = random.Next(2, 12);
                    b = random.Next(2, 12);
                    correctAnswer = a * b;
                    lblEquation.Text = $"{a} * {b} = ?";
                    break;
                case 3: // Деление (без остатка)
                    b = random.Next(2, 12); // Делитель
                    correctAnswer = random.Next(2, 12); // Результат
                    a = b * correctAnswer; // Делимое
                    lblEquation.Text = $"{a} / {b} = ?";
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        // Позволяет нажимать Enter вместо клика по кнопке
        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CheckAnswer();
            }
        }

        private void CheckAnswer()
        {
            gameTimer.Stop(); // Останавливаем таймер на время проверки

            if (int.TryParse(txtAnswer.Text, out int userAnswer))
            {
                if (userAnswer == correctAnswer)
                {
                    currentScore += PointsForCorrect;
                }
                else
                {
                    currentScore -= PenaltyForWrong;
                    MessageBox.Show($"Неверно! Правильный ответ был: {correctAnswer}\nШтраф -{PenaltyForWrong} очков.", "Ошибка");
                }
            }
            else
            {
                currentScore -= PenaltyForWrong;
                MessageBox.Show($"Введено не число! Штраф -{PenaltyForWrong} очков.", "Ошибка ввода");
            }

            NextRound();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimerLabel();

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                currentScore -= PenaltyForWrong; // Штраф за тайм-аут
                MessageBox.Show($"Время вышло!\nПравильный ответ: {correctAnswer}\nШтраф -{PenaltyForWrong} очков.", "Тайм-аут");
                NextRound();
            }
        }

        private void UpdateTimerLabel()
        {
            lblTimer.Text = $"Время: {timeLeft}";
        }

        private void EndGame()
        {
            gameTimer.Stop();
            SetGameState(false);
            lblEquation.Text = "Игра окончена!";
            lblScore.Text = $"Итоговые очки: {currentScore}";
            lblRound.Text = "Раунд: - / -";

            // Обновление таблицы рекордов
            highScores.Add(currentScore);
            highScores = highScores.OrderByDescending(x => x).ToList();

            lstLeaderboard.Items.Clear();
            for (int i = 0; i < highScores.Count; i++)
            {
                lstLeaderboard.Items.Add($"{i + 1} место: {highScores[i]} очков");
            }

            MessageBox.Show($"Ваш результат: {currentScore} очков!", "Конец игры");
        }

        private void SetGameState(bool isPlaying)
        {
            btnStart.Enabled = !isPlaying;
            txtAnswer.Enabled = isPlaying;
            btnSubmit.Enabled = isPlaying;

            if (!isPlaying)
            {
                txtAnswer.Clear();
                lblTimer.Text = "Время: 0";
            }
        }
    }
}