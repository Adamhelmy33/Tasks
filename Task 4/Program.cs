namespace Task_4
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"{Name}, {Balance}$";
        }

    }
    class SavingAccount : Account
    {
        public double IntRate { get; set; }

        public SavingAccount(string name = "Unnamed Savings Account", double balance = 0.0, double IntRate = 0.0) : base(name, balance)

        {
            this.IntRate = IntRate;
        }

        public override bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount * (IntRate / 100); ;
                return true;
            }
        }

        public override string ToString()
        {
            return $"{Name} Saving: {Balance}$, Interest Rate: {IntRate}%";
        }
    }
    class CheckingAccount : Account
    {
        double WithdrawalFee = 1.5;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0) : base(name, balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount + WithdrawalFee);
        }

        public override string ToString()
        {
            return $"{Name} Checking: {Balance}$";
        }
    }
    public class TrustAccount : Account
    {
        double IntRatTrust { get; set; }
        int withdrawalsThisYear;

        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double IntRatTrust = 0.0) : base(name, balance)
        {
            this.IntRatTrust = IntRatTrust;
        }

        public override bool Deposit(double amount)
        {
            if (amount > 0 && amount >= 5000)
                amount += 50;

            Balance += amount + (amount * IntRatTrust / 100);
            return true;
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawalsThisYear >= 3)
                return false;

            if (amount > Balance * 0.20)
                return false;

            if (base.Withdraw(amount))
            {
                withdrawalsThisYear++;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name} Trust: {Balance:C}, Interest Rate: {IntRatTrust}%, Withdrawals: {withdrawalsThisYear}/{MaxWithdrawalsPerYear}";
        }
    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<Account>();
            savAccounts.Add(new SavingAccount());
            savAccounts.Add(new SavingAccount("Superman"));
            savAccounts.Add(new SavingAccount("Batman", 2000));
            savAccounts.Add(new SavingAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<Account>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();
        }


    }
}
