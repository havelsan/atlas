
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
    public partial class PresChaDocInputDetWithAccountancyForm : BaseStockActionDetailInForm
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
#region PresChaDocInputDetWithAccountancyForm_ttbuttonSorgula_Click
   int startNo = Convert.ToInt32(basNo.Text);
            int endNo = Convert.ToInt32(bitNo.Text);
            string seriNu = seriNo.Text;
            
            
            if ( basNo != null && bitNo != null && seriNo.Text != null)
            {
                if(startNo <= endNo)
                {
                    for( int i=startNo ;startNo <= endNo ; startNo++)
                    {
                        PrescriptionPaperInDetail prescriptionPaperInDetail = new PrescriptionPaperInDetail(_StockActionDetailIn.ObjectContext);
                        prescriptionPaperInDetail.SerialNo = seriNu ;
                        prescriptionPaperInDetail.VolumeNo = startNo.ToString();
                        prescriptionPaperInDetail.StockActionDetailIn = _StockActionDetailIn ;
                    }
                }
                else
                {
                    throw new Exception("Başlangıç numarası  bitiş numarasından büyük olamaz.");
                }
            }
            else
            {
                
                throw  new Exception("Başlangıç numarası , bitiş numarası , seri numarası boş geçilemez.");
            }
#endregion PresChaDocInputDetWithAccountancyForm_ttbuttonSorgula_Click
        }

        protected override void PreScript()
        {
#region PresChaDocInputDetWithAccountancyForm_PreScript
    base.PreScript();
             ((ITTMultiRowControl)this.PrescriptionPaperInDetails).MaximumRowCount = (int)_StockActionDetailIn.Amount;
#endregion PresChaDocInputDetWithAccountancyForm_PreScript

            }
                }
}