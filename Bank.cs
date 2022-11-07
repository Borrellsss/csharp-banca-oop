﻿public class Bank
{
    public string Name { get; private set; }
    public List<Customer> Customers;
    public List<Loan> Loans;

    public Bank(string name)
    {
        this.Name = name;
        this.Customers = new List<Customer>();
        this.Loans = new List<Loan>();
    }

    public Customer FindCustomer(string fiscalCode)
    {
        if(fiscalCode != null && Customers.Count() > 0)
        {
            foreach(Customer customer in Customers)
            {
                if(customer.FiscalCode == fiscalCode)
                {
                    return customer;
                }
            }
        }

        return null;
    }

    public bool AddCustomer(string name, string lastName, string fiscalCode, double salary)
    {
        if
        (
            (name != null || name != "") ||
            (lastName != null || lastName != "") ||
            (fiscalCode != null || fiscalCode != "") ||
            (salary < 0)
        )
        {
            if(this.FindCustomer(fiscalCode) == null)
            {
                Customer newCustomer = new Customer(name, lastName, fiscalCode, salary);
                this.Customers.Add(newCustomer);
                return true;
            }
        }

        return false;
    }

    public bool ModifyCustomer(string name, string lastName, string fiscalCode, double salary)
    {
        Customer customerToModify = this.FindCustomer(fiscalCode);

        if (customerToModify != null)
        {
            if((name != null || name != "") && name != customerToModify.Name)
            {
                customerToModify.Name = name;
            }

            if((lastName != null || lastName != "") && lastName != customerToModify.LastName)
            {
                customerToModify.LastName = lastName;
            }

            if((salary < 0) && salary != customerToModify.Salary)
            {
                customerToModify.Salary = salary;
            }

            return true;
        }

        return false;
    }

    public List<Loan> FindLoans(string fiscalCode)
    {
        List<Loan> customerLoans = new List<Loan>();

        if (fiscalCode != null && Loans.Count() > 0)
        {
            foreach (Loan loan in Loans)
            {
                if (loan.Customer.FiscalCode == fiscalCode)
                {
                    customerLoans.Add(loan);
                }
            }
        }

        return customerLoans;
    }

    public bool AddLoan(Customer customer, double amount, DateTime endDate)
    {
        if (FindCustomer(customer.FiscalCode) != null)
        {
            List<Loan> customerLoans = FindLoans(customer.FiscalCode);

            TimeSpan timesSpan = endDate - DateTime.Now;

            double installment = amount / Convert.ToInt16(timesSpan.Days / 30);

            if (customerLoans.Count() > 0)
            {
                double counter = 0;

                foreach(Loan loan in customerLoans)
                {
                    counter += loan.Installment;
                }

                counter += installment;

                if (counter < customer.Salary)
                {
                    Loan newLoan = new Loan(customer, amount, installment, endDate);
                    this.Loans.Add(newLoan);
                    return true;
                }
            }
            else
            {
                if (installment < customer.Salary)
                {
                    Loan newLoan = new Loan(customer, amount, installment, endDate);
                    this.Loans.Add(newLoan);
                    return true;
                }
            }
        }

        return false;
    }

    public List<string> CalcLoansRemainingMonths(string fiscalCode)
    {
        Customer customer = this.FindCustomer(fiscalCode);

        List<Loan> customerLoans = this.FindLoans(fiscalCode);

        List<string> remainingMonth = new List<string>();

        foreach(Loan loan in customerLoans)
        {
            TimeSpan timesSpan = loan.EndDate - DateTime.Now;

            remainingMonth.Add($"al prestito del: {loan.StartDate}, mancano {Convert.ToInt16(timesSpan.Days / 30)} rate");
        }

        return remainingMonth;
    }

    public void PrintLoans()
    {
        foreach(Customer customer in Customers)
        {
            Console.WriteLine(customer.ToString());
        }
    }

    public void PrintCustomers()
    {
        foreach (Loan loan in Loans)
        {
            Console.WriteLine(loan.ToString());
        }
    }
}