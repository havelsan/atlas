
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
    /// Anlaşma Tanımı
    /// </summary>
    public partial class ProtocolForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            btnSearchInProcExceptions.Click += new TTControlEventDelegate(btnSearchInProcExceptions_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnSearchInProcExceptions.Click -= new TTControlEventDelegate(btnSearchInProcExceptions_Click);
            base.UnBindControlEvents();
        }

        private void btnSearchInProcExceptions_Click()
        {
#region ProtocolForm_btnSearchInProcExceptions_Click
   if (this.SearchProcedure.SelectedObject != null)
            {
                IList exceptionProcedureList = ProtocolExceptionProcedureDefinition.GetByProtocolAndProcedure(this._ProtocolDefinition.ObjectContext, this._ProtocolDefinition.ObjectID.ToString(), this.SearchProcedure.SelectedObject.ObjectID.ToString());
                if (exceptionProcedureList.Count > 0)
                {
                    string exceptionDetails = string.Empty;
                    foreach (ProtocolExceptionProcedureDefinition exceptionProcedure in exceptionProcedureList)
                    {
                        exceptionDetails += "Hizmet : " + exceptionProcedure.ProcedureObject.Code + " " + exceptionProcedure.ProcedureObject.Name + "   (" + exceptionProcedure.ProcedureObject.ObjectID.ToString() + ")\r\n";
                        exceptionDetails += "Hasta Tutarı : " + exceptionProcedure.PatientPrice.ToString() + "\r\n";
                        exceptionDetails += "Kurum Tutarı : " + exceptionProcedure.PayerPrice.ToString() + "\r\n";
                        exceptionDetails += "Fiyat Listesi : " + (exceptionProcedure.PricingList != null ? exceptionProcedure.PricingList.Name : string.Empty) + "\r\n";
                        exceptionDetails += "F.L. Çarpan : " + (exceptionProcedure.PricingListMultiplier != null ? exceptionProcedure.PricingListMultiplier.Name : string.Empty) + "\r\n";
                        exceptionDetails += "Alternatif Fiyat Listesi : " + (exceptionProcedure.SecondPricingList != null ? exceptionProcedure.SecondPricingList.Name : string.Empty) + "\r\n";
                        exceptionDetails += "A.F.L. Çarpan : " + (exceptionProcedure.SecondPricingListMultiplier != null ? exceptionProcedure.SecondPricingListMultiplier.Name : string.Empty) + "\r\n";
                        exceptionDetails += "Ayaktan İndirim Oranı : " + exceptionProcedure.OutPatientDiscountPercent.ToString() + "\r\n";
                        exceptionDetails += "Ayaktan Hasta Payı : " + exceptionProcedure.OutPatientPatientPercent.ToString() + "\r\n";
                        exceptionDetails += "Ayaktan Kurum Payı : " + exceptionProcedure.OutPatientPayerPercent.ToString() + "\r\n";
                        exceptionDetails += "Yatan İndirim Oranı : " + exceptionProcedure.InPatientDiscountPercent.ToString() + "\r\n";
                        exceptionDetails += "Yatan Hasta Payı : " + exceptionProcedure.InPatientPatientPercent.ToString() + "\r\n";
                        exceptionDetails += "Yatan Kurum Payı : " + exceptionProcedure.InPatientPayerPercent.ToString() + "\r\n";
                        exceptionDetails += "Başlangıç Yaşı : " + (exceptionProcedure.StartAge.HasValue ? exceptionProcedure.StartAge.ToString() : string.Empty) + "\r\n";
                        exceptionDetails += "Bitiş Yaşı : " + (exceptionProcedure.EndAge.HasValue ? exceptionProcedure.EndAge.ToString() : string.Empty) + "\r\n\r\n";
                        
                    }
                    InfoBox.Show(exceptionDetails, MessageIconEnum.InformationMessage);
                }
                else
                    InfoBox.Show("Seçilen hizmet istisnalar içerisinde bulunamadı.", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("İstisnalar içerisinde aranacak hizmeti seçiniz.", MessageIconEnum.WarningMessage);
#endregion ProtocolForm_btnSearchInProcExceptions_Click
        }
    }
}