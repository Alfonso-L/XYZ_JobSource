using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XYZ_JobSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Visible = false;
            textBox6.Visible = false;
            textBox5.Visible = false;
            textBox4.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;

            label9.Visible = false;
            textBox8.Visible = false;

            textBox1.Text = "";
            textBox2.Text = "0";
            textBox3.Text = "0";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox7.Visible = false;
            textBox6.Visible = false;
            textBox5.Visible = false;
            textBox4.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            textBox8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Visible = true;
            textBox6.Visible = true;
            textBox5.Visible = true;
            textBox4.Visible = true;
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            label9.Visible = true;
            textBox8.Visible = true;
            string fullName = textBox1.Text;
            string[] words = fullName.Split(' ');
            string fname = words[0];
            string lname = words[1];
            int hworked = Convert.ToInt16(textBox2.Text);
            int depen = Convert.ToInt16(textBox3.Text);

            Employee em = new Employee(fname, lname, depen, hworked);//change
             textBox4.Text = Convert.ToString( em.DetermineGross().ToString("C"));
            textBox5.Text = Convert.ToString(em.DetermineAgencyFee().ToString("C"));
            textBox6.Text = Convert.ToString(em.DetermineSocialSecurity().ToString("C"));
            textBox8.Text = Convert.ToString(em.DetermineFederalTax().ToString("C"));
            textBox7.Text = Convert.ToString(em.DetermineNet().ToString("C"));
        }


    }

    class Employee
    {
        private string employeeFirstName;
        private string employeeLastName;
        private int noOfDependents;
        private double noOfHours;

        //Default constructor	
        public Employee()
        {

        }

        public Employee(string first, string last,
                          int dep, double hours)
        {
            employeeFirstName = first;
            employeeLastName = last;
            noOfDependents = dep;
            noOfHours = hours;
        }

        public Employee(string first, string last)
        {
            employeeFirstName = first;
            employeeLastName = last;
        }

        public Employee(string first, string last,
                          int dep)
        {
            employeeFirstName = first;
            employeeLastName = last;
            noOfDependents = dep;
        }

        //Property used to access or change Employee First Name
        public string EmployeeFirstName
        {
            set
            {
                employeeFirstName = value;
            }
            get
            {
                return employeeFirstName;
            }
        }

        //Property used to access or change Employee Last Name
        public string EmployeeLastName
        {
            set
            {
                employeeLastName = value;
            }
            get
            {
                return employeeLastName;
            }
        }

        //Property used to access number of dependents
        public int NoOfDependents
        {
            set
            {
                noOfDependents = value;
            }
            get
            {
                return noOfDependents;
            }
        }

        //Property used to access or change hours worked
        public double NoOfHours
        {
            set
            {
                noOfHours = value;
            }
            get
            {
                return noOfHours;
            }
        }

        //Using the same constant value for a flat hourly rate, 
        //calculate gross pay prior to any deductions
        public double DetermineGross()
        {
            const double RATE = 150.00;
            return noOfHours * RATE;
        }

        //Using the same constant value for the Commission Rate
        //for all employees, calculate commission due employee
        public double DetermineAgencyFee()
        {
            const double AGENCY_CHARGE = 0.13;
            return DetermineGross() * AGENCY_CHARGE;
        }

        //Calculate federal tax due
        public double DetermineFederalTax()
        {
            const double FEDERAL_TAX = 0.25;
            const double DEPENDENT_ALLOWANCE = 0.0575;
            double gross;
            gross = DetermineGross();
            return (gross - (gross *
                (DEPENDENT_ALLOWANCE * noOfDependents))) * FEDERAL_TAX;
        }

        //Calculate Social Security taxes
        public double DetermineSocialSecurity()
        {
            const double SOCIAL_SECURITY_RATE = 0.0785;
            return DetermineGross() * SOCIAL_SECURITY_RATE;
        }

        public double DetermineNet()
        {
            return DetermineGross() - DetermineSocialSecurity() -
               DetermineFederalTax() - DetermineAgencyFee();
        }

        public override string ToString()
        {
            return employeeFirstName + " " + employeeLastName +
                "\nTake Home Pay: " + DetermineNet().ToString("C");
        }
    }
}
