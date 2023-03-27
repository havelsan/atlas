
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class InvoiceInclusionMasterForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            btnCheckAllBranch.Click += new TTControlEventDelegate(btnCheckAllBranch_Click);
            btnUnCheckAllBranch.Click += new TTControlEventDelegate(btnUnCheckAllBranch_Click);
            btnCheckBulletinBranch.Click += new TTControlEventDelegate(btnCheckBulletinBranch_Click);
            btnCheckUnBulletinBranch.Click += new TTControlEventDelegate(btnCheckUnBulletinBranch_Click);

            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnCheckAllBranch.Click -= new TTControlEventDelegate(btnCheckAllBranch_Click);
            btnUnCheckAllBranch.Click -= new TTControlEventDelegate(btnUnCheckAllBranch_Click);
            btnCheckBulletinBranch.Click -= new TTControlEventDelegate(btnCheckBulletinBranch_Click);
            btnCheckUnBulletinBranch.Click -= new TTControlEventDelegate(btnCheckUnBulletinBranch_Click);
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
            #region InvoiceInclusionMasterForm_PreScript
            base.PreScript();

            TTObjectContext context = new TTObjectContext(true);
            IBindingList specialityList = context.QueryObjects("SpecialityDefinition", "ISACTIVE = 1  ORDER BY NAME");

            foreach (SpecialityDefinition item in specialityList)
            {

                bool found = false;
                foreach (IIMSpeciality innerItem in _InvoiceInclusionMaster.IIMSpecialities)
                {
                    if (item.ObjectID == innerItem.Speciality.ObjectID)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    IIMSpeciality newIIMSpeciality = new IIMSpeciality(_InvoiceInclusionMaster.ObjectContext);
                    newIIMSpeciality.Speciality = (SpecialityDefinition)_InvoiceInclusionMaster.ObjectContext.GetObject(item.ObjectID, typeof(SpecialityDefinition));
                    newIIMSpeciality.Checked = false;
                    newIIMSpeciality.InvoiceInclusionMaster = _InvoiceInclusionMaster;
                    _InvoiceInclusionMaster.IIMSpecialities.Add(newIIMSpeciality);
                }
            }


            IBindingList protocolList = context.QueryObjects("ProtocolDefinition", "ISACTIVE = 1  ORDER BY NAME");

            foreach (ProtocolDefinition item in protocolList)
            {

                bool found = false;
                foreach (IIMProtocol innerItem in _InvoiceInclusionMaster.IIMProtocols)
                {
                    if (item.ObjectID == innerItem.ProtocolDefinition.ObjectID)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    IIMProtocol newIIMProtocol = new IIMProtocol(_InvoiceInclusionMaster.ObjectContext);
                    newIIMProtocol.ProtocolDefinition = (ProtocolDefinition)_InvoiceInclusionMaster.ObjectContext.GetObject(item.ObjectID, typeof(ProtocolDefinition));
                    newIIMProtocol.Checked = false;
                    newIIMProtocol.InvoiceInclusionMaster = _InvoiceInclusionMaster;
                    _InvoiceInclusionMaster.IIMProtocols.Add(newIIMProtocol);
                }
            }


            IBindingList detailList = context.QueryObjects("InvoiceInclusionDetail", " ISACTIVE = 1  ORDER BY TYPE ");

            foreach (InvoiceInclusionDetail item in detailList)
            {

                bool found = false;
                foreach (IIMDetail innerItem in _InvoiceInclusionMaster.IIMDetails)
                {
                    if (item.ObjectID == innerItem.InvoiceInclusionDetail.ObjectID)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    IIMDetail newInvoiceInclusionDetail = new IIMDetail(_InvoiceInclusionMaster.ObjectContext);
                    newInvoiceInclusionDetail.InvoiceInclusionDetail = (InvoiceInclusionDetail)_InvoiceInclusionMaster.ObjectContext.GetObject(item.ObjectID, typeof(InvoiceInclusionDetail));
                    newInvoiceInclusionDetail.Checked = false;
                    newInvoiceInclusionDetail.InvoiceInclusionMaster = _InvoiceInclusionMaster;
                    _InvoiceInclusionMaster.IIMDetails.Add(newInvoiceInclusionDetail);
                }
            }
            #endregion InvoiceInclusionMasterForm_PreScript

        }

        private void btnCheckAllBranch_Click()
        {
            foreach (IIMSpeciality speciality in _InvoiceInclusionMaster.IIMSpecialities)
                speciality.Checked = true;
        }

        private void btnUnCheckAllBranch_Click()
        {
            foreach (IIMSpeciality speciality in _InvoiceInclusionMaster.IIMSpecialities)
                speciality.Checked = false;
        }

        private void btnCheckBulletinBranch_Click()
        {
            foreach (IIMSpeciality speciality in _InvoiceInclusionMaster.IIMSpecialities)
            {
                if (speciality.Speciality.IsBulletin == true)
                    speciality.Checked = true;
                else
                    speciality.Checked = false;
            }
        }

        private void btnCheckUnBulletinBranch_Click()
        {
            foreach (IIMSpeciality speciality in _InvoiceInclusionMaster.IIMSpecialities)
            {
                if (speciality.Speciality.IsBulletin == true)
                    speciality.Checked = false;
                else
                    speciality.Checked = true;
            }
        }
    }
}