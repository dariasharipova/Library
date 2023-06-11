/* namespace RWMaintenance;

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
[TestFixture]
public class CarDepotTests
{
    CarDepot depot;
    [SetUp]
    public void Setup()
    {
        depot = new CarDepot("TTT", new List<Service>(){new Service(15, 234, RepairType.Urgent, "werty", "sdfghjn", "dxfcgvbh", 1234, "sdfghj", DateTime.Parse("May 3, 2023")),new Service(15, 234, RepairType.Urgent, "werty", "sdfghjn", "dxfcgvbh", 1234, "sdfghj", DateTime.Parse("May 5, 2023"))}, 2345);
        #depot = new CarDepot("TTT", new List<string>(){"работа1", "робта2", "работа3"}, 23);
    }
    [Test]
    public void ConstructorDepotTests()
    {
        Assert.That(depot.Title, Is.EqualTo("TTT"));
        Assert.That(depot.WorkList, Is.EqualTo(new List<Service>(){"работа1", "робта2", "работа3"}));
        Assert.That(depot.Capacity, Is.EqualTo(23));
    }
    [Test]
    public void GetInfoCarDepotTest()
    {
        var expected = "Название депо: TTT\nСписок работ: работа1\nробта2\nработа3\nВместимость депо: 23";
        Assert.That(depot.GetInfo(), Is.EqualTo(expected));
    }
}
[TestFixture]
public class LocomotiveDepotTests
{
    LocomotiveDepot locoDepot;
    [SetUp]
    public void Setup()
    {
        locoDepot = new LocomotiveDepot("rrr", new List<string>(){"work1", "work2", "work3"}, LocoType.ElectroLoco);
    }
    [Test]
    public void ConstructorLocoDepotTest()
    {
        Assert.That(locoDepot.Title, Is.EqualTo("rrr"));
        Assert.That(locoDepot.WorkList, Is.EqualTo(new List<string>(){"work1", "work2", "work3"}));
        Assert.That(locoDepot.Locomotive, Is.EqualTo(LocoType.ElectroLoco));
    }
    [Test]
    public void GetInfoLocomotiveDepotTest()
    {
        var expected = "Название депо: rrr\nСписок работ: work1\nwork2\nwork3\nТип ремонтируемого локомотива: электровоз";
        Assert.That(locoDepot.GetInfo(), Is.EqualTo(expected));
    }
} */