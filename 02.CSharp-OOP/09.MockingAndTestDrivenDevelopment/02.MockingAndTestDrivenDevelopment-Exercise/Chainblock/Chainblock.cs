using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionsById;

        public Chainblock()
        {
            this.transactionsById = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactionsById.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactionsById.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with Id: {tx.Id} already exists in chainblock");
            }

            this.transactionsById.Add(tx.Id, tx);

        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (transactionsById.ContainsKey(id) == false)
            {
                throw new ArgumentException($"Transaction with Id: {id}, does not exist");
            }

            ITransaction transaction = transactionsById[id];
            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (!this.Contains(tx.Id)) //if ID is not in chainblock - return false
            {
                return false;
            }

            //else check if the transactions values match and return true/false
            ITransaction existingTransaction = this.transactionsById[tx.Id];

            return tx.Id == existingTransaction.Id &&
                tx.Amount == existingTransaction.Amount &&
                tx.From == existingTransaction.From &&
                tx.To == existingTransaction.To &&
                tx.Status == existingTransaction.Status;
        }

        public bool Contains(int id)
        {
            return this.transactionsById.ContainsKey(id);
        }


        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionsById
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No such transactions are present in the record");
            }

            return result;

        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionsById
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No such transactions exist");
            }

            return result;

        }

        public ITransaction GetById(int id)
        {
            if (this.transactionsById.ContainsKey(id) == false)
            {
                throw new InvalidOperationException($"No transaction with given ID: {id} exists");
            }

            return this.transactionsById[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> transactions = this.transactionsById
                .Values
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("No such transactions exist");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            //here
            List<ITransaction> result = this.transactionsById
                .Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No such transactions exist");
            }

            return result;

        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> transactions = this.transactionsById
                .Values
                .Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("No such transactions exist");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> result = this.transactionsById
                .Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException("No such transactions exist");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (transactionsById.Values.Any(t => t.Status == status) == false)
            {
                throw new InvalidOperationException($"No transactions with {status} status exist");
            }

            List<ITransaction> result = this.transactionsById.Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();

            return result;

        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            List<ITransaction> result = this.transactionsById.Values
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            return result;
        }

        public void RemoveTransactionById(int id)
        {
            if (transactionsById.ContainsKey(id) == false) // OR if (!this.Contains(id)) {}
            {
                throw new InvalidOperationException($"Transaction with ID: {id} does not exist");
            }

            transactionsById.Remove(id);

        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactionsById)
            {
                yield return transaction.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            List<ITransaction> transactions = this.transactionsById
                .Values
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .ToList();

            return transactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactionsById.Values.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
        }
    }
}
