
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
    public partial class InpatientPrescriptionBaseForm : PrescriptionBaseForm
    {
#region InpatientPrescriptionBaseForm_ClientSideMethods
        public void CancelERecete(bool ExistsEHUUOnay)
        {
            
            if (!string.IsNullOrEmpty(_InpatientPrescription.EReceteNo))
            {
                Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
                callerObject.ObjectID = _InpatientPrescription.ObjectID;

                if (string.IsNullOrEmpty(_InpatientPrescription.ERecetePassword))
                    throw new TTException("Doktorun E reçete şifresi girilmemiş.");
                
                if ( _InpatientPrescription.IsSignedPrescription() )
                {
//                    EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, _InpatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _InpatientPrescription.ERecetePassword.ToString(), PrescriptionBaseForm.GetEReceteSignedDelete(_InpatientPrescription));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
                }
                else
                {
//                    EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, _InpatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _InpatientPrescription.ERecetePassword.ToString(), Prescription.GetEReceteDelete(_InpatientPrescription));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
                }
                if(ExistsEHUUOnay)
                {
                    TTMessage resOnay = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, _InpatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _InpatientPrescription.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(_InpatientPrescription));
                    if (string.IsNullOrEmpty(_InpatientPrescription.EHURecetePassword) == false && string.IsNullOrEmpty(_InpatientPrescription.EHUUniqueNo) == false)
                    {
                        long uniqueNo = (long)Convert.ToDouble(_InpatientPrescription.EHUUniqueNo);
                        TTMessage ehuOnayIptal = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, _InpatientPrescription.EHUUniqueNo, _InpatientPrescription.EHURecetePassword, callerObject, Prescription.GetEreceteEHUCancelRequest(_InpatientPrescription, uniqueNo));
                    }
                } else
                {
                    EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, _InpatientPrescription.ProcedureDoctor.Person.UniqueRefNo.ToString(), _InpatientPrescription.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(_InpatientPrescription));
                }
                
            }
        }

        public void SendSignedEreceteEHUApproval(ResUser currentUser)
        {
            long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
//            EReceteIslemleri.imzaliEreceteOnayCevapDVO ehuOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), _InpatientPrescription.ERecetePassword.ToString(), PrescriptionBaseForm.GetEreceteSignedEHUApprovalRequest(_InpatientPrescription, uniqueNo));
//            if (ehuOnay != null)
//            {
//                if (ehuOnay.sonucKodu.Equals("0000"))
//                {
//                    InfoBox.Alert(_InpatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete EHU onayı alınmıştır.", MessageIconEnum.InformationMessage);
//                    _InpatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde EHU onayı almıştır.";
//                    _InpatientPrescription.EHUUniqueNo = currentUser.UniqueNo.ToString();
//
//                    if (_InpatientPrescription.IsRepeated.HasValue && (bool)_InpatientPrescription.IsRepeated.Value)
//                    {
//                        TTObjectContext context = new TTObjectContext(false);
//                        ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
//                        updatedUser.ErecetePassword = _InpatientPrescription.EHURecetePassword;
//                        context.Save();
//                        ((ITTObject)currentUser).Refresh();
//                    }
//                }
//                else
//                {
//                    if (!string.IsNullOrEmpty(ehuOnay.uyariMesaji))
//                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + ehuOnay.uyariMesaji);
//                    else
//                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji);
//                }
//            }
        }
        
#endregion InpatientPrescriptionBaseForm_ClientSideMethods
    }
}