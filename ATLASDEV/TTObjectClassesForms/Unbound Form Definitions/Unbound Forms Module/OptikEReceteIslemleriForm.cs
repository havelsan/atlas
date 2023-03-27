
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
    public partial class OptikEReceteIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            grdPrescriptions.CellContentClick += new TTGridCellEventDelegate(grdPrescriptions_CellContentClick);
            cmdQuery.Click += new TTControlEventDelegate(cmdQuery_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            grdPrescriptions.CellContentClick -= new TTGridCellEventDelegate(grdPrescriptions_CellContentClick);
            cmdQuery.Click -= new TTControlEventDelegate(cmdQuery_Click);
            base.UnBindControlEvents();
        }

        private void grdPrescriptions_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region OptikEReceteIslemleri_grdPrescriptions_CellContentClick
   if(grdPrescriptions.CurrentCell != null && grdPrescriptions.CurrentCell.OwningColumn.Name == DeletePrescription.Name)
            {
                OptikReceteIslemleri.ereceteSilDVO _ereceteSilDVO = new OptikReceteIslemleri.ereceteSilDVO();
                _ereceteSilDVO.doktorTcKimlikNo = Common.CurrentUser.UniqueRefNo.ToString();
                _ereceteSilDVO.eReceteNo = grdPrescriptions.CurrentCell.OwningRow.Cells[EReceteNo.Name].Value.ToString();
                _ereceteSilDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                OptikReceteIslemleri.sonucDVO response = OptikReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), Common.CurrentResource.ErecetePassword, _ereceteSilDVO);
                
                if(response != null)
                {
                    if (response.sonucKodu.Equals(0))
                    {
                        InfoBox.Show("Reçete Başarılı Bir Şekilde Silinmiştir.", MessageIconEnum.InformationMessage);
                        grdPrescriptions.Rows.Clear();
                    }
                    else
                    {
                        InfoBox.Show(response.sonucKodu + " " + response.sonucMesaji, MessageIconEnum.ErrorMessage);
                    }
                }
                else
                {
                    InfoBox.Show("Medula ile bağlantı sağlanamadı", MessageIconEnum.ErrorMessage);
                }
                
            }
