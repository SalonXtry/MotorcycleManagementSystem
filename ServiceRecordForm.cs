using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MotorcycleManagementSystem
{
    public class ServiceRecordForm : Form
    {
        private TextBox txtServiceId;
        private TextBox txtMotorcycleId;
        private TextBox txtServiceDate;
        private TextBox txtServiceType;
        private TextBox txtMileage;
        private TextBox txtCost;
        private TextBox txtNotes;

        private ListBox lstServices;
        private List<ServiceRecord> services = new List<ServiceRecord>();

        public ServiceRecordForm()
        {
            Text = "Service Records";
            Size = new Size(650, 680);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "Service Records";
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.Location = new Point(200, 25);
            title.AutoSize = true;

            Label lblServiceId = new Label();
            lblServiceId.Text = "Service ID:";
            lblServiceId.Location = new Point(60, 90);

            txtServiceId = new TextBox();
            txtServiceId.Location = new Point(200, 90);
            txtServiceId.Width = 250;

            Label lblMotorcycleId = new Label();
            lblMotorcycleId.Text = "Motorcycle ID:";
            lblMotorcycleId.Location = new Point(60, 130);
            lblMotorcycleId.AutoSize = true;

            txtMotorcycleId = new TextBox();
            txtMotorcycleId.Location = new Point(200, 130);
            txtMotorcycleId.Width = 250;

            Label lblDate = new Label();
            lblDate.Text = "Service Date:";
            lblDate.Location = new Point(60, 170);

            txtServiceDate = new TextBox();
            txtServiceDate.Location = new Point(200, 170);
            txtServiceDate.Width = 250;

            Label lblType = new Label();
            lblType.Text = "Service Type:";
            lblType.Location = new Point(60, 210);

            txtServiceType = new TextBox();
            txtServiceType.Location = new Point(200, 210);
            txtServiceType.Width = 250;

            Label lblMileage = new Label();
            lblMileage.Text = "Mileage:";
            lblMileage.Location = new Point(60, 250);

            txtMileage = new TextBox();
            txtMileage.Location = new Point(200, 250);
            txtMileage.Width = 250;

            Label lblCost = new Label();
            lblCost.Text = "Cost:";
            lblCost.Location = new Point(60, 290);

            txtCost = new TextBox();
            txtCost.Location = new Point(200, 290);
            txtCost.Width = 250;

            Label lblNotes = new Label();
            lblNotes.Text = "Notes:";
            lblNotes.Location = new Point(60, 330);

            txtNotes = new TextBox();
            txtNotes.Location = new Point(200, 330);
            txtNotes.Width = 250;

            Button btnAdd = new Button();
            btnAdd.Text = "Add Service";
            btnAdd.Location = new Point(200, 380);
            btnAdd.Width = 150;
            btnAdd.Click += AddService;

            lstServices = new ListBox();
            lstServices.Location = new Point(60, 440);
            lstServices.Size = new Size(520, 140);

            Controls.Add(title);
            Controls.Add(lblServiceId);
            Controls.Add(txtServiceId);
            Controls.Add(lblMotorcycleId);
            Controls.Add(txtMotorcycleId);
            Controls.Add(lblDate);
            Controls.Add(txtServiceDate);
            Controls.Add(lblType);
            Controls.Add(txtServiceType);
            Controls.Add(lblMileage);
            Controls.Add(txtMileage);
            Controls.Add(lblCost);
            Controls.Add(txtCost);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(btnAdd);
            Controls.Add(lstServices);
        }

        private void AddService(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtServiceId.Text, out int serviceId) ||
                !int.TryParse(txtMotorcycleId.Text, out int motorcycleId) ||
                !int.TryParse(txtMileage.Text, out int mileage) ||
                !decimal.TryParse(txtCost.Text, out decimal cost))
            {
                MessageBox.Show("Please enter valid numbers.");
                return;
            }

            if (!DateTime.TryParseExact(
    txtServiceDate.Text,
    "dd/MM/yyyy",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out DateTime serviceDate))
{
    MessageBox.Show("Please enter the date as DD/MM/YYYY.");
    return;
}

            if (txtServiceType.Text == "")
            {
                MessageBox.Show("Please enter a service type.");
                return;
            }

            ServiceRecord service = new ServiceRecord
            {
                ServiceId = serviceId,
                MotorcycleId = motorcycleId,
                ServiceDate = serviceDate,
                ServiceType = txtServiceType.Text,
                Mileage = mileage,
                Cost = cost,
                Notes = txtNotes.Text
            };

            services.Add(service);

            lstServices.Items.Add(
                service.ServiceId + " - " +
                service.ServiceType + " - $" +
                service.Cost
            );

            txtServiceId.Clear();
            txtMotorcycleId.Clear();
            txtServiceDate.Clear();
            txtServiceType.Clear();
            txtMileage.Clear();
            txtCost.Clear();
            txtNotes.Clear();
        }
    }
}