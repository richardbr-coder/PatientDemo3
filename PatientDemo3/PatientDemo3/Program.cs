using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDemo2.cs
{
    class Program

    {

        static void Main(string[] args)

        {

            InsuranceCompany[] insuredPatientArr = new InsuranceCompany[5];

            double totalAmtDue = 0;
            double percent_paid;
            string insur_campany = "";

            if (insuredPatientArr.Equals("Wrightstown Mutual"))
            { percent_paid = 80.0;
                insur_campany = "Wrightstown Mutual";
            }
            else if (insuredPatientArr.Equals("Red Umbrella"))
            { percent_paid = 60.0;
              insur_campany = "Red Umbrella";
            }
            else
                percent_paid = 25.0;

            

            for (int i = 0; i < 5; i++)
            {

                insuredPatientArr[i] = new InsuranceCompany(insur_campany, percent_paid);

                WriteLine("Enter Patient Id");
                insuredPatientArr[i].IdNumb = Convert.ToInt32(ReadLine());

                WriteLine("Enter Patient Name");
                insuredPatientArr[i].Name = ReadLine();

                WriteLine("Enter Patient Age");
                insuredPatientArr[i].Age = Convert.ToInt32(ReadLine());

                WriteLine("Enter Amount Due");
                insuredPatientArr[i].AmountDue = Convert.ToDouble(ReadLine());

                WriteLine("Enter Company Name");
                insuredPatientArr[i].insurance_Company_Name = ReadLine();

                totalAmtDue += insuredPatientArr[i].AmountDue;

            }
            //Sort insured patients
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (insuredPatientArr[x].IdNumb < insuredPatientArr[y].IdNumb)
                    {
                        InsuranceCompany temp = insuredPatientArr[y];
                        insuredPatientArr[y] = insuredPatientArr[x];
                        insuredPatientArr[x] = temp;
                    }
                }
            }

            //display
            for (int i = 0; i < 5; i++)
            {
                WriteLine(insuredPatientArr[i].ToString());
            }
            WriteLine("Total Due Amount:{0}", totalAmtDue);
            ReadLine();
        }
    }

    class Patient
    {
        private int idNumb;
        private string name;
        private int age;
        private double amountDue;

        public int IdNumb { get { return idNumb; } set { idNumb = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public double AmountDue { get { return amountDue; } set { amountDue = value; } }//this is the amount due to the hospital

        
    }
    class InsuranceCompany : Patient
    {
        
        public string insurance_Company_Name;
        public double percent_paid;

        public InsuranceCompany(string iCN, double pP)
        {
            insurance_Company_Name = iCN;
            percent_paid = pP;
        }

        public override string ToString()
        {
            return "\n\nPatient ID: " + IdNumb + " \n Patient Name: " + Name + " \n Age: " + Age + " \n Insurance Company Name: " + insurance_Company_Name +
                "\n Percentage Paid: " + percent_paid + "\n amount due after insurance: " + (AmountDue * ((100 - percent_paid) / 100.0));
        }
    }
}