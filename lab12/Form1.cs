using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media; // для подключения нужно добавить в Project->Add reference -> PresentationCore и WindowsBase


namespace lab12
{
    public partial class Form1 : Form
    {
        private int _x; //начальные координаты подвижного обьекта
        private int _y;
        private int _dx; //шаг
        private int _dy;

        private int ejik_size = 80; // габаритный размер картинки "ежик" в пикселях 
        private int gras_size = 240; // габариты неподвижного обьекта трава
        private int apple_size = 75; // габариты неподвижного обьекта яблоко

        private int r1_left_up_point_x = 880;  // координаты неподвижного обьекта яблоко
        private int r1_left_up_point_y = 420;

        private int r2_left_up_point_x = 170;  // координаты неподвижного обьекта  трава1
        private int r2_left_up_point_y = 20;

        private int r3_left_up_point_x = 570;  // координаты неподвижного обьекта  трава2
        private int r3_left_up_point_y = 270;

        System.Media.SoundPlayer backsound = new System.Media.SoundPlayer("sound_1.wav"); // добавление переменной для фоновой музыки
        

        enum Position // перечисление для логики управления ежиком (сохранения состояния)
        {
            Left, Right, Up, Down, Restart, Win, Stop 
        }
        private Position _objPosition;  // переменная перечисления

        public Form1()
        {
            InitializeComponent();
            _x = 50; 
            _y = 50;
            _objPosition = Position.Stop;
            _dx = 2;
            _dy = 2;
            Start.Text = ("Найди яблоко! Для начала кликните Старт. Для управления используйте клавиши-стрелки.");
            
            backsound.PlayLooping(); // фоновая музыка
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);  // буферизация для снижения мерцания изображения
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveSmile();  // ф-ия управления движения обьекта (отрисовка по таймеру, каждые 10 мс)
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // реакция на событие - нажатие клавиши на клавиатуре
        {
            if (e.KeyCode == Keys.Left)   // при нажатии клавиш управления - присвоение значения переменной перечисления
            {
                _objPosition = Position.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _objPosition = Position.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _objPosition = Position.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _objPosition = Position.Down;
            }
        }

        private void MoveSmile() // ф-ия управления движения обьекта и отрисовки окружающих обьектов
        {
            
            Rectangle apple_ = new Rectangle(r1_left_up_point_x, r1_left_up_point_y + 5, apple_size, apple_size);    // создание прямоугольника для неподвижного обьекта(яблоко) 
            Rectangle gras1 = new Rectangle(r2_left_up_point_x, r2_left_up_point_y, gras_size, gras_size);    // создание прямоугольника для неподвижного обьекта(трава1) 
            Rectangle gras2 = new Rectangle(r3_left_up_point_x, r3_left_up_point_y, gras_size, gras_size);          // создание прямоугольника для неподвижного обьекта(трава2) 

            Rectangle eg_image = new Rectangle(_x, _y, ejik_size, ejik_size);            // создание (копии) прямоугольника (не отрисовываем) для подвижного объекта, 
                                                                                         //для проверки пересечения

            //// воспроизведение звука удара о препятствие и "залипание" от левого и правого края формы, и травы////
            if (apple_.IntersectsWith(eg_image)) // пересечение с яблоком
            {
                win(); //  воспроизведение звука при достижении яблока
                _objPosition = Position.Win; // возврат ежикав исходное положение 
            }
            else if ((_x < 0) || (_x > this.ClientSize.Width - ejik_size)) // касание левого или правого края формы
            {
                cick(); 
                _objPosition = Position.Restart;
            }
            else if ((_y < 0) || (_y > this.ClientSize.Height - ejik_size)) // касание верхнего или нижнего края формы
            {
                cick();
                _objPosition = Position.Restart;
            }
            else if (gras2.IntersectsWith(eg_image) || gras1.IntersectsWith(eg_image)) // пересечение с травой (1) и (2)
            {
                cick();
                _objPosition = Position.Restart;
            }

            //// управление движением ежика////
            if (_objPosition == Position.Right) // при нажатии вправо - начинается непрерывное движение вправо
            {
                _x += _dx;
                Start.Text = (" ");  
            }
            else if (_objPosition == Position.Left)  // при нажатии влево - начинается непрерывное движение влево
            {
                _x -= _dx;
                Start.Text = (" ");
            }
            else if (_objPosition == Position.Up)  // при нажатии вверх - начинается непрерывное движение вверх
            {
                _y -= _dy;
                Start.Text = (" ");
            }
            else if (_objPosition == Position.Down)  // при нажатии вниз - начинается непрерывное движение вниз
            {
                _y += _dy;
                Start.Text = (" ");
            }
            else if (_objPosition == Position.Restart) // возврат ежикав исходное положение после касания препятствий
            {
                _x = 50;
                _y = 50;
                Start.Text = ("Попробуйте еще раз.");
            }
            else if (_objPosition == Position.Win) // возврат ежикав исходное положение после попеды
            {
                _x = 50;
                _y = 50;
                Start.Text = ("Вы выиграли!");
            }
             Invalidate(); // команда на перерисовку изображения
        }
            
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Image ejik_image = Image.FromFile("ejik3.jpg"); // создание картинки ежик (size 70)
            Image apple_image = Image.FromFile("apple1.jpg"); // создание картинки яблоко (size 60)
            Image gras_image = Image.FromFile("gras.jpg"); // создание картинки трава (size  182)

            e.Graphics.DrawImage(ejik_image, new Rectangle(_x, _y, ejik_size, ejik_size));  // создание прямоугольника для подвижного обьекта

            e.Graphics.DrawImage(apple_image, r1_left_up_point_x, r1_left_up_point_y);       // отрисовка картинки неподвижного обьекта яблоко
            e.Graphics.DrawImage(gras_image, r2_left_up_point_x, r2_left_up_point_y);       // отрисовка картинки неподвижного обьекта трава (1)
            e.Graphics.DrawImage(gras_image, r3_left_up_point_x, r3_left_up_point_y);       // отрисовка картинки неподвижного обьекта трава (2)
        }
              
        private void Start_b_MouseEnter_1(object sender, EventArgs e) // увеличение шрифта при наведении мыши
        {
            Start_b.Font = new Font("Tahoma", 16, FontStyle.Bold);
        }

        private void Start_b_MouseLeave_1(object sender, EventArgs e) // уменьшение шрифта при уборки мыши
        {
            Start_b.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        private void Start_b_Click_1(object sender, EventArgs e)  // начало движения при клике на lable "Старт"
        {
            _objPosition = Position.Down; // ежик при нажатии кнопки старт начинает движение вниз
        }

        private void cick()   // для воспроизведения звука удара о препятствие
        {
            MediaPlayer cick = new MediaPlayer();
            cick.Open(new Uri("cick.wav", System.UriKind.Relative));
            cick.Play();
        }

        private void win() // для воспроизведения звука при достижении яблока
        {
            MediaPlayer win = new MediaPlayer();
            win.Open(new Uri("win1.wav", System.UriKind.Relative));
            win.Play();
        }
    }
}
