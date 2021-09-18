using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Transformation
{
    public partial class Form1 : Form

    {
        int[] point1 = { 100, 200 };
        int[] point2 = { 200, 300 };
        int[] point3 = { 100, 400 };
        Pen p = new Pen(Brushes.Black, 5);
        Graphics x;
        Point p1, p2, p3;
        public Form1()
        {
            InitializeComponent();
            x=panel1.CreateGraphics();
            comboBox1.SelectedIndex = 0;
        }

        public void drawTriangle(int[] point1, int[] point2, int[] point3)
        {
            p1 = new Point(point1[0], point1[1]);
            p2 = new Point(point2[0], point2[1]);
            p3 = new Point(point3[0], point3[1]);
            x.DrawLine(p, p1, p2);
            x.DrawLine(p, p1, p3);
            x.DrawLine(p, p2, p3);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                trans.Visible = true;
                label24.Text = "";
                panel3.Visible = true;
                rotat.Visible = true;
                label23.Text = "Point2";
                label2.Text = "X1";
                label3.Text = "Y1";
                label29.Text = "X2";
                label30.Text = "Y2";
                label5.Text = "X3";
                label6.Text = "Y3";

            }
             else if (comboBox1.SelectedIndex==2 || comboBox1.SelectedIndex == 4)
            {
                trans.Visible = true;
                label24.Text = "Point2";
                label23.Text = "Point3";
                panel3.Visible = false;
                rotat.Visible = false;
                if (comboBox1.SelectedIndex==2)
                {
                    label2.Text = "θ1";
                    label3.Text = "θ2";
                    label29.Text = "θ3";
                }
                else if (comboBox1.SelectedIndex==4)
                {
                    label2.Text = "X1";
                    label3.Text = "X2";
                    label29.Text = "X3";
                }
                
            }
           
            else if(comboBox1.SelectedIndex==3)
            {
                trans.Visible = false;
                rotat.Visible = false;
                panel3.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawTriangle(point1, point2, point3);
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals(""))
                {
                    string message = "field(s) are EMPTY";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                else if (!isNum(textBox1.Text) || !isNum(textBox2.Text) || !isNum(textBox3.Text) || !isNum(textBox4.Text) || !isNum(textBox5.Text) || !isNum(textBox6.Text))
                {
                    string message = "enter INTEGER number to the fields";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }

                else
                {

                    int[] transform1 = { Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text) };
                    int[] transform2 = { Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text) };

                    int[] transform3 = { Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text) };
                    if (transform1[0] < 0 || transform1[1] < 0 || transform2[0] < 0 || transform2[1] < 0 || transform3[0] < 0 || transform3[1] < 0)
                    {
                        string message = "enter POSITIVE number to the fields";
                        string title = "Error";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 0)
                        {
                            this.point1 = Transform_2D(point1, transform1, 1.0, "Translate");
                            this.point2 = Transform_2D(point2, transform2, 1.0, "Translate");
                            this.point3 = Transform_2D(point3, transform3, 1.0, "Translate");

                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            this.point1 = Transform_2D(point1, transform1, 1.0, "Scale");
                            this.point2 = Transform_2D(point2, transform2, 1.0, "Scale");
                            this.point3 = Transform_2D(point3, transform3, 1.0, "Scale");
                        }
                        x.Clear(Color.White);
                        drawTriangle(point1, point2, point3);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                {
                    string message = "field(s) are EMPTY";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                else if (!isDouble(textBox1.Text) || !isDouble(textBox2.Text) || !isDouble(textBox3.Text))
                {
                    string message = "enter DOUBLE number to the fields";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }

                else
                {
                    double R1 = Convert.ToDouble(textBox1.Text);
                    double R2 = Convert.ToDouble(textBox2.Text);
                    double R3 = Convert.ToDouble(textBox3.Text);
                    if (R1 < 0 || R2 < 0 || R3 < 0)
                    {
                        string message = "enter POSITIVE number to the fields";
                        string title = "Error";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        int[] nulll = { 0 };
                        this.point1 = Transform_2D(point1, nulll, R1, "Rotate");
                        this.point2 = Transform_2D(point2, nulll, R2, "Rotate");
                        this.point3 = Transform_2D(point3, nulll, R3, "Rotate");
                        x.Clear(Color.White);
                        drawTriangle(point1, point2, point3);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                int[] nulll = { 0 };
                this.point1 = Transform_2D(point1, nulll, 1.0, "Reflect");
                this.point2 = Transform_2D(point2, nulll, 1.0, "Reflect");
                this.point3 = Transform_2D(point3, nulll, 1.0, "Reflect");
                x.Clear(Color.White);
                drawTriangle(point1, point2, point3);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                {
                    string message = "field(s) are EMPTY";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                else if (!isNum(textBox1.Text) || !isNum(textBox2.Text) || !isNum(textBox3.Text))
                {
                    string message = "enter INTEGER number to the fields";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }

                else
                {
                    int[] shear1 = { Convert.ToInt32(textBox1.Text) };
                    int[] shear2 = { Convert.ToInt32(textBox2.Text) };
                    int[] shear3 = { Convert.ToInt32(textBox3.Text) };
                    if (shear1[0] < 0 || shear2[0] < 0 || shear3[0] < 0)
                    {
                        string message = "enter POSITIVE number to the fields";
                        string title = "Error";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        
                        this.point1 = Transform_2D(point1, shear1, 1.0, "Shear");
                        this.point2 = Transform_2D(point2, shear2, 1.0, "Shear");
                        this.point3 = Transform_2D(point3, shear3, 1.0, "Shear");
                        x.Clear(Color.White);
                        drawTriangle(point1, point2, point3);
                    }

                }
            }
            string message1 = "Point1 : X1= "+point1[0]+", Y1= "+point1[1]+"\n Point2 : X2= "+point2[0]+", Y2= "+point2[1]+"\n Point3 : X3= "+point3[0]+", Y3= "+point3[1]+" ." ;
            string title1 = "Message";
            MessageBox.Show(message1, title1);

        }

        public Boolean isNum(string x)
        {
            int y;
            try
            {
                y = Convert.ToInt32(x);
                return true;

            }
            catch
            {
                return false;
            }
            return false;

        }
        public Boolean isDouble(string x)
        {
            double y;
            try
            {
                y = Convert.ToDouble(x);
                return true;

            }
            catch
            {
                return false;
            }
            return false;

        }
        public static int[] Transform_2D(int[] p, int[] t, double Thete,string type)
        {
            if(type.Equals("Translate"))
            {
                int P_dash_x = p[0] + t[0];
                int P_dash_y = p[1] + t[1];
                int[] p_dash = { P_dash_x, P_dash_y };
                return p_dash;

            }
            else if(type.Equals("Scale"))
            {
                int P_dash_x = p[0] * t[0];
                int P_dash_y = p[1] * t[1];
                int[] p_dash = { P_dash_x, P_dash_y };
                return p_dash;

            }
            else if (type.Equals("Rotate"))
            {
                int P_dash_x = (p[0] * Convert.ToInt32(Math.Cos(Thete))) - (p[1] * Convert.ToInt32(Math.Sin(Thete)));
                int P_dash_y = (p[0] * Convert.ToInt32(Math.Sin(Thete))) + (p[1] * Convert.ToInt32(Math.Cos(Thete)));
                int[] p_dash = { P_dash_x, P_dash_y };
                return p_dash;

            }
            else if(type.Equals("Reflect"))
            {
                int P_dash_x = p[0] * -1;
                int P_dash_y = p[1] * -1;
                int[] p_dash = { P_dash_x, P_dash_y };
                return p_dash;

            }
            else if(type.Equals("Shear"))
            {
                int P_dash_x = p[0] + (t[0]*p[1]);
                int P_dash_y = p[1] ;
                int[] p_dash = { P_dash_x, P_dash_y };
                return p_dash;
            }
            int[] error = { 0 };
            return error;

            
        }
      
    }
}
