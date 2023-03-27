
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
    /// Taş Kırma
    /// </summary>
    public partial class StoneBreakUpRequestAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            chkDisXXXXXXRaporu.CheckedChanged += new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            StoneBreakUpProcedures.CellValueChanged += new TTGridCellEventDelegate(StoneBreakUpProcedures_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkDisXXXXXXRaporu.CheckedChanged -= new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            StoneBreakUpProcedures.CellValueChanged -= new TTGridCellEventDelegate(StoneBreakUpProcedures_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void chkDisXXXXXXRaporu_CheckedChanged()
        {
            #region StoneBreakUpRequestAcceptionForm_chkDisXXXXXXRaporu_CheckedChanged
            //   if (((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked)
            //            {
            //                
            //                if(this._StoneBreakUpRequest.Episode.Patient.UniqueRefNo == null)
            //                {
            //                    InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
            //                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
            //                    return;
            //                }
            //                
            //                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
            //TODO : MEDULA20140501
            //                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                
            //                _raporOkuTCKimlikNodanDVO.raporTuru="1";
            //                
            //                
            //                _raporOkuTCKimlikNodanDVO.tckimlikNo = this._StoneBreakUpRequest.Episode.Patient.UniqueRefNo.Value.ToString();
            //                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
            //                
            //                if (response != null)
            //                {
            //                    if (!response.sonucKodu.Equals(0))
            //                    {
            //                        InfoBox.Show("Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu);
            //                        return;
            //                    }
            //                    if (response.raporlar ==null)
            //                    {
            //                        InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
            //                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
            //                        return;
            //                    }
            //                    if(response.sonucKodu.Equals(0))
            //                    {
            //                        if(response.raporlar!=null && response.raporlar.Length>0)
            //                        {
            //                            bool isValid=false;
            //                            
            //                            MultiSelectForm multiSelectForm = new MultiSelectForm();
            //                            foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
            //                            {
            //                                if (item.tedaviRapor != null)
            //                                {
            //                                    
            //                                    if(item.tedaviRapor.tedaviRaporTuru==6  )
            //                                    {
            //                                        isValid=true;
            //                                        multiSelectForm.AddMSItem("Rapor Takip Numarası : " +item.raporTakipNo.ToString() +" Rapor Tarihi : "+ item.tedaviRapor.raporDVO.raporBilgisi.tarih,item.raporTakipNo.ToString());
            //                                    }
            //                                    
            //                                    
            //                                }
            //                            }
            //                            string mkey = multiSelectForm.GetMSItem(null, "İlgili Raporu Seçiniz", true);
            //                            if(isValid)
            //                            {
            //                                if (string.IsNullOrEmpty(mkey))
            //                                {
            //                                    InfoBox.Show("İlgili raporu seçmeden işleme devam edemezsiniz.");
            //                                    return;
            //                                }
            //                                string raporTakipNo = multiSelectForm.MSSelectedItemObject as string;
            //                            }
            //                            else
            //                            {
            //                                InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
            //                                ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
            //                                return;
            //                            }
            //                            
            //                            
            //                            if(!string.IsNullOrEmpty(mkey))
            //                            {
            //                                MedulaRaporTakipNo.Visible=true;
            //                                labelMedulaRaporTakipNo.Visible=true;
            //                                MedulaRaporTakipNo.Text=mkey;
            //                                
            //                            }
            //                            else
            //                            {
            //                                MedulaRaporTakipNo.Visible=false;
            //                                labelMedulaRaporTakipNo.Visible=false;
            //                            }
            //                        }
            //                        else{
            //                            InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
            //                            ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
            //                            return;
            //                        }
            //                    }
            //                }
            //            }
            var a = 1;
            #endregion StoneBreakUpRequestAcceptionForm_chkDisXXXXXXRaporu_CheckedChanged
        }

        private void StoneBreakUpProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region StoneBreakUpRequestAcceptionForm_StoneBreakUpProcedures_CellValueChanged
   if (StoneBreakUpProcedures.CurrentCell.OwningColumn.Name == "ProcedureObject")
            {
                  StoneBreakUpProcedure sbUpPro = (StoneBreakUpProcedure)((ITTGridRow)StoneBreakUpProcedures.Rows[rowIndex]).TTObject;
                  if(sbUpPro.ProcedureObject is StoneBreakUpDefinition)
                  {
                      StoneBreakUpDefinition sBUp = (StoneBreakUpDefinition)sbUpPro.ProcedureObject;
                      sbUpPro.NumberOfProcedure = sBUp.Seance;
                  }                 
            }
#endregion StoneBreakUpRequestAcceptionForm_StoneBreakUpProcedures_CellValueChanged
        }

        protected override void PreScript()
        {
#region StoneBreakUpRequestAcceptionForm_PreScript
    base.PreScript();
#endregion StoneBreakUpRequestAcceptionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region StoneBreakUpRequestAcceptionForm_PostScript
    base.PostScript(transDef);
              if(transDef!=null)
            {
                if(transDef.ToStateDefID==StoneBreakUpRequest.States.Procedure)
                {
                    foreach(StoneBreakUpProcedure stoneBreakUpProcedure in this._StoneBreakUpRequest.StoneBreakUpProcedures)
                    {
                        this.ApplyProcedure(stoneBreakUpProcedure);
                    }
                }
                
            }
#endregion StoneBreakUpRequestAcceptionForm_PostScript

            }
                }
}