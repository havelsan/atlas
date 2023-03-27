
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
    public partial class ProcedureRequestCategoryForm : TTForm
    {
    /// <summary>
    /// Hizmet İstek Ekranları Kategorileri
    /// </summary>
        protected TTObjectClasses.ProcedureRequestCategoryDefinition _ProcedureRequestCategoryDefinition
        {
            get { return (TTObjectClasses.ProcedureRequestCategoryDefinition)_ttObject; }
        }

        protected ITTGrid FormDetail;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn ProcedureDefinitionProcedureRequestFormDetailDefinition;
        protected ITTListBoxColumn ObservationUnitProcedureRequestFormDetailDefinition;
        override protected void InitializeControls()
        {
            FormDetail = (ITTGrid)AddControl(new Guid("0ea73a51-816f-40e7-a7eb-ec5ce1aa0512"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("578f7316-3f49-4088-b2ec-66541d165d46"));
            ProcedureDefinitionProcedureRequestFormDetailDefinition = (ITTListBoxColumn)AddControl(new Guid("e910237c-df7e-4bad-b0be-d7ad79bcba0e"));
            ObservationUnitProcedureRequestFormDetailDefinition = (ITTListBoxColumn)AddControl(new Guid("8b6a4e3f-be22-4e4b-a2c9-a902706c4491"));
            base.InitializeControls();
        }

        public ProcedureRequestCategoryForm() : base("PROCEDUREREQUESTCATEGORYDEFINITION", "ProcedureRequestCategoryForm")
        {
        }

        protected ProcedureRequestCategoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}