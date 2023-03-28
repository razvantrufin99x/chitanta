using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chitanta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class compania {
            public int codcompania;
            public string denumire;
            public string adresa;
            public string cif;
        }

        
        

        public class produs
        {
            public int codprodus;
            public string denumire;
            public float pret;
            public string um;
            public float cotatva;
            public float valoaretva;
            public float pretcutva;

            public void calculeazaValoareaTVA()
            {
                this.valoaretva = pret * (cotatva / 100);
            }
            public void calculeazaPretulCuTVA()
            {
                this.pretcutva = pret + valoaretva;
            }
            

        }

        public class produsCantitate
        {
            public produs produsul;
            public int cantitatea;
            
            public float pretulPerToataCantitatea = 0.0f;
            public void calculeazaPretulTotalPentruToataCantitatea()
            {
                if (cantitatea == 1) { pretulPerToataCantitatea = produsul.pret; }
                else { pretulPerToataCantitatea = produsul.pret * cantitatea; }
            }
            
            public float valoareaTVAPerToataCantitatea = 0.0f;
            public void calculeazaValoareaTVATotalPentruToataCantitatea()
            {
                if (cantitatea == 1) { valoareaTVAPerToataCantitatea = produsul.valoaretva; }
                else { valoareaTVAPerToataCantitatea = produsul.valoaretva * cantitatea; }
            }
            
            public float valoareaPretcuTVAPerToataCantitatea = 0.0f;
            public void calculeazaValoareaPretcuTVAPerToataCantitatea()
            {

                valoareaPretcuTVAPerToataCantitatea = pretulPerToataCantitatea + valoareaTVAPerToataCantitatea; 
            }
        }

        public class chitanta
        {
            public compania Compania;
            public int numardeproduse = 0;
            public string moneda = "RON";
            public DateTime datasiora;
            public List<produsCantitate> produse = new List<produsCantitate>();
            public float subtotal = 0.0f;
            public float totalTVA = 0.0f;
            public void calculeazaSubtotal()
            {
                float subtotalul=0.0f;
                for(int i = 0 ; i < produse.Count; i++)
                {
                    subtotalul += produse[i].valoareaPretcuTVAPerToataCantitatea;
                    
                }
                subtotal = subtotalul;
            }
            public void calculeazaTVATotal()
            {
                float totalultva = 0.0f;
                for (int i = 0; i < produse.Count; i++)
                {
                    totalultva += produse[i].valoareaTVAPerToataCantitatea;

                }
                totalTVA = totalultva;
            }
            public void adaugaProdusulPeLista(produsCantitate ppc)
            {
                produse.Add(ppc);
            }
            public void printChitanta(ref TextBox t )
            {
                t.Text  = Compania.codcompania.ToString(); t.Text += "\r\n";
                t.Text += Compania.denumire; t.Text += "\r\n";
                t.Text += Compania.adresa; t.Text += "\r\n";
                t.Text += Compania.cif; t.Text += "\r\n";
                t.Text += "\r\n";
                for (int i = 0;i < produse.Count;i++)
                {
                    t.Text += "\r\n";
                    t.Text += this.produse[i].cantitatea.ToString(); 
                    t.Text += this.produse[i].produsul.um;
                    t.Text += " X ";
                    t.Text += this.produse[i].produsul.pretcutva.ToString(); t.Text += "\r\n";
                    t.Text += this.produse[i].produsul.denumire;
                    t.Text += "\r\t";
                    t.Text += this.produse[i].valoareaPretcuTVAPerToataCantitatea.ToString();
                    t.Text += "\r\n";

                }
                t.Text += "\r\n";
                t.Text += "SUBTOTAL";
                t.Text += "\r\t";
                t.Text += this.subtotal.ToString();
                t.Text += "\r\n";

                t.Text += "TOTAL";
                t.Text += "\r\t";
                t.Text += this.subtotal.ToString();
                t.Text += "\r\n";

                t.Text += "TOTAL TVA";
                t.Text += "\r\n";
                t.Text += "TVA  19.0%   " + this.totalTVA.ToString();
                t.Text += "\r\n";
                t.Text += "TVA  9.0%   " + "0.00";
                t.Text += "\r\n";

                t.Text += "TOTAL";
                t.Text += "\r\n";
                t.Text += "CASH      " + "00000.00 RON"; 
                t.Text += "\r\n";

                t.Text += "\r\n";
                t.Text += "REST";
                t.Text += "\r\n";
                t.Text += "CASH      " + "00000.00 RON";
                t.Text += "\r\n";

                t.Text += "Pretul pungii de plastic";
                t.Text += "\r\n";
                t.Text += "contine";
                t.Text += "\r\n";
                t.Text += "ecotaxa de 0.15 Lei.";
                t.Text += "\r\n";
                t.Text += "****";
                t.Text += "\r\n";
                t.Text += "Tel-verde:0800 800 804";
                t.Text += "\r\n";
                t.Text += "Va multumim !";
                t.Text += "\r\n";
                t.Text += "------------------------------------------------------";
                t.Text += "BRAVO";
                t.Text += "\r\n";
                t.Text += "ca esti PROFI";
                t.Text += "\r\n";
                t.Text += "la cumparaturi";
                t.Text += "\r\n";
                t.Text += "Descarca aplicatia profi";
                t.Text += "\r\n";
                t.Text += "-------------------------------------------------";
                t.Text += "\r\n";
                t.Text += "MG:" + "2110";
                t.Text += "CS:" + "0682";
                t.Text += "\r\n";
                t.Text += "PS:" + "1";
                t.Text += "TR:" + "43240";
                t.Text += "\r\n";
                t.Text += "EJIRZ:" + "00000";
                t.Text += "\r\n";
                t.Text += "IDUNIC:" + "00000798872023032422083216011010";
                t.Text += "\r\n";
                t.Text += "BF." + "01010";
                t.Text += "\r\t";
                t.Text += "DATA:" + this.datasiora.ToString();
                t.Text += "\r\n";
                t.Text += "RL   " + "7000079887";
                t.Text += "\r\n";
                t.Text += " B O N   F I S C A L " + "\r\n";
                t.Text += "||||||||||||||||||||||||||||||||||||||||||||||||"; t.Text += "\r\n";
                t.Text += "||||||||||||||||||||||||||||||||||||||||||||||||"; t.Text += "\r\n";
                t.Text += "||||||||||||||||||||||||||||||||||||||||||||||||"; t.Text += "\r\n";
                t.Text += "||||||||||||||||||||||||||||||||||||||||||||||||"; t.Text += "\r\n";
                t.Text += "2    1   1  0  0   1   4   3   2   4   0   0   4";
                t.Text += "\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            compania profi = new compania();
            profi.codcompania = 1;
            profi.denumire = "PROFI ROM FOOD S.R.L.";
            profi.adresa = "JUD. SIBIU, MUN. SIBIU , CARTIERUL STRAND , BLOC 15, AP. 6 ";
            profi.cif = "R011607939";

            produs COCACOLA = new produs();
            COCACOLA.codprodus = 1;
            COCACOLA.denumire = "COCA COLA";
            COCACOLA.pret = 6.37f;
            COCACOLA.um = "Buc";
            //calculatii
            COCACOLA.cotatva = 19.0f;
            COCACOLA.calculeazaValoareaTVA();
            COCACOLA.calculeazaPretulCuTVA();

            produs MULTIVITAMIN2L = new produs();
            MULTIVITAMIN2L.codprodus = 2;
            MULTIVITAMIN2L.denumire = "COSTA MULTIVITAMIN 2L";
            MULTIVITAMIN2L.pret = 5.00f;
            MULTIVITAMIN2L.um = "Buc";
            //calculatii
            MULTIVITAMIN2L.cotatva = 19.0f;
            MULTIVITAMIN2L.calculeazaValoareaTVA();
            MULTIVITAMIN2L.calculeazaPretulCuTVA();



            chitanta chitanta1 = new chitanta();
            chitanta1.Compania =  profi;
            chitanta1.moneda = "RON";
            chitanta1.datasiora = DateTime.Now;


            //adaugare produs si calculatii
            chitanta1.adaugaProdusulPeLista(new produsCantitate());
            chitanta1.numardeproduse++;
            chitanta1.produse[chitanta1.numardeproduse - 1].produsul = COCACOLA;
            chitanta1.produse[chitanta1.numardeproduse - 1].cantitatea = 2;
            chitanta1.produse[chitanta1.numardeproduse - 1].calculeazaPretulTotalPentruToataCantitatea();
            chitanta1.produse[chitanta1.numardeproduse - 1].calculeazaValoareaPretcuTVAPerToataCantitatea();
            chitanta1.produse[chitanta1.numardeproduse - 1].calculeazaValoareaPretcuTVAPerToataCantitatea();


            chitanta1.adaugaProdusulPeLista(new produsCantitate());
            chitanta1.numardeproduse++;
            chitanta1.produse[chitanta1.numardeproduse - 1].produsul = MULTIVITAMIN2L;
            chitanta1.produse[chitanta1.numardeproduse - 1].cantitatea = 1;
            chitanta1.produse[chitanta1.numardeproduse - 1].calculeazaPretulTotalPentruToataCantitatea();
            chitanta1.produse[chitanta1.numardeproduse - 1].calculeazaValoareaPretcuTVAPerToataCantitatea();
            chitanta1.produse[chitanta1.numardeproduse - 1].calculeazaValoareaPretcuTVAPerToataCantitatea();


            //CALCULEAZA CHITANTA
            chitanta1.calculeazaSubtotal();
            chitanta1.calculeazaTVATotal();


            //PRINTEAZA CHITANTA
            chitanta1.printChitanta(ref this.textBox1);

            //ACESTE PROIECT NU INCLUDE ALTE DATE DECI ESTE UN PROIECT EXEMPLU SIMPLIFICAT LA MAXIM



        }
    }
}
