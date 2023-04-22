namespace RWMaintenance;

public class ServiceTests
{
    static Service service;
    [SetUp]
    public void Setup()
    {
        service = new Service(13, 342, RepairType.Urgent, "Олег", "Карпов", "ПЕтрович", 1234.4, "FWE", DateTime.Parse("April 2, 2023"));
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(service.ServiceNumber, Is.EqualTo(13));
        Assert.That(service.CarNumber, Is.EqualTo(342));
        Assert.That(service.Repair, Is.EqualTo(RepairType.Urgent));
        Assert.That(service.EmployeeName, Is.EqualTo("Олег"));
        Assert.That(service.EmployeeSurname, Is.EqualTo("Карпов"));
        Assert.That(service.EmployeePatronymic, Is.EqualTo("ПЕтрович"));
        Assert.That(service.WorkCost, Is.EqualTo(1234.4));
        Assert.That(service.WorkDescription, Is.EqualTo("FWE"));
        Assert.That(service.StartDate, Is.EqualTo(DateTime.Parse("April 2, 2023")));
        Assert.That(service.Duration.Days, Is.EqualTo((DateTime.Now - DateTime.Parse("April 2, 2023")).Days));
    }
    [Test]
    public void GetInfo_Service_ValuesString()
    {
        string expectedInfo = "Номер заявки: 13";
        expectedInfo += "\nНомер вагона: 342";
        expectedInfo += "\nТип ремонта: срочный";
        expectedInfo += "\nФИО сотрудника, отвественного за произведение работ: Карпов Олег ПЕтрович";
        expectedInfo += "\nСтоимость работ: 1234.4";
        expectedInfo += "\nОписание работ: FWE";
        expectedInfo += "\nДата начала работ: 4/2/2023 12:00:00 AM";
        expectedInfo += $"\nДата завершения работ: {DateTime.Now}";
        expectedInfo += $"\nПродолжительность работ: {(DateTime.Now - DateTime.Parse("April 2, 2023")).Days} дней";
        Assert.That(service.GetInfo(), Is.EqualTo(expectedInfo));
    }
}
