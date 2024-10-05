


using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/books/")]
public class BookController : ControllerBase
{
    private readonly IBookService bookService;
    public BookController(IBookService bookService)
    {
        this.bookService = bookService;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Create(Book book)
    {
        if (book == null)
        {
            return Results.BadRequest("Не удалось добавить!");
        }
        bool res = await bookService.Create(book);
        if (res == false)
        {
            return Results.BadRequest("Не удалось добавить!");
        }
        return Results.Ok("Книга успешно добавлена");
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Update(Book book)
    {
        if (book == null)
        {
            return Results.BadRequest("Не удалось обновить!");
        }
        bool res = await bookService.Update(book);
        if (res == false)
        {
            return Results.BadRequest("Не удалось обновить");
        }
        return Results.Ok("Успешно обновлено!");
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Delete(int id)
    {
        bool res = await bookService.Delete(id);
        if (res == false)
        {
            return Results.BadRequest("Не удалось удалить!");
        }
        return Results.Ok("Успешно удалено!");
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetById(int id)
    {
        Book? book = await bookService.GetById(id);
        if (book == null)
        {
            return Results.NotFound("Не удалось получить!");
        }
        return Results.Ok(book);
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetAll()
    {
        IEnumerable<Book?> books = await bookService.GetAll();
        if (books == null)
        {
            return Results.NotFound("Не удалось получить книги!");
        }
        return Results.Ok(books);
    }
}