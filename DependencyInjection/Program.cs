using System;

namespace DependencyInjection
{
    //Violation:

    //public class SalaryCalculator
    //{
    //    public float CalculateSalary(int hoursWorked, float hourlyRate)
    //        => hoursWorked * hourlyRate;
    //}

    //public class EmployeeDetails
    //{
    //    public int HoursWorked { get; set; }
    //    public int HourlyRate { get; set; }
    //    public float GetSalary()
    //    {
    //        var salaryCalculator = new SalaryCalculator();
    //        return salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
    //    }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeDetailsModified = new EmployeeDetailsModified(new SalaryCalculatorModified());
            var employeeDetailsModified2 = new EmployeeDetailsModified(new SalaryCalculatorModified2());

            employeeDetailsModified.HourlyRate = 100;
            employeeDetailsModified.HoursWorked = 100;
            employeeDetailsModified2.HourlyRate = 100;
            employeeDetailsModified2.HoursWorked = 100;
            Console.WriteLine($"The Total Pay is {employeeDetailsModified.GetSalary()}");
            Console.WriteLine($"The Total Pay is {employeeDetailsModified2.GetSalary()}");
        }
    }

    public interface ISalaryCalculator
    {
        float CalculateSalary(int hoursWorked, float hourlyRate);
    }

    public class SalaryCalculatorModified : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }

    public class SalaryCalculatorModified2 : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate *10;
    }

    public class EmployeeDetailsModified
    {
        private readonly ISalaryCalculator _salaryCalculator;
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public EmployeeDetailsModified(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }
        public float GetSalary()
        {
            return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }
    }
}
