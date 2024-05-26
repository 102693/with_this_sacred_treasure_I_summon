using System;
using System.Windows.Forms;

namespace with_this_sacred_treasure_I_summon
{
    public partial class Yuji_Itadori : Form
    {
        public Yuji_Itadori()
        {
            InitializeComponent();
        }

        private void Yuji_Itadori_Load(object sender, EventArgs e)
        {
            // Загрузка заказов при загрузке формы
            LoadOrders();
        }

        private void LoadOrders()
        {
            // Предположим, что у вас есть метод GetOrdersFromDatabase(),
            // который возвращает список заказов из базы данных
            var orders = GetOrdersFromDatabase();
            dataGridView1.DataSource = orders;
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем идентификатор выбранного заказа
                var orderId = dataGridView1.SelectedRows[0].Cells["OrderId"].Value;

                // Предположим, что у вас есть метод ChangeOrderStatus(),
                // который изменяет статус заказа в базе данных
                ChangeOrderStatus(orderId, "Готов");

                // Обновляем список заказов после изменения статуса
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Выберите заказ для изменения статуса.");
            }
        }

        // Метод для загрузки заказов из базы данных
        private object GetOrdersFromDatabase()
        {
            // Здесь должна быть реализация загрузки заказов из базы данных
            // и возврат списка заказов
            throw new NotImplementedException();
        }

        // Метод для изменения статуса заказа в базе данных
        private void ChangeOrderStatus(object orderId, string newStatus)
        {
            // Здесь должна быть реализация изменения статуса заказа в базе данных
            throw new NotImplementedException();
        }
    }
}

