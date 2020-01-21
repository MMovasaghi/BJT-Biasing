using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elec_Proj
{
    class Program
    {
        private static string version = "1.1";
        static void Main(string[] args)
        {
            Console.WriteLine("BJT DC Biasing [Version {0}]\n" +
                "2020 Shahed University.\n" +
                "(c) MH.Movasaghinia\n" +
                "---------------------------------------------------------\n", Program.version);

            Console.Write("Select the Circuit num. [Check the documentation] :\n" +
                "1. Figure 1.1\n" +
                "2. Figure 1.2\n" +
                "3. Figure 1.3\n" +
                "4. Figure 1.4\n" +
                "5. Figure 1.5\n" +
                "6. Figure 1.6\n" +
                "7. Figure 1.7\n\n" +
                ">>> Choise : ");
            int circuit_num = Int32.Parse(Console.ReadLine());

            Console.WriteLine("---------------------------------------------------------\n" +
                              "     ********************************************        \n" +
                              "     ####      Figure 1.{0} is Selected        ####        \n" +
                              "     ********************************************        \n", circuit_num);

            

            Console.Write("Beta = ");
            decimal Beta = decimal.Parse(Console.ReadLine());

            Console.Write("V[Sat](Press 0 for default = 0.2) = ");
            decimal V_Sat = decimal.Parse(Console.ReadLine());

            //create Object
            DC_Bio dc = new DC_Bio(true, circuit_num, Beta, V_Sat);

            Console.Write("V[BE](Press 0 for default = 0.7) = ");
            dc.V_BE = decimal.Parse(Console.ReadLine());           

            Console.Write("R[C] = ");
            decimal R_C = decimal.Parse(Console.ReadLine());

            if (circuit_num == 1)
            {
                Console.Write("R[B] = ");
                decimal R_B = decimal.Parse(Console.ReadLine());

                Console.Write("V[BB] = ");
                decimal V_BB = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, R_B, V_BB, V_CC);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                 ">>> I[C] = {0}\n" +
                                 ">>> I[B] = {1}\n" +
                                 ">>> V[CE] = {2}\n" +
                                 ">>> {3}", dc.Ic, dc.Ib, V_CE, dc.IsActive_Message(V_CE));
            }
            else if (circuit_num == 2)
            {
                Console.Write("R[B] = ");
                decimal R_B = decimal.Parse(Console.ReadLine());

                Console.Write("R[E] = ");
                decimal R_E = decimal.Parse(Console.ReadLine());

                Console.Write("V[BB] = ");
                decimal V_BB = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, R_B, V_BB, V_CC, R_E);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                  ">>> I[C] = {0}\n" +
                                  ">>> I[B] = {1}\n" +
                                  ">>> I[E] = {2}\n" +
                                  ">>> V[CE] = {3}\n" +
                                  ">>> {4}", dc.Ic, dc.Ib, dc.Ie, V_CE, dc.IsActive_Message(V_CE));
            }
            else if (circuit_num == 3)
            {
                Console.Write("R[B] = ");
                decimal R_B = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, R_B, 0, V_CC);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                  ">>> V[BB] = {0}\n" + 
                                  ">>> I[C] = {1}\n" +
                                  ">>> I[B] = {2}\n" +
                                  ">>> V[CE] = {3}\n" +
                                  ">>> {4}", dc.V_BB, dc.Ic, dc.Ib, V_CE, dc.IsActive_Message(V_CE));
            }
            else if (circuit_num == 4)
            {
                Console.Write("R[B] = ");
                decimal R_B = decimal.Parse(Console.ReadLine());

                Console.Write("R[E] = ");
                decimal R_E = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, R_B, 0, V_CC, R_E);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                  ">>> V[BB] = {0}\n" +
                                  ">>> I[C] = {1}\n" +
                                  ">>> I[B] = {2}\n" +
                                  ">>> I[E] = {3}\n" +
                                  ">>> V[CE] = {4}\n" +
                                  ">>> {5}", dc.V_BB, dc.Ic, dc.Ib, dc.Ie, V_CE, dc.IsActive_Message(V_CE));
            }
            else if (circuit_num == 5)
            {
                Console.Write("R[B1] = ");
                decimal R_B1 = decimal.Parse(Console.ReadLine());

                Console.Write("R[B2] = ");
                decimal R_B2 = decimal.Parse(Console.ReadLine());

                Console.Write("R[E] = ");
                decimal R_E = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, 0, 0, V_CC, R_E, R_B1, R_B2);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                  ">>> V[th] = {0}\n" +
                                  ">>> R[th] = {1}\n" +
                                  ">>> I[C] = {2}\n" +
                                  ">>> I[B] = {3}\n" +
                                  ">>> I[E] = {4}\n" +
                                  ">>> V[CE] = {5}\n" +
                                  ">>> {6}", dc.V_BB, dc.R_B, dc.Ic, dc.Ib, dc.Ie, V_CE, dc.IsActive_Message(V_CE));
            }
            else if (circuit_num == 6)
            {
                Console.Write("R[B] = ");
                decimal R_B = decimal.Parse(Console.ReadLine());

                Console.Write("R[E] = ");
                decimal R_E = decimal.Parse(Console.ReadLine());

                Console.Write("V[EE] = ");
                decimal V_EE = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, R_B, 0, V_CC, R_E, 0, 0, V_EE);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                  ">>> V[BB] = {0}\n" +
                                  ">>> V[EE] = {1}\n" +
                                  ">>> I[C] = {2}\n" +
                                  ">>> I[B] = {3}\n" +
                                  ">>> I[E] = {4}\n" +
                                  ">>> V[CE] = {5}\n" +
                                  ">>> {6}", dc.V_BB, dc.V_EE, dc.Ic, dc.Ib, dc.Ie, V_CE, dc.IsActive_Message(V_CE));
            }
            else if (circuit_num == 7)
            {
                Console.Write("R[B] = ");
                decimal R_B = decimal.Parse(Console.ReadLine());

                Console.Write("R[E] = ");
                decimal R_E = decimal.Parse(Console.ReadLine());

                Console.Write("V[CC] = ");
                decimal V_CC = decimal.Parse(Console.ReadLine());

                dc.DC_Initial(R_C, R_B, 0, V_CC, R_E);

                decimal V_CE = dc.CalCulate_VCE();

                Console.WriteLine("-----------------------------------");

                Console.WriteLine("## Result:\n" +
                                  ">>> V[BB] = {0}\n" +
                                  ">>> I[C] = {1}\n" +
                                  ">>> I[B] = {2}\n" +
                                  ">>> I[E] = {3}\n" +
                                  ">>> V[CE] = {4}\n" +
                                  ">>> {5}", dc.V_BB, dc.Ic, dc.Ib, dc.Ie, V_CE, dc.IsActive_Message(V_CE));
            }

        }
    }
}
