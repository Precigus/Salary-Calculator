using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SalaryCounter
{
    public partial class Skaiciuokle : Form
    {
        public Skaiciuokle()
        {
            InitializeComponent();
        }

        private bool Ready = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("values.txt");
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string control = line.Substring(0, line.IndexOf(':'));
                string val = line.Substring(line.IndexOf(':') + 1);

                if (Controls[control] != null)
                {
                    ((MaskedTextBox)Controls[control]).Text = val;
                }
            }
            sr.Close();
            Ready = true;
        }

        public bool IsReady()
        {
            return Ready;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TextWriter sw = new StreamWriter("values.txt");
            foreach (var control in Controls)
            {
                if (control is MaskedTextBox)
                {
                    MaskedTextBox txt = (MaskedTextBox)control;
                    sw.WriteLine(txt.Name + ":" + txt.Text);
                }
            }
            sw.Close();
        }


        private void PaperSalary()
        {
            double.TryParse(txt1PaperSalary.Text, out double salary);
            double.TryParse(mtxtMinSalary.Text, out double minSalary);
            double.TryParse(mtxtIncomeTaxInput.Text, out double incTaxInput);
            double.TryParse(mtxtNpdInput.Text, out double npdInput);
            double.TryParse(mtxtPnpdInput.Text, out double pnpdInput);
            double.TryParse(mtxtHealthInsInput.Text, out double healthInsInput);
            double.TryParse(mtxtSocInsInput.Text, out double socInsInput);
            double.TryParse(mtxtEmployerTaxInput.Text, out double employerTaxInput);
            double.TryParse(mtxtAuthRightsInput.Text, out double authRightsInput);
            int.TryParse(cbox1ChildCount.Text, out int childCount);
            double.TryParse(mtxt1AuthRightsIncome.Text, out double authRights);

            Calcs calc = new Calcs();

            calc.SetSalary(salary);
            calc.SetMinSalary(minSalary);
            calc.SetIncomeTaxInput(incTaxInput);
            calc.SetNpdInput(npdInput);
            calc.SetPnpdInput(pnpdInput);
            calc.SetHealthInsuranceInput(healthInsInput);
            calc.SetSocInsuranceInput(socInsInput);
            calc.SetEmployerTaxInput(employerTaxInput);
            calc.SetAuthRightsTaxInput(authRightsInput);
            calc.SetChild(childCount);
            calc.SetParents(rbtn1OneParent.Checked);
            calc.SetAuthRightsCheckbox(chk1AuthRightsIncome.Checked);
            calc.SetAuthRightsIncome(authRights);

            calc.CalculateSalary();

            mtxt1Npd.Text = calc.GetNpd().ToString("N2");
            mtxt1Pnpd.Text = calc.GetPnpd().ToString("N2");
            mtxt1IncomeTax.Text = calc.GetIncomeTax().ToString("N2");
            mtxt1HealthInsurance.Text = calc.GetHealthInsurance().ToString("N2");
            mtxt1SocInsurance.Text = calc.GetSocInsurance().ToString("N2");
            mtxt1EmployerTax.Text = calc.GetEmployerTax().ToString("N2");
            mtxt1WorkCost.Text = calc.GetWorkCost().ToString("N2");
            if (chk1AuthRightsIncome.Checked)
            {
                mtxt1AuthRightsIncomeTax.Text = calc.GetAuthRightsTax().ToString("N2");
            }
            mtxt1InHandSalary.Text = calc.GetSalary().ToString("N2");
        }


        private void HandSalary()
        {

            Calcs calc = new Calcs();


            double.TryParse(txt2HandSalary.Text, out double salary);
            double.TryParse(mtxtMinSalary.Text, out double minSalary);
            double.TryParse(mtxtIncomeTaxInput.Text, out double incTaxInput);
            double.TryParse(mtxtNpdInput.Text, out double npdInput);
            double.TryParse(mtxtPnpdInput.Text, out double pnpdInput);
            double.TryParse(mtxtHealthInsInput.Text, out double healthInsInput);
            double.TryParse(mtxtSocInsInput.Text, out double socInsInput);
            double.TryParse(mtxtEmployerTaxInput.Text, out double employerTaxInput);
            double.TryParse(mtxtAuthRightsInput.Text, out double authRightsInput);
            int.TryParse(cbox2ChildCount.Text, out int childCount);
            double.TryParse(mtxt2AuthRightsIncome.Text, out double authRights);


            calc.SetSalary(salary);
            calc.SetMinSalary(minSalary);
            calc.SetIncomeTaxInput(incTaxInput);
            calc.SetNpdInput(npdInput);
            calc.SetPnpdInput(pnpdInput);
            calc.SetHealthInsuranceInput(healthInsInput);
            calc.SetSocInsuranceInput(socInsInput);
            calc.SetEmployerTaxInput(employerTaxInput);
            calc.SetAuthRightsTaxInput(authRightsInput);
            calc.SetChild(childCount);
            calc.SetParents(rbtn2OneParent.Checked);
            calc.SetAuthRightsCheckbox(chk2AuthRightsIncome.Checked);
            calc.SetAuthRightsIncome(authRights);


            Calcs handSalary = new CalcsHand(calc.GetSalary(), calc.GetChild(), calc.GetParents(), calc.GetIncomeTaxInput(), calc.GetNpdInput(),
                    calc.GetPnpdInput(), calc.GetMinSalary(), calc.GetHealthInsuranceInput(), calc.GetSocInsuranceInput(),
                    calc.GetEmployerTaxInput(), calc.GetAuthRightsCheckbox(), calc.GetAuthRightsIncome(), calc.GetAuthRightsTaxInput());

            handSalary.CalculateSalary();

            mtxt2Npd.Text = handSalary.GetNpd().ToString("N2");
            mtxt2Pnpd.Text = handSalary.GetPnpd().ToString("N2");
            mtxt2IncomeTax.Text = handSalary.GetIncomeTax().ToString("N2");
            mtxt2HealthInsurance.Text = handSalary.GetHealthInsurance().ToString("N2");
            mtxt2SocInsurance.Text = handSalary.GetSocInsurance().ToString("N2");
            mtxt2EmployerTax.Text = handSalary.GetEmployerTax().ToString("N2");
            mtxt2WorkCost.Text = handSalary.GetWorkCost().ToString("N2");
            if (chk2AuthRightsIncome.Checked)
            {
                mtxt2AuthRightsIncomeTax.Text = handSalary.GetAuthRightsTax().ToString("N2");
            }
            mtxt2PaperSalary.Text = handSalary.GetSalaryOnPaper().ToString("N2");
        }


        private void txtPaperSalary_TextChanged(object sender, EventArgs e)
        {

            if (IsReady())
            {
                PaperSalary();
            }
        }


        private void chkAuthRightsIncome_CheckedChanged(object sender, EventArgs e)
        {

            mtxt1AuthRightsIncome.Visible = chk1AuthRightsIncome.Checked;
            mtxt1AuthRightsIncome.ResetText();
            label1AuthRightsIncomeTax.Visible = chk1AuthRightsIncome.Checked;
            mtxt1AuthRightsIncomeTax.Visible = chk1AuthRightsIncome.Checked;
            mtxt1AuthRightsIncomeTax.ResetText();

        }



        private void cboxChildCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1ParentCount.Visible = rbtn1OneParent.Visible = rbtn1BothParents.Visible = rbtn1OneParent.Checked =
                cbox1ChildCount.Text != "0";

            if (IsReady())
            {
                PaperSalary();
            }
        }

        private void rbtnOneParent_CheckedChanged(object sender, EventArgs e)
        {
            if (IsReady())
            {
                PaperSalary();
            }
        }

        private void mtxtAuthRightsIncome_TextChanged(object sender, EventArgs e)
        {
            if (IsReady())
            {
                PaperSalary();
            }
        }

        private void mtxtMinSalary_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtNpdInput_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtPnpdInput_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtIncomeTaxInput_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtHealthInsInput_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtSocInsInput_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtEmployerTaxInput_TextChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab.Name == "tabPage1" && IsReady())
            {
                PaperSalary();
            }
            else
            {
                HandSalary();
            }
        }

        private void mtxtAuthRightsInput_TextChanged(object sender, EventArgs e)
        {
            if (IsReady())
            {
                PaperSalary();
            }
        }

        private void chk2AuthRightsIncome_CheckedChanged(object sender, EventArgs e)
        {
            mtxt2AuthRightsIncome.Visible = chk2AuthRightsIncome.Checked;
            mtxt2AuthRightsIncome.ResetText();
            label2AuthRightsIncomeTax.Visible = chk2AuthRightsIncome.Checked;
            mtxt2AuthRightsIncomeTax.Visible = chk2AuthRightsIncome.Checked;
            mtxt2AuthRightsIncomeTax.ResetText();
        }

        private void cbox2ChildCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2ParentCount.Visible = rbtn2OneParent.Visible = rbtn2BothParents.Visible = rbtn2OneParent.Checked =
                cbox2ChildCount.Text != "0";

            if (IsReady())
            {
                HandSalary();
            }
        }

        private void rbtn2OneParent_CheckedChanged(object sender, EventArgs e)
        {
            if (IsReady())
            {
                HandSalary();
            }
        }

        private void mtxt2AuthRightsIncome_TextChanged(object sender, EventArgs e)
        {
            if (IsReady())
            {
                HandSalary();
            }
        }

        private void txt2HandSalary_TextChanged(object sender, EventArgs e)
        {
            if (IsReady())
            {
                HandSalary();
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt1PaperSalary.ResetText();
            txt2HandSalary.ResetText();
            cbox1ChildCount.Text = "0";
            cbox2ChildCount.Text = "0";
            chk1AuthRightsIncome.Checked = false;
            chk2AuthRightsIncome.Checked = false;

        }
    }
}
