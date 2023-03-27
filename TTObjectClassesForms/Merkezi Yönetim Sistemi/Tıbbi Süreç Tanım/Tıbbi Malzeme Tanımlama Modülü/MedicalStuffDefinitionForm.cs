
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
    public partial class MedicalStuffDefinitionForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnUpdate.Click += new TTControlEventDelegate(btnUpdate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnUpdate.Click -= new TTControlEventDelegate(btnUpdate_Click);
            base.UnBindControlEvents();
        }
        private void btnUpdate_Click()
        {
            TibbiMalzemeYardimciIslemler.butKodlariCevapDVO service = TibbiMalzemeYardimciIslemler.WebMethods.sutMalzemeSorgulaSync(TTObjectClasses.Sites.SiteLocalHost);

            if (service.sonucKodu == "0000")
            {
                foreach (var item in service.malzemeListesi)
                {
                    TTObjectContext cnx = new TTObjectContext(false);

                    if (true)//item.Actýve == true
                    {
                        ITTListViewItem listViewItem = MedicalStuffListView.Items.Add(item.adi.ToString());
                        listViewItem.SubItems.Add(item.butKodu.ToString());
                        listViewItem.SubItems.Add(item.malzemeGrubuAdi.ToString());
                        listViewItem.SubItems.Add(item.turu.ToString());
                        listViewItem.Tag = item.butId;

                        var medicalStuffDefinitionList = MedicalStuffDefinition.GetByButID(cnx, item.butKodu);

                        if (medicalStuffDefinitionList.Count == 0)
                        {
                            MedicalStuffDefinition medicalStuffDefinition = (MedicalStuffDefinition)cnx.CreateObject("MEDICALSTUFFDEFINITION");
                            medicalStuffDefinition.Active = true;
                            medicalStuffDefinition.Code = item.butKodu;
                            medicalStuffDefinition.Name = item.adi;
                            medicalStuffDefinition.MedicalStuffGroup = MedicalStuffGroup.GetMedicalStuffGroupByCode(cnx, item.malzemeGrubuKodu).FirstOrDefault();
                            cnx.Save();
                        }
                    }
                    else//pasif
                    {
                        //if (MedicalStuffDefinition.IsSKRSActive(item.butKodu).Count == 0)//pasif yap
                        {
                            MedicalStuffDefinition skrsSistemKodlari = (MedicalStuffDefinition)cnx.GetObject(new Guid(item.butKodu), "MEDICALSTUFFDEFINITION");
                            skrsSistemKodlari.Active = false;
                            cnx.Save();
                        }
                    }

                    cnx.Dispose();
                }
            }
        }

        private void FillMedicalStuffList()
        {
            TTObjectContext context = new TTObjectContext(false);
            this.MedicalStuffListView.Items.Clear();
            IList medicalStuffList = context.QueryObjects("MEDICALSTUFFDEFINITION",null);
            //foreach (MedicalStuffDefinition medicalStuff in medicalStuffList)
            //{
            //    ListViewItem item = new ListViewItem(medicalStuff.Name);
            //    item.Tag = medicalStuff.ObjectID;
             

            //    this.MedicalStuffListView.Items.Add(item);
            //}
        }

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.FillMedicalStuffList();
        }
    }
}