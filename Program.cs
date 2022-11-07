
//Oggi cerchiamo di migliorare un pochino l’approccio nella costruzione di un codice ad oggetti, ben suddiviso tra diverse responsabilità.
//Il program.cs si occuperà quindi di gestire tutti i console.writeline/readline mentre le classi di dominio del nostro progetto
//devono occuparsi solo della logica applicativa e fare dei controlli dei dati quando questi violano qualche logica.
//Esempio, quando un cliente non può chiedere più prestiti? quale entità potrebbe occuparsi di questo controllo?
//Non dimentichiamoci però che abbiamo aggiunto la keyword static, quale parametro di quale entità potrebbe essere trasformato in STATIC così come abbiamo visto negli esempi?
//Consegna:
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

Bank bankTest = new Bank("BankTest");

bool runProgram = true;

while(runProgram)
{
    Console.WriteLine("Quale operazione vuoi eseguire?");
    Console.WriteLine("[1]: aggiungi utente.");
    Console.WriteLine("[2]: ricerca utente.");
    Console.WriteLine("[3]: modifica utente.");
    Console.WriteLine("[4]: aggiungi prestito.");
    Console.WriteLine("[5]: ricerca prestito.");
    Console.WriteLine("[6]: mostra tutti i clienti.");
    Console.WriteLine("[7]: mostra tutti i prestiti.");

    string userChoice = Console.ReadLine();

    if(userChoice == "1")
    {
        Console.WriteLine("Inserisci i dati dell'utente.");

        Console.Write("Nome: ");
        string userName = Console.ReadLine();

        Console.Write("Cognome: ");
        string userLastName = Console.ReadLine();

        Console.Write("Codice Fiscale: ");
        string userFiscalCode = Console.ReadLine();

        Console.Write("Stipendio: ");
        double userSalary = Convert.ToDouble(Console.ReadLine());

        bool addCustomerConfirm = bankTest.AddCustomer(userName, userLastName, userFiscalCode, userSalary);

        if (addCustomerConfirm)
        {
            Console.WriteLine("Utente aggiunto con successo!");
        }
        else
        {
            Console.WriteLine("Errore: impossibile aggiungere utente!");
        }

        bool firtsWhileCon = true;

        while(firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else if(userChoice == "2")
    {
        Console.WriteLine("Inserisci i dati dell'utente.");

        Console.Write("Codice Fiscale: ");
        string userFiscalCode = Console.ReadLine();

        Customer customerFound = bankTest.FindCustomer(userFiscalCode);

        if (customerFound != null)
        {
            Console.WriteLine("Utente trovato!");
        }
        else
        {
            Console.WriteLine("Nessun utente trovato!");
            Console.WriteLine("Potrebbe non essere registrato o potrebbe essere stato inserito un codice fiscale errato.");
        }

        bool firtsWhileCon = true;

        while (firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else if (userChoice == "3")
    {
        Console.WriteLine("Inserisci il codice fiscale dell'utente da modificare.");

        Console.Write("Codice Fiscale: ");
        string userFiscalCode = Console.ReadLine();

        Customer customerFound = bankTest.FindCustomer(userFiscalCode);

        if (customerFound != null)
        {
            Console.WriteLine("Inserisci i nuovi dati.");

            Console.Write("Nome: ");
            string newUserName = Console.ReadLine();

            Console.Write("Cognome: ");
            string unewUerLastName = Console.ReadLine();

            Console.Write("Codice Fiscale: ");
            string newUserFiscalCode = Console.ReadLine();

            Console.Write("Stipendio: ");
            double newUserSalary = Convert.ToDouble(Console.ReadLine());

            bool modifyCustomerConfirm = bankTest.ModifyCustomer(customerFound, newUserName, unewUerLastName, newUserFiscalCode, newUserSalary);

            if (modifyCustomerConfirm)
            {
                Console.WriteLine("Utente modificato con successo!");
            }
            else
            {
                Console.WriteLine("Errore: impossibile modificare utente!");
                Console.WriteLine("Potrebbe non essere registrato o potrebbe essere stato inserito un codice fiscale errato.");
            }
        }
        else
        {
            Console.WriteLine("Nessun utente trovato!");
            Console.WriteLine("Potrebbe non essere registrato o potrebbe essere stato inserito un codice fiscale errato.");
        }

        bool firtsWhileCon = true;

        while (firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else if (userChoice == "4")
    {
        Console.WriteLine("Inserisci il tuo codice fiscale");

        Console.Write("Codice Fiscale: ");
        string userFiscalCode = Console.ReadLine();

        Customer customerFound = bankTest.FindCustomer(userFiscalCode);

        if(customerFound != null)
        {
            Console.WriteLine("Di che cifra hai bisogno?");

            Console.Write("Ammontare prestito: ");
            double loanAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Entro quando vuoi ripagare il prestito?");

            Console.Write("Giorno: ");
            int day = Convert.ToInt16(Console.ReadLine());

            Console.Write("Mese: ");
            int month = Convert.ToInt16(Console.ReadLine());

            Console.Write("Anno: ");
            int year = Convert.ToInt16(Console.ReadLine());

            DateTime endDate = new DateTime(year, month, day);

            if (bankTest.AddLoan(customerFound, loanAmount, endDate))
            {
                Console.WriteLine("prestito accettato!");
            }
            else
            {
                Console.WriteLine("prestito rifiutato.");
            }
        }
        else
        {
            Console.WriteLine("Non è registrato alcun utente con questo codice fiscale!");
        }

        bool firtsWhileCon = true;

        while (firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else if (userChoice == "5")
    {
        Console.WriteLine("Inserisci il tuo codice fiscale");

        Console.Write("Codice Fiscale: ");
        string userFiscalCode = Console.ReadLine();

        Customer customerFound = bankTest.FindCustomer(userFiscalCode);

        List<Loan> customerLoans = bankTest.FindLoans(customerFound.FiscalCode);

        if (customerLoans.Count() > 0)
        {
            Console.WriteLine("sono presenti prestiti per questo utente");
        }
        else
        {
            Console.WriteLine("Errore: nessun prestito trovato per questo utente");
        }

        bool firtsWhileCon = true;

        while (firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else if (userChoice == "6")
    {
        Console.WriteLine("Lista clienti registrati: ");
        bankTest.PrintAllCustomers();

        bool firtsWhileCon = true;

        while (firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else if (userChoice == "7")
    {
        Console.WriteLine("Lista prestiti concessi: ");
        bankTest.PrintAllLoans();

        bool firtsWhileCon = true;

        while (firtsWhileCon)
        {
            Console.WriteLine("Desideri fare altro?");
            Console.WriteLine("[1]: sì.");
            Console.WriteLine("[2]: no.");

            string ProgramContinue = Console.ReadLine();

            if (ProgramContinue == "1")
            {
                firtsWhileCon = false;
            }
            else if (ProgramContinue == "2")
            {
                Console.WriteLine("Grazie, buona giornata!");
                runProgram = false;
                firtsWhileCon = false;
            }
            else
            {
                Console.WriteLine("Mi spiace ma non ho capito.");
            }
        }
    }
    else
    {
        Console.WriteLine("Mi spiace ma non ho capito.");
    }
}