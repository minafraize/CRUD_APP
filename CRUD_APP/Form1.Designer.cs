
namespace CRUD_APP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            first_name = new TextBox();
            last_name = new TextBox();
            email = new TextBox();
            phone = new TextBox();
            Insert = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            usersTable = new DataGridView();
            first_name_col = new DataGridViewTextBoxColumn();
            last_name_col = new DataGridViewTextBoxColumn();
            email_col = new DataGridViewTextBoxColumn();
            phone_col = new DataGridViewTextBoxColumn();
            alphabetizedTable = new DataGridView();
            user_name = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)usersTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphabetizedTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(398, 6);
            label1.Name = "label1";
            label1.Size = new Size(117, 30);
            label1.TabIndex = 0;
            label1.Text = "CRUD APP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 54);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "First Name:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 87);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 2;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(11, 120);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(11, 154);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Phone Num:";
            label5.Click += label5_Click;
            // 
            // first_name
            // 
            first_name.Location = new Point(99, 51);
            first_name.Name = "first_name";
            first_name.Size = new Size(132, 23);
            first_name.TabIndex = 5;
            // 
            // last_name
            // 
            last_name.Location = new Point(99, 84);
            last_name.Name = "last_name";
            last_name.Size = new Size(132, 23);
            last_name.TabIndex = 6;
            // 
            // email
            // 
            email.Location = new Point(99, 117);
            email.Name = "email";
            email.Size = new Size(132, 23);
            email.TabIndex = 7;
            // 
            // phone
            // 
            phone.Location = new Point(99, 151);
            phone.Name = "phone";
            phone.Size = new Size(132, 23);
            phone.TabIndex = 8;
            // 
            // Insert
            // 
            Insert.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Insert.Location = new Point(11, 190);
            Insert.Name = "Insert";
            Insert.Size = new Size(220, 43);
            Insert.TabIndex = 9;
            Insert.Text = "Insert";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_New_User;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(11, 239);
            button2.Name = "button2";
            button2.Size = new Size(220, 43);
            button2.TabIndex = 10;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Update_Current_User;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(11, 288);
            button3.Name = "button3";
            button3.Size = new Size(220, 45);
            button3.TabIndex = 11;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Delete_User;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(11, 339);
            button4.Name = "button4";
            button4.Size = new Size(220, 46);
            button4.TabIndex = 12;
            button4.Text = "Insert 10 random users";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Insert_Number_Of_Random_Users;
            // 
            // usersTable
            // 
            usersTable.BackgroundColor = Color.White;
            usersTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersTable.Columns.AddRange(new DataGridViewColumn[] { first_name_col, last_name_col, email_col, phone_col });
            usersTable.Location = new Point(253, 51);
            usersTable.Name = "usersTable";
            usersTable.Size = new Size(443, 386);
            usersTable.TabIndex = 13;
            usersTable.CellClick += usersTable_CellContentClick;
            // 
            // first_name_col
            // 
            first_name_col.HeaderText = "First Name";
            first_name_col.Name = "first_name_col";
            // 
            // last_name_col
            // 
            last_name_col.HeaderText = "Last Name";
            last_name_col.Name = "last_name_col";
            // 
            // email_col
            // 
            email_col.HeaderText = "Email";
            email_col.Name = "email_col";
            // 
            // phone_col
            // 
            phone_col.HeaderText = "Phone Num";
            phone_col.Name = "phone_col";
            // 
            // alphabetizedTable
            // 
            alphabetizedTable.BackgroundColor = Color.White;
            alphabetizedTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alphabetizedTable.Columns.AddRange(new DataGridViewColumn[] { user_name });
            alphabetizedTable.Location = new Point(749, 104);
            alphabetizedTable.Name = "alphabetizedTable";
            alphabetizedTable.Size = new Size(143, 333);
            alphabetizedTable.TabIndex = 14;
            // 
            // user_name
            // 
            user_name.HeaderText = "User Name";
            user_name.Name = "user_name";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(720, 51);
            button1.Name = "button1";
            button1.Size = new Size(199, 47);
            button1.TabIndex = 15;
            button1.Text = "Display the user's name alphabetized";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Alphabetized_User_Names;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(11, 391);
            button5.Name = "button5";
            button5.Size = new Size(220, 46);
            button5.TabIndex = 16;
            button5.Text = "Display users sorted";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Display_Sorted_User_List;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 450);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(alphabetizedTable);
            Controls.Add(usersTable);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Insert);
            Controls.Add(phone);
            Controls.Add(email);
            Controls.Add(last_name);
            Controls.Add(first_name);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)usersTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphabetizedTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox first_name;
        private TextBox last_name;
        private TextBox email;
        private TextBox phone;
        private Button Insert;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView usersTable;
        private DataGridViewTextBoxColumn first_name_col;
        private DataGridViewTextBoxColumn last_name_col;
        private DataGridViewTextBoxColumn email_col;
        private DataGridViewTextBoxColumn phone_col;
        private DataGridView alphabetizedTable;
        private DataGridViewTextBoxColumn user_name;
        private Button button1;
        private Button button5;
    }
}
