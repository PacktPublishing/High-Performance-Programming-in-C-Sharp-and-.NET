using System;
using CH01_Records;

var bookOne = new Book { 
    Title = "Made Up Book", 
    Author = "Made Up Author",
    PublisherName = "Made Up Publisher Ltd."
};

var bookTwo = bookOne with { 
    Title = "And Another Made Up Book"
};

var bookThree = bookTwo with { 
    Title = "Yet Another Made Up Book"
};

var bookFour = bookThree with { 
    Title = "And Yet Another Made Up Book: Part 1",
};

var bookFive = bookFour with { 
    Title = "And Yet Another Made Up Book: Part 2"
};

var bookSix = bookFive with { 
    Title = "And Yet Another Made Up Book: Part 3"
};

Console.WriteLine($"Some of {bookThree.Author}'s books include:\n");
Console.WriteLine($"- {bookOne.Title}");
Console.WriteLine($"- {bookTwo.Title}");
Console.WriteLine($"- {bookThree.Title}");
Console.WriteLine($"- {bookFour.Title}");
Console.WriteLine($"- {bookFive.Title}");
Console.WriteLine($"- {bookSix.Title}");

Console.WriteLine($"\nMy favourite book by {bookOne.Author} is {bookOne.Title}.");
Console.WriteLine($"These books were originally published by {bookSix.PublisherName}.");

var book = bookThree with { Title = "Made Up Book" };
var booksEqual = Object.Equals(book, bookOne) ? "Yes" : "No";
Console.WriteLine($"Are {book.Title} and {bookOne.Title} equal? {booksEqual}");

var ide = new Product("Awesome-X", "Advanced Multi-Language IDE");
var (product, description) = ide;

Console.WriteLine($"The product called {product} is an {description}.");