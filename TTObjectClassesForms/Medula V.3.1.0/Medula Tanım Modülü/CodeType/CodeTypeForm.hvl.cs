
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
    /// ESAW Kod Tipi Tanımları
    /// </summary>
    public partial class CodeTypeForm : TTDefinitionForm
    {
    /// <summary>
    /// ESAW Kod Tipi
    /// </summary>
        protected TTObjectClasses.CodeType _CodeType
        {
            get { return (TTObjectClasses.CodeType)_ttObject; }
        }

        protected ITTLabel labelKind;
        protected ITTTextBox Kind;
        protected ITTTextBox CodeTypeCode;
        protected ITTTextBox CodeTypeName;
        protected ITTLabel labelCodeTypeCode;
        protected ITTLabel labelCodeTypeName;
        override protected void InitializeControls()
        {
            labelKind = (ITTLabel)AddControl(new Guid("6a223bec-b05e-4c41-8b82-f147a2f334d3"));
            Kind = (ITTTextBox)AddControl(new Guid("9a1d6a10-029c-4c2f-845b-f56fb4582e72"));
            CodeTypeCode = (ITTTextBox)AddControl(new Guid("0e346b24-01c5-41ad-bd4a-5958c1fc3ec3"));
            CodeTypeName = (ITTTextBox)AddControl(new Guid("15d22842-d973-4964-b331-76c9490df328"));
            labelCodeTypeCode = (ITTLabel)AddControl(new Guid("fa26c9d2-c8c8-4c52-8f20-23f1944dc629"));
            labelCodeTypeName = (ITTLabel)AddControl(new Guid("da2a18a5-2dae-42ff-a696-25069f603c01"));
            base.InitializeControls();
        }

        public CodeTypeForm() : base("CODETYPE", "CodeTypeForm")
        {
        }

        protected CodeTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}