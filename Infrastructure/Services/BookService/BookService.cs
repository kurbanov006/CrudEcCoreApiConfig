

using Infrastructure.DataContext;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{

    private readonly AppDbContext _dbContext;
    public BookService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Create(Book book)
    {
        try
        {
            if(book == null)
            {
                System.Console.WriteLine($"Ваша книга null!");
                return false;
            }
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return true;

        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Book? book = await _dbContext.Books.FindAsync(id);
            if(book == null)
            {
                System.Console.WriteLine($"Книга не найдена!");
                return false;
            }

             _dbContext.Books.Remove(book);
             await _dbContext.SaveChangesAsync();

             return true;

        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Book?>> GetAll()
    {
        try
        {
            return await _dbContext.Books.ToListAsync();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<Book?> GetById(int id)
    {
        try
        {
            Book? book = await _dbContext.Books.FindAsync(id);
            if(book == null)
            {
                System.Console.WriteLine($"Нет таkой книги по {id}");
                return null;
            }
            return book;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> Update(Book book)
    {
        try
        {
            Book? res = await _dbContext.Books.FindAsync(book.Id);
            if(res == null!)
            {
                System.Console.WriteLine($"Не удалось найти book");
                return false;
            }
            res.Author = book.Author;
            res.Title = book.Title;
            res.Description = book.Description;
            await  _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}