#endregion OptikEReceteIslemleri_grdPrescriptions_CellContentClick
        }

        private void cmdQuery_Click()
        {
#region OptikEReceteIslemleri_cmdQuery_Click
   if(Common.CurrentResource == null)
            {
                InfoBox.Show("Geçersiz kaynak", MessageIconEnum.ErrorMessage);
                return;
            }

            if(string.IsNullOrEmpty(Common.CurrentResource.ErecetePassword))
            {
                InfoBox.Show("Kullanıcının e-reçete boş olamaz", MessageIconEnum.ErrorMessage);
                return;
            }
            
            grdPrescriptions.Rows.Clear();
            Patient patient = (Patient)PatientSearchList.SelectedObject;
            OptikReceteIslemleri.ereceteListeSorguIstekDVO _ereceteListeSorguIstekDVO = new OptikReceteIslemleri.ereceteListeSorguIstekDVO();
            _ereceteListeSorguIstekDVO.doktorTcKimlikNo = Convert.ToInt64(Common.CurrentUser.UniqueRefNo);
            _ereceteListeSorguIstekDVO.hastaTcKimlikNo = Convert.ToInt64(patient.UniqueRefNo);
            _ereceteListeSorguIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            OptikReceteIslemleri.ereceteListeSorguCevapDVO response = OptikReceteIslemleri.WebMethods.ereceteListeSorgu(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), Common.CurrentResource.ErecetePassword, _ereceteListeSorguIstekDVO);
            
            if(response != null && response.ereceteListesi != null)
            {
                OptikReceteIslemleri.receteTesisDVO[] sonucList = response.ereceteListesi;
                if(sonucList.Length == 0)
                {
                    InfoBox.Show("Bu hastaya ait optik e-reçete kaydı bulunamıştır.", MessageIconEnum.ErrorMessage);
                }
                else
                {
                    foreach(OptikReceteIslemleri.receteTesisDVO recete in response.ereceteListesi)
                    {
                        ITTGridRow newRow = grdPrescriptions.Rows.Add();
                        switch(recete.receteTipi)
                        {
                            case "N":
                                newRow.Cells[ReceteTipi.Name].Value = "Normal";
                                break;
                            case "T":
                                newRow.Cells[ReceteTipi.Name].Value = "Teleskopik";
                                break;
                            case "L":
                                newRow.Cells[ReceteTipi.Name].Value = "Lens";
                                break;
                            case "K":
                                newRow.Cells[ReceteTipi.Name].Value = "Keratakonuslens";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.provizyonTipi)
                        {
                            case "N":
                                newRow.Cells[ProvizyonTipi.Name].Value = "Normal";
                                break;
                            case "D":
                                newRow.Cells[ProvizyonTipi.Name].Value = "Doğal Afet";
                                break;
                            case "T":
                                newRow.Cells[ProvizyonTipi.Name].Value = "Trafik Kazası";
                                break;
                            case "I":
                                newRow.Cells[ProvizyonTipi.Name].Value = "İş Kazası";
                                break;
                            case "Y":
                                newRow.Cells[ProvizyonTipi.Name].Value = "Yurtdışı";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.gozlukTuru1)
                        {
                            case "U":
                                newRow.Cells[GozlukTuru1.Name].Value = "Uzak";
                                break;
                            case "Y":
                                newRow.Cells[GozlukTuru1.Name].Value = "Yakın";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.gozlukTuru2)
                        {
                            case "U":
                                newRow.Cells[GozlukTuru2.Name].Value = "Uzak";
                                break;
                            case "Y":
                                newRow.Cells[GozlukTuru2.Name].Value = "Yakın";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.camTipi1)
                        {
                            case "D":
                                newRow.Cells[CamTipi1.Name].Value = "Düz";
                                break;
                            case "O":
                                newRow.Cells[CamTipi1.Name].Value = "Organik";
                                break;
                            case "B":
                                newRow.Cells[CamTipi1.Name].Value = "Bifocal-Progresif";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.camTipi2)
                        {
                            case "D":
                                newRow.Cells[CamTipi2.Name].Value = "Düz";
                                break;
                            case "O":
                                newRow.Cells[CamTipi2.Name].Value = "Organik";
                                break;
                            case "B":
                                newRow.Cells[CamTipi2.Name].Value = "Bifocal-Progresif";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.camRengi1)
                        {
                            case "S":
                                newRow.Cells[CamRengi1.Name].Value = "Seçiniz";
                                break;
                            case "C":
                                newRow.Cells[CamRengi1.Name].Value = "Colormatik";
                                break;
                            case "B":
                                newRow.Cells[CamRengi1.Name].Value = "Beyaz";
                                break;
                            default:
                                break;
                        }
                        
                        switch(recete.camRengi2)
                        {
                            case "S":
                                newRow.Cells[CamRengi2.Name].Value = "Seçiniz";
                                break;
                            case "C":
                                newRow.Cells[CamRengi2.Name].Value = "Colormatik";
                                break;
                            case "B":
                                newRow.Cells[CamRengi2.Name].Value = "Beyaz";
                                break;
                            default:
                                break;
                        }
                        
                        newRow.Cells[TakipNo.Name].Value = recete.takipNo;
                        newRow.Cells[ReceteTarihi.Name].Value = recete.receteTarihi;
                        newRow.Cells[ProtokolNo.Name].Value = recete.protokolNo;
                        newRow.Cells[ReceteTeshis.Name].Value = recete.receteTeshis;
                        newRow.Cells[TesisKodu.Name].Value = recete.tesisKodu;
                        newRow.Cells[DrTescilNo.Name].Value = recete.drTescilNo;
                        newRow.Cells[DrTCKimlikNo.Name].Value = recete.doktorTcKimlikNo;
                        newRow.Cells[EReceteNo.Name].Value = recete.eReceteNo;
                        newRow.Cells[SagSferik1.Name].Value = recete.sagSferik1;
                        newRow.Cells[SagSilendirik1.Name].Value = recete.sagSilendirik1;
                        newRow.Cells[SagAks1.Name].Value = recete.sagAks1;
                        newRow.Cells[SolSferik1.Name].Value = recete.solSferik1;
                        newRow.Cells[SolSilendirik1.Name].Value = recete.solSilendirik1;
                        newRow.Cells[SolAks1.Name].Value = recete.solAks1;
                        newRow.Cells[SagSferik2.Name].Value = recete.sagSferik2;
                        newRow.Cells[SagSilendirik2.Name].Value = recete.sagSilendirik2;
                        newRow.Cells[SagAks2.Name].Value = recete.sagAks2;
                        newRow.Cells[SolSferik2.Name].Value = recete.solSferik2;
                        newRow.Cells[SolSilendirik2.Name].Value = recete.solSilendirik2;
                        newRow.Cells[SolAks2.Name].Value = recete.solAks2;
                    }
                }
            }
            else
            {
                InfoBox.Show("Medula ile bağlantı sağlanamadı", MessageIconEnum.ErrorMessage);
            }
#endregion OptikEReceteIslemleri_cmdQuery_Click
        }
    }
}