
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
    /// Patoloji Tetkik Tanım Ekranı
    /// </summary>
    public partial class PathologyTestDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Patoloji Test Tanımı
    /// </summary>
        protected TTObjectClasses.PathologyTestDefinition _PathologyTestDefinition
        {
            get { return (TTObjectClasses.PathologyTestDefinition)_ttObject; }
        }

        protected ITTLabel labelResultTime;
        protected ITTTextBox ResultTime;
        protected ITTTextBox IntegrationCode;
        protected ITTLabel labelIntegrationCode;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTCheckBox RequestApprove;
        protected ITTLabel labelName;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelDescription;
        protected ITTLabel labelQref;
        protected ITTTextBox Description;
        protected ITTLabel labelEnglishName;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ProcedureTree;
        protected ITTTextBox Qref;
        protected ITTLabel labelID;
        protected ITTTextBox EnglishName;
        protected ITTTextBox ID;
        protected ITTTabPage tttabpage2;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTabPage tttabpage3;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn TDescription;
        protected ITTTabPage tttabpage4;
        protected ITTObjectListBox TahlilTipi;
        protected ITTLabel labelTahlilTipi;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        protected ITTObjectListBox Category;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            labelResultTime = (ITTLabel)AddControl(new Guid("777dcbaa-77b7-4b2b-884a-d9b2f3b94cf2"));
            ResultTime = (ITTTextBox)AddControl(new Guid("f7b50a02-9fef-4c57-9fca-4f9a20849f4f"));
            IntegrationCode = (ITTTextBox)AddControl(new Guid("7f395ae2-42f9-4324-886f-b29900ea30d1"));
            labelIntegrationCode = (ITTLabel)AddControl(new Guid("3da69e77-1e6d-433c-acce-b0bbe50d0d6f"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("071461ea-7b06-4a00-90b4-6fbdd7d095f7"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("91c904ee-e52e-4784-9d7d-f1da3aa6acde"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("2e20db45-0745-4e9e-ad05-f65d6487ecca"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("982ca8ff-7e95-4b13-a15b-895217a820ce"));
            RequestApprove = (ITTCheckBox)AddControl(new Guid("ac40564a-f520-4ff7-8850-f3728d2a8b4a"));
            labelName = (ITTLabel)AddControl(new Guid("cda411fa-a6fd-47a5-b8a0-457a4733d86a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ec89c378-76ff-4cf2-8d76-dcd86e36d550"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d35f2eea-617a-4d16-aed5-47b9919432ce"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("51496845-a90e-4bdd-bf98-c48fe2557525"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b4cfff1a-724d-4819-8ff2-d35ed6d906e0"));
            labelDescription = (ITTLabel)AddControl(new Guid("502060a6-dff2-40fd-977b-4891a01d55ff"));
            labelQref = (ITTLabel)AddControl(new Guid("f28009ca-7aa4-4e26-8bdc-b83b6c280aab"));
            Description = (ITTTextBox)AddControl(new Guid("c5a82876-c2cc-4eec-97b8-ba39f3e3d15b"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("176bd685-1b4a-4b17-bbba-c5a3f90f71b9"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2a4356c4-c4d8-4116-9c30-24b144c2b136"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4ac690c5-f378-4ff5-96db-b322432b5004"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("2809851c-6b7d-4f71-ab27-67582a4de3d8"));
            Qref = (ITTTextBox)AddControl(new Guid("02396865-d223-459f-8d26-1ce7fc6ab7ef"));
            labelID = (ITTLabel)AddControl(new Guid("ee573c80-dd8c-49bb-a92a-f96e91378f22"));
            EnglishName = (ITTTextBox)AddControl(new Guid("0d4c5f12-e5ca-430c-95cf-7c4e130c02ba"));
            ID = (ITTTextBox)AddControl(new Guid("daed3875-7c46-463c-895b-1321b3df9a37"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("2f247bc3-df07-4ff8-b28d-9428e3bf1677"));
            Materials = (ITTGrid)AddControl(new Guid("14eeeb21-0752-4e8c-897e-d2ef4711dffb"));
            Material = (ITTListBoxColumn)AddControl(new Guid("cdbf71f6-bfd6-4016-8585-b6ebb7a2a12c"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("9e2a617f-2cf4-416f-83d8-46af0094738e"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("048ccb97-1ca6-4a3e-913d-d5d6dbfe24d2"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("107d452d-4799-43ca-a8b2-26f784c08dd4"));
            TDescription = (ITTListBoxColumn)AddControl(new Guid("6072241f-c1e2-41db-b87a-c23147c825c0"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("7c42bc84-2069-49af-a48b-e480a690b723"));
            TahlilTipi = (ITTObjectListBox)AddControl(new Guid("37265947-c2af-470c-8a8f-6a52fb034a54"));
            labelTahlilTipi = (ITTLabel)AddControl(new Guid("ec357bba-94b8-4a03-8727-63c10505582c"));
            Name = (ITTTextBox)AddControl(new Guid("d8fbbb7d-db97-470c-a7d6-6f733c9c23ee"));
            Code = (ITTTextBox)AddControl(new Guid("70d74180-a853-4392-b85d-cf50ac05121e"));
            labelCode = (ITTLabel)AddControl(new Guid("a5b6ff75-3789-4959-9a44-5ffe234b18c7"));
            Category = (ITTObjectListBox)AddControl(new Guid("0e348c68-1fa1-4b37-95d1-9ed42369e9c2"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("aeb671da-f34e-4f7d-82ba-8f243f0fe998"));
            base.InitializeControls();
        }

        public PathologyTestDefinitionForm() : base("PATHOLOGYTESTDEFINITION", "PathologyTestDefinitionForm")
        {
        }

        protected PathologyTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}