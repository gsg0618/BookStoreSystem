using BookStoreDATA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreLIB
{
    [TestClass]
    public class BookAndCategoryTests
    {
        [TestMethod]
        public void TestBookDALAddReturnsARow()
        {
            var dal = new DALBookCatalog();
            var rows = dal.AddBook("isbntest", "Good Book", "Friendly author", 0.1f, 1985, 1);
            Assert.AreEqual(1, rows);
        }

        [TestMethod]
        public void TestBookDALAddCategoryReturnsARow()
        {
            var dal = new DALBookCatalog();
            var rows = dal.AddCategory("Good category");
            Assert.AreEqual(1, rows);
        }

        [TestMethod]
        public void TestAddedBookHasCorrectTitle()
        {
            var dal = new DALBookCatalog();
            var title = dal.GetBookTitle("isbntest");
            Assert.AreEqual("Good Book", title);
        }

        [TestMethod]
        public void TestAddedBookCategoryHasCorrectName()
        {
            var dal = new DALBookCatalog();
            var title = dal.GetBookCategoryName(11);
            Assert.AreEqual("Demo category", title);
        }

        [TestMethod]
        public void TestIfAddAndDeleteReturnsTrue()
        {
            var catalog = new BookCatalog();
            var isbn = "0205080061";
            catalog.RemoveBook(isbn);

            var status = catalog.AddBook(isbn, "Lorem", "Ipsum", 23.4f, 2023, 1);
            Assert.IsTrue(status);

            status = catalog.RemoveBook(isbn);
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestIfDeleteReturnsFalseIfNonExistent()
        {
            var catalog = new BookCatalog();
            var isbn = "shouldnotexist";
            var status = catalog.RemoveBook(isbn);
            Assert.IsFalse(status);
        }
        [TestMethod]

        public void TestIfCategoryAddReturnsTrue()
        {
            var catalog = new BookCatalog();
            var status = catalog.AddCategory("Demo category");
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void TestIfCategoryDeleteReturnsFalseIfNonExistent()
        {
            var catalog = new BookCatalog();
            var status = catalog.RemoveCategory(-1);
            Assert.IsFalse(status);
        }
    }
}
