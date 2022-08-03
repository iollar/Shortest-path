using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MatrixAdg(KolvoV);
            comm.Text = "Заполните матрицу смежности, указывая длины троп, соединяющих площадки. Нажмите кнопку \"построить тропы\".";
            comm.Text += "\r\nВНИМАНИЕ! Если между площадками имеется несколько кратчайших путей, то изображен будет только один.";
        }
        const int KolvoV = 7;

        float[,] MasXY = new float[100, 100];
        float[,] MasOD = new float[100, 100];
        

        //строим вершины
        private void VertexOnArc(Graphics DrawingArea, float centerX, float centerY, float radius, float angle1, float angle2, int val)
        {
            Font font = new Font("Arial", 14, FontStyle.Regular);
            Pen pen = new Pen(Color.Green,5);

            angle1 = (float)((angle1 / 180) * Math.PI);
            angle2 = (float)((angle2 / 180) * Math.PI);
            float delta = (angle2 - angle1) / val;

            float x1 = centerX + radius * (float)Math.Cos(angle1);
            float y1 = centerY - radius * (float)Math.Sin(angle1);
            MasXY[0, 0] = x1;
            MasXY[1, 0] = y1;
            for (int i = 1; i <= val; i++)
            {
                angle1 += delta;
                float x2 = centerX + radius * (float)Math.Cos(angle1);
                float y2 = centerY - radius * (float)Math.Sin(angle1);
                DrawingArea.DrawEllipse(pen, x1 - 15, y1 - 15, 30, 30);
                DrawingArea.FillEllipse(Brushes.White, x1 - 15, y1 - 15, 30, 30);
                DrawingArea.DrawString(i.ToString(), font, Brushes.Black, x1 - 8, y1 - 10);
                MasXY[0, i] = x2;
                MasXY[1, i] = y2;
                x1 = x2;
                y1 = y2;
            }
        }
        

        //матрица смежности
        private void MatrixAdg(int val)
        {
            dataGridView1.Columns.Clear();
            for (int i = 1; i <= val; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), "v" + i.ToString());
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 1].HeaderCell.Value = "v" + i.ToString(); //
                dataGridView1.Columns[i - 1].Width = 30;
                dataGridView1.RowHeadersWidth = 48;
            }
            for (int i = 0; i < val; i++)
                for (int j = 0; j < val; j++)
                    if (i == j)
                        dataGridView1[i, j].Value = "0";
                    else
                        dataGridView1[i, j].Value = "\u221e";
        }


        //симметричное заполнение матрицы смежности
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1[e.RowIndex, e.ColumnIndex].Value = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            }
            catch
            { }
        }


        //создать граф
        private void create_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            Graphics pic = Graphics.FromImage(bmp);
            picture.Image = bmp;

            VertexOnArc(pic, picture.Width / 2, picture.Height / 2, 140, 450, 90, KolvoV);

            int val = KolvoV;
            float x1, x2, y1, y2;

            {
                Pen pen = new Pen(Color.DarkKhaki, 3);
                for (int i = 0; i < val; i++)
                {
                    for (int j = i + 1; j < val; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString() != "\u221e")
                        {
                            x1 = MasXY[0, i];
                            y1 = MasXY[1, i];
                            x2 = MasXY[0, j];
                            y2 = MasXY[1, j];
                            float theta = (float)Math.Atan2(y2 - y1, x2 - x1);
                            x1 = x1 + 15 * (float)Math.Cos(theta);
                            y1 = y1 + 15 * (float)Math.Sin(theta);
                            x2 = x2 - 15 * (float)Math.Cos(theta);
                            y2 = y2 - 15 * (float)Math.Sin(theta);
                            pic.DrawLine(pen, x1, y1, x2, y2);
                        }
                    }
                }
            }
            comm.Text = "Укажите номера начальной и конечной площадки. Нажмите кнопку \"найти кратчайший путь\".\r\n";

        }
        

        // Алгоритм Дейкстры
        List<List<int>> way = new List<List<int>>();
        string[] length = new string[KolvoV];
        bool testG = false;
        private void Dijkstra(int v1, int v2)
        {
            try
            {
                HashSet<int> Clean = new HashSet<int>();
                List<int> wayNow = new List<int>();
                for (int i = 0; i < KolvoV; i++)
                { }

                //первоначальное заполнение
                for (int i = 0; i < KolvoV; i++)
                {
                    if (i != v1)
                    {
                        length[i] = "\u221e";
                    }
                    else
                    {
                        length[i] = "0";
                    }
                    way.Add(wayNow.GetRange(0, wayNow.Count));
                    Clean.Add(i);
                }


                bool test = true;
                int now = 0;

                //проверка на не посещенность            
                for (int k = 0; k < 7; k++)
                {
                    //выбор вершины с мин меткой
                    for (int i = 0; i < KolvoV && k != KolvoV; i++)
                    {
                        if (Clean.Contains(i) && length[i] != "\u221e" && (test == true || int.Parse(length[i]) < int.Parse(length[now])))
                        {
                            test = false;
                            now = i;
                            wayNow = way[now];
                            wayNow.Add(now);
                        }
                    }

                    //проверка смежных с now, новая метка для i
                    for (int i = 0; i < KolvoV; i++)
                        if (
                               Clean.Contains(i) &&
                               dataGridView1.Rows[now].Cells[i].Value.ToString() != "\u221e" &&
                               (length[i] == "\u221e" ||
                               int.Parse(dataGridView1.Rows[now].Cells[i].Value.ToString()) + int.Parse(length[now]) < int.Parse(length[i]))
                           )
                        {
                            length[i] = (uint.Parse(dataGridView1.Rows[now].Cells[i].Value.ToString()) + int.Parse(length[now])).ToString();

                            way[i] = wayNow.GetRange(0, wayNow.Count);
                        }
                    Clean.Remove(now);
                    test = true;
                }
                testG = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Недопустимое значение! Длина тропы должна являться неотрицательным числом от 0 до 4 294 967 295");
                testG = false;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Недопустимое значение! Длина тропы должна являться неотрицательным числом от 0 до 4 294 967 295");
                testG = false;
            }
        }

        //построение мин. пути
        int vertex1 = 0, vertex2 = 0;
        private void search_Click(object sender, EventArgs e)
        {
            if (v1.Text == "" || v2.Text == "")
                MessageBox.Show("Вы забыли внести номера площадок");
            else
            {
                int val = KolvoV;
                try
                {
                    vertex1 = Int32.Parse(v1.Text);
                    vertex2 = Int32.Parse(v2.Text);

                    if (vertex1 > 0 && vertex1 < 8 && vertex2 < 8 && vertex2 > 0)
                    {
                        Dijkstra(vertex1 - 1, vertex2 - 1);

                        if (length[vertex2 - 1] == "\u221e" && testG)
                            comm.Text = "Пути от площадки" + vertex1 + " до площадки " + vertex2 + " не существует";
                        else
                        if(testG)
                        {
                            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
                            Graphics pic = Graphics.FromImage(bmp);
                            picture.Image = bmp;
                            VertexOnArc(pic, picture.Width / 2, picture.Height / 2, 140, 450, 90, KolvoV);

                            float x1, x2, y1, y2;

                            Pen pen = new Pen(Color.DarkKhaki, 3);
                            Pen pen2 = new Pen(Color.DarkBlue, 6);
                            for (int i = 0; i < val; i++)
                            {
                                for (int j = i + 1; j < val; j++)
                                {
                                    if (dataGridView1.Rows[i].Cells[j].Value.ToString() != "\u221e")
                                    {
                                        x1 = MasXY[0, i];
                                        y1 = MasXY[1, i];
                                        x2 = MasXY[0, j];
                                        y2 = MasXY[1, j];
                                        float theta = (float)Math.Atan2(y2 - y1, x2 - x1);
                                        x1 = x1 + 15 * (float)Math.Cos(theta);
                                        y1 = y1 + 15 * (float)Math.Sin(theta);
                                        x2 = x2 - 15 * (float)Math.Cos(theta);
                                        y2 = y2 - 15 * (float)Math.Sin(theta);
                                        pic.DrawLine(pen, x1, y1, x2, y2);
                                    }
                                }
                            }
                            for (int i = 0; i < way[vertex2 - 1].Count - 1; i++)
                            {
                                x1 = MasXY[0, way[vertex2 - 1][i]];
                                y1 = MasXY[1, way[vertex2 - 1][i]];
                                x2 = MasXY[0, way[vertex2 - 1][i + 1]];
                                y2 = MasXY[1, way[vertex2 - 1][i + 1]];
                                float theta = (float)Math.Atan2(y2 - y1, x2 - x1);
                                x1 = x1 + 15 * (float)Math.Cos(theta);
                                y1 = y1 + 15 * (float)Math.Sin(theta);
                                x2 = x2 - 15 * (float)Math.Cos(theta);
                                y2 = y2 - 15 * (float)Math.Sin(theta);
                                pic.DrawLine(pen2, x1, y1, x2, y2);
                            }
                            comm.Text = "Кратчайший путь от площадки " + vertex1 + " до площадки " + vertex2 + " построен и равен " + length[vertex2 - 1];
                        }
                    }
                    else
                        MessageBox.Show("Вы ввели несуществующие номера площадок");
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Недопустимое значение! Номер площадки должен являться неотрицательным числом");
                }
            }
            way.Clear();
        }


        private void clean_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
            Close();
        }


        //не исп.
        private void picture_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void v2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

    }


}
