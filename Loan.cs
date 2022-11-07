public class Loan
{
    public static int id = 0;
    public Customer Customer { get; private set; }
    public double Amount { get; private set; }
    public double Installment { get; private set; }
    public int RemainingMonths { get; private set; }
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

        TimeSpan timeSpan = endDate - StartDate;

        this.RemainingMonths = Convert.ToInt16(timeSpan.Days / 30);
    }

    public override string ToString()
    {
        return $"prestito {id}: codice fiscale: {this.Customer.FiscalCode} | totale: {this.Amount} euro | inizio prestito: {this.StartDate} - fine prestito: {this.EndDate}";
    }

    public int CalcRemainingMonths(Loan loan)
    {
        TimeSpan timeSpan = loan.EndDate - loan.StartDate;

        loan.RemainingMonths -= Convert.ToInt16(timeSpan.Days / 30);

        return loan.RemainingMonths;
    }
}