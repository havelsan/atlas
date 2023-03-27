
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
    /// Bina Tanımı
    /// </summary>
    public partial class BuildingDefinitionForm : TTForm
    {
    /// <summary>
    /// Bina 
    /// </summary>
        protected TTObjectClasses.ResBuilding _ResBuilding
        {
            get { return (TTObjectClasses.ResBuilding)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel UzmanlikDallari;
        protected ITTCheckBox AktifBina;
        protected ITTLabel XXXXXX;
        protected ITTObjectListBox Hospital;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("5a550d1e-cf1a-48ba-bc5b-1288ba84ac83"));
            Location = (ITTTextBox)AddControl(new Guid("d808c037-2162-4c18-9e1c-97cac8106b91"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("9ae96396-b135-4ed5-841b-c1a69c705848"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("42d9ae0e-4307-412b-ba53-89a6320c5772"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("9b2d2a92-9e17-4597-930a-613428a1b045"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7a1c5f40-44d1-4ac5-826c-0ddb78a587e9"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("5d3aa71c-b986-42af-91a1-ed9956c4dc87"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("af477b67-2e55-46d5-8cd5-3caa69806dcb"));
            UzmanlikDallari = (ITTLabel)AddControl(new Guid("7cfffe6a-2b0f-4eec-a568-b0e2e25c41a9"));
            AktifBina = (ITTCheckBox)AddControl(new Guid("89d8bba8-ac84-442a-9eae-c852da356097"));
            XXXXXX = (ITTLabel)AddControl(new Guid("d82286c6-9918-4b43-9625-fac0c32834b5"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("8670cc00-261e-45cf-b653-9857fc427093"));
            base.InitializeControls();
        }

        public BuildingDefinitionForm() : base("RESBUILDING", "BuildingDefinitionForm")
        {
        }

        protected BuildingDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}