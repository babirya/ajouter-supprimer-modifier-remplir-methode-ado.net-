using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace devtech3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //  1>>> declare  class ado  to  use it here 
        ado d = new ado();  

        // 2 >>> declaration de la methode nombre here 

        public int  number()
        {
            int cpt;
            d.cmd.CommandText = "select count (matricule) from stag where matricule="+textBox1.Text+"";
            d.cmd.Connection = d.con;
              cpt=(int)d.cmd.ExecuteScalar();
              return cpt;
        } 

        // 3>>>  declare  methode pour remlir datagrid view 
        public void remplir()
        { 
            // this pour eviter probleme de repetition des donnes 
             if(d.dt.Rows!=null)
             {
                 d.dt.Clear(); 
             }
            d.connecter();
            d.cmd.CommandText = "select * from stag ";
            d.cmd.Connection = d.con;
            d.rd = d.cmd.ExecuteReader();
            d.dt.Load(d.rd);
            dataGridView1.DataSource = d.dt;
            d.rd.Close();
        }
        // 4 >>> declaration de la methode ajouter  
        public bool ajouter()
        {
            if(number()==0)
            {
                d.cmd.CommandText = "insert into stag values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "' )";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();

                return true; 
            }
            return false;
        } 

        // 5>>> declaration de la methode suprimer 

        public bool suprimer()
        {
            if (number() != 0)
            {
                d.cmd.CommandText = "delete from stag where matricule ='"+textBox1.Text+"' ";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        // 5>>> declaration de la methode modifier 

        public bool modifier()
        {
            if (number() != 0)
            {
                d.cmd.CommandText = "update stag set nom = '" + textBox2.Text + "',prenom='" + textBox3.Text + "',moyenne='" + textBox4.Text + "',age='" + textBox4.Text + "' where matricule='"+textBox1.Text+"' "; 


                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();

                return true;
            }
            return false;
        }

        // 6 >>> this is for delete whatever we want  
        public void vider (Control f)
        {
            foreach (Control ct in f.Controls)
            { 
                // this for textBox
                   if(ct.GetType()==typeof(TextBox))
                   {
                       ct.Text = "";
                   }  
              
                   // this for sous controls
                if(ct.Controls.Count!=0)
                {
                    vider(ct);
                }
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("vouler vous quiter ","comfirmation",MessageBoxButtons.YesNo)==DialogResult.Yes)
           {
               this.Close();
               d.deconnecter();
               
           }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            remplir();

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            if(MessageBox.Show("vouler vous vider toutes ","comfirmation",MessageBoxButtons.YesNo)==DialogResult.Yes)
            vider(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // pour control de saisie 
            if(textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text=="" )
            {
                MessageBox.Show("s'il vous plait remolir toutes les champs");
                return; 
            } 
            if(ajouter()==true)
            {
                MessageBox.Show("ce stagiare ajouter avec sucess");
                remplir(); 
            }else
            {

                MessageBox.Show("ce stagiare exist deja ");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter votre matricule s'ill vous plait ");
                return;
            }
            if (suprimer() == true)
            {
                MessageBox.Show("ce stagiare supprimer avec sucess");
                remplir();
            }
            else
            {

                MessageBox.Show("ce stagiare  ne exist pas ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // pour control de saisie 
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("s'il vous plait remolir toutes les champs");
                return;
            }
            if (modifier() == true)
            {
                MessageBox.Show("ce stagiare modifier avec sucess");
                remplir();
            }
            else
            {

                MessageBox.Show("ce stagiare no exist  ");
            }
        }
    }
}
