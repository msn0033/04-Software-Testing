using Moq;
using SW.Payroll;

namespace SW.PayrollTests
{

    public class SalarySlipProcessorTests
    {
        [Fact]
        public void CalculateBasicSalary_IsNull_return_ArgumentNullException()
        {
            // Given -- Arrange
            Employee employee = null;
            SalarySlipProcessor Salary = new SalarySlipProcessor(null);
            // When  -- Act
            Func<Employee, decimal> func = e => Salary.CalculateBasicSalary(e);

            // Then --Assert
            Assert.Throws<ArgumentNullException>(() => func(employee));
        }
        [Fact]
        public void CalculateBasicSalary_ForEmployeeWageAndWorkingDays_Return_BasicSalary()
        {
            // Given
            Employee employee = new Employee
            {
                Wage = 50,
                WorkingDays = 30
            };
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            // When
            var acual = salarySlipProcessor.CalculateBasicSalary(employee);
            var expected = 1500m;
            // Then
            Assert.Equal(expected, acual);
        }

        //====================================
        [Fact]
        public void CalculateDangerPay_Employee_IsNull_Return_ArgumentNullException()
        {
            // Given
            Employee employee = null;
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
            // When
            Func<Employee, decimal> func = e => salarySlipProcessor.CalculateDangerPay(e);
            // Then
            Assert.Throws<ArgumentNullException>(() => func(employee));

        }
        [Fact]
        public void CalculateDangerPay_Employee_IsDanger_true_Return_DangerPayAmount()
        {
            // Given
            Employee employee = new Employee { IsDanger = true };
            // When
            var salarySlipProcessor = new SalarySlipProcessor(null);
            decimal actual = salarySlipProcessor.CalculateDangerPay(employee);
            decimal expected = Constants.DangerPayAmount;
            // Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDangerPay_Employee_IsDangerOffAndInDangerZone_Return_DangerPayAmount()
        {
            //Given
            Employee employee = new Employee { IsDanger = false, DutyStation = "Ukrania" };
            var mock = new Mock<IZoneService>();
            var setup = mock.Setup(z => z.IsDangerZone(employee.DutyStation)).Returns(true);



            //When
            var salarySlipProcessor = new SalarySlipProcessor(mock.Object);
            decimal actual = salarySlipProcessor.CalculateDangerPay(employee);
            decimal expected = Constants.DangerPayAmount;

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDangerPay_Employee_IsDangerOffAndNotInDangerZone_Return_Zero()
        {
            //Given
            Employee employee = new Employee { IsDanger = false, DutyStation = "Ukrania" };
            var mock = new Mock<IZoneService>();
            var setup = mock.Setup(z => z.IsDangerZone(employee.DutyStation)).Returns(false);



            //When
            var salarySlipProcessor = new SalarySlipProcessor(mock.Object);
            decimal actual = salarySlipProcessor.CalculateDangerPay(employee);
            decimal expected = 0m;

            //Then
            Assert.Equal(expected, actual);
        }


        /*
         public decimal CalculateDangerPay(Employee employee)
        {
            var isDangerZone = zoneService.IsDangerZone(employee.DutyStation);

            if (isDangerZone)
                return Constants.DangerPayAmount;

            return 0m;
        }

        */

    }
}