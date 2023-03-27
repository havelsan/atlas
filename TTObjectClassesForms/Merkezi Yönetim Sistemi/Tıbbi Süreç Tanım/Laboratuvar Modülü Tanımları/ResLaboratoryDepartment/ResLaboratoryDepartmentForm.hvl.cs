
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
    public partial class ResLaboratoryDepartmentForm : ObservationUnitDepartmentDefinitionForm
    {
    /// <summary>
    /// Laboratuvar Bölümü
    /// </summary>
        protected TTObjectClasses.ResLaboratoryDepartment _ResLaboratoryDepartment
        {
            get { return (TTObjectClasses.ResLaboratoryDepartment)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox IsmedicalWaste;
        override protected void InitializeControls()
        {
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("d1272672-891a-47e7-8f1a-1ac375989276"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("530da4d1-d8f6-4ed0-a1f8-27a9434ecd05"));
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("26b9d488-84c3-4142-ab7b-9600fba55ec6"));
            base.InitializeControls();
        }

        public ResLaboratoryDepartmentForm() : base("RESLABORATORYDEPARTMENT", "ResLaboratoryDepartmentForm")
        {
        }

        protected ResLaboratoryDepartmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}