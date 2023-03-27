
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
    /// Vezne İade İşlemi
    /// </summary>
    public partial class MainCashOfficeBackOperationForm : TTForm
    {
    /// <summary>
    /// Vezne İade İşlemi
    /// </summary>
        protected TTObjectClasses.MainCashOfficeBackOperation _MainCashOfficeBackOperation
        {
            get { return (TTObjectClasses.MainCashOfficeBackOperation)_ttObject; }
        }

        protected ITTGroupBox BANKDELIVERY;
        protected ITTTextBox RECEIPTNO;
        protected ITTLabel ttlabel3;
        protected ITTTextBox SPECIALNO;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox BANKACCOUNT;
        protected ITTLabel ttlabel8;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox Description;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox MONEYBACKTYPE;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox BACKBANKACCOUNT;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            BANKDELIVERY = (ITTGroupBox)AddControl(new Guid("d25f9b6d-41b5-449b-85e2-8765e2c891fa"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("4f3a91a9-79dd-4d03-86b5-10255804ddeb"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ee489f8f-07f8-412b-883e-e0386173eeb0"));
            SPECIALNO = (ITTTextBox)AddControl(new Guid("b46fbd20-2044-48d7-9e59-800890677ef0"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("af711f2a-52fc-4975-a186-f3448f0b24b5"));
            BANKACCOUNT = (ITTObjectListBox)AddControl(new Guid("426ec14b-20a4-4c22-8184-09fd1061272f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d74805b0-2e58-4286-b415-fe0c54168463"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("bbbe2c22-a2ca-4d1c-a084-9913bf922c51"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("f5527f35-37a3-4b8b-895e-60eff724fa92"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("d87adbbc-4028-471c-9fba-f1c58afead3e"));
            Description = (ITTTextBox)AddControl(new Guid("3db1952a-f4dc-42e2-a387-2e781d752f85"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("503d3b10-790a-43af-bf68-e012884d4b7e"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e2051bdb-c3af-4961-9c9f-8faac04bd346"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("e223a679-e7b1-49ed-87f7-944ed1cbe68d"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("d958ce82-9ce6-4442-a2d7-3f5bc13e84b3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("87ef72a7-c778-4034-91c9-d430e7d556da"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1aabe24f-af7c-4ef9-85c0-aec4bf007684"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("b717e7f9-dd73-4f1f-9c13-4f6cf613f786"));
            MONEYBACKTYPE = (ITTObjectListBox)AddControl(new Guid("3c9ea2fd-0bfc-4d59-a7d4-2c2495ff8b6b"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("de52ee78-d073-4fd6-bc00-4307ee1522f8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("224f6436-17a6-4b0a-b3ca-964cbda9b344"));
            BACKBANKACCOUNT = (ITTObjectListBox)AddControl(new Guid("6afb5c6e-13d3-424b-a9c1-df894d8b2cd2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("50c6ebe2-0594-4ada-9d68-dd31613b4b44"));
            base.InitializeControls();
        }

        public MainCashOfficeBackOperationForm() : base("MAINCASHOFFICEBACKOPERATION", "MainCashOfficeBackOperationForm")
        {
        }

        protected MainCashOfficeBackOperationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}