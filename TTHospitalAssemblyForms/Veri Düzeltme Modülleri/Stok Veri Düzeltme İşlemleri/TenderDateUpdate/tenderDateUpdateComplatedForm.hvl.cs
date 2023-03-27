
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
    /// İhale Tarih ve Kayıt No Güncelleme
    /// </summary>
    public partial class tenderDateUpdateComplatedForm : TTForm
    {
    /// <summary>
    /// İhale Tarih ve Kayıt No Güncelleme
    /// </summary>
        protected TTObjectClasses.TenderDateUpdate _TenderDateUpdate
        {
            get { return (TTObjectClasses.TenderDateUpdate)_ttObject; }
        }

        protected ITTDateTimePicker AuctionDate;
        protected ITTTextBox ID;
        protected ITTTextBox RegistrationAuctionNo;
        protected ITTTextBox StockActionIDStockAction;
        protected ITTLabel labelRegistrationAuctionNo;
        protected ITTLabel labelAuctionDate;
        protected ITTLabel labelID;
        protected ITTButton ttbutton;
        protected ITTLabel labelIDBaseAction;
        override protected void InitializeControls()
        {
            AuctionDate = (ITTDateTimePicker)AddControl(new Guid("818670e4-a862-4a29-99d9-b9f93e3d37f3"));
            ID = (ITTTextBox)AddControl(new Guid("6db4c239-62b0-49a0-8d62-432bd231f70c"));
            RegistrationAuctionNo = (ITTTextBox)AddControl(new Guid("9a1137ce-d564-434c-9d58-f7d11473c604"));
            StockActionIDStockAction = (ITTTextBox)AddControl(new Guid("9cfa45d3-11a4-4c55-9b4a-57ab58d2ead2"));
            labelRegistrationAuctionNo = (ITTLabel)AddControl(new Guid("a9a4f45c-e1f0-4123-bb9b-4f6090f08c83"));
            labelAuctionDate = (ITTLabel)AddControl(new Guid("e2e25d86-59a1-4f50-b7fd-1bd728a19f0e"));
            labelID = (ITTLabel)AddControl(new Guid("e2ca1692-75f1-4638-b15a-173ac14c9fc1"));
            ttbutton = (ITTButton)AddControl(new Guid("2359567c-442a-4ddc-b441-7499b4e84025"));
            labelIDBaseAction = (ITTLabel)AddControl(new Guid("7c0edd53-9529-42c0-b887-78bf710505c4"));
            base.InitializeControls();
        }

        public tenderDateUpdateComplatedForm() : base("TENDERDATEUPDATE", "tenderDateUpdateComplatedForm")
        {
        }

        protected tenderDateUpdateComplatedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}