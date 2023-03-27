
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
    public partial class SterilizationRequestForm : TTForm
    {
    /// <summary>
    /// Sterilizasyon İstek
    /// </summary>
        protected TTObjectClasses.SterilizationRequest _SterilizationRequest
        {
            get { return (TTObjectClasses.SterilizationRequest)_ttObject; }
        }

        protected ITTLabel labelSterilizationUnit;
        protected ITTObjectListBox SterilizationUnit;
        protected ITTLabel labelRequestResource;
        protected ITTObjectListBox RequestResource;
        protected ITTLabel labelRequestUser;
        protected ITTObjectListBox RequestUser;
        protected ITTGrid SterilizationHistories;
        protected ITTListBoxColumn ReusableMaterialSterilizationHistory;
        protected ITTLabel labelİstekTarihi;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            labelSterilizationUnit = (ITTLabel)AddControl(new Guid("89c27952-2a69-49c6-886b-fc735fcd6c78"));
            SterilizationUnit = (ITTObjectListBox)AddControl(new Guid("26f2fe62-d28a-4b56-acd0-6a329a9c60f7"));
            labelRequestResource = (ITTLabel)AddControl(new Guid("9cc65353-c06c-4979-a72b-d1b72e17945a"));
            RequestResource = (ITTObjectListBox)AddControl(new Guid("c5dd7421-ae00-4736-b160-b071a88798f7"));
            labelRequestUser = (ITTLabel)AddControl(new Guid("35e6c6c4-1dc1-4fba-996f-50f99a107091"));
            RequestUser = (ITTObjectListBox)AddControl(new Guid("97f1dda2-fe35-47a4-9096-8f4f0829dff2"));
            SterilizationHistories = (ITTGrid)AddControl(new Guid("734c487a-c62c-4a7c-82b3-6f2265db5338"));
            ReusableMaterialSterilizationHistory = (ITTListBoxColumn)AddControl(new Guid("c5a20adc-43a2-4840-91e0-126f4c26e9ac"));
            labelİstekTarihi = (ITTLabel)AddControl(new Guid("6aed55da-6aa2-4b04-a1ad-ce9e7c547558"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("a4d29c72-d543-4481-8fde-5044de3b5469"));
            base.InitializeControls();
        }

        public SterilizationRequestForm() : base("STERILIZATIONREQUEST", "SterilizationRequestForm")
        {
        }

        protected SterilizationRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}