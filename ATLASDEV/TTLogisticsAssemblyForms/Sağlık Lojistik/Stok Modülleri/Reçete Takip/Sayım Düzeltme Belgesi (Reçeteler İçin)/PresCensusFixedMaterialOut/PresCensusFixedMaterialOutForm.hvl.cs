
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
    /// Malzeme Detayları
    /// </summary>
    public partial class PresCensusFixedMaterialOutForm : BaseStockActionDetailOutForm
    {
        protected TTObjectClasses.PresCensusFixedMaterialOut _PresCensusFixedMaterialOut
        {
            get { return (TTObjectClasses.PresCensusFixedMaterialOut)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTTextBox seriNo;
        protected ITTLabel ttlabel3;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox basNo;
        protected ITTTextBox bitNo;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("c1766038-fd49-4973-b5f3-a89cab2bb2ab"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("bcd43301-4798-4589-aba9-24615b763be9"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("1af66aa5-777f-4729-b2a1-ac7e201f4233"));
            seriNo = (ITTTextBox)AddControl(new Guid("a9997a9c-2136-4379-9ee8-eb132da87f2c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c08e4843-47de-4aac-b55a-ce110b1482b3"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c1a6f42d-2710-49aa-958d-31c45b8254b4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("80b767a0-b6df-440c-a503-59502479e299"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d57de412-cccf-4721-9ef1-21c512bd6509"));
            basNo = (ITTTextBox)AddControl(new Guid("cfcde7b6-2411-4d88-b273-6e5e99b33e43"));
            bitNo = (ITTTextBox)AddControl(new Guid("4cd8b37f-769c-4d11-abec-f215297ac674"));
            ttbutton1 = (ITTButton)AddControl(new Guid("078a7f82-e437-468b-87e0-2bf2499f1e11"));
            base.InitializeControls();
        }

        public PresCensusFixedMaterialOutForm() : base("PRESCENSUSFIXEDMATERIALOUT", "PresCensusFixedMaterialOutForm")
        {
        }

        protected PresCensusFixedMaterialOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}