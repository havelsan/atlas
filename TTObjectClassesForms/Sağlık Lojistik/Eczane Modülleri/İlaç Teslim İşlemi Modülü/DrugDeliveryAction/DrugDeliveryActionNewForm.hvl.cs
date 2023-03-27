
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
    /// İlaç Teslim İşlemi
    /// </summary>
    public partial class DrugDeliveryActionNewForm : TTForm
    {
    /// <summary>
    /// İlaç Teslim İşlemi
    /// </summary>
        protected TTObjectClasses.DrugDeliveryAction _DrugDeliveryAction
        {
            get { return (TTObjectClasses.DrugDeliveryAction)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox ID;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel1;
        protected ITTGrid DrugDeliveryActionDetails;
        protected ITTTextBoxColumn DrugName;
        protected ITTTextBoxColumn ResDose;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5c7c166f-36b2-4489-9ed9-1299ae58b0cf"));
            ID = (ITTTextBox)AddControl(new Guid("90c03914-f341-478d-a9f3-5efc2f3c9322"));
            labelID = (ITTLabel)AddControl(new Guid("2c429909-2334-4eb6-8987-6fd6b4da4d87"));
            labelActionDate = (ITTLabel)AddControl(new Guid("aa5a479a-8b7f-4b76-bfa8-5a36ebe728b0"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("56ade96b-986f-4892-ac2f-ea081a6ee257"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("689a49e4-2de3-4c38-a8dc-e6c5e45b39c9"));
            DrugDeliveryActionDetails = (ITTGrid)AddControl(new Guid("aec70d31-1f6d-4eeb-ad4b-409180372bdb"));
            DrugName = (ITTTextBoxColumn)AddControl(new Guid("16adc2e7-8d0b-4d4d-85a4-96be0124644f"));
            ResDose = (ITTTextBoxColumn)AddControl(new Guid("8b5d700f-e394-494d-9f04-5ae63a8a39e8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f55d336d-71eb-4d01-9290-6954ac79d048"));
            base.InitializeControls();
        }

        public DrugDeliveryActionNewForm() : base("DRUGDELIVERYACTION", "DrugDeliveryActionNewForm")
        {
        }

        protected DrugDeliveryActionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}