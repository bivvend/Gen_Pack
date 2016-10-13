using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gen_Pack
{
    public partial class Form1 : Form
    {
        public Panel main_panel = new Panel();
        public List<Part> initial_part_list = new List<Part>();
        private Gen_Packer packer = new Gen_Packer();
        private double max_x = 0.0d;
        private double min_x = 0.0d;
        private double max_y = 0.0d;
        private double min_y = 0.0d;

        private double sheet_x = 0.0d;
        private double sheet_y = 0.0d;

        private int number_parts = 1;

        private int number_siblings = 100;   //the number of evolutions at any time.
        private int number_steps = 1000;

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBoxMaxX.Text = "200";
            this.textBoxMaxY.Text = "200";
            this.textBoxMinX.Text = "100";
            this.textBoxMinY.Text = "100";

            this.textBoxNumber.Text = "10";
            this.textBoxSheetX.Text = "500";
            this.textBoxSheetY.Text = "500";

            packer.Number_Of_Siblings = number_siblings;
            packer.Number_Of_Steps = number_steps;

            Store_Data();           

        }

        private void Store_Data()
        {
            try
            {
                this.max_x = Convert.ToDouble(textBoxMaxX.Text);
                this.min_x = Convert.ToDouble(textBoxMinX.Text);
                this.max_y = Convert.ToDouble(textBoxMaxY.Text);
                this.min_y = Convert.ToDouble(textBoxMinY.Text);

                this.sheet_x = Convert.ToDouble(textBoxSheetX.Text);
                this.sheet_y = Convert.ToDouble(textBoxSheetY.Text);

                this.number_parts = Convert.ToInt32(textBoxNumber.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Generate();

        }

        public void Generate()
        {
            Store_Data();
            main_panel = new Panel(sheet_x, sheet_y);
            packer = new Gen_Packer();
            packer.Number_Of_Siblings = number_siblings;
            packer.Number_Of_Steps = number_steps;
            packer.panel = main_panel;
            initial_part_list = new List<Part>();

            double position_x;
            double position_y;
            double size_x;
            double size_y;

            double step_y = 0.0d;
            double step_x = 0.0d;

            if (main_panel.size_y > main_panel.size_x)
            {
                step_y = main_panel.size_y / number_parts;
                step_x = 1;
            }
            else
            {
                step_x = main_panel.size_x / number_parts;
                step_y = 1;
            }

            random = new Random((int)DateTime.Now.Ticks);

            while (initial_part_list.Count< number_parts)
            {
                size_x = GetRandomNumber(min_x, max_x);
                size_y = GetRandomNumber(min_y, max_y);


                position_x = initial_part_list.Count * step_x;
                position_y = main_panel.size_y - initial_part_list.Count * step_y;

                initial_part_list.Add(new Part(position_x, position_y, size_x, size_y, Part.priority.normal));                
            }
            packer.initial_part_list = initial_part_list;
            packer.Fill_To_N_Evolutions(number_siblings, initial_part_list);
            

            //show initial state
            Show_Evolution(packer.initial_part_list);
        }

        public double GetRandomNumber(double minimum, double maximum)
        {

            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void buttonPack_Click(object sender, EventArgs e)
        {
            try
            {
                packer.Evolve();
                labelHighestScore.Text = "Highest score: " + packer.best_score.ToString();
                labelAverageScore.Text = "Average score: " + packer.average_score.ToString();
                labelBestEverScore.Text = "Best ever score: " + packer.best_ever_score;
                Show_Evolution(packer.best_ever_part_list);
         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
        }

        public void Show_Evolution(List<Part> part_list)
        {
            try
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);

                double scale_x = (double)pictureBox1.Size.Width / sheet_x;
                double scale_y = (double)pictureBox1.Size.Height / sheet_y;

                double height = (double)pictureBox1.Size.Height;
                double width = (double)pictureBox1.Size.Width;

                double plotx1 = 0.0d;
                double ploty1 = 0.0d;
                double plot_width = 0.0d;
                double plot_height = 0.0d;

                Pen blackPen = new Pen(Color.Black, 0.1f);
                Pen redPen = new Pen(Color.Red, 0.1f);

                // Draw line to screen.
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    foreach (Part a_part in part_list)
                    {
                        if (a_part.is_placed)
                        {
                            plotx1 = a_part.position_x * scale_x;
                            ploty1 = height - (a_part.position_y * scale_y);

                            plot_width = a_part.size_x * scale_x;
                            plot_height = a_part.size_y * scale_y;

                            if(a_part.clashes)
                                graphics.DrawRectangle(redPen, (float)plotx1, (float)ploty1, (float)plot_width, (float)plot_height);
                            else
                                graphics.DrawRectangle(blackPen, (float)plotx1, (float)ploty1, (float)plot_width, (float)plot_height);
                        }
                    }
                }

                pictureBox1.Image = bitmap;
                blackPen.Dispose();
                redPen.Dispose();  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void buttonShowN_Click(object sender, EventArgs e)
        {
            try
            {
                int N = Convert.ToInt32(this.textBoxN.Text);
                Show_Evolution(packer.evolutions[N].configuration);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
