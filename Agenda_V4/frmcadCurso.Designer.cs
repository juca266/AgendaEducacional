namespace Agenda_V4
{
    partial class frmCadCurso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadCurso));
            this.textBoxCurso = new System.Windows.Forms.TextBox();
            this.textBoxCodCurso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonMais = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.tblDisciplinaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bancoAgenda_V4DataSet = new Agenda_V4.BancoAgenda_V4DataSet();
            this.tblDisciplinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCodDisciplina = new System.Windows.Forms.TextBox();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblDisciplinaTableAdapter = new Agenda_V4.BancoAgenda_V4DataSetTableAdapters.tblDisciplinaTableAdapter();
            this.buttonMenos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblDisciplinaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancoAgenda_V4DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDisciplinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCurso
            // 
            this.textBoxCurso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxCurso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCurso.Location = new System.Drawing.Point(95, 68);
            this.textBoxCurso.MaxLength = 80;
            this.textBoxCurso.Name = "textBoxCurso";
            this.textBoxCurso.Size = new System.Drawing.Size(421, 20);
            this.textBoxCurso.TabIndex = 2;
            this.textBoxCurso.Enter += new System.EventHandler(this.textBoxCurso_Enter);
            this.textBoxCurso.Leave += new System.EventHandler(this.textBoxCurso_Leave);
            // 
            // textBoxCodCurso
            // 
            this.textBoxCodCurso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxCodCurso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCodCurso.Location = new System.Drawing.Point(14, 68);
            this.textBoxCodCurso.MaxLength = 10;
            this.textBoxCodCurso.Name = "textBoxCodCurso";
            this.textBoxCodCurso.Size = new System.Drawing.Size(75, 20);
            this.textBoxCodCurso.TabIndex = 1;
            this.textBoxCodCurso.Enter += new System.EventHandler(this.textBoxCodCurso_Enter);
            this.textBoxCodCurso.Leave += new System.EventHandler(this.textBoxCodCurso_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Curso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Disciplinas";
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(455, 252);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(61, 23);
            this.buttonExcluir.TabIndex = 8;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonMais
            // 
            this.buttonMais.Location = new System.Drawing.Point(446, 107);
            this.buttonMais.Name = "buttonMais";
            this.buttonMais.Size = new System.Drawing.Size(32, 23);
            this.buttonMais.TabIndex = 6;
            this.buttonMais.Text = "+";
            this.buttonMais.UseVisualStyleBackColor = true;
            this.buttonMais.Click += new System.EventHandler(this.buttonMais_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(157, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 24);
            this.label11.TabIndex = 44;
            this.label11.Text = "Cadastro de Cursos";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxDisciplina.DataSource = this.tblDisciplinaBindingSource1;
            this.comboBoxDisciplina.DisplayMember = "Disciplina";
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(95, 106);
            this.comboBoxDisciplina.MaxDropDownItems = 80;
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(345, 21);
            this.comboBoxDisciplina.TabIndex = 5;
            this.comboBoxDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedIndexChanged);
            // 
            // tblDisciplinaBindingSource1
            // 
            this.tblDisciplinaBindingSource1.DataMember = "tblDisciplina";
            this.tblDisciplinaBindingSource1.DataSource = this.bancoAgenda_V4DataSet;
            // 
            // bancoAgenda_V4DataSet
            // 
            this.bancoAgenda_V4DataSet.DataSetName = "BancoAgenda_V4DataSet";
            this.bancoAgenda_V4DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblDisciplinaBindingSource
            // 
            this.tblDisciplinaBindingSource.DataMember = "tblDisciplina";
            this.tblDisciplinaBindingSource.DataSource = this.bancoAgenda_V4DataSet;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Disciplina";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Cód. Disc.";
            // 
            // textBoxCodDisciplina
            // 
            this.textBoxCodDisciplina.Location = new System.Drawing.Point(14, 107);
            this.textBoxCodDisciplina.MaxLength = 10;
            this.textBoxCodDisciplina.Name = "textBoxCodDisciplina";
            this.textBoxCodDisciplina.Size = new System.Drawing.Size(75, 20);
            this.textBoxCodDisciplina.TabIndex = 4;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(17, 252);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(61, 23);
            this.buttonGravar.TabIndex = 7;
            this.buttonGravar.Text = "Novo";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(502, 100);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // tblDisciplinaTableAdapter
            // 
            this.tblDisciplinaTableAdapter.ClearBeforeFill = true;
            // 
            // buttonMenos
            // 
            this.buttonMenos.Location = new System.Drawing.Point(484, 107);
            this.buttonMenos.Name = "buttonMenos";
            this.buttonMenos.Size = new System.Drawing.Size(32, 23);
            this.buttonMenos.TabIndex = 7;
            this.buttonMenos.Text = "-";
            this.buttonMenos.UseVisualStyleBackColor = true;
            this.buttonMenos.Click += new System.EventHandler(this.buttonMenos_Click);
            // 
            // frmCadCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 287);
            this.Controls.Add(this.buttonMenos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCodDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonMais);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCodCurso);
            this.Controls.Add(this.textBoxCurso);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadCurso";
            this.Text = "Cadastro de Cursos";
            this.Load += new System.EventHandler(this.frmCadCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblDisciplinaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancoAgenda_V4DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDisciplinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCurso;
        private System.Windows.Forms.TextBox textBoxCodCurso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonMais;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCodDisciplina;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BancoAgenda_V4DataSet bancoAgenda_V4DataSet;
        private System.Windows.Forms.BindingSource tblDisciplinaBindingSource;
        private BancoAgenda_V4DataSetTableAdapters.tblDisciplinaTableAdapter tblDisciplinaTableAdapter;
        private System.Windows.Forms.BindingSource tblDisciplinaBindingSource1;
        private System.Windows.Forms.Button buttonMenos;
    }
}