


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

## Point of intests
