# CashRegister
Simple cash register for demo

## Requests
We’re going to see how far we can get in implementing a supermarket checkout that calculates the total price of a number of items.  

In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our store, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually. 

| Item  | Price  |
| ----- | ------ |
| A     | £5.00  |
| B     | £3.00  |
| C     | £2.00  |
| D     | £1.50  |

Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two ‘B’s and price them at £6.00 (for a total price so far of £11.00). 
In addition, some items are multi-priced: buy n of them, and they’ll cost you y pounds.

For example, item A might cost £5.00 individually, but this week we have a special offer: buy three ‘A’s and they’ll cost you £13.00 
The price and offer table:

| Item  | Price  | Offer        |
| ----- | ------ | ------------ |
| A     | £5.00  | 3 for £13.00 |
| B     | £3.00  | 2 for £4.50  |
| C     | £2.00  |              |
| D     | £1.50  |              |

## Overview
This application is build with .NET core 2.0, the latest version of .NET. 

.NET Core is a general purpose, modular, cross-platform and open source implementation of the .NET Platform. It contains many of the same APIs as the .NET Framework (but .NET Core is a smaller set) and includes runtime, framework, compiler and tools components that support a variety of operating systems and chip targets. Microsoft is considering this technology as the [future of its development platform](https://blogs.msdn.microsoft.com/dotnet/2014/11/12/net-core-is-open-source/).

For this reason _CashRegister.Library_ can be used in every kind of application: web, mobile or desktop. In my implementation I use it for a _Console_ application.

## Application structure
The application has the following components.
![Application diagram](https://github.com/erossini/CashRegister/blob/master/Screenshot/Diagram.PNG)

### CashRegister.Library
This is the important part of this project. This library contains the logic to add new goods in the shopping list. 
![CashRegister.Library](https://github.com/erossini/CashRegister/blob/master/Screenshot/CashRegister.Library.Overview.PNG)

First of all, you find _Interfaces_. An interface is defined as a syntactical contract that all the classes inheriting the interface should follow. The interface defines the _what_ part of the syntactical contract and the deriving classes define the _how_ part of the syntactical contract.

Interfaces define properties, methods, and events, which are the members of the interface. Interfaces contain only the declaration of the members. It is the responsibility of the deriving class to define the members. It often helps in providing a standard structure that the deriving classes would follow.

- **IBasketManager.cs** defines what functions we want to manage a basket
- **IGoodsManager.cs** defines how to manage your good
- **IRepository.cs** defines the requirements for a simple repository

#### BasketManager implements IBasketManager.cs
_BasketManager_ is responsible for managing your shopping, creating the shopping history and writing your receipt. 

When a new item is added in the basker, _BasketManager_ checks if there is any offer for that product and, eventually, calculates the right price and update the receipt.

#### GoodsManager implements IGoodsManager
_GoodManager_ is responsible for managing items in the shopping list. 

When you add a new good, there is a validation of your input and a check if this element already exists in the shopping list.

### CashRegister.Tests
Test-driven development (TDD) is a software development process that relies on the repetition of a very short development cycle: requirements are turned into very specific test cases, then the software is improved to pass the new tests, only. TDD is primarily a developer’s tool to help create well-written unit of code (function, class, or module) that correctly performs a set of operations.

With TDD it cans test all functions and scenarios for **CashRegister.Library**. 

![Test Explorer for CashRegister.Library](https://github.com/erossini/CashRegister/blob/master/Screenshot/TestExplorer.PNG)

### CashRegister.Repository
In this project there is the implementation from **CashRegister.Library** for repository. Basically this module is responsible to read and write on file system the list of goods or a basket. Files are saved in _json_ format in a _Data_ folder in the local directory.

To avoid redundant code or duplicated function, there is a generic _GenericRepository<T>_ that write or read a file in json, serialized or deserialized data with a particular type: for each model there is class that it defines only the name of the function.

### CashRegister.ConsoleApp

#### Main screen
![Main screen](https://github.com/erossini/CashRegister/blob/master/Screenshot/CashRegister1.PNG)

#### Goods menu
![Goods menu](https://github.com/erossini/CashRegister/blob/master/Screenshot/CashRegister2.PNG)

#### List of Goods
![List of Goods](https://github.com/erossini/CashRegister/blob/master/Screenshot/CashRegister3.PNG)

#### Shopping menu
![Shopping menu](https://github.com/erossini/CashRegister/blob/master/Screenshot/CashRegister4.PNG)

#### Basket screen
![Basket screen](https://github.com/erossini/CashRegister/blob/master/Screenshot/CashRegister5.PNG)

## Point of intests
