
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
    public partial class tenderDateUpdateNewForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// İhale Tarih ve Kayıt No Güncelleme
    /// </summary>
        protected TTObjectClasses.TenderDateUpdate _TenderDateUpdate
        {
            get { return (TTObjectClasses.TenderDateUpdate)_ttObject; }
        }

        protected ITTTextBox RegistrationAuctionNo;
        protected ITTTextBox StockActionIDStockAction;
        protected ITTLabel labelRegistrationAuctionNo;
        protected ITTLabel labelAuctionDate;
        protected ITTDateTimePicker AuctionDate;
        protected ITTButton ttbutton;
        protected ITTLabel labelIDBaseAction;
        override protected void InitializeControls()
        {
            RegistrationAuctionNo = (ITTTextBox)AddControl(new Guid("3687e8e3-1a24-4bf5-9e54-e5475362a837"));
            StockActionIDStockAction = (ITTTextBox)AddControl(new Guid("7d38064a-00b2-48d8-9d53-4d85e72fe545"));
            labelRegistrationAuctionNo = (ITTLabel)AddControl(new Guid("a3a7a329-dae2-4e2c-a2c1-3465b81fb561"));
            labelAuctionDate = (ITTLabel)AddControl(new Guid("aac280d1-1371-47b4-9a83-148faebd40d1"));
            AuctionDate = (ITTDateTimePicker)AddControl(new Guid("3bd50518-8d2a-43d8-80d3-effcc3a38856"));
            ttbutton = (ITTButton)AddControl(new Guid("1da8eb86-40fa-4fad-b2d1-4909bcf63e06"));
            labelIDBaseAction = (ITTLabel)AddControl(new Guid("dcf79820-e7a2-4538-9bf7-c22bf8091895"));
            base.InitializeControls();
        }

        public tenderDateUpdateNewForm() : base("TENDERDATEUPDATE", "tenderDateUpdateNewForm")
        {
        }

        protected tenderDateUpdateNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}