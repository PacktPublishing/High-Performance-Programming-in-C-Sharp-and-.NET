using System;
using CH01_Books;

var bookName = new Book { Title = "Made up book name", Author = "Made Up Author" };

Console.WriteLine($"{bookName.Title} is written by {bookName.Author}. Well worth reading!");
