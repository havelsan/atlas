
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
    public partial class MedulaEtkinMaddeListesiSorgulama : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdClose.Click += new TTControlEventDelegate(cmdClose_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdClose.Click -= new TTControlEventDelegate(cmdClose_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void cmdClose_Click()
        {
#region MedulaEtkinMaddeListesiSorgulama_cmdClose_Click
   Close();
#endregion MedulaEtkinMaddeListesiSorgulama_cmdClose_Click
        }

        private void ttbutton1_Click()
        {
#region MedulaEtkinMaddeListesiSorgulama_ttbutton1_Click
   //   if (string.IsNullOrEmpty(edtDoktorTC.Text))
//            {
//                InfoBox.Show("Lütfen Doktor T.C. Alanını Doldurunuz.");
//            }
//            else
//            {
//                
//                YardimciIslemler.EtkinMaddeListesiSorguIstekDVO request = new YardimciIslemler.EtkinMaddeListesiSorguIstekDVO();
//                request.doktorTcKimlikNo = (long)Convert.ToDouble(edtDoktorTC.Text);
//                request.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
//             
//                DrugListWebCaller callerObject = new DrugListWebCaller();
//                callerObject.ObjectID = this.ObjectID;
//
//                //YardimciIslemler.EtkinMaddeListesiSorguCevapDVO response = YardimciIslemler.WebMethods.etkinMaddeListesiSorgula(Sites.SiteLocalHost,callerObject, request);
//
//                TTMessage responseMesage = YardimciIslemler.WebMethods.etkinMaddeListesiSorgula(Sites.SiteLocalHost,callerObject, request);
//                
//                gridEtkinMadde.Rows.Clear();
//                
//                if (responseMesage.ReturnValue != null)
//                {
//                    var response = responseMesage.ReturnValue;
//                    if (!String.IsNullOrEmpty(response.sonucKodu))
//                    {
//                        this.txtSonucKodu.Text = response.sonucKodu;
//                        this.txtSonucMesaji.Text = response.sonucMesaji;
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            if (response.etkinMaddeListesi  == null)
//                            {
//                                InfoBox.Show("Etkin Madde Listesi Bulunamadı", MessageIconEnum.InformationMessage);
//                                return;
//                            }
//                            
//                            foreach (YardimciIslemler.EtkinMaddeDVO etkinMaddeDVO in response.etkinMaddeListesi)
//                            {
//
//                                ITTGridRow newRow = gridEtkinMadde.Rows.Add();
//                                newRow.Cells[etkinMaddeKodu.Name].Value = etkinMaddeDVO.kodu;
//                                newRow.Cells[etkinMaddeAdi.Name].Value = etkinMaddeDVO.adi;
//                                //newRow.Cells[adetMiktar.Name].Value = etkinMaddeDVO.;
//                                newRow.Cells[icerikMiktari.Name].Value = etkinMaddeDVO.icerikMiktari;
//                                newRow.Cells[form.Name].Value = etkinMaddeDVO.formu;
//                                
//                            }
//                        }
//                    }
//                    else
//                    {
//                        InfoBox.Show("Medula' dan sonuç alınamadı", MessageIconEnum.InformationMessage);
//                        return;
//                    }
//                }
//                
//                
//
//
//            }
#endregion MedulaEtkinMaddeListesiSorgulama_ttbutton1_Click
        }

#region MedulaEtkinMaddeListesiSorgulama_Methods
        protected override void OnLoad(EventArgs e)
        {
            ResUser currentUser = Common.CurrentResource;
            ((ITTObject)currentUser).Refresh();
            if( currentUser.UniqueNo == null || string.IsNullOrEmpty(currentUser.UniqueNo))
            {
                this.edtDoktorTC.Enabled = true;
            }
            else
            {
                this.edtDoktorTC.Text =currentUser.ErecetePassword;
                this.edtDoktorTC.Enabled = false;
            }
        }
        
           [Serializable]
        public class DrugListWebCaller : IWebMethodCallback
        {
            private Guid _objectID;
            public Guid ObjectID
            {
                get { return _objectID; }
                set { _objectID = value; }
            }

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (messageException == null && returnValue != null)
                {
                    if (returnValue is YardimciIslemler.etkinMaddeListesiSorguCevapDVO)
                    {
                        if (((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).sonucKodu.Equals("0"))
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.etkinMaddeListesiSorguCevapDVO responseList =new YardimciIslemler.etkinMaddeListesiSorguCevapDVO();
                            responseList.etkinMaddeListesi = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).etkinMaddeListesi;
                            responseList.sonucMesaji=((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.etkinMaddeListesiSorguCevapDVO responseList = new YardimciIslemler.etkinMaddeListesiSorguCevapDVO();
                            responseList.etkinMaddeListesi = null;
                            responseList.sonucMesaji = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();
                        }
                    }

                }
                return false;
            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }
        }
        
#endregion MedulaEtkinMaddeListesiSorgulama_Methods
    }
}