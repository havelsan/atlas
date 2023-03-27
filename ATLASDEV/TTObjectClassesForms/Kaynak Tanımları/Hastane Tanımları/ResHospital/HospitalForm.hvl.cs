
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
    /// XXXXXX Tanımı
    /// </summary>
    public partial class HospitalForm : TTForm
    {
    /// <summary>
    /// XXXXXX
    /// </summary>
        protected TTObjectClasses.ResHospital _ResHospital
        {
            get { return (TTObjectClasses.ResHospital)_ttObject; }
        }

        protected ITTLabel labelSKRSIlceKodlari;
        protected ITTObjectListBox SKRSIlceKodlari;
        protected ITTLabel labelSKRSILKodlari;
        protected ITTObjectListBox SKRSILKodlari;
        protected ITTLabel labelSite;
        protected ITTObjectListBox Site;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelQref;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelSKRSIlceKodlari = (ITTLabel)AddControl(new Guid("f4c6676e-3288-45e7-8c04-de3dcc30ed1d"));
            SKRSIlceKodlari = (ITTObjectListBox)AddControl(new Guid("01ae65ce-1504-4fad-b408-9bcf98b22ac3"));
            labelSKRSILKodlari = (ITTLabel)AddControl(new Guid("363bb814-3ec4-4fce-a627-1f11e41dea7f"));
            SKRSILKodlari = (ITTObjectListBox)AddControl(new Guid("ed1e12e2-85c0-4c3d-aa6e-ccbc4d2e798b"));
            labelSite = (ITTLabel)AddControl(new Guid("b833f867-bbef-46c0-bc99-bc87e2684ce6"));
            Site = (ITTObjectListBox)AddControl(new Guid("d6a45f87-3114-4f4b-a6b6-f4a5c18a89aa"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("3331f9bc-25c4-4710-86a8-c95127a96ef3"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("a122e173-9316-4901-8457-a5a875b0dad3"));
            labelQref = (ITTLabel)AddControl(new Guid("9d7124a1-acfd-40af-b412-3d35b9da141c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7318e6e3-cae6-4a3d-809b-04b1d0972334"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("fbe362cf-e0cf-4704-a31d-7750a6229140"));
            Location = (ITTTextBox)AddControl(new Guid("8c9f54b1-7cf0-4dd3-aa7a-693a3e686049"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("529002d3-4367-4c3b-9a84-1e0120e48550"));
            labelName = (ITTLabel)AddControl(new Guid("5c3181b5-5eee-4622-bb30-e832dbf6fcbc"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("a4c5b540-e0de-4841-9fed-69c245e39594"));
            labelLocation = (ITTLabel)AddControl(new Guid("164187c5-79db-409c-807d-f30ac817a611"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("ab021964-6276-46c6-9c81-5c7e4e03ff60"));
            base.InitializeControls();
        }

        public HospitalForm() : base("RESHOSPITAL", "HospitalForm")
        {
        }

        protected HospitalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}