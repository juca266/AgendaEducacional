namespace Agenda_V4
{
    partial class frmCadPessoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadPessoa));
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxCracha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEmailSecundario = new System.Windows.Forms.TextBox();
            this.textBoxEmailPrincipal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxUsuario = new System.Windows.Forms.CheckBox();
            this.checkBoxAdministrador = new System.Windows.Forms.CheckBox();
            this.checkBoxInstrutor = new System.Windows.Forms.CheckBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.buttonCor = new System.Windows.Forms.Button();
            this.labelCorInstrutor = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerNascimento = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAdmissao = new System.Windows.Forms.DateTimePicker();
            this.maskedTextBoxTelPrincipal = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxTelSecundario = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxUsuarioDesativado = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonMais = new System.Windows.Forms.Button();
            this.buttonMenos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNome
            // 
            this.textBoxNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNome.Location = new System.Drawing.Point(27, 60);
            this.textBoxNome.MaxLength = 80;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(302, 20);
            this.textBoxNome.TabIndex = 1;
            this.textBoxNome.Enter += new System.EventHandler(this.textBoxNome_Enter);
            // 
            // textBoxCracha
            // 
            this.textBoxCracha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxCracha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCracha.Location = new System.Drawing.Point(27, 99);
            this.textBoxCracha.MaxLength = 5;
            this.textBoxCracha.Name = "textBoxCracha";
            this.textBoxCracha.Size = new System.Drawing.Size(65, 20);
            this.textBoxCracha.TabIndex = 2;
            this.textBoxCracha.Enter += new System.EventHandler(this.textBoxCracha_Enter);
            this.textBoxCracha.Leave += new System.EventHandler(this.textBoxCracha_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Crachá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nascimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Admissão";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Telefone Principal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email Principal";
            // 
            // textBoxEmailSecundario
            // 
            this.textBoxEmailSecundario.Location = new System.Drawing.Point(27, 216);
            this.textBoxEmailSecundario.MaxLength = 50;
            this.textBoxEmailSecundario.Name = "textBoxEmailSecundario";
            this.textBoxEmailSecundario.Size = new System.Drawing.Size(302, 20);
            this.textBoxEmailSecundario.TabIndex = 8;
            // 
            // textBoxEmailPrincipal
            // 
            this.textBoxEmailPrincipal.Location = new System.Drawing.Point(27, 177);
            this.textBoxEmailPrincipal.MaxLength = 50;
            this.textBoxEmailPrincipal.Name = "textBoxEmailPrincipal";
            this.textBoxEmailPrincipal.Size = new System.Drawing.Size(302, 20);
            this.textBoxEmailPrincipal.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Email Secundário";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(40, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 24);
            this.label11.TabIndex = 23;
            this.label11.Text = "Cadastro de Pessoas";
            // 
            // checkBoxUsuario
            // 
            this.checkBoxUsuario.AutoSize = true;
            this.checkBoxUsuario.Location = new System.Drawing.Point(27, 242);
            this.checkBoxUsuario.Name = "checkBoxUsuario";
            this.checkBoxUsuario.Size = new System.Drawing.Size(62, 17);
            this.checkBoxUsuario.TabIndex = 9;
            this.checkBoxUsuario.Text = "Usuário";
            this.checkBoxUsuario.UseVisualStyleBackColor = true;
            this.checkBoxUsuario.CheckedChanged += new System.EventHandler(this.checkBoxUsuario_CheckedChanged);
            // 
            // checkBoxAdministrador
            // 
            this.checkBoxAdministrador.AutoSize = true;
            this.checkBoxAdministrador.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxAdministrador.Enabled = false;
            this.checkBoxAdministrador.Location = new System.Drawing.Point(40, 344);
            this.checkBoxAdministrador.Name = "checkBoxAdministrador";
            this.checkBoxAdministrador.Size = new System.Drawing.Size(74, 31);
            this.checkBoxAdministrador.TabIndex = 12;
            this.checkBoxAdministrador.Text = "Administrador";
            this.checkBoxAdministrador.UseVisualStyleBackColor = true;
            // 
            // checkBoxInstrutor
            // 
            this.checkBoxInstrutor.AutoSize = true;
            this.checkBoxInstrutor.Location = new System.Drawing.Point(141, 242);
            this.checkBoxInstrutor.Name = "checkBoxInstrutor";
            this.checkBoxInstrutor.Size = new System.Drawing.Size(64, 17);
            this.checkBoxInstrutor.TabIndex = 13;
            this.checkBoxInstrutor.Text = "Instrutor";
            this.checkBoxInstrutor.UseVisualStyleBackColor = true;
            this.checkBoxInstrutor.CheckedChanged += new System.EventHandler(this.checkBoxInstrutor_CheckedChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Enabled = false;
            this.labelUsuario.Location = new System.Drawing.Point(24, 263);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 29;
            this.labelUsuario.Text = "Usuário";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Enabled = false;
            this.textBoxUsuario.Location = new System.Drawing.Point(27, 279);
            this.textBoxUsuario.MaxLength = 20;
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(105, 20);
            this.textBoxUsuario.TabIndex = 10;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Enabled = false;
            this.labelSenha.Location = new System.Drawing.Point(24, 302);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(38, 13);
            this.labelSenha.TabIndex = 31;
            this.labelSenha.Text = "Senha";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Enabled = false;
            this.textBoxSenha.Location = new System.Drawing.Point(27, 318);
            this.textBoxSenha.MaxLength = 16;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '*';
            this.textBoxSenha.Size = new System.Drawing.Size(105, 20);
            this.textBoxSenha.TabIndex = 11;
            // 
            // buttonCor
            // 
            this.buttonCor.Enabled = false;
            this.buttonCor.Location = new System.Drawing.Point(142, 277);
            this.buttonCor.Name = "buttonCor";
            this.buttonCor.Size = new System.Drawing.Size(40, 22);
            this.buttonCor.TabIndex = 14;
            this.buttonCor.Text = "Cor";
            this.buttonCor.UseVisualStyleBackColor = true;
            this.buttonCor.Click += new System.EventHandler(this.buttonCor_Click_1);
            // 
            // labelCorInstrutor
            // 
            this.labelCorInstrutor.AutoSize = true;
            this.labelCorInstrutor.Enabled = false;
            this.labelCorInstrutor.Location = new System.Drawing.Point(139, 263);
            this.labelCorInstrutor.Name = "labelCorInstrutor";
            this.labelCorInstrutor.Size = new System.Drawing.Size(136, 13);
            this.labelCorInstrutor.TabIndex = 33;
            this.labelCorInstrutor.Text = "Selecione a cor do instrutor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(188, 279);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 20);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.Enabled = false;
            this.labelDisciplina.Location = new System.Drawing.Point(139, 302);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(52, 13);
            this.labelDisciplina.TabIndex = 35;
            this.labelDisciplina.Text = "Disciplina";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(142, 317);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDisciplina.TabIndex = 15;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(27, 439);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(65, 20);
            this.buttonGravar.TabIndex = 17;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(255, 439);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(74, 20);
            this.buttonLimpar.TabIndex = 19;
            this.buttonLimpar.Text = "Novo";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(135, 344);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(194, 89);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Disciplina";
            this.Column1.HeaderText = "Disciplina";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IdDisciplina";
            this.Column2.HeaderText = "Id";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // dateTimePickerNascimento
            // 
            this.dateTimePickerNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNascimento.Location = new System.Drawing.Point(122, 99);
            this.dateTimePickerNascimento.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerNascimento.Name = "dateTimePickerNascimento";
            this.dateTimePickerNascimento.Size = new System.Drawing.Size(84, 20);
            this.dateTimePickerNascimento.TabIndex = 3;
            // 
            // dateTimePickerAdmissao
            // 
            this.dateTimePickerAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerAdmissao.Location = new System.Drawing.Point(242, 99);
            this.dateTimePickerAdmissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerAdmissao.Name = "dateTimePickerAdmissao";
            this.dateTimePickerAdmissao.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerAdmissao.TabIndex = 42;
            // 
            // maskedTextBoxTelPrincipal
            // 
            this.maskedTextBoxTelPrincipal.Location = new System.Drawing.Point(27, 138);
            this.maskedTextBoxTelPrincipal.Mask = "(99) 00000-0000";
            this.maskedTextBoxTelPrincipal.Name = "maskedTextBoxTelPrincipal";
            this.maskedTextBoxTelPrincipal.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxTelPrincipal.TabIndex = 5;
            // 
            // maskedTextBoxTelSecundario
            // 
            this.maskedTextBoxTelSecundario.Location = new System.Drawing.Point(226, 138);
            this.maskedTextBoxTelSecundario.Mask = "(99) 00000-0000";
            this.maskedTextBoxTelSecundario.Name = "maskedTextBoxTelSecundario";
            this.maskedTextBoxTelSecundario.Size = new System.Drawing.Size(101, 20);
            this.maskedTextBoxTelSecundario.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Telefone Secundário";
            // 
            // checkBoxUsuarioDesativado
            // 
            this.checkBoxUsuarioDesativado.AutoSize = true;
            this.checkBoxUsuarioDesativado.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxUsuarioDesativado.Location = new System.Drawing.Point(25, 385);
            this.checkBoxUsuarioDesativado.Name = "checkBoxUsuarioDesativado";
            this.checkBoxUsuarioDesativado.Size = new System.Drawing.Size(104, 31);
            this.checkBoxUsuarioDesativado.TabIndex = 16;
            this.checkBoxUsuarioDesativado.Text = "Usuário Desativado";
            this.checkBoxUsuarioDesativado.UseVisualStyleBackColor = true;
            this.checkBoxUsuarioDesativado.CheckedChanged += new System.EventHandler(this.checkBoxUsuarioDesativado_CheckedChanged);
            // 
            // buttonMais
            // 
            this.buttonMais.Enabled = false;
            this.buttonMais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMais.Location = new System.Drawing.Point(281, 315);
            this.buttonMais.Name = "buttonMais";
            this.buttonMais.Size = new System.Drawing.Size(21, 22);
            this.buttonMais.TabIndex = 43;
            this.buttonMais.Text = "+";
            this.buttonMais.UseVisualStyleBackColor = true;
            this.buttonMais.Click += new System.EventHandler(this.buttonMais_Click);
            // 
            // buttonMenos
            // 
            this.buttonMenos.Enabled = false;
            this.buttonMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenos.Location = new System.Drawing.Point(308, 315);
            this.buttonMenos.Name = "buttonMenos";
            this.buttonMenos.Size = new System.Drawing.Size(21, 22);
            this.buttonMenos.TabIndex = 44;
            this.buttonMenos.Text = "-";
            this.buttonMenos.UseVisualStyleBackColor = true;
            this.buttonMenos.Click += new System.EventHandler(this.buttonMenos_Click);
            // 
            // frmCadPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(339, 465);
            this.Controls.Add(this.buttonMenos);
            this.Controls.Add(this.buttonMais);
            this.Controls.Add(this.checkBoxUsuarioDesativado);
            this.Controls.Add(this.maskedTextBoxTelSecundario);
            this.Controls.Add(this.maskedTextBoxTelPrincipal);
            this.Controls.Add(this.dateTimePickerAdmissao);
            this.Controls.Add(this.dateTimePickerNascimento);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCorInstrutor);
            this.Controls.Add(this.buttonCor);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.checkBoxInstrutor);
            this.Controls.Add(this.checkBoxAdministrador);
            this.Controls.Add(this.checkBoxUsuario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxEmailPrincipal);
            this.Controls.Add(this.textBoxEmailSecundario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCracha);
            this.Controls.Add(this.textBoxNome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadPessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Pessoas";
            this.Load += new System.EventHandler(this.frmCadPessoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxCracha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEmailSecundario;
        private System.Windows.Forms.TextBox textBoxEmailPrincipal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxUsuario;
        private System.Windows.Forms.CheckBox checkBoxAdministrador;
        private System.Windows.Forms.CheckBox checkBoxInstrutor;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Button buttonCor;
        private System.Windows.Forms.Label labelCorInstrutor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerNascimento;
        private System.Windows.Forms.DateTimePicker dateTimePickerAdmissao;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelPrincipal;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelSecundario;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxUsuarioDesativado;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonMais;
        private System.Windows.Forms.Button buttonMenos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}