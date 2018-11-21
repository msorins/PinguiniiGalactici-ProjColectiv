Create a new database called AcademicInfo.
If you give it another name, modify the name in the USE instruction as well (each script starts with a USE instruction).
Execute the scripts.
Execution order:
	1. Create_Tables
	2. Create_Procedures_And_Roles
	3. Insert
If 3. gives errors, it should still be okay. Check that all the tables are created and have data in them.

We use SQL Users to authenticate. Each user has a username, a password and a role. There are 3 roles: Admin, Teacher and Student. Each role has certain permissions. They only have permission to execute some stored procedures, so we should only work with stored procedures, NOT directly on the tables.
If you try to execute Students_ReadAll after the insertion and the table seems empty, it might be because you don't have the rights to see the students. Try using
EXECUTE AS LOGIN='admin1'
EXECUTE Students_ReadAll
If this doesn't work either, there might be a bug somewhere.

The names of the tables have been changed to hide what they contain and to protect from sql injection. You can find the mapping of the new names in the file called Mapping.

Authentication example:
            string username = "mmie2169";
            string password = "pass";
            string connectionString =
            "Data Source=MADALINA\\SQLEXPRESS01;" +
            "Initial Catalog=AcademicInfo;" +
            "User id=" + username + ";" +
            "Password=" + password + ";";

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Table1_ReadAll";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            conn.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ParentList.DataSource = ds.Tables[0];
            conn.Close();