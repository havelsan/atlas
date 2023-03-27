
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
    /// İndirim Tipi Tanımlama
    /// </summary>
    public partial class DiscountTypeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// İndirim Tipi Tanımlama
    /// </summary>
        protected TTObjectClasses.DiscountTypeDefinition _DiscountTypeDefinition
        {
            get { return (TTObjectClasses.DiscountTypeDefinition)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDProcedureGroups;
        protected ITTListBoxColumn PROCEDURETREE;
        protected ITTCheckBoxColumn ISPERCENTAGEDISCOUNTPG;
        protected ITTTextBoxColumn DISCOUNTPERCENTAGEPG;
        protected ITTCheckBoxColumn ISAMOUNTDISCOUNTPG;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GRIDProcedureExceptions;
        protected ITTListBoxColumn PROCEDURE;
        protected ITTCheckBoxColumn ISPERCENTAGEDISCOUNTPE;
        protected ITTTextBoxColumn DISCOUNTPRTCENTAGEPE;
        protected ITTCheckBoxColumn ISAMOUNTDISCOUNTPE;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GRIDMaterialGroups;
        protected ITTListBoxColumn MATERIALTREE;
        protected ITTCheckBoxColumn ISPERCENTAGEDISCOUNTMG;
        protected ITTTextBoxColumn DISCOUNTPERCENTAGEMG;
        protected ITTCheckBoxColumn ISAMOUNTDISCOUNTMG;
        protected ITTTabPage tttabpage4;
        protected ITTGrid GRIDMaterialExceptions;
        protected ITTListBoxColumn MATERIAL;
        protected ITTCheckBoxColumn ISPERCENTAGEDISCOUNTME;
        protected ITTTextBoxColumn DISCOUNTPERCENTAGEME;
        protected ITTCheckBoxColumn ISAMOUNTDISCOUNTME;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox Description;
        protected ITTTextBox CODE;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ae7d3c6a-4bfd-4197-be78-7a355f5ebbe6"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("1238443e-8dd5-437a-b730-49299b3ab843"));
            GRIDProcedureGroups = (ITTGrid)AddControl(new Guid("af4bcd8a-ec7c-49b4-aefe-03460aa77d40"));
            PROCEDURETREE = (ITTListBoxColumn)AddControl(new Guid("b47f7538-9e8c-48de-9a32-8504c1a798c6"));
            ISPERCENTAGEDISCOUNTPG = (ITTCheckBoxColumn)AddControl(new Guid("c7fcd472-7100-42c7-adb5-e9e63ab8bf44"));
            DISCOUNTPERCENTAGEPG = (ITTTextBoxColumn)AddControl(new Guid("a8005934-bdc6-4d95-a4ef-9bcea721ca58"));
            ISAMOUNTDISCOUNTPG = (ITTCheckBoxColumn)AddControl(new Guid("27ff0c73-891f-4b58-9aff-3529648bd321"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("c37feacc-edb8-46fa-b447-937293e77ff2"));
            GRIDProcedureExceptions = (ITTGrid)AddControl(new Guid("17486132-b3d8-4fc7-bd0b-9c87253a7a99"));
            PROCEDURE = (ITTListBoxColumn)AddControl(new Guid("b5678aa5-705d-46b5-859d-06310e7576ce"));
            ISPERCENTAGEDISCOUNTPE = (ITTCheckBoxColumn)AddControl(new Guid("43473ecd-0f6f-45ec-8c2f-6ce4e94330f8"));
            DISCOUNTPRTCENTAGEPE = (ITTTextBoxColumn)AddControl(new Guid("a9763ef9-6687-484d-b208-904a43c43fac"));
            ISAMOUNTDISCOUNTPE = (ITTCheckBoxColumn)AddControl(new Guid("b26b81f6-6ae5-4438-aadd-8713ca7b0a30"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("3fa401ea-52ee-44c3-b2b1-db1ae6cb58f7"));
            GRIDMaterialGroups = (ITTGrid)AddControl(new Guid("db449b7a-a7ec-4d57-b824-f423c0cd7da6"));
            MATERIALTREE = (ITTListBoxColumn)AddControl(new Guid("7d22aee2-924d-40a1-8e92-61582320a694"));
            ISPERCENTAGEDISCOUNTMG = (ITTCheckBoxColumn)AddControl(new Guid("cd70fe9d-3c3a-4f5a-93c6-796ea02ccedc"));
            DISCOUNTPERCENTAGEMG = (ITTTextBoxColumn)AddControl(new Guid("990bd9e1-5663-4e91-bd5a-24ca6446e715"));
            ISAMOUNTDISCOUNTMG = (ITTCheckBoxColumn)AddControl(new Guid("aa721074-f963-4fbb-8cf2-a27006d5c886"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("79fdff49-232d-4069-a86e-73ee7dea2760"));
            GRIDMaterialExceptions = (ITTGrid)AddControl(new Guid("8c0ebbe5-2616-48f9-bdc7-44adf969f6f6"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("51240e4a-7b8a-4324-af92-d6fd30a6d66e"));
            ISPERCENTAGEDISCOUNTME = (ITTCheckBoxColumn)AddControl(new Guid("892292af-cc2f-4628-a774-5e629978b0d1"));
            DISCOUNTPERCENTAGEME = (ITTTextBoxColumn)AddControl(new Guid("cdfd9751-24d6-4bdf-9604-110d9d431658"));
            ISAMOUNTDISCOUNTME = (ITTCheckBoxColumn)AddControl(new Guid("83bd0832-f2e0-4546-b66f-bd3a8847c06e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9b0ad4a7-1c82-4e75-ae4d-2924854e391e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2d1be624-59ad-412c-ad4a-d896a1e1d987"));
            Description = (ITTTextBox)AddControl(new Guid("2dd179c0-1567-41cf-9924-db7f0fcb6144"));
            CODE = (ITTTextBox)AddControl(new Guid("fc242c52-e571-4f98-a43e-247ce3923f7a"));
            base.InitializeControls();
        }

        public DiscountTypeDefinitionForm() : base("DISCOUNTTYPEDEFINITION", "DiscountTypeDefinitionForm")
        {
        }

        protected DiscountTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}