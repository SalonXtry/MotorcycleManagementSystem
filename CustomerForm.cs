using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MotorcycleManagementSystem
{
    public class CustomerForm : Form
    {
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;

        private ListBox lstCustomers;
        private List<Customer> customers;

        public CustomerForm()
        {
            customers = DataManager.LoadCustomers();
            Text = "Customer Management";
            Size = new Size(600, 500);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "Customer Management";
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.Location = new Point(160, 30);
            title.AutoSize = true;

            Label lblId = new Label();
            lblId.Text = "Customer ID:";
            lblId.Location = new Point(60, 100);

            txtId = new TextBox();
            txtId.Location = new Point(180, 100);
            txtId.Width = 250;

            Label lblName = new Label();
            lblName.Text = "Name:";
            lblName.Location = new Point(60, 140);

            txtName = new TextBox();
            txtName.Location = new Point(180, 140);
            txtName.Width = 250;

            Label lblPhone = new Label();
            lblPhone.Text = "Phone:";
            lblPhone.Location = new Point(60, 180);

            txtPhone = new TextBox();
            txtPhone.Location = new Point(180, 180);
            txtPhone.Width = 250;

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(60, 220);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(180, 220);
            txtEmail.Width = 250;

            Button btnAdd = new Button();
            btnAdd.Text = "Add Customer";
            btnAdd.Location = new Point(180, 270);
            btnAdd.Width = 150;
            btnAdd.Click += AddCustomer;

            lstCustomers = new ListBox();
            lstCustomers.Location = new Point(60, 330);
            lstCustomers.Size = new Size(470, 100);
            foreach (Customer customer in customers)
{
    lstCustomers.Items.Add(
        customer.CustomerId + " - " +
        customer.Name + " - " +
        customer.Phone
    );
}

            Controls.Add(title);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnAdd);
            Controls.Add(lstCustomers);
        }

        private void AddCustomer(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Please enter a valid Customer ID.");
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter the customer name.");
                return;
            }

            Customer customer = new Customer
            {
                CustomerId = id,
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };

            customers.Add(customer);
            DataManager.SaveCustomers(customers);

            lstCustomers.Items.Add(
                customer.CustomerId + " - " +
                customer.Name + " - " +
                customer.Phone
            );

            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }
    }
}