
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
    /// Firma Personeli Listesi
    /// </summary>
    public partial class FirmPersonelList : TTForm
    {
    /// <summary>
    /// Firma Personeli
    /// </summary>
        protected TTObjectClasses.MNZFirmPersonnel _MNZFirmPersonnel
        {
            get { return (TTObjectClasses.MNZFirmPersonnel)_ttObject; }
        }

        protected ITTTextBox LisencePlate;
        protected ITTTextBox NationalIdentity;
        protected ITTTextBox Surname;
        protected ITTLabel labelNationalIdentity;
        protected ITTLabel labelName;
        protected ITTTextBox Title;
        protected ITTLabel labelSurname;
        protected ITTGrid ttgrid1;
        protected ITTLabel labelWorkingUnit;
        protected ITTObjectListBox WorkingUnit;
        protected ITTLabel labelLisencePlate;
        protected ITTLabel labelTitle;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            LisencePlate = (ITTTextBox)AddControl(new Guid("1fac519b-037f-422a-9b43-0a869a003e33"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("15d8dc3b-707e-4aa6-896c-0dfc72d66723"));
            Surname = (ITTTextBox)AddControl(new Guid("f11945d5-b126-4555-ada9-138ee2f3a8a8"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("c2b2bc98-4b41-48f4-bbbc-1f5620235829"));
            labelName = (ITTLabel)AddControl(new Guid("e706e0da-10ef-4e39-af74-27d111f00f06"));
            Title = (ITTTextBox)AddControl(new Guid("7f629556-fcc2-4969-9b53-5d93fd4b4c5a"));
            labelSurname = (ITTLabel)AddControl(new Guid("8cadaae5-fa76-4106-849e-83d5baec714a"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("b641b42e-df63-4987-93ac-9e6497b73185"));
            labelWorkingUnit = (ITTLabel)AddControl(new Guid("0ed1406f-83df-47f2-b60b-9c8d47b55b1b"));
            WorkingUnit = (ITTObjectListBox)AddControl(new Guid("80cdbde8-d0fc-4236-9989-a3dc456896b7"));
            labelLisencePlate = (ITTLabel)AddControl(new Guid("20b6c0fb-d438-4f1d-9d69-98c9d40976e4"));
            labelTitle = (ITTLabel)AddControl(new Guid("2e6b6c5b-6c3e-40bc-a994-bf609ab76043"));
            Name = (ITTTextBox)AddControl(new Guid("3d6d37b5-4c77-4214-816b-f4f6a0882e18"));
            base.InitializeControls();
        }

        public FirmPersonelList() : base("MNZFIRMPERSONNEL", "FirmPersonelList")
        {
        }

        protected FirmPersonelList(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}