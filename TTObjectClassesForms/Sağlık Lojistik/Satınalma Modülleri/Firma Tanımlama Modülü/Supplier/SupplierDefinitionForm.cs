
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
    /// <summary>
    /// Tedarikçi Tanımı
    /// </summary>
    public partial class SupplierDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            ttTedarikceUpdate.Click += new TTControlEventDelegate(ttTedarikceUpdate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttTedarikceUpdate.Click -= new TTControlEventDelegate(ttTedarikceUpdate_Click);
            base.UnBindControlEvents();
        }

        private void ttTedarikceUpdate_Click()
        {
            #region SupplierDefinitionForm_ttTedarikceUpdate_Click
            //ITSStakeHolderServis.stakeholderRequest request = new ITSStakeHolderServis.stakeholderRequest();
            //ITSStakeHolderServis.stakeholderResponse response = new ITSStakeHolderServis.stakeholderResponse();

            //labelProgress.Text = "Tedarikçi Listesi Güncelleniyor....";
            ////Application.DoEvents();.DoEvents();

            //request.stakeholderType = "depo";
            //response = ITSStakeHolderServis.WebMethods.CallStakeholder(Sites.SiteLocalHost, request);
            //int sayac = 0;

            //foreach (ITSStakeHolderServis.company cmp in response.companies)
            //{
            //    IList supplierlist = _Supplier.ObjectContext.QueryObjects("SUPPLIER", "GLNNO = '" + cmp.gln + "'");
            //    if (supplierlist.Count == 0)
            //    {
            //        TTObjectContext itssupplierContext = new TTObjectContext(false);
            //        Supplier sp = new Supplier(itssupplierContext);
            //        sp.ActivityType = ActivityTypeEnum.Firm;
            //        sp.Address = cmp.address;
            //        //sp.Code = //SupplierCodeSeq
            //        sp.Email = cmp.email;
            //        sp.Fax = "";
            //        sp.GLNNo = cmp.gln;
            //        sp.Name = cmp.companyName.ToUpper();
            //        sp.Note = "ITS";
            //        sp.RelatedPerson = "";
            //        //sp.TaxNo =  "";
            //        sp.Telephone = cmp.phone;
            //        sp.Type = SupplierTypeEnum.Producer;

            //        itssupplierContext.Save();
            //        itssupplierContext.Dispose();

            //        labelProgress.Text = sayac + " - " + cmp.companyName + " Eklendi!";
            //        //Application.DoEvents();.DoEvents();

            //        sayac++;
            //    }

            //}


            //ITSStakeHolderServis.stakeholderRequest requesturetici = new ITSStakeHolderServis.stakeholderRequest();
            //ITSStakeHolderServis.stakeholderResponse responseuretici = new ITSStakeHolderServis.stakeholderResponse();

            //requesturetici.stakeholderType = "uretici";
            //responseuretici = ITSStakeHolderServis.RemoteMethods.CallStakeholder(Sites.SiteLocalHost, requesturetici);

            //foreach(ITSStakeHolderServis.company cmp in responseuretici.companies)
            //{
            //    IList supplierlist = _Supplier.ObjectContext.QueryObjects("SUPPLIER", "GLNNO = '" + cmp.gln + "'");
            //    if(supplierlist.Count == 0)
            //    {
            //        TTObjectContext itssupplierContext = new TTObjectContext(false);            
            //        Supplier sp = new Supplier(itssupplierContext);
            //        sp.ActivityType = ActivityTypeEnum.Firm;
            //        sp.Address = cmp.address;
            //        //sp.Code = //SupplierCodeSeq
            //        sp.Email = cmp.email;
            //        sp.Fax = "";
            //        sp.GLNNo = cmp.gln;
            //        sp.Name = cmp.companyName.ToUpper();
            //        sp.Note = "ITS";
            //        sp.RelatedPerson = "";
            //        //sp.TaxNo =  "";
            //        sp.Telephone = cmp.phone;
            //        sp.Type = SupplierTypeEnum.Producer;

            //        itssupplierContext.Save();
            //        itssupplierContext.Dispose();

            //        labelProgress.Text = sayac + " - " + cmp.companyName + " Eklendi!";
            //        //Application.DoEvents();.DoEvents();

            //        sayac++;
            //    }

        }


        //ITSStakeHolderServis.stakeholderRequest requestXXXXXX = new ITSStakeHolderServis.stakeholderRequest();
        //ITSStakeHolderServis.stakeholderResponse responseXXXXXX = new ITSStakeHolderServis.stakeholderResponse();

        //requestXXXXXX.stakeholderType = "XXXXXX";
        //responseXXXXXX = ITSStakeHolderServis.RemoteMethods.CallStakeholder(Sites.SiteLocalHost, requestXXXXXX);

        //foreach(ITSStakeHolderServis.company cmp in responseXXXXXX.companies)
        //{
        //    IList supplierlist = _Supplier.ObjectContext.QueryObjects("SUPPLIER", "GLNNO = '" + cmp.gln + "'");
        //    if(supplierlist.Count == 0)
        //    {
        //        TTObjectContext itssupplierContext = new TTObjectContext(false);            
        //        Supplier sp = new Supplier(itssupplierContext);
        //        sp.ActivityType = ActivityTypeEnum.Firm;
        //        sp.Address = cmp.address;
        //        //sp.Code = //SupplierCodeSeq
        //        sp.Email = cmp.email;
        //        sp.Fax = "";
        //        sp.GLNNo = cmp.gln;
        //        sp.Name = cmp.companyName.ToUpper();
        //        sp.Note = "ITS";
        //        sp.RelatedPerson = "";
        //        //sp.TaxNo =  "";
        //        sp.Telephone = cmp.phone;
        //        sp.Type = SupplierTypeEnum.Producer;

        //        itssupplierContext.Save();
        //        itssupplierContext.Dispose();

        //        labelProgress.Text = sayac + " - " + cmp.companyName + " Eklendi!";
        //        //Application.DoEvents();.DoEvents();

        //        sayac++;
        //    }

        //}


        //labelProgress.Text = sayac.ToString() + " adet Tedarikçi Eklendi.!";
        #endregion SupplierDefinitionForm_ttTedarikceUpdate_Click
    }


    
}