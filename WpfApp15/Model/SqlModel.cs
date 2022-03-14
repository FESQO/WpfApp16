using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using System.Data;
using WpfApp15.Tools;

namespace WpfApp15.Model
{
    public class SqlModel
    {
        private SqlModel() { }
        static SqlModel sqlModel;
        public static SqlModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SqlModel();
            return sqlModel;
        }

        internal List<curator> SelectCurator()
        {
            var curators = new List<curator>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `curator`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        curators.Add(new curator
                        {
                            ID = dr.GetInt32("id"),
                            FirstNameC = dr.GetString("firstName"),
                            LastNameC = dr.GetString("lastName"),
                            BirthdayC = dr.GetDateTime("birthday")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return curators;

        }

        internal List<Student> SelectStudent()
        {
            var students = new List<Student>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `student`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        students.Add(new Student
                        {
                            ID = dr.GetInt32("id"),
                            FirstName = dr.GetString("firstName"),
                            LastName = dr.GetString("lastName"),
                            PatronymicName = dr.GetString("patronymicName"),
                            GroupId = dr.GetInt32("group_id"),
                            Birthday = dr.GetDateTime("birthday")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return students;

        }

        internal List<Specials> SelectSpecial()
        {
            var specials = new List<Specials>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `specials`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        specials.Add(new Specials
                        {
                            ID = dr.GetInt32("id"),
                            TittleS = dr.GetString("title")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return specials;

        }

        public List<Discipline> SelectDiscipline()
        {
            var discipline = new List<Discipline>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `discipline`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        discipline.Add(new Discipline
                        {
                            ID = dr.GetInt32("id"),
                            TitleD = dr.GetString("title"),
                            prepod_id = dr.GetInt32("prepod_id")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return discipline;
        }

        internal List<Prepods> SelectPrepod()
        {
            var prepods = new List<Prepods>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `prepods`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        prepods.Add(new Prepods
                        {
                            ID = dr.GetInt32("id"),
                            firstNameP = dr.GetString("firstName"),
                            lastNameP = dr.GetString("lastName")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return prepods;

        }

        internal List<Journal> SelectJournalByDiscipline(Discipline selectedDiscipline)
        {
            int id = selectedDiscipline?.ID ?? 0;
            var journal = new List<Journal>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM journal j, student s WHERE j.student_id = s.id and j.discipline_id = {id}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var j = new Journal
                        {
                            ID = dr.GetInt32("id"),
                            Day = dr.GetDateTime("day"),
                            Value = dr.GetString("value"),
                            StudentId = dr.GetInt32("student_id"),
                            DisciplineId = dr.GetInt32("discipline_id")
                        };

                        j.Student = new Student
                        {
                            ID = dr.GetInt32(5),
                            FirstName = dr.GetString("firstName"),
                            LastName = dr.GetString("lastName"),
                            PatronymicName = dr.GetString("patronymicName"),
                            GroupId = dr.GetInt32("group_id"),
                            Birthday = dr.GetDateTime("birthday")
                        };
                        journal.Add(j);
                    }
                }
                mySqlDB.CloseConnection();
            }
            return journal;
        }

        internal List<Student> SelectStudentsByGroup(Group selectedGroup)
        {
            int id = selectedGroup?.ID ?? 0;
            var students = new List<Student>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `student` WHERE group_id = {id}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        students.Add(new Student
                        {
                            ID = dr.GetInt32("id"),
                            FirstName = dr.GetString("firstName"),
                            LastName = dr.GetString("lastName"),
                            PatronymicName = dr.GetString("patronymicName"),
                            GroupId = dr.GetInt32("group_id"),
                            Birthday = dr.GetDateTime("birthday")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return students;
        }

        internal List<Discipline> SelectDisciplinesByPrepod(Prepods selectedPrepod)
        {
            int id = selectedPrepod?.ID ?? 0;
            var disciplines = new List<Discipline>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `discipline` WHERE prepod_id = {id}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        disciplines.Add(new Discipline
                        {
                            ID = dr.GetInt32("id"),
                            TitleD = dr.GetString("title"),
                            prepod_id = dr.GetInt32("prepod_id")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return disciplines;
        }

        internal curator SelectCuratorByGroup(Group selectedGroup)
        {
            int id = selectedGroup?.curator_id ?? 0;
            curator curator = null;
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `curator` WHERE id = {id}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        curator = new curator
                        {
                            ID = dr.GetInt32("id"),
                            FirstNameC = dr.GetString("firstName"),
                            LastNameC = dr.GetString("lastName"),
                            BirthdayC = dr.GetDateTime("birthday")
                        };
                    }
                }
                mySqlDB.CloseConnection();
            }
            return curator;
        }


        //INSERT INTO `group` set title='1125', year = 2018;
        // возвращает ID добавленной записи
        public int Insert<T>(T value)
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateInsertQuery(table, values);
            var db = MySqlDB.GetDB();
            // лучше эти 2 запроса объединить в один с помощью транзакции
            int id = db.GetNextID(table);
            db.ExecuteNonQuery(query.Item1, query.Item2);
            return id;
        }
        // обновляет объект в бд по его id
        public void Update<T>(T value) where T : BaseDTO
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateUpdateQuery(table, values, value.ID);
            var db = MySqlDB.GetDB();
            db.ExecuteNonQuery(query.Item1, query.Item2);
        }

        public void Delete<T>(T value) where T : BaseDTO
        {
            var type = value.GetType();
            string table = GetTableName(type);
            var db = MySqlDB.GetDB();
            string query = $"delete from `{table}` where id = {value.ID}";
            db.ExecuteNonQuery(query);
        }

        public int GetNumRows(Type type)
        {
            string table = GetTableName(type);
            return MySqlDB.GetDB().GetRowsCount(table);
        }

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            return ((TableAttribute)tableAtrributes.First()).Table;
        }

        public List<Group> SelectGroupsRange(int skip, int count)
        {
            var groups = new List<Group>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `group` g, curator c, specials s WHERE g.curator_id = c.id AND g.special_id = s.id LIMIT { skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var g = new Group
                        {
                            ID = dr.GetInt32("id"),
                            Title = dr.GetString("title"),
                            Year = dr.GetInt32("year"),
                            curator_id = dr.GetInt32("curator_id"),
                            special_id = dr.GetInt32("special_id")
                        };

                        g.Curator = new curator
                        {
                            ID = dr.GetInt32("id"),
                            FirstNameC = dr.GetString("firstName"),
                            LastNameC = dr.GetString("lastName"),
                            BirthdayC = dr.GetDateTime("birthday")
                        };

                        g.Specials = new Specials
                        {
                            ID = dr.GetInt32("id"),
                            TittleS = dr.GetString("title")
                        };
                        groups.Add(g);
                    }
                }
                mySqlDB.CloseConnection();
            }
            return groups;
        }

        private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<(string, object)> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"INSERT INTO `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<(string, object)> values, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            stringBuilder.Append($" WHERE id = {id}");
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static List<MySqlParameter> InitParameters(List<(string, object)> values, StringBuilder stringBuilder)
        {
            var parameters = new List<MySqlParameter>();
            int count = 1;
            var rows = values.Select(s =>
            {
                parameters.Add(new MySqlParameter($"p{count}", s.Item2));
                return $"{s.Item1} = @p{count++}";
            });
            stringBuilder.Append(string.Join(',', rows));
            return parameters;
        }

        private static void GetMetaData<T>(T value, out string table, out List<(string, object)> values)
        {
            var type = value.GetType();
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            table = ((TableAttribute)tableAtrributes.First()).Table;
            values = new List<(string, object)>();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (columnAttributes.Length > 0)
                {
                    string column = ((ColumnAttribute)columnAttributes.First()).Column;
                    values.Add(new(column, prop.GetValue(value)));
                }
            }
        }
    }
}
