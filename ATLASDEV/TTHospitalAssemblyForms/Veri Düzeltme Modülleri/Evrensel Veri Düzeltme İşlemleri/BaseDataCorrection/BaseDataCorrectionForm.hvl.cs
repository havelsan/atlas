
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
    public partial class BaseDataCorrectionForm : ActionForm
    {
        protected TTObjectClasses.BaseDataCorrection _BaseDataCorrection
        {
            get { return (TTObjectClasses.BaseDataCorrection)_ttObject; }
        }

        protected ITTDateTimePicker ActionDate;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelWorkListDate;
        override protected void InitializeControls()
        {
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a345e6f3-6589-42cd-bfdd-5545f725cb90"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("d47210e0-aa03-4d04-9b69-feba0456ee51"));
            labelID = (ITTLabel)AddControl(new Guid("f0602aa6-e83b-49c3-b668-43515759ed0b"));
            ID = (ITTTextBox)AddControl(new Guid("3190176a-571f-4b2c-baca-0b8fd4bde458"));
            labelActionDate = (ITTLabel)AddControl(new Guid("01e4c9dc-3de7-4331-95ce-8f5d23da2347"));
            labelWorkListDate = (ITTLabel)AddControl(new Guid("eefdbbba-6cd1-44f3-9ef1-b617886d511a"));
            base.InitializeControls();
        }

        public BaseDataCorrectionForm() : base("BASEDATACORRECTION", "BaseDataCorrectionForm")
        {
        }

        protected BaseDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}