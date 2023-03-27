
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
    /// Gayri Menkul Değer Bilgileri
    /// </summary>
    public partial class NewImmovableForm : TTForm
    {
    /// <summary>
    /// GayriMenkul
    /// </summary>
        protected TTObjectClasses.MPBSImmovable _MPBSImmovable
        {
            get { return (TTObjectClasses.MPBSImmovable)_ttObject; }
        }

        protected ITTTextBox Value;
        protected ITTLabel labelPieceNumber;
        protected ITTTextBox Kind;
        protected ITTLabel labelYear;
        protected ITTTextBox PieceNumber;
        protected ITTLabel labelDeclerationDate;
        protected ITTLabel labelValue;
        protected ITTLabel labelOfficerPettyOfficer;
        protected ITTDateTimePicker Year;
        protected ITTLabel labelKind;
        protected ITTDateTimePicker DeclerationDate;
        protected ITTObjectListBox OfficerPettyOfficer;
        override protected void InitializeControls()
        {
            Value = (ITTTextBox)AddControl(new Guid("ed7e5abb-3a4d-4e31-b0a2-10aef66b4287"));
            labelPieceNumber = (ITTLabel)AddControl(new Guid("beb58173-8fa5-458f-bd9b-0b3a195b0912"));
            Kind = (ITTTextBox)AddControl(new Guid("b60570f5-6bf1-4b9f-aae2-2073423871e2"));
            labelYear = (ITTLabel)AddControl(new Guid("a4d017d9-ca8a-4579-82d5-53a31a9a96fa"));
            PieceNumber = (ITTTextBox)AddControl(new Guid("280ea5cb-62f5-45a8-b453-4a1bf0be0106"));
            labelDeclerationDate = (ITTLabel)AddControl(new Guid("d9145f38-b843-4a63-a175-6fc05fbdf358"));
            labelValue = (ITTLabel)AddControl(new Guid("8971695a-6852-455a-b20d-8b0824b562ef"));
            labelOfficerPettyOfficer = (ITTLabel)AddControl(new Guid("b772389d-35b4-47a7-8c2e-8d39d2cfbfa7"));
            Year = (ITTDateTimePicker)AddControl(new Guid("1b029793-f423-4326-986b-c92560f88731"));
            labelKind = (ITTLabel)AddControl(new Guid("19a2c53b-b48a-428e-9b05-e5cd1acfda11"));
            DeclerationDate = (ITTDateTimePicker)AddControl(new Guid("62b6a600-f78f-4725-b14e-c058710e46dd"));
            OfficerPettyOfficer = (ITTObjectListBox)AddControl(new Guid("7634deba-8067-4b74-8f39-e488ebd64145"));
            base.InitializeControls();
        }

        public NewImmovableForm() : base("MPBSIMMOVABLE", "NewImmovableForm")
        {
        }

        protected NewImmovableForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}