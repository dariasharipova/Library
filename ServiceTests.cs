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
    [Test]
    public void ComparerToTest()
    {
        var service = new Service(13, 342, RepairType.Urgent, "Олег", "Карпов", "ПЕтрович", 1234.4, "FWE", DateTime.Parse("April 2, 2023"));
        var service_two = new Service(15, 234, RepairType.Urgent, "Алексей", "Смирнов", "Генадьевич", 1234, "sdfghj", DateTime.Parse("May 3, 2023"));
        var service_three = new Service(178, 12, RepairType.Prevention, "Виктор", "Лукьянов", "Дмитреевич", 12904, "fdghasf", DateTime.Parse("May 5, 2023"));
        Assert.That(service.CompareTo(service_two), Is.LessThan(0));
        Assert.That(service_three.CompareTo(service_three), Is.EqualTo(0));
    }
}
[TestFixture]
public class CarDepotTests
{
    static Service service;
    static Service service_two;
    static Service service_three;
    CarDepot depot;
    [SetUp]
    public void Setup()
    {
        service = new Service(13, 342, RepairType.Urgent, "Олег", "Карпов", "ПЕтрович", 1234.4, "FWE", DateTime.Parse("April 2, 2023"));
        service_two = new Service(15, 234, RepairType.Urgent, "Алексей", "Смирнов", "Генадьевич", 1234, "sdfghj", DateTime.Parse("May 3, 2023"));
        service_three = new Service(178, 12, RepairType.Prevention, "Виктор", "Лукьянов", "Дмитреевич", 12904, "fdghasf", DateTime.Parse("May 5, 2023"));
        depot = new CarDepot("TTT", new List<Service>(){service, service_two, service_three}, 2345);
    }
    [Test]
    public void ConstructorDepotTests()
    {
        Assert.That(depot.Title, Is.EqualTo("TTT"));
        Assert.That(depot.WorkList, Is.EqualTo(new List<Service>(){service, service_two, service_three}));
        Assert.That(depot.Capacity, Is.EqualTo(2345));
        Assert.That(depot.CarCount, Is.EqualTo(3));
    }
    [Test]
    public void GetInfoCarDepotTest()
    {
        var expected = "Название депо: TTT\nСписок работ: FWE\nsdfghj\nfdghasf\nВместимость депо: 2345\nКоличество вагонов на ремонте: 3";
        Assert.That(depot.GetInfo(), Is.EqualTo(expected));
    }
    [Test]
    public void IEnumerableTest()
    {
        var i = 0;
        foreach(var work in depot.WorkList)
        {
            Assert.That(work, Is.SameAs(depot.WorkList[i++]));
        }
    }
}
[TestFixture]
public class LocomotiveDepotTests
{
    static Service service;
    static Service service_two;
    static Service service_three;
    LocomotiveDepot locoDepot;
    [SetUp]
    public void Setup()
    {
        service = new Service(13, 342, RepairType.Urgent, "Олег", "Карпов", "ПЕтрович", 1234.4, "FWE", DateTime.Parse("April 2, 2023"));
        service_two = new Service(15, 234, RepairType.Urgent, "Алексей", "Смирнов", "Генадьевич", 1234, "sdfghj", DateTime.Parse("May 3, 2023"));
        service_three = new Service(178, 12, RepairType.Prevention, "Виктор", "Лукьянов", "Дмитреевич", 12904, "fdghasf", DateTime.Parse("May 5, 2023"));
        locoDepot = new LocomotiveDepot("rrr", new List<Service>(){service, service_two, service_three}, LocoType.ElectroLoco);
    }
    [Test]
    public void ConstructorLocoDepotTest()
    {
        Assert.That(locoDepot.Title, Is.EqualTo("rrr"));
        Assert.That(locoDepot.WorkList, Is.EqualTo(new List<Service>(){service, service_two, service_three}));
        Assert.That(locoDepot.Locomotive, Is.EqualTo(LocoType.ElectroLoco));
    }
    [Test]
    public void GetInfoLocomotiveDepotTest()
    {
        var expected = "Название депо: rrr\nСписок работ: FWE\nsdfghj\nfdghasf\nТип ремонтируемого локомотива: электровоз";
        Assert.That(locoDepot.GetInfo(), Is.EqualTo(expected));
    }
}   