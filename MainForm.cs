namespace MotorcycleManagementSystem;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "Motorcycle Management System";
        Width = 600;
        Height = 420;
        StartPosition = FormStartPosition.CenterScreen;

        var title = new Label
        {
            Text = "Motorcycle Management System",
            AutoSize = true,
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            Left = 120,
            Top = 45
        };

        var customersButton = new Button { Text = "Customers", Width = 180, Height = 45, Left = 195, Top = 130 };
        customersButton.Click += OpenCustomers;
        var motorcyclesButton = new Button { Text = "Motorcycles", Width = 180, Height = 45, Left = 195, Top = 195 };
        var servicesButton = new Button { Text = "Service Records", Width = 180, Height = 45, Left = 195, Top = 260 };

        Controls.Add(title);
        Controls.Add(customersButton);
        Controls.Add(motorcyclesButton);
        Controls.Add(servicesButton);
        
    }
    private void OpenCustomers(object? sender, EventArgs e)
{
    CustomerForm customerForm = new CustomerForm();
    customerForm.ShowDialog();
}
}
