using System;
using CH01_PatternMatching;

var orderOne = new OrderItem {
        Name = "50-80mm Scottish Cobbles", 
        Description = "These rounded stones are frequently used for edging paths and to add interest to gardens", 
        QuantityOrdered = 4, 
        UnitPrice = 199 
};

var orderTwo = new OrderItem
{
    Name = "50-80mm Scottish Cobbles",
    Description = "These rounded stones are frequently used for edging paths and to add interest to gardens",
    QuantityOrdered = 7,
    UnitPrice = 199
};

var orderThree = new OrderItem
{
    Name = "50-80mm Scottish Cobbles",
    Description = "These rounded stones are frequently used for edging paths and to add interest to gardens",
    QuantityOrdered = 31,
    UnitPrice = 199
};

static int GetDiscount(object order) =>
    order switch
    {
        OrderItem o when o.QuantityOrdered == 0 => throw new ArgumentException("Quantity must be greater than zero."),
        OrderItem o when o.QuantityOrdered > 20 => 30,
        OrderItem o when o.QuantityOrdered < 5 => 10,
        OrderItem => 20,
        _ => throw new ArgumentException("Not a known OrderItem!", nameof(order))
    };

static int GetDiscountRelational(OrderItem orderItem) =>
    orderItem.QuantityOrdered switch
    {
        < 1 => throw new ArgumentException("Quantity must be greater than zero."),
        > 20 => 30,
        < 5 => 10,
        _ => 20
    };

static int GetDiscountLogical(OrderItem orderItem) =>
    orderItem.QuantityOrdered switch
    {
        < 1 => throw new ArgumentException("Quantity must be greater than zero."),
        > 0 and < 5 => 10,
        > 4 and < 21 => 20,
        > 20 => 30
    };

Console.WriteLine($"The discount for Order One is {GetDiscount(orderOne)}%.");
Console.WriteLine($"The discount for Order Two is {GetDiscount(orderTwo)}%.");
Console.WriteLine($"The discount for Order Three is {GetDiscount(orderThree)}%.");

Console.WriteLine($"The discount for Order One is {GetDiscountRelational(orderOne)}%.");
Console.WriteLine($"The discount for Order Two is {GetDiscountRelational(orderTwo)}%.");
Console.WriteLine($"The discount for Order Three is {GetDiscountRelational(orderThree)}%.");

Console.WriteLine($"The discount for Order One is {GetDiscountLogical(orderOne)}%.");
Console.WriteLine($"The discount for Order Two is {GetDiscountLogical(orderTwo)}%.");
Console.WriteLine($"The discount for Order Three is {GetDiscountLogical(orderThree)}%.");