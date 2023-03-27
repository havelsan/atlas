
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
    public partial class PresReturningDocumentMaterialForm : ReturningDocumentMaterialForm
    {
        protected TTObjectClasses.PresReturningDocMaterial _PresReturningDocMaterial
        {
            get { return (TTObjectClasses.PresReturningDocMaterial)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PrescriptionPaperOutDetails;
        protected ITTListBoxColumn PrescriptionPaperPrescriptionPaperOutDetail;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox basNo;
        protected ITTTextBox bitNo;
        protected ITTLabel ttlabel3;
        protected ITTTextBox seriNo;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("76664096-8f9f-46f9-8969-a065301cd8ea"));
            PrescriptionPaperOutDetails = (ITTGrid)AddControl(new Guid("f182e9aa-3c43-4d35-8d20-04589fe3fc10"));
            PrescriptionPaperPrescriptionPaperOutDetail = (ITTListBoxColumn)AddControl(new Guid("ae7f4fb3-6315-4666-8554-f699589312c6"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("210655a5-caaf-45bf-9504-b1e63bbb47de"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("33ca0ffc-1c18-4ee5-8e2c-4b6be84d10e9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("69e12e75-8802-4d87-93c2-690dd55f8efb"));
            basNo = (ITTTextBox)AddControl(new Guid("c82b1c73-fca5-438d-bf75-575d6594fa44"));
            bitNo = (ITTTextBox)AddControl(new Guid("fc703aec-cd1c-4bf4-ae14-bab2d33fc292"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("04d7474c-552b-4857-83f0-1520e88e6d39"));
            seriNo = (ITTTextBox)AddControl(new Guid("87bec214-04ab-4573-bc6a-f099cdf2766d"));
            ttbutton1 = (ITTButton)AddControl(new Guid("71fa335d-3d6c-4d6a-b7cc-22231fdcd44e"));
            base.InitializeControls();
        }

        public PresReturningDocumentMaterialForm() : base("PRESRETURNINGDOCMATERIAL", "PresReturningDocumentMaterialForm")
        {
        }

        protected PresReturningDocumentMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}