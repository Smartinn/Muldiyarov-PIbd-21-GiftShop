using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace GiftShopView
{
    public partial class FPutStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStorageService serviceS;

        private readonly IElementService serviceE;

        private readonly IMainService serviceM;

        public FPutStorage(IStorageService serviceS, IElementService serviceE, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceE = serviceE;
            this.serviceM = serviceM;
        }

        private void FPutStorage_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElementViewModel> listC = serviceE.GetList();
                if (listC != null)
                {
                    comboBoxElement.DisplayMember = "ElementName";
                    comboBoxElement.ValueMember = "Id";
                    comboBoxElement.DataSource = listC;
                    comboBoxElement.SelectedItem = null;
                }
                List<StorageViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxStorage.DisplayMember = "StorageName";
                    comboBoxStorage.ValueMember = "Id";
                    comboBoxStorage.DataSource = listS;
                    comboBoxStorage.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxElement.SelectedValue == null)
            {
                MessageBox.Show("Выберите элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.PutElementInStorage(new StorageElementCoverModel
                {
                    ElementId = Convert.ToInt32(comboBoxElement.SelectedValue),
                    StorageId = Convert.ToInt32(comboBoxStorage.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
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
