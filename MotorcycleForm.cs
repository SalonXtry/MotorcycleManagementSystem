using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MotorcycleManagementSystem
{
    public class MotorcycleForm : Form
    {
        private TextBox txtId;
        private TextBox txtRegistration;
        private TextBox txtMake;
        private TextBox txtModel;
        private TextBox txtYear;
        private TextBox txtMileage;
        private TextBox txtCustomerId;

        private ListBox lstMotorcycles;
        private List<Motorcycle> motorcycles = new List<Motorcycle>();

        public MotorcycleForm()
        {
            Text = "Motorcycle Management";
            Size = new Size(650, 650);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "Motorcycle Management";
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.Location = new Point(160, 25);
            title.AutoSize = true;

            Label lblId = new Label();
            lblId.Text = "Motorcycle ID:";
            lblId.Location = new Point(60, 90);
            lblId.AutoSize = true;

            txtId = new TextBox();
            txtId.Location = new Point(200, 90);
            txtId.Width = 250;

            Label lblRegistration = new Label();
            lblRegistration.Text = "Registration:";
            lblRegistration.Location = new Point(60, 130);

            txtRegistration = new TextBox();
            txtRegistration.Location = new Point(200, 130);
            txtRegistration.Width = 250;

            Label lblMake = new Label();
            lblMake.Text = "Make:";
            lblMake.Location = new Point(60, 170);

            txtMake = new TextBox();
            txtMake.Location = new Point(200, 170);
            txtMake.Width = 250;

            Label lblModel = new Label();
            lblModel.Text = "Model:";
            lblModel.Location = new Point(60, 210);

            txtModel = new TextBox();
            txtModel.Location = new Point(200, 210);
            txtModel.Width = 250;

            Label lblYear = new Label();
            lblYear.Text = "Year:";
            lblYear.Location = new Point(60, 250);

            txtYear = new TextBox();
            txtYear.Location = new Point(200, 250);
            txtYear.Width = 250;

            Label lblMileage = new Label();
            lblMileage.Text = "Mileage:";
            lblMileage.Location = new Point(60, 290);

            txtMileage = new TextBox();
            txtMileage.Location = new Point(200, 290);
            txtMileage.Width = 250;

            Label lblCustomerId = new Label();
            lblCustomerId.Text = "Customer ID:";
            lblCustomerId.Location = new Point(60, 330);
            

            txtCustomerId = new TextBox();
            txtCustomerId.Location = new Point(200, 330);
            txtCustomerId.Width = 250;

            Button btnAdd = new Button();
            btnAdd.Text = "Add Motorcycle";
            btnAdd.Location = new Point(200, 380);
            btnAdd.Width = 150;
            btnAdd.Click += AddMotorcycle;

            lstMotorcycles = new ListBox();
            lstMotorcycles.Location = new Point(60, 440);
            lstMotorcycles.Size = new Size(520, 120);

            Controls.Add(title);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblRegistration);
            Controls.Add(txtRegistration);
            Controls.Add(lblMake);
            Controls.Add(txtMake);
            Controls.Add(lblModel);
            Controls.Add(txtModel);
            Controls.Add(lblYear);
            Controls.Add(txtYear);
            Controls.Add(lblMileage);
            Controls.Add(txtMileage);
            Controls.Add(lblCustomerId);
            Controls.Add(txtCustomerId);
            Controls.Add(btnAdd);
            Controls.Add(lstMotorcycles);
        }

        private void AddMotorcycle(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) ||
                !int.TryParse(txtYear.Text, out int year) ||
                !int.TryParse(txtMileage.Text, out int mileage) ||
                !int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Please enter valid numbers.");
                return;
            }

            if (txtRegistration.Text == "" || txtMake.Text == "" || txtModel.Text == "")
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            Motorcycle motorcycle = new Motorcycle
            {
                MotorcycleId = id,
                RegistrationNumber = txtRegistration.Text,
                Make = txtMake.Text,
                Model = txtModel.Text,
                Year = year,
                Mileage = mileage,
                CustomerId = customerId
            };

            motorcycles.Add(motorcycle);

            lstMotorcycles.Items.Add(
                motorcycle.MotorcycleId + " - " +
                motorcycle.RegistrationNumber + " - " +
                motorcycle.Make + " " +
                motorcycle.Model
            );

            txtId.Clear();
            txtRegistration.Clear();
            txtMake.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtMileage.Clear();
            txtCustomerId.Clear();
        }
    }
}