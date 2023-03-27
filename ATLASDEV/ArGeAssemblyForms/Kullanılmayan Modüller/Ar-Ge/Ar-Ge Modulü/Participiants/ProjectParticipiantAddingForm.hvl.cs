
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
    public partial class ProjectParticipiantAddingForm : TTForm
    {
        protected TTObjectClasses.Participiants _Participiants
        {
            get { return (TTObjectClasses.Participiants)_ttObject; }
        }

        protected ITTLabel labelOwnerDepartment;
        protected ITTObjectListBox OwnerDepartment;
        protected ITTLabel labelNameMilitaryClassDefinitions;
        protected ITTTextBox NameMilitaryClassDefinitions;
        protected ITTTextBox NameRankDefinitions;
        protected ITTTextBox Biography;
        protected ITTLabel labelNameRankDefinitions;
        protected ITTLabel labelProjectParticipiant;
        protected ITTObjectListBox ProjectParticipiant;
        protected ITTLabel labelBiography;
        override protected void InitializeControls()
        {
            labelOwnerDepartment = (ITTLabel)AddControl(new Guid("10cb8d22-553a-45ba-8088-98945f67459a"));
            OwnerDepartment = (ITTObjectListBox)AddControl(new Guid("de9b3c42-2054-4778-9d3a-64383d94d0c4"));
            labelNameMilitaryClassDefinitions = (ITTLabel)AddControl(new Guid("7f635409-c642-476a-892c-9ea9343be3c6"));
            NameMilitaryClassDefinitions = (ITTTextBox)AddControl(new Guid("a9cb48b4-fc31-4d69-9912-2d05f0df9941"));
            NameRankDefinitions = (ITTTextBox)AddControl(new Guid("078ed602-dce0-414d-9ca8-c1fab663a063"));
            Biography = (ITTTextBox)AddControl(new Guid("3d6713de-75e1-475f-9832-29e47b6a7228"));
            labelNameRankDefinitions = (ITTLabel)AddControl(new Guid("96f85381-e0ff-4e6f-87e7-dcbf1c608e7d"));
            labelProjectParticipiant = (ITTLabel)AddControl(new Guid("730b2321-558b-40f5-9346-7fe834ec856b"));
            ProjectParticipiant = (ITTObjectListBox)AddControl(new Guid("a9e0563e-9258-464a-84c4-7683113c97e2"));
            labelBiography = (ITTLabel)AddControl(new Guid("3f3a541b-dcbc-4178-a33a-b916c797375f"));
            base.InitializeControls();
        }

        public ProjectParticipiantAddingForm() : base("PARTICIPIANTS", "ProjectParticipiantAddingForm")
        {
        }

        protected ProjectParticipiantAddingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}