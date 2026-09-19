namespace MotorcycleManagementSystem;

public class ServiceRecord
{
    public int ServiceId { get; set; }
    public int MotorcycleId { get; set; }
    public DateTime ServiceDate { get; set; } = DateTime.Today;
    public string ServiceType { get; set; } = "";
    public int Mileage { get; set; }
    public decimal Cost { get; set; }
    public string Notes { get; set; } = "";
}
