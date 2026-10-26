using BookStore.API.Data;

namespace BookStore.API.Features.Books.DeleteBook
{
    public class DeleteBookHandler(BookStoreData data)
    {
        public void Handle(Guid id)
        {
            data.RemoveBook(id);
        }
    }
}
