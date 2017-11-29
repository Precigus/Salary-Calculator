using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCounter
{
    class Calcs
    {
        private double salary;
        private double salaryOnPaper;
        protected double npd;
        protected double pnpd;
        private double incomeTax;
        private double healthInsurance;
        private double socInsurance;
        private double employerTax;
        private int children;
        private int parents;
        private double workCost;
        private bool authRightsCheckbox;
        private double authRightsIncome;
        private double authRights;
        private double minSalary;
        private double npdInput;
        private double pnpdInput;
        private double incomeTaxInput;
        private double healthInsuranceInput;
        private double socInsuranceInput;
        private double employerTaxInput;
        private double authRightsTaxInput;


        public Calcs(double salary, int children, int parents, double incomeTaxInput, double npdInput, double pnpdInput, double minSalary,
            double healthInsuranceInput, double socInsuranceInput, double employerTaxInput, bool authRightsCheckbox, 
            double authRightsIncome, double authRightsTaxInput)
        {
            salaryOnPaper = salary;
            SetSalary(salary);
            this.children = children;
            this.parents = parents;
            this.incomeTaxInput = incomeTaxInput;
            this.npdInput = npdInput;
            this.pnpdInput = pnpdInput;
            this.minSalary = minSalary;
            this.healthInsuranceInput = healthInsuranceInput;
            this.socInsuranceInput = socInsuranceInput;
            this.employerTaxInput = employerTaxInput;
            this.authRightsCheckbox = authRightsCheckbox;
            this.authRightsIncome = authRightsIncome;
            this.authRightsTaxInput = authRightsTaxInput;


        }

        public Calcs()
        {
        }

        public void Calculate()
        {
            incomeTax = Math.Round((salary - npd - pnpd) * incomeTaxInput, 2);
            if (incomeTax < 0.0d)
            {
                incomeTax = 0.0d;
            }
            healthInsurance = Math.Round(salary * healthInsuranceInput, 2);
            socInsurance = Math.Round(salary * socInsuranceInput, 2);
            employerTax = Math.Round(salary * employerTaxInput, 2);
            workCost = Math.Round(salary + employerTax, 2);
            CalcAuthRights();
            salary = Math.Round(salary - incomeTax - healthInsurance - socInsurance + authRightsIncome - authRights, 2);
            salaryOnPaper = Math.Round(salaryOnPaper + authRightsIncome - authRights, 2);
        }


        public void CalculateSalary()
        {
            CalcNPD();
            CalcPNPD();
            Calculate();
        }

        public void CalcNPD()
        {
            if (salary <= minSalary)
            {
                npd = Math.Round(npdInput, 2);
                return;
            }
            npd = Math.Round(npdInput - 0.5d * (salary - minSalary), 2);
            if (npd < 0.0d)
            {
                npd = 0.0d;
            }
        }

        public void CalcPNPD()
        {
            pnpd = Math.Round(children * pnpdInput / parents, 2);
        }

        public void CalcAuthRights()
        {
            if (authRightsCheckbox)
            {
                authRights = Math.Round(authRightsIncome * authRightsTaxInput, 2);
            }
            else
            {
                authRightsIncome = 0.0d;
                authRights = 0.0d;
            }
        }


        public void SetSalary(double newSalary)
        {
            salary = newSalary;
        }
        public double GetSalary()
        {
            return salary;
        }

        public void SetSalaryOnPaper(double newSalaryOnPaper)
        {
            salaryOnPaper = newSalaryOnPaper;
        }
        public double GetSalaryOnPaper()
        {
            return salaryOnPaper;
        }

        public void SetNpd(double newNpd)
        {
            npd = newNpd;
        }
        public double GetNpd()
        {
            return npd;
        }

        public void SetPnpd(double newPnpd)
        {
            pnpd = newPnpd;
        }
        public double GetPnpd()
        {
            return pnpd;
        }

        public void SetIncomeTax(double newIncomeTax)
        {
            incomeTax = newIncomeTax;
        }
        public double GetIncomeTax()
        {
            return incomeTax;
        }

        public void SetHealthInsurance(double newHealthInsurance)
        {
            healthInsurance = newHealthInsurance;
        }
        public double GetHealthInsurance()
        {
            return healthInsurance;
        }

        public void SetSocInsurance(double newSocInsurance)
        {
            socInsurance = newSocInsurance;
        }
        public double GetSocInsurance()
        {
            return socInsurance;
        }

        public void SetEmployerTax(double newEmployerTax)
        {
            employerTax = newEmployerTax;
        }
        public double GetEmployerTax()
        {
            return employerTax;
        }

        public void SetChild(int newChildren)
        {
            children = newChildren;
        }
        public int GetChild()
        {
            return children;
        }

        public void SetParents(bool newParents)
        {
            if (children != 0)
            {
                if (newParents)
                {
                    parents = 1;
                }
                else
                {
                    parents = 2;
                }
            }
            else
            {
                parents = 1;
            }
        }
        public int GetParents()
        {
            return parents;
        }

        public double GetWorkCost()
        {
            return workCost;
        }

        public void SetAuthRightsCheckbox(bool check)
        {
            authRightsCheckbox = check;
        }
        public bool GetAuthRightsCheckbox()
        {
            return authRightsCheckbox;
        }

        public void SetAuthRightsIncome(double newIncome)
        {
            authRightsIncome = newIncome;
        }
        public double GetAuthRightsIncome()
        {
            return authRightsIncome;
        }

        public double GetAuthRightsTax()
        {
            return authRights;
        }

        public void SetMinSalary(double newMinSalary)
        {
            minSalary = newMinSalary;
        }
        public double GetMinSalary()
        {
            return minSalary;
        }

        public void SetNpdInput(double newNpdInput)
        {
            npdInput = newNpdInput;
        }
        public double GetNpdInput()
        {
            return npdInput;
        }

        public void SetPnpdInput(double newPnpdInput)
        {
            pnpdInput = newPnpdInput;
        }
        public double GetPnpdInput()
        {
            return pnpdInput;
        }

        public void SetIncomeTaxInput(double newIncomeTax)
        {
            incomeTaxInput = newIncomeTax / 100d;
        }
        public double GetIncomeTaxInput()
        {
            return incomeTaxInput;
        }

        public void SetHealthInsuranceInput(double newHealthInsurance)
        {
            healthInsuranceInput = newHealthInsurance / 100d;
        }
        public double GetHealthInsuranceInput()
        {
            return healthInsuranceInput;
        }

        public void SetSocInsuranceInput(double newSocInsurance)
        {
            socInsuranceInput = newSocInsurance / 100d;
        }
        public double GetSocInsuranceInput()
        {
            return socInsuranceInput;
        }

        public void SetEmployerTaxInput(double newEmployerTax)
        {
            employerTaxInput = newEmployerTax / 100d;
        }
        public double GetEmployerTaxInput()
        {
            return employerTaxInput;
        }

        public void SetAuthRightsTaxInput(double newAuthRightsTax)
        {
            authRightsTaxInput = newAuthRightsTax / 100d;
        }
        public double GetAuthRightsTaxInput()
        {
            return authRightsTaxInput;
        }

    }
}
