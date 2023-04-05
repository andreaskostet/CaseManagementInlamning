using CaseManagementInlamning.DataAccess;
using CaseManagementInlamning.Models;
using System;
using System.Collections.Generic;

namespace CaseManagementInlamning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapar anslutningssträng till databasen
            string _CaseManagementDBConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CaseManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // Skapar instans av CaseRepository
            CaseRepository caseRepository = new CaseRepository(_CaseManagementDBConnectionString);

            // Skapar nytt ärende
            Case newCase = new Case
            {
                CustomerFirstName = "John",
                CustomerLastName = "Doe",
                CustomerEmail = "johndoe@example.com",
                CustomerPhone = "555-1234",
                Description = "Min dator startar ej.",
                Status = CaseStatus.New,
                CreatedAt = DateTime.Now
            };
            caseRepository.Insert(newCase);

            // Hämtar alla ärenden och skriver ut
            List<Case> allCases = caseRepository.GetAll();
            foreach (Case c in allCases)
            {
                Console.WriteLine(c.ToString());
            }

            // Hämtar ett specifikt ärende och skriver ut 
            Case retrievedCase = caseRepository.GetById(1);
            Console.WriteLine(retrievedCase.ToString());

            // Uppdaterar statusen på ett ärende
            retrievedCase.Status = CaseStatus.InProgress;
            caseRepository.Update(retrievedCase);

            // Hämtar det uppdaterade ärendet och skriver ut 
            retrievedCase = caseRepository.GetById(1);
            Console.WriteLine(retrievedCase.ToString());
        }
    }
}

