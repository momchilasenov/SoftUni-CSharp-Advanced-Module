using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        //private ITransaction transaction;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
            //this.transaction = new Transaction();
        }

        [Test]
        public void Add_ThrowsException_WhenTransactionIdAlreadyExists()
        {
            int id = 1;

            this.chainblock.Add(new Transaction { Id = id, Amount = 20, From = "Pesho", To = "Gosho" });

            Assert.Throws<InvalidOperationException>(() =>
             this.chainblock.Add(new Transaction { Id = id, Amount = 30, From = "Tosho", To = "Losho" }));
        }

        [Test]
        public void Add_AddsATransactionToTheRecord_WhenIdIsUnique()
        {
            ITransaction transaction = CreateTransaction(1);
            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(transaction), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenIdIsPresentInTheRecord()
        {
            ITransaction transaction = CreateTransaction(1);

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnFalse_WhenIdIsNotPresentInTheRecord()
        {
            Assert.That(this.chainblock.Contains(1), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenIdExistsButOtherPropertiesDoNotMatch()
        {
            ITransaction transaction = CreateTransaction(1);
            this.chainblock.Add(transaction);

            ITransaction unequalTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount + 50,
                From = transaction.From + "Fake",
                To = transaction.To + "Fake",
                Status = TransactionStatus.Aborted
            };

            Assert.That(this.chainblock.Contains(unequalTransaction), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(this.chainblock.Contains(CreateTransaction(1)), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsTrue_WhenTransactionMatchesChainblockTransaction()
        {
            ITransaction transaction = CreateTransaction(1);

            chainblock.Add(transaction);

            ITransaction duplicateTransaction = CreateTransaction(1);

            Assert.That(chainblock.Contains(duplicateTransaction), Is.True);
        }

        [Test]
        public void Count_ReturnsZero_WhenChainblockIsEmpty()
        {
            Assert.That(this.chainblock.Count, Is.Zero);
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = CreateTransaction(1);

            Assert.Throws<ArgumentException>
                (() => this.chainblock.ChangeTransactionStatus(2, TransactionStatus.Unauthorized));
        }

        [Test]
        public void ChangeTransactionStatuc_ChangesStatus_WhenIdExists()
        {
            ITransaction transaction = CreateTransaction(1);

            this.chainblock.Add(transaction);

            TransactionStatus changedStatus = TransactionStatus.Unauthorized;
            this.chainblock.ChangeTransactionStatus(transaction.Id, changedStatus);

            Assert.That(transaction.Status, Is.EqualTo(changedStatus));
        }

        [Test]
        public void RemoveTransactionById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = CreateTransaction(1);
            this.chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(2));
        }

        [Test]
        public void RemoveTransactionById_RemovesTransaction_IfIdExists()
        {
            int idToRemove = 1;
            ITransaction transaction = CreateTransaction(idToRemove);
            this.chainblock.Add(transaction);

            this.chainblock.RemoveTransactionById(idToRemove);

            Assert.That(this.chainblock.Count, Is.Zero);
            Assert.That(this.chainblock.Contains(idToRemove), Is.False);
        }

        [Test]
        public void GetById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = CreateTransaction(1);
            this.chainblock.Add(transaction);

            int invalidId = 2;

            Assert.That(() => this.chainblock.GetById(invalidId), Throws.InvalidOperationException);
        }

        [Test]
        public void GetById_ReturnsProperTransaction_WhenIdExists()
        {
            int id = 1;
            ITransaction transaction = CreateTransaction(id);
            this.chainblock.Add(transaction);

            ITransaction returnedTransaction = this.chainblock.GetById(id);

            Assert.That(returnedTransaction, Is.EqualTo(transaction));
        }

        [Test]
        public void GetByTransactionStatus_ThrowsException_WhenNoSuchStatusExists()
        {
            GenerateThreeTransactions();

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsACollectionOfTransactionsDesdcending_WhenStatusExists()
        {
            GenerateBulkTransactions();

            TransactionStatus targetStatus = TransactionStatus.Failed;

            List<ITransaction> expected = this.chainblock
                .Where(t => t.Status == targetStatus)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actual = this.chainblock.GetByTransactionStatus(targetStatus).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsException_WhenNoTransactionsWithGivenStatusExist()
        {
            GenerateThreeTransactions();

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsSortedData_WhenNoTransactionsExist()
        {
            GenerateBulkTransactions();

            TransactionStatus status = TransactionStatus.Successfull;

            List<string> expected = this.chainblock
                .Where(t => t.Status == TransactionStatus.Successfull)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            List<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(status).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsException_WhenTransactionStatusDoesNotExist()
        {
            GenerateThreeTransactions();

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsSortedData_WhenTransactionsExist()
        {
            GenerateBulkTransactions();

            TransactionStatus status = TransactionStatus.Failed;

            List<string> expected = this.chainblock
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To) //from the filtered transactions take the Receivers (To)
                .ToList();

            List<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(status).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsDataInExpectedOrder()
        {
            GenerateBulkTransactions();

            List<ITransaction> expected = this.chainblock.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            List<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsException_IfNoSuchTransactionsExist()
        {
            GenerateBulkTransactions();

            string invalidSender = "NoSuchSenderExists";

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetBySenderOrderedByAmountDescending(invalidSender));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsDataFilteredBySender()
        {
            this.GenerateBulkTransactions();

            string sender = this.chainblock.FirstOrDefault().From; //take firstOrDefault transaction and then take the sender (from)

            List<ITransaction> expected = this.chainblock
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();
            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsException_WhenNoSuchTransactionsExist()
        {
            this.GenerateBulkTransactions();

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByReceiverOrderedByAmountThenById("Invalid receiver"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsTransactionsWithSetReceiver()
        {
            this.GenerateBulkTransactions();

            string receiver = this.chainblock.FirstOrDefault().To;

            List<ITransaction> expected = this.chainblock
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            List<ITransaction> actual = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();

            Assert.That(expected, Is.EqualTo(actual));
        }


        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenStatusIsNotValid()
        {
            GenerateThreeTransactions();

            Assert.That(this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 50),
                Is.EquivalentTo(new List<ITransaction>()));

        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenAmountIsNotValid()
        {
            GenerateThreeTransactions();

            Assert.That(this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 20),
                Is.EquivalentTo(new List<ITransaction>()));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsAllTransactionsWithGivenAmountAndStatus()
        {
            GenerateBulkTransactions();

            TransactionStatus status = TransactionStatus.Aborted;
            double amount = 50;

            List<ITransaction> expected = this.chainblock
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actual = this.chainblock
                .GetByTransactionStatusAndMaximumAmount(status, amount)
                .ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenSenderDoesNotExist()
        {
            GenerateBulkTransactions();

            double amount = this.chainblock.Min(t => t.Amount); //valid - the transaction with the lowest amount

            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetBySenderAndMinimumAmountDescending("Invalid Sender", amount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenAmountIsGreaterThanProvided()
        {
            this.GenerateBulkTransactions();

            string sender = this.chainblock.FirstOrDefault().From;

            double maxAmount = this.chainblock.Max(t => t.Amount) + 1; //invalid amount (greater than the max amount with 1)

            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetBySenderAndMinimumAmountDescending(sender, maxAmount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsAllTransactionsWithSenderAndHigherAmount()
        {
            GenerateBulkTransactions();

            string sender = this.chainblock.FirstOrDefault().From;

            double amount = this.chainblock.Min(t => t.Amount);

            //List<ITransaction> expected = this.chainblock
            //    .Where(t => t.From == sender)
            //    .Where(t => t.Amount > amount)
            //    .OrderByDescending(t => t.Amount)
            //    .ToList();

            List<ITransaction> result = this.chainblock
                .GetBySenderAndMinimumAmountDescending(sender, amount)
                .ToList();

            double prevAmount = double.MaxValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.From, Is.EqualTo(sender));
                Assert.That(transaction.Amount, Is.GreaterThan(sender));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));

                prevAmount = transaction.Amount; //grab the next biggest amount 
            }
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsException_WhenReceiverDoesNotExist()
        {
            GenerateBulkTransactions();

            string receiver = "Invalid receiver";
            double low = this.chainblock.Min(t => t.Amount);
            double high = this.chainblock.Max(t => t.Amount);

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByReceiverAndAmountRange(receiver, low, high));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsException_WhenAmountIsOutsideOfRange()
        {
            GenerateBulkTransactions();
            string receiver = this.chainblock.FirstOrDefault().To;
            double low = this.chainblock.Max(t => t.Amount) + 1; //invalid low
            double high = this.chainblock.Min(t => t.Amount) - 1; //invalid high

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByReceiverAndAmountRange(receiver, low, high));
        }

        [Test]
        public void GetByReceiverAndAmountRange_FiltersAndOrdersData()
        {
            GenerateBulkTransactions();

            string receiver = this.chainblock.FirstOrDefault().To;
            double low = this.chainblock.Min(t => t.Amount);
            double high = this.chainblock.Max(t => t.Amount);

            List<ITransaction> expected = this.chainblock
                .Where(t => t.To == receiver && t.Amount >= low && t.Amount < high)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t=>t.Id)
                .ToList();

            List<ITransaction> actual = this.chainblock
                .GetByReceiverAndAmountRange(receiver, low, high)
                .ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllInAmountRange_ReturnsEmptyCollection_WhenNoTransactionsAreFound()
        {
            GenerateBulkTransactions();

            double low = this.chainblock.Max(t => t.Amount) + 1;
            double high = this.chainblock.Min(t => t.Amount) - 1;

            Assert.That(this.chainblock.GetAllInAmountRange(low, high), Is.EquivalentTo(new List<ITransaction>()));
        }

        [Test]
        public void GetAllInAmountRange_ReturnsAllTransactionWithinGivenRange()
        {
            GenerateBulkTransactions();

            double low = this.chainblock.Min(t => t.Amount);
            double high = this.chainblock.Max(t => t.Amount);

            List<ITransaction> expected = this.chainblock
                .Where(t => t.Amount >= low && t.Amount <= high)
                .ToList();

            List<ITransaction> actual = this.chainblock
                .GetAllInAmountRange(low, high)
                .ToList();

            Assert.That(expected, Is.EquivalentTo(actual));

        }

        private void GenerateBulkTransactions()
        {
            Random random = new Random();
            int n = 100;
            string[] senders = { "Peter", "Momchil", "Ivan", "Toncho", "Stoyan" };
            string[] receivers = { "Ivo", "Gosho", "Tosho", "Niki", "Emo" };

            for (int i = 0; i < 100; i++)
            {
                int randomFrom = random.Next(0, 5);
                int randomTo = random.Next(0, 5);
                double amount = random.Next(1, 101);
                int randomStatusEnum = random.Next(0, 4);

                ITransaction transaction = new Transaction
                {
                    Id = n - i,
                    From = senders[randomFrom],
                    To = receivers[randomTo],
                    Amount = amount,
                    Status = (TransactionStatus)randomStatusEnum
                };

                this.chainblock.Add(transaction);
            }
        }

        private void GenerateThreeTransactions()
        {
            ITransaction transaction = CreateTransaction(1);
            transaction.Status = TransactionStatus.Aborted;

            ITransaction transaction2 = CreateTransaction(2);// Status Failed

            ITransaction transaction3 = CreateTransaction(3);
            transaction3.Status = TransactionStatus.Successfull;

            this.chainblock.Add(transaction);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
        }

        private ITransaction CreateTransaction(int id)
        {
            ITransaction transaction = new Transaction
            { Id = id, Amount = 50, From = "Pesho", To = "Gosho", Status = TransactionStatus.Failed };

            return transaction;
        }
    }
}
