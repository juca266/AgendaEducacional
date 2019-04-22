using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda_V4
{
    public partial class frmPrincipal : Form
    {
        public bool salvo = true; // se verdadeiro não deixa salvar
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmCadDisciplina frm = new frmCadDisciplina();                          //
            if (Application.OpenForms.OfType<frmCadDisciplina>().Count() > 0)   //
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this; // coloca o formulario 2 encaixado no 1
                frm.Show(); // abre o forme 2
            }
            this.Cursor = Cursors.Default;
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmCadPessoa frm = new frmCadPessoa();                          //
            if (Application.OpenForms.OfType<frmCadPessoa>().Count() > 0)   //
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this; // coloca o formulario 2 encaixado no 1
                frm.Show(); // abre o forme 2
            }
            this.Cursor = Cursors.Default;
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmCadCurso frm = new frmCadCurso();                          //
            if (Application.OpenForms.OfType<frmCadCurso>().Count() > 0)   //
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this; // coloca o formulario 2 encaixado no 1
                frm.Show(); // abre o forme 2
            }
            this.Cursor = Cursors.Default;
        }

        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmCadSala frm = new frmCadSala();                          //
            if (Application.OpenForms.OfType<frmCadSala>().Count() > 0)   //
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this; // coloca o formulario 2 encaixado no 1
                frm.Show(); // abre o forme 2
            }
            this.Cursor = Cursors.Default;
        }

        private void turmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmProgCurso frm = new frmProgCurso();                              //
            if (Application.OpenForms.OfType<frmProgCurso>().Count() > 0)       //
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;   // coloca o formulario 2 encaixado no 1
                frm.Show();             // abre o forme 2
            }
            this.Cursor = Cursors.Default;
        }
    }
}
