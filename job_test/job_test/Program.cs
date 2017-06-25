using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace job_test
{
    public struct person
    {
        public int id;
        public string fio;
        public string status;
        public string dep;
        public string post;
        public Nullable<DateTime> date_employ;
        public Nullable<DateTime> date_unemploy;
    }

    public struct stat
    {
        public int count;
        public Nullable<DateTime> date;
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }
    }

    public class sql
    {
        MySql.Data.MySqlClient.MySqlConnection myConnection;
        string Connect = @"server=" + Properties.Settings.Default.server + ";uid=" + Properties.Settings.Default.login + ";pwd =" + Properties.Settings.Default.password + ";database=" + Properties.Settings.Default.database + ";charset=" + Properties.Settings.Default.charset + ";";

        public sql()
        {
            // Конструктор
        }

        ~sql()
        {
            // Деструктор
        }

        void connectOpen()
        {
            myConnection = new MySql.Data.MySqlClient.MySqlConnection();
            myConnection.ConnectionString = Connect;
            myConnection.Open();
        }

        void connectClose()
        {
            myConnection.Close();
        }

        void connectError(MySql.Data.MySqlClient.MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }

        public List<person> selectPerson()
        {
            List<person> getPost = new List<person>{ };

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        persons.id, LEFT(persons.first_name, 1), LEFT(persons.second_name, 1), persons.last_name,
                        status.name, deps.name, posts.name,
                        persons.date_employ, persons.date_uneploy
                    FROM persons, status, deps, posts
                    WHERE persons.status = status.id and persons.id_dep = deps.id and persons.id_post = posts.id;";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person temp;
                    temp.id = (int)reader[0];
                    temp.fio = reader[3].ToString() + " " + reader[1].ToString() + ". " + reader[2].ToString() + ".";
                    temp.status = reader[4].ToString();
                    temp.dep = reader[5].ToString();
                    temp.post = reader[6].ToString();
                    temp.date_employ = (reader[7] != DBNull.Value) ? temp.date_employ = Convert.ToDateTime(reader[7]) : null;
                    temp.date_unemploy = (reader[8] != DBNull.Value) ? temp.date_unemploy = Convert.ToDateTime(reader[8]) : null;

                    getPost.Add(temp);
                }

                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }

        public List<person> selectStatus(string status)
        {
            List<person> getPost = new List<person> { };

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        persons.id, LEFT(persons.first_name, 1), LEFT(persons.second_name, 1), persons.last_name,
                        status.name, deps.name, posts.name,
                        persons.date_employ, persons.date_uneploy
                    FROM persons, status, deps, posts
                    WHERE persons.status = status.id and persons.id_dep = deps.id and persons.id_post = posts.id and status.name = '"+ status +"';";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person temp;
                    temp.id = (int)reader[0];
                    temp.fio = reader[3].ToString() + " " + reader[1].ToString() + ". " + reader[2].ToString() + ".";
                    temp.status = reader[4].ToString();
                    temp.dep = reader[5].ToString();
                    temp.post = reader[6].ToString();
                    temp.date_employ = (reader[7] != DBNull.Value) ? temp.date_employ = Convert.ToDateTime(reader[7]) : null;
                    temp.date_unemploy = (reader[8] != DBNull.Value) ? temp.date_unemploy = Convert.ToDateTime(reader[8]) : null;

                    getPost.Add(temp);
                }

                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }

        public List<person> selectDeps(string dep)
        {
            List<person> getPost = new List<person> { };

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        persons.id, LEFT(persons.first_name, 1), LEFT(persons.second_name, 1), persons.last_name,
                        status.name, deps.name, posts.name,
                        persons.date_employ, persons.date_uneploy
                    FROM persons, status, deps, posts
                    WHERE persons.status = status.id and persons.id_dep = deps.id and persons.id_post = posts.id and deps.name = '" + dep + "';";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person temp;
                    temp.id = (int)reader[0];
                    temp.fio = reader[3].ToString() + " " + reader[1].ToString() + ". " + reader[2].ToString() + ".";
                    temp.status = reader[4].ToString();
                    temp.dep = reader[5].ToString();
                    temp.post = reader[6].ToString();
                    temp.date_employ = (reader[7] != DBNull.Value) ? temp.date_employ = Convert.ToDateTime(reader[7]) : null;
                    temp.date_unemploy = (reader[8] != DBNull.Value) ? temp.date_unemploy = Convert.ToDateTime(reader[8]) : null;

                    getPost.Add(temp);
                }

                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }

        public List<person> selectPosts(string post)
        {
            List<person> getPost = new List<person> { };

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        persons.id, LEFT(persons.first_name, 1), LEFT(persons.second_name, 1), persons.last_name,
                        status.name, deps.name, posts.name,
                        persons.date_employ, persons.date_uneploy
                    FROM persons, status, deps, posts
                    WHERE persons.status = status.id and persons.id_dep = deps.id and persons.id_post = posts.id and posts.name = '" + post + "';";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person temp;
                    temp.id = (int)reader[0];
                    temp.fio = reader[3].ToString() + " " + reader[1].ToString() + ". " + reader[2].ToString() + ".";
                    temp.status = reader[4].ToString();
                    temp.dep = reader[5].ToString();
                    temp.post = reader[6].ToString();
                    temp.date_employ = (reader[7] != DBNull.Value) ? temp.date_employ = Convert.ToDateTime(reader[7]) : null;
                    temp.date_unemploy = (reader[8] != DBNull.Value) ? temp.date_unemploy = Convert.ToDateTime(reader[8]) : null;

                    getPost.Add(temp);
                }

                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }

        public List<person> selectLastName(string last_name)
        {
            List<person> getPost = new List<person> { };

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        persons.id, LEFT(persons.first_name, 1), LEFT(persons.second_name, 1), persons.last_name,
                        status.name, deps.name, posts.name,
                        persons.date_employ, persons.date_uneploy
                    FROM persons, status, deps, posts
                    WHERE persons.status = status.id and persons.id_dep = deps.id and persons.id_post = posts.id and persons.last_name LIKE '%" + last_name + "%';";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person temp;
                    temp.id = (int)reader[0];
                    temp.fio = reader[3].ToString() + " " + reader[1].ToString() + ". " + reader[2].ToString() + ".";
                    temp.status = reader[4].ToString();
                    temp.dep = reader[5].ToString();
                    temp.post = reader[6].ToString();
                    temp.date_employ = (reader[7] != DBNull.Value) ? temp.date_employ = Convert.ToDateTime(reader[7]) : null;
                    temp.date_unemploy = (reader[8] != DBNull.Value) ? temp.date_unemploy = Convert.ToDateTime(reader[8]) : null;

                    getPost.Add(temp);
                }

                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }

        public List<string> selectStatusName()
        {
            List<string> getPost = new List<string>{};

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT name FROM status;";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    getPost.Add(reader[0].ToString());
                }

                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }

        public List<stat> selectStatistic(string start, string finish, string status, bool employ)
        {

            string date_col = (employ) ? "date_employ" : "date_uneploy";

            List<stat> getPost = new List<stat> { };

            try
            {
                connectOpen();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"
                    SELECT date(date_employ), count(date(date_employ)) 
                    FROM persons, status 
                    WHERE persons.status = status.id and
                    ("+ date_col + " between '" + start + "' and '" + finish + "') and status.name = '" + status + "';";
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    stat temp;
                    temp.date = (reader[0] != DBNull.Value) ? temp.date = Convert.ToDateTime(reader[0]) : null;
                    temp.count = Convert.ToInt32(reader[1]);

                    getPost.Add(temp);
                }

                
                connectClose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                connectError(ex);
            }

            return getPost;
        }
    }


}
