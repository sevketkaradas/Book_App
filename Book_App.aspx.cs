using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_book_app
{
    public partial class Book_App : System.Web.UI.Page
    {
        private static Book get_books = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Show_book (object sender, EventArgs e)
        {
            get_books = get_book();
            repeaterYukle(get_books);

        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            RepeaterItem Item = (sender as LinkButton).Parent as RepeaterItem;
            int id_book = int.Parse((Item.FindControl("id") as TextBox).Text);
            string bookName = ((Item.FindControl("txtbookName") as TextBox).Text);
            string Writer = (Item.FindControl("txtWriter") as TextBox).Text;
            string PageCount = (Item.FindControl("txtPageCount") as TextBox).Text;
            string Categori = (Item.FindControl("txtCategories") as TextBox).Text;
            BookAppDataDataContext db = new BookAppDataDataContext();
            var get_book = db.BookAppDatebases.Single(c => c.id == id_book);

            get_book.BookName = bookName;
            get_book.Writer = Writer;
            get_book.PagesCount =Convert.ToInt32(PageCount);
            get_book.Categories = Categori;

            db.SubmitChanges();
        }
        private Book get_book()
        {
            Book BooksApp = new Book
            {
                books = new List<booksAppModel>()
            };
            BookAppDataDataContext db = new BookAppDataDataContext();

            var q = db.BookAppDatebases.AsQueryable();
            var buffer = (from i in q
                          select new
                          {

                              i.BookName,
                              i.Writer,
                              i.PagesCount,
                              i.Categories,
                              i.id,

                          }).ToList();
            BooksApp.books = (from i in buffer

                              select new booksAppModel
                              {
                                  BookName = i.BookName,
                                  WriterName = i.Writer,
                                  PagesCount = Convert.ToInt32(i.PagesCount),
                                  Categories = (i.Categories),
                                  id = i.id,

                              }).ToList();
            return BooksApp;
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem Item = (sender as LinkButton).Parent as RepeaterItem;
            int id_book = int.Parse((Item.FindControl("id") as TextBox).Text);
            BookAppDataDataContext db = new BookAppDataDataContext();
            var DeleteBook = db.BookAppDatebases.First(c => c.id == id_book);
            db.BookAppDatebases.DeleteOnSubmit(DeleteBook);
            db.SubmitChanges();
            get_books = get_book();
            repeaterYukle(get_books);
        }
        protected void Save_Book(object sender, EventArgs e)
        {
         
            BookAppDataDataContext db = new BookAppDataDataContext();
            try
            {
                BookAppDatebase  Book = new BookAppDatebase
                {
                    BookName = (txtBookName.Text),
                    Writer = (txtWriter.Text),
                    PagesCount = Convert.ToInt32(txtPageCount.Text),
                    Categories = txtCategori.Text

                };

                db.BookAppDatebases.InsertOnSubmit(Book);
                db.SubmitChanges();
                
            }
            catch (Exception ex)
            {

            }
        }
        public void repeaterYukle(Book booksapp)
        {
            Repeater1.DataSource = booksapp.books;

            Repeater1.DataBind();

        }
        protected void rptTablo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

       
        public class Book
        {

            public List<booksAppModel> books;
            public string hata;

        }

        public class booksAppModel
        {

            public int id { get; set; }
            public string BookName { get; set; }
            public string WriterName { get; set; }
            public int PagesCount { get; set; }
            public string Categories { get; set; }




        }
    }
}