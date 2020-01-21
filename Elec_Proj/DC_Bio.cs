using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elec_Proj
{    
    class DC_Bio
    {
        private decimal Beta { get; set; }

        private decimal _V_Sat;
        public decimal V_Sat
        {
            get { return _V_Sat; }
            set {
                if (value == 0)
                    _V_Sat = 0.2m;
                else
                    _V_Sat = value;
            }
        }

        private int Circuit_Number { get; set; }
        private bool Je { get; set; }
        public decimal Ie { get; set; }
        public decimal Ib { get; set; }
        public decimal Ic { get; set; }
        private decimal R_C { get; set; }
        public decimal R_B { get; set; }
        private decimal R_B1 { get; set; }
        private decimal R_B2 { get; set; }
        private decimal R_E { get; set; }
        public decimal V_BB { get; set; }
        public decimal V_EE { get; set; }
        private decimal V_CC { get; set; }

        private decimal _V_BE;
        public decimal V_BE
        {
            get { return _V_BE; }
            set {
                if (value == 0)
                    _V_BE = 0.7m;
                else
                    _V_BE = value;
            }
        }
        private decimal V_CE { get; set; }
        public DC_Bio(bool jE, int circuit_number, decimal beta, decimal vsat = 0)
        {
            this.Beta = beta;
            this.Circuit_Number = circuit_number;
            this.Je = jE;
            this.V_Sat = vsat;
        }
        public void DC_Initial(decimal rc = 0, decimal rb = 0, decimal vbb = 0, decimal vcc = 0, decimal re = 0, decimal rb1 = 0, decimal rb2 = 0,decimal vee = 0)
        {
            this.R_C = rc;
            if(rb1 != 0 && rb2 != 0)
            {                
                this.R_B1 = rb1;
                this.R_B2 = rb2;
                this.R_B = (this.R_B1 * this.R_B2) / (this.R_B1 + this.R_B2);
                this.V_BB = (this.R_B2/(this.R_B1 + this.R_B2)) * vbb;
            }
            else
            {
                this.R_B = rb;
                this.V_BB = vbb;
            }            
            this.R_E = re;            
            this.V_CC = vcc;
            this.V_EE = vee;
        }
        public decimal CalCulate_VCE()
        {
            if (Je)
            {
                this.Ib = this.Cal_Ib();
                this.Ic = this.Cal_Ic();
                this.Ie = this.Cal_Ie();
                this.V_CE = Cal_Vce();
                return V_CE;
            }
            else
                return 0m;
        }        
        private decimal Cal_Ic()
        {
            return Beta * Ib;
        }
        private decimal Cal_Ie()
        {
            return (Beta + 1) * Ib;
        }
        private decimal Cal_Ib()
        {
            switch (Circuit_Number)
            {
                case 1:
                    return (this.V_BB - this.V_BE) / this.R_B;
                case 2:
                    return (this.V_BB - this.V_BE) / (this.R_B + (this.Beta + 1) * this.R_E);
                case 3:
                    return (this.V_CC - this.V_BE) / (this.R_B + (this.Beta + 1) * this.R_C);
                case 4:
                    return (this.V_CC - this.V_BE) / (this.R_B + (this.Beta + 1) * this.R_E);
                case 5:
                    return (this.V_BB - this.V_BE) / (this.R_B + (this.Beta + 1) * this.R_E);
                case 6:
                    return ((this.V_EE - this.V_BE) / (((1 / this.Beta) * this.R_B) + (((this.Beta + 1) / this.Beta) * this.R_E))) / this.Beta;
                case 7:
                    return (this.V_BB - this.V_BE) / (this.R_B + (this.Beta + 1) * (this.R_E + this.R_C));
                default:
                    return 0m;
            }
        }        
        private decimal Cal_Vce()
        {
            switch (Circuit_Number)
            {
                case 1:
                    return this.V_CC - (this.Ic * this.R_C);
                case 2:
                    return this.V_CC - (this.Ic * (this.R_C + ((this.Beta + 1) / this.Beta) * this.R_E));
                case 3:
                    return this.V_CC - ((this.Beta / (this.Beta + 1)) * (this.Ic * this.R_C));
                case 4:
                    return this.V_CC - (this.Ic * (this.R_C + ((this.Beta + 1) / this.Beta) * this.R_E ));
                case 5:
                    return this.V_CC - (this.Ic * (this.R_C + ((this.Beta + 1) / this.Beta) * this.R_E));
                case 6:
                    return this.V_CC + this.V_BE - (this.Ic * (this.R_C - (this.R_B / this.Beta))) ;
                case 7:
                    return this.V_CC - (this.Ic * ((this.Beta + 1) / this.Beta) * (this.R_C + this.R_E));
                default:
                    return 0m;
            }
        }
        public int IsActive(decimal Vce)
        {
            if (Je)
            {
                if (Vce > this.V_Sat)
                {
                    return 2;
                }
                return 1;
            }
            else
                return 0;
        }
        public string IsActive_Message(decimal Vce)
        {
            switch (this.IsActive(V_CE))
            {
                case 0:
                    return "It is Disable!";
                case 1:
                    return "It is Saturate!";
                case 2:
                    return "It is Active!";
            }
            return "Error";
        }

    }
}
