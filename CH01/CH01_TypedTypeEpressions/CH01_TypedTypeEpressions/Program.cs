using CH01_TargetedTypeEpressions;
using System;
using System.Collections.Generic;
using System.Linq;

Student jenniferAlbright = new ("Jennifer", "Albright");

var studentList = new List<Student>
{
    new ("Jennifer", "Albright"),
    new ("Kelly", "Charmichael"),
    new ("Lydia", "Braithwait")
};

var (firstName, lastName) = jenniferAlbright;
Console.WriteLine($"Student: {lastName}, {firstName}");

(firstName, lastName) = studentList.Last();
Console.WriteLine($"Student: {lastName}, {firstName}");
