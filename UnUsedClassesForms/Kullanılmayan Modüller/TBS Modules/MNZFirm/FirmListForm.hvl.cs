
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
    /// Firma Listesi
    /// </summary>
    public partial class FirmListForm : TTForm
    {
    /// <summary>
    /// DE_Firma Tanımı
    /// </summary>
        protected TTObjectClasses.MNZFirm _MNZFirm
        {
            get { return (TTObjectClasses.MNZFirm)_ttObject; }
        }

        protected ITTLabel labelLiablePerson;
        protected ITTTextBox Title;
        protected ITTLabel labelEndDate;
        protected ITTTextBox Name;
        protected ITTObjectListBox City;
        protected ITTLabel labelTitle;
        protected ITTDateTimePicker StartDate;
        protected ITTTextBox LiablePerson;
        protected ITTLabel labelLiablePersonTitle;
        protected ITTLabel labelCity;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTGrid ttgrid1;
        protected ITTLabel labelName;
        protected ITTTextBox LiablePersonTitle;
        override protected void InitializeControls()
        {
            labelLiablePerson = (ITTLabel)AddControl(new Guid("e874b7b1-86d3-43c9-84b6-2994ad8015dd"));
            Title = (ITTTextBox)AddControl(new Guid("d93bd1f6-586e-4e54-a19e-2d9f11d15351"));
            labelEndDate = (ITTLabel)AddControl(new Guid("995f9d33-9568-4222-8aa8-1a932153bda2"));
            Name = (ITTTextBox)AddControl(new Guid("c80091f8-306b-4d91-af6e-2207eee405f2"));
            City = (ITTObjectListBox)AddControl(new Guid("58fc4e9e-d7a9-4862-b389-2415923ac26d"));
            labelTitle = (ITTLabel)AddControl(new Guid("34f89f09-5fbd-41b7-a103-480b7aa8adfe"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("135806fb-bb15-476b-be25-6e3b14d4e80f"));
            LiablePerson = (ITTTextBox)AddControl(new Guid("eaf7b19e-eed8-43b0-8c60-54a93788ac6d"));
            labelLiablePersonTitle = (ITTLabel)AddControl(new Guid("ca69e152-83a0-47de-a1df-a74977ab2da7"));
            labelCity = (ITTLabel)AddControl(new Guid("36eeccbf-d116-4285-b906-c918511fcd28"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("1b83c632-7c44-4818-9d1f-bf14845bdbb1"));
            labelStartDate = (ITTLabel)AddControl(new Guid("9ff610ec-d86b-47e9-8235-d0382e69da75"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("cece75e6-8a92-4b05-b7ac-dc10bb38827d"));
            labelName = (ITTLabel)AddControl(new Guid("12835cec-1260-41be-8768-ee7ead145b72"));
            LiablePersonTitle = (ITTTextBox)AddControl(new Guid("45cb9b29-83e8-4f5b-9665-f00fd00bbbd5"));
            base.InitializeControls();
        }

        public FirmListForm() : base("MNZFIRM", "FirmListForm")
        {
        }

        protected FirmListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}