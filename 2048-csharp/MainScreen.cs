using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game2048
{
    public class MainScreen : Form
    {
        string userName = "";
        int current_Bill = -1;
        private Timer timer1;
        private System.ComponentModel.IContainer components;


        private Boolean auto = false;

        public MainScreen()
        {
            InitializeComponent();
            
            this.Load += (sender, e) => MainScreen_Load(sender, e);
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        /// <summary>
        /// Обработчик события загрузки формы.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Класс события.</param>
        private void MainScreen_Load(object sender, EventArgs e)
        {
            fStart start = new fStart();
            start.ShowDialog();
            if (!start.isPlay) Close();

            current_Bill = start.Bill;
            userName = start.UserName;

            int fieldSize = Cell.SizeValue * Field.Dimension + Cell.MarginValue * (Field.Dimension + 1);

            int headerHeight = 70;

            int width = fieldSize + _PADDING * 2;
            int height = fieldSize + _PADDING * 3 + headerHeight;
            int x = Screen.PrimaryScreen.Bounds.Width / 2 - width / 2;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 - height / 2;

            Name = "2048";
            Text = "2048";
            MaximizeBox = false;
            ClientSize = new Size(width, height);
            Location = new Point(x, y);
            BackColor = Color.FromArgb(251, 249, 239);

            Panel header = new Panel()
            {
                Location = new Point(_PADDING, _PADDING),
                Width = width - _PADDING * 2,
                Height = headerHeight
            };

            _BestScore = new Score("Рекорд", _Storage.ReadBestScore())
            {
                Location = new Point(header.Width - Score.WidthValue, 0)
            };

            _CurrentScore = new Score("Счет", current_Bill)
            {
                Location = new Point(header.Width - Score.WidthValue * 2 - _PADDING, 0)
            };

            _CurrentUser = new LabelShow("Игрок: ",userName)
            {
                Location = new Point(0, 0)
            };

            header.Controls.Add(_CurrentUser);
            header.Controls.Add(_BestScore);
            header.Controls.Add(_CurrentScore);

            _Field = new Field()
            {
                Location = new Point(_PADDING, _PADDING * 2 + header.Height),
                Size = new Size(fieldSize, fieldSize)
            };

            Controls.Add(header);
            Controls.Add(_Field);

            _Field.AddRandomItem();
            _Field.UpdateUI();
        }

        /// <summary>
        /// Обработчик события нажатия на клавишу.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Класс события.</param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            bool isMove = false;
            int score = 0;

            if(e.KeyCode == Keys.Q) 
                auto = !auto;

            switch (auto)
            {
               case true:
                    if(timer1!=null) timer1.Start();
                    break;
               case false:
                    if(timer1!=null) timer1.Stop();
                    break;
            }
           
 
            if(!auto)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        isMove = _Field.ChangeByDirection(EDirection.UP, out score);
                        break;
                    case Keys.Right:
                        isMove = _Field.ChangeByDirection(EDirection.RIGHT, out score);
                        break;
                    case Keys.Down:
                        isMove = _Field.ChangeByDirection(EDirection.DOWN, out score);
                        break;
                    case Keys.Left:
                        isMove = _Field.ChangeByDirection(EDirection.LEFT, out score);
                        break;

                }
            }


            _CurrentScore.Increase(score);
            if (_CurrentScore.Value > _BestScore.Value)
            {
                _BestScore.SetValue(_CurrentScore.Value);
                _Storage.WriteBestScore(_BestScore.Value);
            }

            if (isMove)
            {
                _Field.AddRandomItem();
            }
            _Field.UpdateUI();
            if (_Field.isGameOver())
            {
                MessageBox.Show("Вы проиграли!");
                ResetState();
            }
        }

        /// <summary>
        /// Сбрасывает компоненты игры.
        /// </summary>
        private void ResetState()
        {
            _CurrentScore.Reset();
            _Field.Reset();
            _Field.AddRandomItem();
            _Field.UpdateUI();
        }

        private readonly Storage _Storage = new Storage();

        private const int _PADDING = 25;

        private Field _Field;

        private Score _CurrentScore;

        private LabelShow _CurrentUser;

        private Score _BestScore;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainScreen
            // 
            this.ClientSize = new System.Drawing.Size(309, 223);
            this.Name = "MainScreen";
            this.ResumeLayout(false);

        }

        Random rnd = new Random();
        private EDirection Next()
        {
            int[,] field = _Field.GetCells();
            int direct = rnd.Next(4);
            if (direct == 0) return EDirection.UP;
            if (direct == 1) return EDirection.LEFT;
            if (direct == 2) return EDirection.RIGHT;
            return EDirection.DOWN;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isMove = false;
            int score = 0;
            isMove = _Field.ChangeByDirection(Next(), out score);

            _CurrentScore.Increase(score);
            if (_CurrentScore.Value > _BestScore.Value)
            {
                _BestScore.SetValue(_CurrentScore.Value);
                _Storage.WriteBestScore(_BestScore.Value);
            }

            if (isMove)
            {
                _Field.AddRandomItem();
            }
            _Field.UpdateUI();
            if (_Field.isGameOver())
            {
                MessageBox.Show("Вы проиграли!");
                ResetState();
            }
        }
    }
}