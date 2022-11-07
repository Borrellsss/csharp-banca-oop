public class Loan
{
    public static int id = 0;
    public Customer Customer { get; private set; }
    public double Amount { get; private set; }
    public double Installment { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Loan(Customer customer, double amount, double installment, DateTime endDate)
    {
        Loan.id++;
        this.Customer = customer;
        this.Amount = amount;
        this.Installment = installment;
        this.StartDate = DateTime.Now;
        this.EndDate = endDate;
    }

    public override string ToString()
    {
        return $"prestito {id}: codice fiscale: {this.Customer.FiscalCode} | totale: {this.Amount} euro | inizio prestito: {this.StartDate} - fine prestito: {this.EndDate}";
    }
}