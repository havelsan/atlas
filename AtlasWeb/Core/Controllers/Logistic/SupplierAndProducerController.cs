using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class SupplierAndProducerController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SupplierAndProcedureDataSource getAllSupplierOrProcedure()
        {
            SupplierAndProcedureDataSource dataSource = new SupplierAndProcedureDataSource();
            dataSource.suppliersAndProducers = new List<SuppliersAndProducer>();
            List<Supplier.GetSupplierList_Class> supps = Supplier.GetSupplierList(string.Empty).ToList();

            foreach (Supplier.GetSupplierList_Class item in supps)
            {
                SuppliersAndProducer supp = new SuppliersAndProducer();
                supp.Code = Int32.Parse(item.Code.ToString());
                if (item.IsActive != null)
                    supp.IsActive = item.IsActive.Value;
                supp.Name = item.Name;
                supp.ObjectID = item.ObjectID.Value;
                supp.Tax = item.TaxNo;
                dataSource.suppliersAndProducers.Add(supp);
            }

            return dataSource;
        }


        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public InputDVO GetSuppOrProducer(Guid ObjectID)
        {
            InputDVO inputDVO = new InputDVO();
            using (var context = new TTObjectContext(false))
            {
                Supplier supplier = context.GetObject<Supplier>(ObjectID);
                inputDVO.objectID = supplier.ObjectID;
                inputDVO.Code = Int32.Parse(supplier.Code.ToString());
                inputDVO.FirmAddress = supplier.Address;
                inputDVO.FirmEmail = supplier.Email;
                inputDVO.FirmFax = supplier.Fax;
                inputDVO.FirmGLNNo = supplier.GLNNo;
                inputDVO.FirmGLNNo = supplier.SupplierNumber;
                inputDVO.isActive = supplier.IsActive.Value;
                inputDVO.FirmName = supplier.Name;
                inputDVO.FirmNote = supplier.Note;
                inputDVO.FirmTaxNo = supplier.TaxNo;
                inputDVO.FirmTaxOfficeName = supplier.TaxOfficeName;
                inputDVO.FirmTelephone = supplier.Telephone;
                inputDVO.FirmIdentifierNo = supplier.FirmIdentifierNo.ToString();
            }
            return inputDVO;
        }
        [HttpGet]
        public InputDVO mkysSupplier(string FirmTaxNo)
        {
            InputDVO inputDVO = new InputDVO();
            TTObjectContext objectContext = new TTObjectContext(false);
            MkysServis.firmaBilgileriGetVergiNoSonuc[] firmaBilgileri = MkysServis.WebMethods.firmaBilgileriGetVergiNoSync(Sites.SiteLocalHost, FirmTaxNo);
            if (firmaBilgileri.Length > 0)
            {
                foreach (MkysServis.firmaBilgileriGetVergiNoSonuc item in firmaBilgileri)
                {
                    var supplierList = objectContext.QueryObjects<Supplier>("TAXNO = '" + item.vergiNo + "'");
                    Supplier supplier = null;
                    if (supplierList.Count > 0)
                    {
                        supplier = supplierList.FirstOrDefault();
                    }
                    else
                    {
                        supplier = new Supplier(objectContext);
                    }

                    supplier.ActivityType = ActivityTypeEnum.Firm;
                    supplier.Address = item.isAdresi;
                    supplier.Email = "";
                    supplier.Fax = "";
                    supplier.GLNNo = item.firmakod.ToString();
                    supplier.Name = item.unvan;
                    supplier.TaxNo = item.vergiNo;
                    supplier.TaxOfficeName = item.vergiDairesiAdi;
                    supplier.FirmIdentifierNo = item.firmakod;
                    supplier.Type = SupplierTypeEnum.Producer;
                    objectContext.Save();
                    objectContext.Dispose();

                    inputDVO.objectID = supplier.ObjectID;
                    inputDVO.Code = Int32.Parse(supplier.Code.ToString());
                    inputDVO.FirmAddress = supplier.Address;
                    inputDVO.FirmEmail = supplier.Email;
                    inputDVO.FirmFax = supplier.Fax;
                    inputDVO.FirmGLNNo = supplier.GLNNo;
                    inputDVO.FirmGLNNo = supplier.SupplierNumber;
                    inputDVO.isActive = supplier.IsActive.Value;
                    inputDVO.FirmName = supplier.Name;
                    inputDVO.FirmNote = supplier.Note;
                    inputDVO.FirmTaxNo = supplier.TaxNo;
                    inputDVO.FirmTaxOfficeName = supplier.TaxOfficeName;
                    inputDVO.FirmTelephone = supplier.Telephone;
                    inputDVO.FirmIdentifierNo = supplier.FirmIdentifierNo.ToString();
                }
                return inputDVO;
            }
            else
            {
                return inputDVO;
            }
        }
        [HttpGet]
        public InputDVO ütsSupplier(string FirmTaxNo)
        {
            InputDVO inputDVO = new InputDVO();
            UTSServis.FirmaSorgulaIstek firmaSorgulaIstek = new FirmaSorgulaIstek();
            firmaSorgulaIstek.VRG = FirmTaxNo;
            List<UTSServis.FirmaSorgulaCevap> sonuc = UTSServis.WebMethods.FirmaSorgulaSonucSync_ServerSide2(firmaSorgulaIstek);
            if (sonuc.Count > 0)
            {
                foreach (UTSServis.FirmaSorgulaCevap item in sonuc)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    Supplier supplier;

                    var getSupplier = objectContext.QueryObjects<Supplier>("TAXNO = '" + FirmTaxNo + "'").FirstOrDefault();

                   // IBindingList list = objectContext.QueryObjects(typeof(Supplier).Name, "TAX ='" + FirmTaxNo + "'");
                    if (getSupplier != null)
                    {
                        supplier = (Supplier)getSupplier;
                    }
                    else
                    {
                        supplier = new Supplier(objectContext);
                    }
                    supplier.GLNNo = item.MRS.ToString();
                    supplier.SupplierNumber = item.KRN.ToString();
                    if (item.DRM == "AKTIF")
                        supplier.IsActive = true;
                    else
                        supplier.IsActive = false;

                    string parseName = " - ";
                    String[] tokens = item.GAD.Split(parseName);
                    if(tokens.Length > 1)
                    {
                        String[] parseFirmName = tokens[1].Split('(');
                        if (parseFirmName.Length > 0)
                        {
                            supplier.Name = parseFirmName[0];
                        }
                        else
                        {
                            supplier.Name = tokens[1];
                        }
                    }
                    else
                    {
                        supplier.Name = item.GAD;
                    }
                    
                    supplier.Note = item.GAD;
                    supplier.TaxNo = FirmTaxNo;
                    supplier.ActivityType = ActivityTypeEnum.Firm;
                    supplier.Type = SupplierTypeEnum.Producer;
                    supplier.FirmIdentifierNo = long.Parse(item.KRN.ToString());
                    
                    objectContext.Save();
                    objectContext.Dispose();

                    inputDVO.objectID = supplier.ObjectID;
                    inputDVO.Code = Int32.Parse(supplier.Code.ToString());
                    inputDVO.FirmAddress = supplier.Address;
                    inputDVO.FirmEmail = supplier.Email;
                    inputDVO.FirmFax = supplier.Fax;
                    inputDVO.FirmGLNNo = supplier.GLNNo;
                    inputDVO.isActive = supplier.IsActive.Value;
                    inputDVO.FirmName = supplier.Name;
                    inputDVO.FirmTaxNo = supplier.TaxNo;
                    inputDVO.FirmTaxOfficeName = supplier.TaxOfficeName;
                    inputDVO.FirmTelephone = supplier.Telephone;
                    inputDVO.FirmIdentifierNo = supplier.FirmIdentifierNo.ToString();

                }



                return inputDVO;
            }
            else
            {
                return inputDVO;
            }
        }


        public void addProducer(InputDVO inputDVO, TTObjectContext objectContext)
        {
            Producer producer = new Producer(objectContext);
            producer.Address = inputDVO.FirmAddress;
            producer.Email = inputDVO.FirmEmail;
            producer.Fax = inputDVO.FirmFax;
            producer.GLNNo = inputDVO.FirmGLNNo;
            producer.SupplierNumber = inputDVO.FirmGLNNo;
            producer.IsActive = inputDVO.isActive;
            producer.Name = inputDVO.FirmName;
            producer.Note = inputDVO.FirmNote;
            producer.TaxNo = inputDVO.FirmTaxNo;
            producer.TaxOfficeName = inputDVO.FirmTaxOfficeName;
            producer.Telephone = inputDVO.FirmTelephone;

            if (string.IsNullOrEmpty(inputDVO.FirmIdentifierNo) == false)
                producer.FirmIdentifierNo = long.Parse(inputDVO.FirmIdentifierNo);
        }

        public SupplierAndProcedureDataSource saveObject(InputDVO inputDVO)
        {
            TTObjectContext objectContext = new TTObjectContext(false);

            Supplier supplier;
            if (inputDVO.objectID != Guid.Empty)
            {
                supplier = (Supplier)objectContext.GetObject(inputDVO.objectID, typeof(Supplier));
            }
            else
            {
                supplier = new Supplier(objectContext);
                this.addProducer(inputDVO,objectContext);
            }
            supplier.Address = inputDVO.FirmAddress;
            supplier.Email = inputDVO.FirmEmail;
            supplier.Fax = inputDVO.FirmFax;


            supplier.GLNNo = inputDVO.FirmGLNNo;
            supplier.SupplierNumber = inputDVO.FirmGLNNo;
            supplier.IsActive = inputDVO.isActive;
            supplier.Name = inputDVO.FirmName;
            supplier.Note = inputDVO.FirmNote;
            supplier.TaxNo = inputDVO.FirmTaxNo;
            supplier.TaxOfficeName = inputDVO.FirmTaxOfficeName;
            supplier.Telephone = inputDVO.FirmTelephone;
            supplier.ActivityType = ActivityTypeEnum.Firm;
            supplier.Type = SupplierTypeEnum.Producer;

            if (string.IsNullOrEmpty(inputDVO.FirmIdentifierNo) == false)
                supplier.FirmIdentifierNo = long.Parse(inputDVO.FirmIdentifierNo);
            objectContext.Save();


           return this.getAllSupplierOrProcedure();

        }
    }

}
