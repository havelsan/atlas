
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
    /// Kabul Sebepleri Kaynak Tanımları
    /// </summary>
    public partial class ReasonForAdmissinRelatedResourceForm : TTForm
    {
        protected TTObjectClasses.ReasonForAdmissionRelatedResources _ReasonForAdmissionRelatedResources
        {
            get { return (TTObjectClasses.ReasonForAdmissionRelatedResources)_ttObject; }
        }

        protected ITTGrid ProcedureDefinitions;
        protected ITTListBoxColumn ProcedureDefinition;
        protected ITTLabel labelResource;
        protected ITTObjectListBox Resource;
        protected ITTLabel labelActionType;
        protected ITTEnumComboBox ActionType;
        override protected void InitializeControls()
        {
            ProcedureDefinitions = (ITTGrid)AddControl(new Guid("ab2a6f18-9b89-402b-9953-35b6af95a965"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("1970c309-64bd-44c5-abf9-5c9a81165f54"));
            labelResource = (ITTLabel)AddControl(new Guid("5cff75ba-538a-4c72-874f-bd94fe451863"));
            Resource = (ITTObjectListBox)AddControl(new Guid("2b4b7695-70b4-42ba-911a-78c184b67cd5"));
            labelActionType = (ITTLabel)AddControl(new Guid("dba60709-9bb1-48f9-91d4-0c2fa5a52f31"));
            ActionType = (ITTEnumComboBox)AddControl(new Guid("af39c060-d8eb-4769-923b-118436b515fe"));
            base.InitializeControls();
        }

        public ReasonForAdmissinRelatedResourceForm() : base("REASONFORADMISSIONRELATEDRESOURCES", "ReasonForAdmissinRelatedResourceForm")
        {
        }

        protected ReasonForAdmissinRelatedResourceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}