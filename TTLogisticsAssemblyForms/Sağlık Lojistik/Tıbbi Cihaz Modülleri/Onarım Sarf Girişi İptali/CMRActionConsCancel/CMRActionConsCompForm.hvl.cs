
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
    /// Onarım Sarf Girişi İptali
    /// </summary>
    public partial class CMRActionConsCompForm : ActionForm
    {
    /// <summary>
    /// Onarım Sarf Girişi İptali
    /// </summary>
        protected TTObjectClasses.CMRActionConsCancel _CMRActionConsCancel
        {
            get { return (TTObjectClasses.CMRActionConsCancel)_ttObject; }
        }

        protected ITTButton cmdConsDetail;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox ID;
        protected ITTTextBox CMRActionRequestNo;
        protected ITTButton cmdFindCMRAction;
        protected ITTGrid CMRActionConsCancelDetails;
        protected ITTCheckBoxColumn CancelCMRActionConsCancelDetail;
        protected ITTTextBoxColumn MaterialName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelCMRActionRequestNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            cmdConsDetail = (ITTButton)AddControl(new Guid("0debe49c-cb1d-4c5b-9805-f4ccf12238b5"));
            labelDescription = (ITTLabel)AddControl(new Guid("d29fc61c-0905-4df2-b7fc-4652c14e0b7c"));
            Description = (ITTTextBox)AddControl(new Guid("f45e5b4f-487e-4b59-83b3-6892c948d8c6"));
            ID = (ITTTextBox)AddControl(new Guid("d6224397-b7bb-4760-a9a0-3e41ff82a21b"));
            CMRActionRequestNo = (ITTTextBox)AddControl(new Guid("f90c2ca8-b566-4492-89a7-f2f82ebf8fc6"));
            cmdFindCMRAction = (ITTButton)AddControl(new Guid("d8ef4479-ea2a-4ae1-9a7f-4d8efed5f331"));
            CMRActionConsCancelDetails = (ITTGrid)AddControl(new Guid("66a1d6bc-0b99-4510-b481-bd59dd680c39"));
            CancelCMRActionConsCancelDetail = (ITTCheckBoxColumn)AddControl(new Guid("f03f40b4-3b52-4644-82b6-1d198a9821bd"));
            MaterialName = (ITTTextBoxColumn)AddControl(new Guid("f2e4d8ea-b064-4d08-981a-6709cb0edf17"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6e36a0ce-1f3c-45fc-875b-7fe4067f5ca5"));
            labelID = (ITTLabel)AddControl(new Guid("ca5063d6-4df7-4d75-a226-ce778bc908d6"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c60ff6ed-e183-4736-80dd-a9513bb386a4"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("32dc7980-4283-414c-a2fc-845cf71c2911"));
            labelCMRActionRequestNo = (ITTLabel)AddControl(new Guid("73402a91-ffa1-4fd2-99df-eb4243736399"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ff62eb2a-6ea2-43b6-8872-7255d2187c54"));
            base.InitializeControls();
        }

        public CMRActionConsCompForm() : base("CMRACTIONCONSCANCEL", "CMRActionConsCompForm")
        {
        }

        protected CMRActionConsCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}