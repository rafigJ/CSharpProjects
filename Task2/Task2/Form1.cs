using System;
using System.Windows.Forms;
using WinF.Models;

namespace WinF
{
    public partial class Form1 : Form
    {
        private Airplane airplane;
        private Helicopter helicopter;
        private Label heightLabel;
        private TextBox heightTextBox;
        private Button airplaneTakeoffButton;
        private Button airplaneLandingButton;
        private Button helicopterTakeoffButton;
        private Button helicopterLandingButton;
        private TextBox helicopterHeightTextBox;
        private Label runwayLengthLabel;
        private TextBox runwayLengthTextBox;
        



        public Form1()
        {
            InitializeComponent();

            airplane = new Airplane(0);
            airplane.TakeOffEvent += HandleTakeOffEvent;
            airplane.LandingEvent += HandleLandingEvent;

            helicopter = new Helicopter();
            helicopter.TakeOffEvent += HandleTakeOffEvent;
            helicopter.LandingEvent += HandleLandingEvent;



        }
        private void InitializeComponent()
        {
            heightLabel = new Label();
            heightTextBox = new TextBox();
            runwayLengthLabel = new Label();
            runwayLengthTextBox = new TextBox();
            helicopterHeightTextBox = new TextBox();
            airplaneTakeoffButton = new Button();
            airplaneLandingButton = new Button();
            helicopterTakeoffButton = new Button();
            helicopterLandingButton = new Button();
            label1 = new Label();
            label2 = new Label();
            this.label3 = new Label();
            SuspendLayout();
             
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(23, 47);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(70, 15);
            heightLabel.TabIndex = 0;
            heightLabel.Text = "Высота (м):";
            heightLabel.Click += heightLabel_Click;
            
            heightTextBox.Location = new Point(118, 44);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.ReadOnly = true;
            heightTextBox.Size = new Size(100, 23);
            heightTextBox.TabIndex = 1;
            heightTextBox.Text = "0";
           
            runwayLengthLabel.AutoSize = true;
            runwayLengthLabel.Location = new Point(38, 159);
            runwayLengthLabel.Name = "runwayLengthLabel";
            runwayLengthLabel.Size = new Size(164, 15);
            runwayLengthLabel.TabIndex = 0;
            runwayLengthLabel.Text = "Длина взлетной полосы (м):";
            
            runwayLengthTextBox.Location = new Point(208, 156);
            runwayLengthTextBox.Name = "runwayLengthTextBox";
            runwayLengthTextBox.Size = new Size(100, 23);
            runwayLengthTextBox.TabIndex = 9;
            
            helicopterHeightTextBox.Location = new Point(499, 44);
            helicopterHeightTextBox.Name = "helicopterHeightTextBox";
            helicopterHeightTextBox.ReadOnly = true;
            helicopterHeightTextBox.Size = new Size(100, 23);
            helicopterHeightTextBox.TabIndex = 8;
            helicopterHeightTextBox.Text = "0";
             
            airplaneTakeoffButton.Location = new Point(38, 84);
            airplaneTakeoffButton.Name = "airplaneTakeoffButton";
            airplaneTakeoffButton.Size = new Size(90, 27);
            airplaneTakeoffButton.TabIndex = 4;
            airplaneTakeoffButton.Text = "Взлет (Самолет)";
            airplaneTakeoffButton.Click += AirplaneTakeOffButton_Click;
           
            airplaneLandingButton.Location = new Point(38, 117);
            airplaneLandingButton.Name = "airplaneLandingButton";
            airplaneLandingButton.Size = new Size(90, 27);
            airplaneLandingButton.TabIndex = 5;
            airplaneLandingButton.Text = "Посадка (Самолет)";
            airplaneLandingButton.Click += AirplaneLandingButton_Click;
            
            helicopterTakeoffButton.Location = new Point(416, 84);
            helicopterTakeoffButton.Name = "helicopterTakeoffButton";
            helicopterTakeoffButton.Size = new Size(90, 27);
            helicopterTakeoffButton.TabIndex = 6;
            helicopterTakeoffButton.Text = "Взлет (Вертолет)";
            helicopterTakeoffButton.Click += HelicopterTakeOffButton_Click;
           
            helicopterLandingButton.Location = new Point(416, 117);
            helicopterLandingButton.Name = "helicopterLandingButton";
            helicopterLandingButton.Size = new Size(90, 27);
            helicopterLandingButton.TabIndex = 7;
            helicopterLandingButton.Text = "Посадка (Вертолет)";
            helicopterLandingButton.Click += HelicopterLandingButton_Click;
           
            label1.AutoSize = true;
            label1.Location = new Point(401, 47);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 10;
            label1.Text = "Высота (м):";
            
            label2.AutoSize = true;
            label2.Location = new Point(38, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 11;
            label2.Text = "Самолет";
            label2.Click += label2_Click;
           
            this.label3.AutoSize = true;
            this.label3.Location = new Point(416, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(55, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Вертолет";
            
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 466);
            Controls.Add(this.label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(runwayLengthLabel);
            Controls.Add(runwayLengthTextBox);
            Controls.Add(airplaneTakeoffButton);
            Controls.Add(airplaneLandingButton);
            Controls.Add(helicopterTakeoffButton);
            Controls.Add(helicopterLandingButton);
            Controls.Add(helicopterHeightTextBox);
            Controls.Add(heightLabel);
            Controls.Add(heightTextBox);
            Name = "Form1";
            Text = "Aircraft Control";
            ResumeLayout(false);
            PerformLayout();
        }

        private void HandleTakeOffEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Takeoff successful!");
        }

        private void HandleLandingEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Landing successful!");
        }

        private void AirplaneTakeOffButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(runwayLengthTextBox.Text, out int runwayLength))
            {
                
                airplane.RunwayLength = runwayLength;

                
                airplane.TakeOff();
              
                heightTextBox.Text = airplane.Altitude.ToString();
            }
            else
            {
               
                MessageBox.Show("Введите корректное значение для длины взлетной полосы.");
            }
        }


        private void AirplaneLandingButton_Click(object sender, EventArgs e)
        {
            airplane.Land();
            heightTextBox.Text = airplane.Altitude.ToString();
        }

        private void HelicopterTakeOffButton_Click(object sender, EventArgs e)
        {
            helicopter.TakeOff();
            helicopterHeightTextBox.Text = helicopter.Altitude.ToString();
        }

        private void HelicopterLandingButton_Click(object sender, EventArgs e)
        {
            helicopter.Land();
            helicopterHeightTextBox.Text = helicopter.Altitude.ToString();
        }

        private void heightLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
