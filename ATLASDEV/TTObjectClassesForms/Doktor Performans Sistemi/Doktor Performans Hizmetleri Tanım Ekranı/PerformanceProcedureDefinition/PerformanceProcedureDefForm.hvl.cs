
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
    /// Doktor Performans Hizmetleri Tanım Ekranı
    /// </summary>
    public partial class PerformanceProcedureDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Doktor Performans Hizmetleri Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.PerformanceProcedureDefinition _PerformanceProcedureDefinition
        {
            get { return (TTObjectClasses.PerformanceProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTTextBox txtGILCode;
        protected ITTTextBox txtGILPoint;
        protected ITTLabel labelName;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelQref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelID;
        protected ITTLabel lblGILCode;
        protected ITTLabel lblGILPoint;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("ddf3485c-bd3f-4258-a88d-5eea5d83dd18"));
            Description = (ITTTextBox)AddControl(new Guid("e7fafe77-42e5-4b9b-8131-72229029f21b"));
            Name = (ITTTextBox)AddControl(new Guid("7c6a802b-4fa7-42a4-9e1c-822483ee2ded"));
            Code = (ITTTextBox)AddControl(new Guid("398443a9-7518-4f38-851b-97120cfdca35"));
            ID = (ITTTextBox)AddControl(new Guid("2818a491-22de-40b2-bfb3-4cad5e003d85"));
            Qref = (ITTTextBox)AddControl(new Guid("6ba2e84a-d7df-44d4-ba95-dd72d3ebc687"));
            txtGILCode = (ITTTextBox)AddControl(new Guid("8742666e-b0e1-41ae-a772-1a1859b8ab35"));
            txtGILPoint = (ITTTextBox)AddControl(new Guid("73f035f7-0cdc-4b53-a7fb-31700a921b4b"));
            labelName = (ITTLabel)AddControl(new Guid("4e78d5ec-cc36-4ef6-89d7-363ff11f2075"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("2ee96d61-4f8a-4565-8242-09f1eb18cc4e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2addf485-187f-4423-b1cf-3ae83e06232f"));
            labelDescription = (ITTLabel)AddControl(new Guid("d65205ed-e189-4b5b-845c-f6906bdeabda"));
            labelQref = (ITTLabel)AddControl(new Guid("483c280d-2bfe-48ea-84be-48f26bb72c17"));
            IsActive = (ITTCheckBox)AddControl(new Guid("4a676c3d-ad31-4fa1-84de-2e47afee0f14"));
            labelID = (ITTLabel)AddControl(new Guid("e2e89721-74ab-4dc4-b236-c4fd754e2950"));
            lblGILCode = (ITTLabel)AddControl(new Guid("1715dbf1-d298-42c3-9c19-2452a7862cfa"));
            lblGILPoint = (ITTLabel)AddControl(new Guid("fb8c17db-5317-4fb8-9af4-0b8775422966"));
            base.InitializeControls();
        }

        public PerformanceProcedureDefForm() : base("PERFORMANCEPROCEDUREDEFINITION", "PerformanceProcedureDefForm")
        {
        }

        protected PerformanceProcedureDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}