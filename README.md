# DotNetStandardUWP

An example of moving a WinForms BLL / DAL to .NET Standard 2.0 and consuming from a UWP app - including co-evolution of projects to introduce new features such as Windows Hello, Notifications and Inking.

## Pre-requisites

* Visual Studio 15.4 or Visual Studio 2017 with .NET Core 2.0 SDK
* Local SQL Server Express database instance
  * Ensure appropriate firewall rules are allowed - UDP, TCP ports 1433 and 1434
  * Ensure SQL Server and SQL Server Browser services are started (services.msc)
  * privateNetworkClientServer capability will need to be in the UWP appxmanifest.xml, but this will already be added for this project
* Windows 10 Fall Creators Update
* Windows 10 Fall Creators Update SDK

## Setup

* Create local Northwind database - either through Database\instnwnd.sql scripe, or by attaching Northwind.mdf

* Update database connection string in the following files:
  * Northwind\Northwind.NET.DAL\Properties\Settings.settings
  * Northwind\Northwind.Std.DAL\Helpers\Settings.cs

* Update Nuget packages
  * Remove existing Telerik.* references and point to Nuget package for "Telerik.UI.for.UniversalWindowsPlatform"
  * Remove existing System.Data.DataSetExtensions and point to Nuget package for "System.Data.DataSetExtensions"

(At the time of writing, the Nuget implementations either did not exist or were awaiting bug fixes.)

* Set Startup project to either Northwind.NET.WinForms or Northwind.UWP.UI and run.
