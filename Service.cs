using System;
namespace RWMaintenance;
public enum RepairType
{
    Urgent,
    Regular,
    Prevention
}
public class Service
{
    public readonly int ServiceNumber;
    public int CarNumber;
    public RepairType Repair;
    public DateTime StartDate;
    public DateTime EndDate;
    public readonly TimeSpan Duration;
    public string EmployeeName{get; set;}
    public string EmployeeSurname{get; set;}
    public string EmployeePatronymic{get; set;}
    public double WorkCost;
    public string WorkDescription;
    public Service(int serviceNumber, int carNumber, RepairType repair, 
    string name, string surname, string patronymic,
    double cost, string description,
    DateTime sDate)
    {
        ServiceNumber = serviceNumber;
        CarNumber = carNumber;
        Repair = repair;
        EmployeeName = name;
        EmployeeSurname = surname;
        EmployeePatronymic = patronymic;
        WorkCost = cost;
        WorkDescription = description;
        StartDate = sDate;
        EndDate = DateTime.Now;
        Duration = EndDate - StartDate;
    }
    public string GetInfo()
    {
        var repair = "";
        if (Repair == RepairType.Urgent)
        {
            repair = "срочный";
        }
        else if (Repair == RepairType.Regular)
        {
            repair = "обычный";
        }
        else if (Repair == RepairType.Prevention)
        {
            repair = "профилактика";
        }
        return $"Номер заявки: {ServiceNumber}\nНомер вагона: {CarNumber}\nТип ремонта: {repair}\nФИО сотрудника, отвественного за произведение работ: {EmployeeSurname} {EmployeeName} {EmployeePatronymic}\nСтоимость работ: {WorkCost}\nОписание работ: {WorkDescription}\nДата начала работ: {StartDate}\nДата завершения работ: {EndDate}\nПродолжительность работ: {Duration.Days} дней";
    }
}
public abstract class Depot
{
    public string Title;
    public List<Service> WorkList; 
    public Depot(string depotTitle, List<Service> depotWorkList)
    {
        Title = depotTitle;
        WorkList = depotWorkList;
    }
    public abstract string GetInfo();
}
public class CarDepot : Depot
{
    public readonly int Capacity;
    public CarDepot(string depotTitle, List<Service> depotWorkList, int depotCapacity) : base(depotTitle, depotWorkList)
    {
        Capacity = depotCapacity;
    }
    public override string GetInfo()
    {
        string list = "";
        foreach (Service element in WorkList)
        {
            list += $"{element.WorkDescription}\n";
        }
        return $"Название депо: {Title}" +$"\nСписок работ: {list}" + $"Вместимость депо: {Capacity}";
    }
}
public enum LocoType
{
    ElectroLoco,
    WarmLoco
}
public class LocomotiveDepot : Depot
{
    public LocoType Locomotive;
    public LocomotiveDepot(string depotTitle, List<Service> depotWorkList, LocoType locoType) : base(depotTitle, depotWorkList)
    {
        Locomotive = locoType;
    }
    public override string GetInfo()
    {
        var carType = "";
        if(Locomotive == LocoType.ElectroLoco)
        {
            carType = "электровоз";
        }
        else if(Locomotive == LocoType.WarmLoco)
        {
            carType = "тепловоз";
        }
        string list = "";
        foreach (Service element in WorkList)
        {
            list += $"{element}\n";
        }
        return $"Название депо: {Title}" +$"\nСписок работ: {list}" + $"Тип ремонтируемого локомотива: {carType}";
    }
}
