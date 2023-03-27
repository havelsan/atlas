
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Sağlık Kurulu XXXXXX Okul Tc Kimlik No Eşleştirme
    /// </summary>
    public partial class HCMilitaryUnitTCNoMatchForm : TTUnboundForm
    {
        protected ITTButton ReportButton;
        protected ITTButton DeleteButton;
        protected ITTTextBox Year;
        protected ITTLabel FileName;
        protected ITTButton SaveButton;
        protected ITTButton ImportFileButton;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MilitaryUnitList;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            ReportButton = (ITTButton)AddControl(new Guid("157c70fd-2354-48ab-8b86-2d5bd4040f5b"));
            DeleteButton = (ITTButton)AddControl(new Guid("58ff82f1-1380-42ee-9b3e-7a94e7769411"));
            Year = (ITTTextBox)AddControl(new Guid("effcbe6c-23b2-4f2b-9156-93865bfb131e"));
            FileName = (ITTLabel)AddControl(new Guid("bb45a666-3a7d-40f3-b9f8-6e2813cf2e5c"));
            SaveButton = (ITTButton)AddControl(new Guid("e32e980a-7661-4483-a425-b61a07580651"));
            ImportFileButton = (ITTButton)AddControl(new Guid("342fcd06-a35d-4c89-a228-3bd177bebc5a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6a05956c-57cb-4325-8fa2-92318793f91f"));
            MilitaryUnitList = (ITTObjectListBox)AddControl(new Guid("fe1e7ef1-78e8-4e83-8472-2b129d22467f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("350ad30c-642b-4545-bdcd-a0313d1c0acb"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("60bc06f1-0abe-4721-9dca-a74d88be2dcc"));
            base.InitializeControls();
        }

        public HCMilitaryUnitTCNoMatchForm() : base("HCMilitaryUnitTCNoMatchForm")
        {
        }

        protected HCMilitaryUnitTCNoMatchForm(string formDefName) : base(formDefName)
        {
        }

#region HCMilitaryUnitTCNoMatchForm_Methods
        protected override void BarcodeRead(string value)
        {   
            base.BarcodeRead(value);
            TTObjectContext context = new TTObjectContext(false);
            HCMilitaryUnitTCNoMatch hcMilitaryUnitTCNoMatch = null;
            if(value.Contains("*"))
            {
                value = value.Replace("*",String.Empty);
            }
            IBindingList hcMilitaryUnitTCNoMatchList = context.QueryObjects("HCMILITARYUNITTCNOMATCH", "TCNO='" + value + "' AND YEAR =" + DateTime.Today.Year);
            if (hcMilitaryUnitTCNoMatchList.Count == 0)
                InfoBox.Show(value + " kimlik numaralı kayıt bulunamadı.", MessageIconEnum.InformationMessage);
            else
            {
                hcMilitaryUnitTCNoMatch = (HCMilitaryUnitTCNoMatch)context.GetObject(((HCMilitaryUnitTCNoMatch)hcMilitaryUnitTCNoMatchList[0]).ObjectID, typeof(HCMilitaryUnitTCNoMatch));
                hcMilitaryUnitTCNoMatch.IsRead = true;
                context.Save();
                InfoBox.Show(hcMilitaryUnitTCNoMatch.MilitaryUnit.Name, MessageIconEnum.InformationMessage);
            }
            context.Dispose();
        }
        
#endregion HCMilitaryUnitTCNoMatchForm_Methods
    }
}