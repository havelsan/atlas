
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Reçete Detayları Oluşturma
    /// </summary>
    public partial class CreatePresDetailActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbuttonSorgula.Click += new TTControlEventDelegate(ttbuttonSorgula_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbuttonSorgula.Click -= new TTControlEventDelegate(ttbuttonSorgula_Click);
            base.UnBindControlEvents();
        }

        private void ttbuttonSorgula_Click()
        {
#region CreatePresDetailActionForm_ttbuttonSorgula_Click
   int startNo = Convert.ToInt32(basNo.Text);
            int endNo = Convert.ToInt32(bitNo.Text);
            string seriNu = seriNo.Text;
            if(_CreatePresDetailAction.Material == null)
                throw new Exception("Reçete malzemesini seçmeden reçete detayı oluşturamazsınız.");

            if (_CreatePresDetailAction.Amount > 0)
            {

                if (basNo != null && bitNo != null && seriNo.Text != null)
                {
                    if (startNo <= endNo)
                    {
                        for (int i = startNo; startNo <= endNo; startNo++)
                        {
                            PresActionDetail presActionDetail = new PresActionDetail(_CreatePresDetailAction.ObjectContext);
                            presActionDetail.SerialNo = seriNu;
                            presActionDetail.VolumeNo = startNo.ToString();
                            presActionDetail.CreatePresDetailAction = _CreatePresDetailAction;
                        }
                    }
                    else
                    {
                        throw new Exception("Başlangıç numarası  bitiş numarasından büyük olamaz.");
                    }
                }
                else
                {

                    throw new Exception("Başlangıç numarası , bitiş numarası , seri numarası boş geçilemez.");
                }
            }
            else
            {
                throw new Exception("0 mevcutlu malzemeye detay oluşturamazsınız.");
            }
#endregion CreatePresDetailActionForm_ttbuttonSorgula_Click
        }

        protected override void PreScript()
        {
#region CreatePresDetailActionForm_PreScript
    base.PreScript();
#endregion CreatePresDetailActionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region CreatePresDetailActionForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            MainStoreDefinition mainStoreDefinition = new MainStoreDefinition();
            IList mainStores = _CreatePresDetailAction.ObjectContext.QueryObjects("MAINSTOREDEFINITION", "ISACTIVE = 1");

            if (mainStores.Count == 0)
                throw new TTException("İşlemin yapılacağı saymanlık deposu bulunamadığından işleme devam edemezsiniz.");
            if (mainStores.Count == 1)
                mainStoreDefinition = (MainStoreDefinition)mainStores[0];
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition  ms in mainStores)
                {
                    mSelectForm.AddMSItem(ms.Name, ms.ObjectID.ToString(), ms);
                }
                string mkey = mSelectForm.GetMSItem(this, "İlgili Saymanlık Deposunu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                {
                    throw new TTException("İşlemin yapılacağı saymanlık deposu seçilmeden işleme devam edemezsiniz.");
                }
                else
                {
                    mainStoreDefinition = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                }
            }
            _CreatePresDetailAction.MainStoreDefinition = mainStoreDefinition;
#endregion CreatePresDetailActionForm_ClientSidePreScript

        }
    }
}