
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
    /// Ambalajlama İş İstek
    /// </summary>
    public partial class PackagingDepartmentActionNewForm : TTForm
    {
    /// <summary>
    /// Ambalajlama İş İstek
    /// </summary>
        protected TTObjectClasses.PackagingDepartmentAction _PackagingDepartmentAction
        {
            get { return (TTObjectClasses.PackagingDepartmentAction)_ttObject; }
        }

        protected ITTLabel labelResDivision;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelRequestNo;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            labelResDivision = (ITTLabel)AddControl(new Guid("603a5005-895d-46b6-a2d1-c6f97bd12c54"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("9c633e09-230e-4cac-b452-84f62f5cc2f6"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("f1305b1a-02c3-4419-9dc9-31c2fb084c75"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("564054b5-f714-4a34-b763-9e5a0a7b12d2"));
            labelStartDate = (ITTLabel)AddControl(new Guid("369f357b-31f6-436e-bb59-b4e64459775a"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("f3639fc8-4730-4c17-a684-a33541ba2ff0"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("0903d117-5406-4171-a48e-d1d0f4e09818"));
            RequestNo = (ITTTextBox)AddControl(new Guid("9bc1b82a-ce5e-4f13-b445-155ba649605a"));
            labelDescription = (ITTLabel)AddControl(new Guid("12c23bd2-feb3-4d8c-90ac-59e693db44ce"));
            Description = (ITTTextBox)AddControl(new Guid("966face9-b5b1-4fc1-8309-665208b78b68"));
            base.InitializeControls();
        }

        public PackagingDepartmentActionNewForm() : base("PACKAGINGDEPARTMENTACTION", "PackagingDepartmentActionNewForm")
        {
        }

        protected PackagingDepartmentActionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}