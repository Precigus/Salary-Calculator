using SalaryCounter;
using System;

class CalcsHand : Calcs
{
    public CalcsHand(double salary, int children, int parents, double incomeTaxInput, double npdInput, double pnpdInput, double minSalary,
            double healthInsuranceInput, double socInsuranceInput, double employerTaxInput, bool authRightsCheckbox,
            double authRightsIncome, double authRightsTaxInput)
        : base(salary, children, parents, incomeTaxInput, npdInput, pnpdInput, minSalary, healthInsuranceInput, socInsuranceInput,
            employerTaxInput, authRightsCheckbox, authRightsIncome, authRightsTaxInput)
    {
        CalcPNPD();

        double salaryOnPaper = Math.Round((salary - incomeTaxInput * (npdInput + 0.5d * minSalary + pnpd)) /
            (1d - 1.5d * incomeTaxInput - healthInsuranceInput - socInsuranceInput), 2);
        double x = npdInput - (0.5d * (salaryOnPaper - minSalary));
        if ( x < 0.0d)
        {
            salaryOnPaper = Math.Round(((salary - incomeTaxInput * pnpd) /
                (1d - incomeTaxInput - healthInsuranceInput - socInsuranceInput)), 2);
        }
        if (salaryOnPaper <= (x + pnpd))
        {
            if ((npdInput + pnpd) > salaryOnPaper)
            {
                salaryOnPaper = Math.Round(salary / (1 - healthInsuranceInput - socInsuranceInput), 2);
            }
            else
            {
                salaryOnPaper = Math.Round((salary - incomeTaxInput * (salary - (npdInput - 0.5 * (salary - minSalary)) - pnpd) - 
                    salary * healthInsuranceInput - salary * socInsuranceInput), 2) ;
            }
        }

        SetSalary(salaryOnPaper);
        SetSalaryOnPaper(salaryOnPaper);
    }

}

