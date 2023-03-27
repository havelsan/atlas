
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
    /// Geleneksel ve Tamamlayıcı Tıp Uygulamaları Formu
    /// </summary>
    public partial class GetatExaminationForm : TTForm
    {
    /// <summary>
    /// Traditional and complementary medicine object
    /// </summary>
        protected TTObjectClasses.TraditionalMedicine _TraditionalMedicine
        {
            get { return (TTObjectClasses.TraditionalMedicine)_ttObject; }
        }

        protected ITTLabel labelGetatApplicationType;
        protected ITTObjectListBox GetatApplicationType;
        protected ITTGrid TraditionalMedAppRegion;
        protected ITTListBoxColumn SKRSGetatApplicationRegionTraditionalMedAppRegion;
        protected ITTGrid TraditionalMedAppCases;
        protected ITTListBoxColumn SKRSGetatAppliedCasesTradititionalMedAppCases;
        protected ITTLabel labelGetatApplicationUnit;
        protected ITTObjectListBox GetatApplicationUnit;
        protected ITTLabel labelGetatExaminationResult;
        protected ITTObjectListBox GetatExaminationResult;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            labelGetatApplicationType = (ITTLabel)AddControl(new Guid("78acca86-ffd8-45b4-9afb-0078f0aec18e"));
            GetatApplicationType = (ITTObjectListBox)AddControl(new Guid("033de0d9-cd74-4086-b1e4-682d81f402ca"));
            TraditionalMedAppRegion = (ITTGrid)AddControl(new Guid("4e356ade-95f4-4e0e-9dfc-fc3d7042d03a"));
            SKRSGetatApplicationRegionTraditionalMedAppRegion = (ITTListBoxColumn)AddControl(new Guid("3128a8e4-dfaa-4a87-bf4a-cc3f438968d2"));
            TraditionalMedAppCases = (ITTGrid)AddControl(new Guid("4cd00228-4fff-4611-9336-b4db20c63ef9"));
            SKRSGetatAppliedCasesTradititionalMedAppCases = (ITTListBoxColumn)AddControl(new Guid("6389b474-188e-4588-a474-a276c7ef2fbe"));
            labelGetatApplicationUnit = (ITTLabel)AddControl(new Guid("5dbb0647-40c1-4b21-b0c6-a59ddc7aa980"));
            GetatApplicationUnit = (ITTObjectListBox)AddControl(new Guid("a3e4ff4d-9a73-42a9-b92c-f0ae5b42d6c5"));
            labelGetatExaminationResult = (ITTLabel)AddControl(new Guid("c131f10c-269e-43d6-a7cb-b47dded15093"));
            GetatExaminationResult = (ITTObjectListBox)AddControl(new Guid("ee146c92-e134-4f25-9918-3fc3e56a974d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ea935ab5-57a4-4282-9937-6092a84b794e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("21ff2323-f311-47cd-be82-13c6b7c8b2cd"));
            base.InitializeControls();
        }

        public GetatExaminationForm() : base("TRADITIONALMEDICINE", "GetatExaminationForm")
        {
        }

        protected GetatExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}