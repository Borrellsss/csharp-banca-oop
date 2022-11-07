public class Customer
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FiscalCode { get; private set; }
    public double Salary { get; set; }

    public Customer(string name, string lastName, string fiscalCode, double salary)
    {
        this.Name = name;
        this.LastName = lastName;
        this.FiscalCode = fiscalCode;
        this.Salary = salary;
    }
}