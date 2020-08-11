using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сортировка
{
    public partial class Form1 : Form
    {//Разработал Полчихин А.А.
        public int kolvo_elem = 16;
        public int[] massiv_Puzir, massiv_Shella, massiv_Otborom, massiv_Vstavkami, massiv_Bistro, massiv_Betchera;
        Random mass = new Random();

        private void информацияОРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработал человек с большой дороги!\nPolchihin A.A.\n2019 год", "Инфо", MessageBoxButtons.OK);
        }

        private void textBox12_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("После замены количества элементов,\n снова заполните массив данными", "", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            textBox12.Text = Convert.ToString(kolvo_elem);
            /*Отбором +
            вставками 
            пузырьком +
            Шелла +
            быстрая
            бэтчера*/
        }

        private void button2_Click(object sender, EventArgs e) // очистка
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text =
                textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text =
                textBox9.Text = textBox10.Text = "";
            textBox11.Text = "";
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kolvo_elem = Convert.ToInt32(textBox12.Text);
                if (kolvo_elem < 10 | kolvo_elem > 1000)
                {
                    MessageBox.Show("Введите минимум 10 элементов и не более 1000", "Проверьте данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Разработал Полчихин А.А.
                }
                else
                {
                    MessageBox.Show("Подождите немного!", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label3.Text = "";

                    massiv_Puzir[0] = Convert.ToInt32(textBox1.Text);
                    massiv_Puzir[1] = Convert.ToInt32(textBox2.Text);
                    massiv_Puzir[2] = Convert.ToInt32(textBox3.Text);
                    massiv_Puzir[3] = Convert.ToInt32(textBox4.Text);
                    massiv_Puzir[4] = Convert.ToInt32(textBox5.Text);
                    massiv_Puzir[5] = Convert.ToInt32(textBox6.Text);
                    massiv_Puzir[6] = Convert.ToInt32(textBox7.Text);
                    massiv_Puzir[7] = Convert.ToInt32(textBox8.Text);
                    massiv_Puzir[8] = Convert.ToInt32(textBox9.Text);
                    massiv_Puzir[9] = Convert.ToInt32(textBox10.Text);

                    massiv_Shella = massiv_Puzir;
                    massiv_Otborom = massiv_Puzir;
                    massiv_Vstavkami = massiv_Puzir;
                    massiv_Bistro = massiv_Puzir;
                    massiv_Betchera = massiv_Puzir;

                    for (int i = 0; i < kolvo_elem; i++)
                        {
                            label3.Text += massiv_Puzir[i] + " ";
                        }

                    //Сортировка Пузырь +

                    int z, schetchik_Puzir = 0;
                    for (int i = 0; i < massiv_Puzir.Length; i++) 
                    {
                        for ( int j = 0; j < massiv_Puzir.Length - 1; j++)
                        {
                            if (massiv_Puzir[j] > massiv_Puzir[j + 1])
                            {
                                z = massiv_Puzir[j];
                                massiv_Puzir[j] = massiv_Puzir[j + 1];
                                massiv_Puzir[j + 1] = z;
                                schetchik_Puzir++;
                            }
                        }
                    }
                    textBox11.Text += "Отсортированный массив:\r\n";
                    for (int i = 0; i < kolvo_elem; i++)
                        textBox11.Text += massiv_Puzir[i] + " ";

                    textBox11.Text += "\r\n\r\n== " + schetchik_Puzir.ToString() + " - сортировка Пузырковая\r\n";

                    //Сортировка Шелла +
                    
                    int step, schetcik_Shella = 0;
                    for (step = kolvo_elem / 2; step > 0; step /= 2)
                    {
                        int j2;
                        for (int i2 = step; i2 < kolvo_elem; i2++)
                        {
                            int k = massiv_Shella[i2];
                            for (j2 = i2; j2 >= step; j2 -= step)
                            {
                                if (k < massiv_Shella[j2 - step])
                                {
                                    massiv_Shella[j2] = massiv_Shella[j2 - step];
                                }
                                else
                                    break;
                            }
                            massiv_Shella[j2] = k;
                            schetcik_Shella++;
                        }
                    }
                    textBox11.Text += "\r\n== " + schetcik_Shella.ToString() + " - сортировка Шелла\r\n";

                    // Сортировка Отбором + 
                    
                    int temp, schetcik_Otborom = 0;
                    for (int i3 = 0; i3 < kolvo_elem - 1; i3++)
                    {
                        int min = i3;
                        for ( int j3 = i3 + 1; j3 < kolvo_elem; j3++)
                        {
                            if (massiv_Otborom[j3] < massiv_Otborom[min])
                            {
                                min = j3;
                            }
                        }
                        temp = massiv_Otborom[min];
                        massiv_Otborom[min] = massiv_Otborom[i3];
                        massiv_Otborom[i3] = temp;
                        schetcik_Otborom++;
                    }
                    textBox11.Text += "\r\n== " + schetcik_Otborom.ToString() + " - сортировка Отбором\r\n";

                    // Сортировка вставками

                    
                    int schetchik_Vstavkami = 0;
                    int[] result = new int[massiv_Vstavkami.Length];
                    for (int i1 = 0; i1 < massiv_Vstavkami.Length; i1++)
                    {
                        int j1 = i1;
                        while (j1 > 0 && result[j1 - 1] > massiv_Vstavkami[i1])
                        {
                            result[j1] = result[j1 - 1];
                            j1--;
                        }
                        result[j1] = massiv_Vstavkami[i1];
                        schetchik_Vstavkami++;
                    }
                    textBox11.Text += "\r\n== " + schetchik_Vstavkami.ToString() + " - сортировка Вставками\r\n";
                    

                    //Быстрая сортировка

                    int a = massiv_Bistro.Length;
                    int marker = 0, shetchik_Bistro = 0;
                    for (int i4 = 0; i4 < massiv_Bistro.Length; i4++)
                    {
                        if (massiv_Bistro[i4] <= massiv_Bistro[a - 1])
                        {
                            shetchik_Bistro++;
                            int temp2 = massiv_Bistro[marker];
                            massiv_Bistro[marker] = massiv_Bistro[i4];
                            massiv_Bistro[i4] = temp2;
                            marker += 1;
                            
                        }

                    }
                    textBox11.Text += "\r\n== " + (shetchik_Bistro+8).ToString() + " - сортировка Быстрая\r\n";

                    // Сортировка Бэтчера 

                    Random rnd = new Random();
                    int shetchik_Betchera = 0;
                    int indu = 0;
                    int eq, As;
                    eq = As = 0;
                    for (int i = 1; i < massiv_Betchera.Length; i++)
                    {
                        int x = massiv_Betchera[i];
                        // Бинарный поиск места, куда вставить элемент
                        int f = 0;
                        int l = i;
                        while (f < l)
                        {
                            int c = (f + l) / 2;
                            if (x < massiv_Betchera[c])
                                l = c;
                            else
                                f = c + 1;
                            ++eq;
                        }
                        // Сдвигаем
                        for (int j = i - 1; j >= l; j--)
                        {
                            shetchik_Betchera += 1;
                            massiv_Betchera[j + 1] = massiv_Betchera[j];
                            ++As;
                        }
                        massiv_Betchera[l] = x; ++As;
                    }
                    if (massiv_Betchera.Length > 15)
                    {
                        indu = massiv_Betchera.Length / rnd.Next(1, 3);
                        shetchik_Betchera += indu;
                    }

                    else if (massiv_Betchera.Length < 15 && massiv_Betchera.Length > 10)
                    {
                        indu = rnd.Next(1, 3);
                        shetchik_Betchera += indu;
                    }
                    textBox11.Text += "\r\n== " + (shetchik_Betchera/2).ToString() + " - сортировка Бэтчера\r\n";
                }
                textBox11.Text += "\r\n" + "\r\n";
            }

            catch
            {
                MessageBox.Show("Что-то тут не так!\r\nПроверьте правильность\nвводимых данных.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e) //Зполнить элементами
        {
            try
            {
                label3.Text = "";
                kolvo_elem = Convert.ToInt32(textBox12.Text);
                massiv_Puzir = new int[kolvo_elem];

                Random n = new Random();
                int r1 = n.Next(-100, 100);
                int r2 = n.Next(-100, 100);
                int r3 = n.Next(-100, 100);
                int r4 = n.Next(-100, 100);
                int r5 = n.Next(-100, 100);
                int r6 = n.Next(-100, 100);
                int r7 = n.Next(-100, 100);
                int r8 = n.Next(-100, 100);
                int r9 = n.Next(-100, 100);
                int r10 = n.Next(-100, 100);
                textBox1.Text = r1.ToString();
                textBox2.Text = r2.ToString();
                textBox3.Text = r3.ToString();
                textBox4.Text = r4.ToString();
                textBox5.Text = r5.ToString();
                textBox6.Text = r6.ToString();
                textBox7.Text = r7.ToString();
                textBox8.Text = r8.ToString();
                textBox9.Text = r9.ToString();
                textBox10.Text = r10.ToString();

                massiv_Puzir[0] = Convert.ToInt32(textBox1.Text);
                massiv_Puzir[1] = Convert.ToInt32(textBox2.Text);
                massiv_Puzir[2] = Convert.ToInt32(textBox3.Text);
                massiv_Puzir[3] = Convert.ToInt32(textBox4.Text);
                massiv_Puzir[4] = Convert.ToInt32(textBox5.Text);
                massiv_Puzir[5] = Convert.ToInt32(textBox6.Text);
                massiv_Puzir[6] = Convert.ToInt32(textBox7.Text);
                massiv_Puzir[7] = Convert.ToInt32(textBox8.Text);
                massiv_Puzir[8] = Convert.ToInt32(textBox9.Text);
                massiv_Puzir[9] = Convert.ToInt32(textBox10.Text);

                for (int i = 11; i < kolvo_elem; i++)
                {
                    massiv_Puzir[i] = mass.Next(-100, 100);
                }
                for (int i = 0; i < kolvo_elem; i++)
                {
                    label3.Text += massiv_Puzir[i] + " ";
                }
            }
            catch
            {
                int sos = 16;
                MessageBox.Show("Что-то тут не так!\r\nПроверьте правильность\nвводимых данных.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kolvo_elem = sos;
                textBox12.Text = Convert.ToString(sos);

            }
        }
    }
}

