using System;
using System.Collections;

namespace RWMaintenance;
public enum RepairType
{
    Urgent,
    Regular,
    Prevention
}
public class Service: IComparable<Service>
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
    public int CompareTo(Service other)
    {
        if(StartDate != other.StartDate)
            return StartDate.CompareTo(other.StartDate);
        else
            return WorkDescription.CompareTo(other.WorkDescription);
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
public class CarNumberComparer: IComparer<Service>
{
    public int Compare(Service one, Service two)
    {
        return (int)two.CarNumber - (int)one.CarNumber;
    }
}
public abstract class Depot: IEnumerable<Service>
{
    public string Title;
    public List<Service> WorkList; 
    public Depot(string depotTitle, IEnumerable<Service> depotWorkList)
    {
        Title = depotTitle;
        WorkList =new List<Service>(depotWorkList.Distinct());
        WorkList.Sort();
    }
    public IEnumerator<Service> GetEnumerator() => WorkList.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public abstract string GetInfo();
}
public class CarDepot : Depot
{
    public readonly int Capacity;
    public readonly int CarCount; //readonly не позволяет изменять количетво работ не создавая депо заново
    public CarDepot(string depotTitle, List<Service> depotWorkList, int depotCapacity) : base(depotTitle, depotWorkList)
    {
        Capacity = depotCapacity;
        CarCount = WorkList.Count; 
    }
    public override string GetInfo()
    {
        string list = "";
        foreach (Service element in WorkList)
        {
            list += $"{element.WorkDescription}\n";
        }
        return $"Название депо: {Title}\nСписок работ: {list}Вместимость депо: {Capacity}\nКоличество вагонов на ремонте: {CarCount}";
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
            list += $"{element.WorkDescription}\n";
        }
        return $"Название депо: {Title}" +$"\nСписок работ: {list}" + $"Тип ремонтируемого локомотива: {carType}";
    }
}
