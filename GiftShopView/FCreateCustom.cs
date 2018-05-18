using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace GiftShopView
{
    public partial class FCreateCustom : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICustomerService serviceC;

        private readonly IGiftService serviceG;

        private readonly IMainService serviceM;

        public FCreateCustom(ICustomerService serviceC, IGiftService serviceG, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceG = serviceG;
            this.serviceM = serviceM;
        }

        private void FCreateCustom_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxCustomer.DisplayMember = "CustomerFIO";
                    comboBoxCustomer.ValueMember = "Id";
                    comboBoxCustomer.DataSource = listC;
                    comboBoxCustomer.SelectedItem = null;
                }
                List<GiftViewModel> listP = serviceG.GetList();
                if (listP != null)
                {
                    comboBoxGift.DisplayMember = "GiftName";
                    comboBoxGift.ValueMember = "Id";
                    comboBoxGift.DataSource = listP;
                    comboBoxGift.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxGift.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxGift.SelectedValue);
                    GiftViewModel gift = serviceG.GetElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * (int)gift.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxGift_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxGift.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.CreateCustom(new CustomCoverModel
                {
                    CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    GiftId = Convert.ToInt32(comboBoxGift.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Summa = Convert.ToInt32(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
