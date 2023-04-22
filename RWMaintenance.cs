using RWMaintenance;
Service Service1;
Service1 = new Service(13, 342, RepairType.Urgent, "Олег", "Карпов", "ПЕтрович", 1234.4, "FWE", DateTime.Parse("April 2, 2023"));
Console.WriteLine(Service1.GetInfo());