namespace MotorcycleManagementSystem;

public class Motorcycle
{
    public int MotorcycleId { get; set; }
    public string RegistrationNumber { get; set; } = "";
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public int Mileage { get; set; }
    public int CustomerId { get; set; }
}
