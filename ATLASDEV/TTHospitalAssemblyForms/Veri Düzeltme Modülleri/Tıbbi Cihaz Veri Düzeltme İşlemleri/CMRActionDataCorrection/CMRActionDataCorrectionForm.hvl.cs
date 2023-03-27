
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
    /// Kalibrasyon/Bakım/Onarım İstek Durumu Düzeltme
    /// </summary>
    public partial class CMRActionDataCorrectionForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek Durumu Düzeltme
    /// </summary>
        protected TTObjectClasses.CMRActionDataCorrection _CMRActionDataCorrection
        {
            get { return (TTObjectClasses.CMRActionDataCorrection)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTTextBox NewCMRActionStatus;
        protected ITTTextBox OldCMRActionStatus;
        protected ITTLabel labelRequestNoCMRAction;
        protected ITTLabel labelNewCMRActionStatus;
        protected ITTLabel labelOldCMRActionStatus;
        protected ITTButton cmdUpdateCMRAction;
        protected ITTButton cmdGetCMRAction;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("77a1135d-3002-4af6-863b-908ca15ae0e9"));
            NewCMRActionStatus = (ITTTextBox)AddControl(new Guid("8fe8f36a-e411-4166-a30c-11eb78852dd9"));
            OldCMRActionStatus = (ITTTextBox)AddControl(new Guid("3da0a7d9-21a9-454f-8f1f-98621ef70edc"));
            labelRequestNoCMRAction = (ITTLabel)AddControl(new Guid("beb48b11-54da-4075-bfd1-5b7c4ba2d5ba"));
            labelNewCMRActionStatus = (ITTLabel)AddControl(new Guid("87eab61a-7d58-49cb-b155-ef829123d8ae"));
            labelOldCMRActionStatus = (ITTLabel)AddControl(new Guid("4ecf3967-d644-4ed3-ad76-675bd9ccc4f8"));
            cmdUpdateCMRAction = (ITTButton)AddControl(new Guid("7fafa261-b592-4dd8-8f60-96dc336ec838"));
            cmdGetCMRAction = (ITTButton)AddControl(new Guid("01fe3bfd-5384-4359-a96f-87c09e8b5807"));
            base.InitializeControls();
        }

        public CMRActionDataCorrectionForm() : base("CMRACTIONDATACORRECTION", "CMRActionDataCorrectionForm")
        {
        }

        protected CMRActionDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}