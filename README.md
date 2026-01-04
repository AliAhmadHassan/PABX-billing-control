# PABX Billing Control (Tarifador)

Legacy but production-oriented PABX billing control system built in C#/.NET Framework. It ingests Call Detail Records (CDR) from multiple dialer platforms, normalizes them, applies tariff and cadence rules, and persists billable events for auditing and reconciliation.

## What this project does
- Imports CDRs from Gennex (MySQL) and TotalIP (PostgreSQL).
- Normalizes and enriches call data (operator, route, campaign, status).
- Calculates call cost based on configurable tariffs and cadences.
- Persists billable events and supports reconciliation against external reports.

## Architecture and methodology
Layered architecture with clear separation of concerns:
- `Tarifador.DTO`: Data Transfer Objects used across layers.
- `Tarifador.DAL`: Data Access Layer with direct SQL queries (ADO.NET).
- `Tarifador.BLL`: Business Logic Layer, interfaces, and pricing rules.
- `Tarifador.ImportaBilhetagem`: Console ETL for CDR import.
- `ConciliaContas`: Console tool for reconciliation and auditing.

This structure keeps domain rules isolated from data access and makes the ETL pipelines testable and maintainable.

## Technologies
- C# / .NET Framework 4.5.2
- ADO.NET data access
- MySQL Connector (Gennex CDR)
- Npgsql (PostgreSQL TotalIP)
- SQL Server core database (billing system)

## Data flow (high level)
1. Importers pull CDRs in batches using the last processed ID stored in local files (`ultimoId*.txt`).
2. Business rules map routes, operators, and campaigns; missing lookup records are created as needed.
3. Cadence-based tariff rules compute the final cost for each call.
4. Clean, normalized billing records are persisted for reporting or reconciliation.

## Business logic highlights
- Cadence-based billing: initial block + incremental blocks with rounding rules.
- Differentiation of local vs. long-distance based on DDD and number length.
- Automatic discovery of new campaigns and call statuses.

## How to run (overview)
- Open `Tarifador.sln` in Visual Studio 2017+ (or build with MSBuild).
- Configure connection strings in the app.config files.
- Run importers:
  - `Tarifador.ImportaBilhetagem.exe \g` to import Gennex CDRs
  - `Tarifador.ImportaBilhetagem.exe \t1` or `\t2` for TotalIP servers
- Run reconciliation:
  - `ConciliaContas.exe <input_csv>`

## Configuration notes
Connection strings and server IPs are hardcoded for the original environment. Replace them with your own values before using the project in a public or new environment.

## Why this is relevant
This project demonstrates real-world integration work (telephony CDRs), domain-specific billing logic, and reliable batch processing. It is a practical example of backend engineering across multiple databases and external systems.
