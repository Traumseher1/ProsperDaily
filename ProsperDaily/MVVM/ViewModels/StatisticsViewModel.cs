using PropertyChanged;
using ProsperDaily.MVVM.Models;
using System.Collections.ObjectModel;

namespace ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSummary> Summary { get; set; }

        public ObservableCollection<Transaction> SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data = App.TransactionsRepo.GetItems();
            var result = new List<TransactionsSummary>();
            var groupedTransactions = data.GroupBy(x => x.OperationDate.Date);

            foreach (var group in groupedTransactions)
            {
                var transactionsSummary = new TransactionsSummary
                {
                    TransactionsDate = group.Key,
                    TransactionsTotal = group.Sum(x => x.IsIncome ? x.Amount : -x.Amount),
                    ShownDate = group.Key.ToString("dd/MM")
                };
                result.Add(transactionsSummary);
                result = result.OrderBy(x => x.TransactionsDate).ToList();

                Summary = new ObservableCollection<TransactionsSummary>(result);

                var spendingList = data.Where(x => x.IsIncome == false);
                SpendingList = new ObservableCollection<Transaction>(spendingList);
            }
        }
    }
}
