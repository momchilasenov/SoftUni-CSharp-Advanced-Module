using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        private Dictionary<string, Item> vaultCells;

        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();

            this.item = new Item("Owner", "1");
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>
                (() => vault.AddItem("Invalid cell", null));
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellIsAlreadyTaken()
        {
            vault.AddItem("A2", item);
            Assert.That(() => vault.AddItem("A2", new Item("Me", "10")), 
                Throws.ArgumentException
                .With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void CellExists_ThrowsException_WhenCellWithGivenIdAlreadyExist()
        {
            vault.AddItem("A2", item);

            Assert.That(() => vault.AddItem("A4", new Item(item.Owner, item.ItemId)),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void ItemIsSavedSuccesfully_WhenDataIsCorrect()
        {
            string result = vault.AddItem("A2", item);

            Assert.That(result, Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("I323", item));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellValueDoesNotExist()
        {
            vault.AddItem("A2", item);

            Assert.Throws<ArgumentException>
                (() => vault.RemoveItem("A2", new Item("Fake", "Fake")));
        }

        [Test]
        public void RemoveItem_RemovesItemAndSetsItToNull_WhenDataIsCorrect()
        {
            vault.AddItem("A2", item);
            string result = vault.RemoveItem("A2", item);

            Assert.That(vault.VaultCells["A2"], Is.EqualTo(null));
            Assert.AreEqual($"Remove item:{item.ItemId} successfully!", result);
        }
    }
}