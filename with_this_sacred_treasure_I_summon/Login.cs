using with_this_sacred_treasure_I_summon;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace with_this_sacred_treasure_I_summon
{
    public partial class Gojo_Satoru : Form
    {
        public Gojo_Satoru()
        {
            InitializeComponent();

            TestDatabaseConnection();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            using (var conn = await Database.GetConnectionAsync())
            {
                try
                {
                    
                    string sql = "SELECT * FROM Users WHERE username=@username AND password=@password";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        string username = txtUsername.Text;
                        string password = txtPassword.Text;

                        // Логирование для отладки
                        Console.WriteLine($"Username: {username}");
                        Console.WriteLine($"Password: {password}");

                    
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        using (var rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (await rdr.ReadAsync())
                            {
                                string role = rdr["role"].ToString();
                                MessageBox.Show($"Добро пожаловать, {rdr["name"].ToString()}!");

                                this.Hide();
                                if (role == "администратор")
                                {
                                    Console.WriteLine("poehaly");
                                    Megumi_Fushiguro adminForm = new Megumi_Fushiguro();
                                    adminForm.Visible = true; // Устанавливаем свойство Visible в true
                                    adminForm.Activate(); // Активируем форму
                                    adminForm.Show();
                                    Console.WriteLine("poehaly");
                                }
                                else if (role == "официант")
                                {
                                    Yuta_Okkotsu waiterForm = new Yuta_Okkotsu();
                                    waiterForm.Show();
                                }
                                else if (role == "повар")
                                {
                                    Yuji_Itadori cookForm = new Yuji_Itadori();
                                    cookForm.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("вот ты и попался");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void TestDatabaseConnection()
        {
            try
            {
                bool isConnected = await Database.TestConnectionAsync();
                if (isConnected)
                {
                    MessageBox.Show("Подключение к базе данных успешно установлено.");
                }
                else
                {
                    MessageBox.Show("Не удалось установить подключение к базе данных.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке подключения к базе данных: " + ex.Message);
            }
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}