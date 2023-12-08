using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace CRUD_APP
{
    public partial class Form1 : Form
    {
        // Path of database
        string path = "data_table.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\data_table.db";

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        //------------------------------ Validate name function
        private bool Is_Valid_Name(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length > 2)
                {
                    return true;
                }
            }

            return false;
        }
        //------------------------------ Validate Email function
        private bool Is_Valid_Email(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, emailPattern);
        }

        //------------------------------ Validate phone number Function
        private bool Is_Valid_PhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^[0-9]+([-|\s]?[0-9]+)*$";

            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        //------------------------------ Display this error message when the validation is wrong
        private void Validation_Error_Message()
        {
            MessageBox.Show("First name and last name must be more than 2 characters," +
                "the email must be valid and phone number must be number");
        }

        //------------------------------ Reset inputs form data
        private void Reset_Form_Data()
        {
            first_name.Text = "";
            last_name.Text = "";
            email.Text = "";
            phone.Text = "";
        }


        //------------------------------ Create the database
        private void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE USERS(" +
                        "first_name TEXT NOT NULL," +
                        "last_name TEXT NOT NULL, " +
                        "email TEXT NOT NULL, " +
                        "phone TEXT NOT NULL)";

                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Cannot create the database");
                return;
            }
        }

        //------------------------------ Show data in the table (data grid view)
        private void data_show()
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            try
            {
                string stm = "SELECT * FROM USERS";
                var cmd = new SQLiteCommand(stm, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Add users data that came from database to data grid view component
                    usersTable.Rows.Insert(0, dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("OOPS! something went wrong");
                return;
            }
        }


        //------------------------------ Insert a new user
        private void Insert_New_User(object sender, EventArgs e)
        {
            string First_Name = first_name.Text;
            string Last_Name = last_name.Text;
            string Email = email.Text;
            string Phone = phone.Text;

            if (
                Is_Valid_Name(First_Name)
                && Is_Valid_Name(Last_Name)
                && Is_Valid_Email(Email)
                && Is_Valid_PhoneNumber(Phone)
               )
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);

                try
                {
                    cmd.CommandText = "INSERT INTO USERS VALUES(@first_name, @last_name, @email, @phone)";

                    // Insert new user to database
                    cmd.Parameters.AddWithValue("@first_name", First_Name);
                    cmd.Parameters.AddWithValue("@last_name", Last_Name);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@phone", Phone);

                    // Add the new user data to data grid view component
                    usersTable.ColumnCount = 4;
                    usersTable.Columns[0].Name = "first_name_col";
                    usersTable.Columns[1].Name = "last_name_col";
                    usersTable.Columns[2].Name = "email_col";
                    usersTable.Columns[3].Name = "phone_col";
                    string[] row = new string[] { First_Name, Last_Name, Email, Phone };
                    usersTable.Rows.Add(row);
                    alphabetizedTable.Rows.Clear();

                    cmd.ExecuteNonQuery();
                    Reset_Form_Data();
                    MessageBox.Show("The User Added Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Cannot insert a new user");
                    return;
                }
            }
            else
            {
                Validation_Error_Message();
            }
        }


        //------------------------------ Update current user
        private void Update_Current_User(object sender, EventArgs e)
        {
            string First_Name = first_name.Text;
            string Last_Name = last_name.Text;
            string Email = email.Text;
            string Phone = phone.Text;

            if (
                Is_Valid_Name(First_Name)
                && Is_Valid_Name(Last_Name)
                && Is_Valid_Email(Email)
                && Is_Valid_PhoneNumber(Phone)
               )
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);

                try
                {
                    cmd.CommandText = "UPDATE USERS SET " +
                        "first_name=@first_name," +
                        "last_name=@last_name," +
                        "phone=@phone " +
                        "WHERE email=@email";

                    cmd.Prepare();

                    // Update and save the user data to database
                    cmd.Parameters.AddWithValue("@first_name", First_Name);
                    cmd.Parameters.AddWithValue("@last_name", Last_Name);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@phone", Phone);

                    cmd.ExecuteNonQuery();
                    usersTable.Rows.Clear();
                    alphabetizedTable.Rows.Clear();
                    data_show();
                    MessageBox.Show("The User Updated Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Cannot update the user");
                    return;
                }
            }
            else
            {
                Validation_Error_Message();
            }
        }


        //------------------------------ Delete user
        private void Delete_User(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);

            string Email = email.Text;

            if (Is_Valid_Email(Email))
            {
                try
                {
                    cmd.CommandText = "DELETE FROM USERS WHERE email=@email";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@email", Email);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        usersTable.Rows.Clear();
                        alphabetizedTable.Rows.Clear();
                        data_show();
                        Reset_Form_Data();
                        MessageBox.Show("The User Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("The Email doesn't exist, add valid Email");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Cannot delete the user");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid email, so you can delete the user");
            }
        }


        //------------------------------ Display the users sorted alphabetized
        private void Display_Sorted_User_List(object sender, EventArgs e)
        {
            Reset_Form_Data();
            usersTable.Rows.Clear();
            var con = new SQLiteConnection(cs);
            con.Open();

            try
            {
                string stm = "SELECT * FROM USERS ORDER BY first_name, last_name";
                var cmd = new SQLiteCommand(stm, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Add users data that came from database to data grid view component
                    usersTable.Rows.Insert(0, dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("OOPS! something went wrong");
                return;
            }
        }


        //------------------------------ Insert 10 random users to database
        static string Generate_Random_Name()
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int nameLength = random.Next(5, 10);

            char[] nameArray = new char[nameLength];
            for (int i = 0; i < nameLength; i++)
            {
                nameArray[i] = characters[random.Next(characters.Length)];
            }

            return new string(nameArray);
        }

        static void Insert_Random_Names(int numberOfNames)
        {
            try
            {
                using (var sqlite = new SQLiteConnection(@"Data Source=data_table.db"))
                {
                    sqlite.Open();
                    string sql = "INSERT INTO USERS VALUES(@first_name, @last_name, @email, @phone)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqlite))
                    {
                        // Generate and insert random names to database
                        for (int i = 0; i < numberOfNames; i++)
                        {
                            string randomName = Generate_Random_Name();
                            cmd.Parameters.AddWithValue("@first_name", randomName);
                            cmd.Parameters.AddWithValue("@last_name", randomName);
                            cmd.Parameters.AddWithValue("@email", $"{randomName}@gmail.com");
                            cmd.Parameters.AddWithValue("@phone", "0123497659");

                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("OOPS! something went wrong");
                return;
            }
        }

        private void Insert_Number_Of_Random_Users(object sender, EventArgs e)
        {
            Reset_Form_Data();
            usersTable.Rows.Clear();
            alphabetizedTable.Rows.Clear();
            Insert_Random_Names(10);
            data_show();
        }


        //------------------------------ Display an alphabetized list of the current users
        static List<string> Get_Sorted_User_Names()
        {
            List<string> userNames = new List<string>();

            try
            {
                using (var sqlite = new SQLiteConnection(@"Data Source=data_table.db"))
                {
                    sqlite.Open();
                    string sql = "SELECT * FROM USERS ORDER BY first_name, last_name";
                    using (SQLiteCommand command = new SQLiteCommand(sql, sqlite))
                    {
                        using (SQLiteDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string userName = $"{dr["first_name"]}  {dr["last_name"]}";
                                string sortedName = Sort_Name_Alphabetically(userName);
                                userNames.Add(sortedName);
                            }
                        }
                    }
                }

                userNames.Sort(); // Alphabetically sort the names

                return userNames;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("OOPS! something went wrong");
                return userNames;
            }
        }

        static string Sort_Name_Alphabetically(string name)
        {
            char[] charArray = name.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        private void Alphabetized_User_Names(object sender, EventArgs e)
        {
            List<string> sortedNames = Get_Sorted_User_Names();

            alphabetizedTable.Rows.Clear();

            foreach (var name in sortedNames)
            {
                alphabetizedTable.Rows.Insert(0, name); // Add users names to data grid view component
            }
        }


        //------------------------------ Call Create_db & data_show functions when the app runs
        private void Form1_Load(object sender, EventArgs e)
        {
            Create_db();
            data_show();
        }


        //------------------------------ When Selected row Fill Inputs with the data of the row 
        private void usersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (usersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                usersTable.CurrentRow.Selected = true;
                first_name.Text = usersTable.Rows[e.RowIndex].Cells["first_name_col"].FormattedValue.ToString();
                last_name.Text = usersTable.Rows[e.RowIndex].Cells["last_name_col"].FormattedValue.ToString();
                email.Text = usersTable.Rows[e.RowIndex].Cells["email_col"].FormattedValue.ToString();
                phone.Text = usersTable.Rows[e.RowIndex].Cells["phone_col"].FormattedValue.ToString();
            }
        }
    }
}
