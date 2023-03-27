
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
    /// Şablon İnceleme / Silme
    /// </summary>
    public partial class UserTemplateDeleteForm : TTUnboundForm
    {
        protected ITTButton cmdCancel;
        protected ITTButton cmdTemplateDelete;
        protected ITTGrid UserTemplateGrid;
        protected ITTCheckBoxColumn Select;
        protected ITTTextBoxColumn Description;
        protected ITTTextBoxColumn TemplateType;
        protected ITTTextBoxColumn UserTemplateObjectID;
        override protected void InitializeControls()
        {
            cmdCancel = (ITTButton)AddControl(new Guid("ffc4e361-4d14-46ef-91c8-e064d5ee1ff2"));
            cmdTemplateDelete = (ITTButton)AddControl(new Guid("8638700a-0832-478c-b298-48cba951c53a"));
            UserTemplateGrid = (ITTGrid)AddControl(new Guid("03b87e3c-5e9b-4510-b7d0-aeedafc1c9ed"));
            Select = (ITTCheckBoxColumn)AddControl(new Guid("903fefc8-90e2-46fb-abf1-7199a4acfcdb"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("599e8a8c-2fa7-490b-b5b8-c028c91c0238"));
            TemplateType = (ITTTextBoxColumn)AddControl(new Guid("3f3b7be6-cb81-4d0b-acff-55849b649d3e"));
            UserTemplateObjectID = (ITTTextBoxColumn)AddControl(new Guid("0c6b8ef9-9ddf-43d0-8fa3-68e6344bc688"));
            base.InitializeControls();
        }

        public UserTemplateDeleteForm() : base("UserTemplateDeleteForm")
        {
        }

        protected UserTemplateDeleteForm(string formDefName) : base(formDefName)
        {
        }
    }
}