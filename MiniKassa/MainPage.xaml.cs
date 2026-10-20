using System.Globalization;
using System.Runtime.CompilerServices;

namespace MiniKassa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            if (ProductPicker.SelectedItem == null) //проверка на выбор товара
            {
                await DisplayAlertAsync("Ошибка", "Выбери товар из списка!", "Хорошо");
                return;
            }

            //проверка на количество
            bool isNumber = int.TryParse(QuantityEntry.Text, out int quantity);
            if (!isNumber || quantity < 1 || quantity > 100)
            {
                await DisplayAlertAsync("Ошибка", "Введите число от 1 до 100", "Хорошо");
                return;
            }

            string selectedProduct = ProductPicker.SelectedItem.ToString(); //Определение цены товара
            int price = 0;

            switch (selectedProduct)
            {
                case "Кофе (150 руб.)":
                    price = 150;
                    break;
                case "Чай (100 руб.)":
                    price = 100;
                    break;
                case "Круассан (200 руб.)":
                    price = 200;
                    break;
                case "Сэндвич (250 руб.)":
                    price = 250;
                    break;
            }

            //Сумма и результат
            int total = price * quantity;
            ResultLabel.Text = $"Вы выбрали {selectedProduct} \nКоличество {quantity} шт. \nИтого:{total} руб.";
        }
        private void OnResetClicked(object sender, EventArgs e)
        {
            ProductPicker.SelectedItem = null;
            QuantityEntry.Text = "";
            ResultLabel.Text = "";

        }

    }
}
