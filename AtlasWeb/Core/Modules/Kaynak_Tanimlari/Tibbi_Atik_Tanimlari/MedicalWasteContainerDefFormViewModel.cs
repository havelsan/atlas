using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using System.Globalization;
using System.Text;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class MedicalWasteDefServiceController : Controller
    {

        [HttpGet]
        public MedicalWasteContainerDefViewModel LoadMedicalWasteDefFormViewModel()
        {
            MedicalWasteContainerDefViewModel viewModel = new MedicalWasteContainerDefViewModel();
            viewModel.ContainerList = new List<MedicalWasteContainer>();
            viewModel.WasteTypeList = new List<MedicalWasteType>();
            viewModel.ProductList = new List<MedicalWasteProduct>();
            viewModel.ContainerList = this.GetMedicalWasteContainerList("");
            viewModel.WasteTypeList = this.GetMedicalWasteTypeList("");
            viewModel.ProductList = this.GetMedicalWasteProductList("");
            viewModel.ActiveWasteTypeList = viewModel.WasteTypeList.Where(type => type.Active == true).ToList();
            return viewModel;
        }

        #region Container Definition

        [HttpGet]
        public List<MedicalWasteContainer> SaveOrUpdateContainer(string name, int capacity, bool active, Guid? ContainerObjectID = null)
        {
            List<MedicalWasteContainer> containerList = new List<MedicalWasteContainer>();
            using (var objectContext = new TTObjectContext(false))
            {
                MedicalWasteContainerDefinition container;

                if (ContainerObjectID == null)
                    container = new MedicalWasteContainerDefinition(objectContext);
                else
                    container = objectContext.GetObject<MedicalWasteContainerDefinition>((Guid)ContainerObjectID);


                container.Name = name;
                container.Capacity = capacity;
                container.IsActive = active;

                objectContext.Save();

                containerList = this.GetMedicalWasteContainerList("");

            }
            return containerList;
        }

        [HttpGet]
        public List<MedicalWasteContainer> DeleteContainerDefinitionObject(Guid? ObjectID)
        {
            List<MedicalWasteContainer> containerList = new List<MedicalWasteContainer>();
            using (var objectContext = new TTObjectContext(false))
            {

                MedicalWasteContainerDefinition container = objectContext.GetObject<MedicalWasteContainerDefinition>((Guid)ObjectID);
                ((ITTObject)container).Delete();
                objectContext.Save();
                var list = MedicalWasteContainerDefinition.GetMedicalWasteContainerList("");

                containerList = this.GetMedicalWasteContainerList("");

                return containerList;
            }
        }

        public List<MedicalWasteContainer> GetMedicalWasteContainerList(string filter)
        {
            List<MedicalWasteContainer> containerList = new List<MedicalWasteContainer>();
            var list = MedicalWasteContainerDefinition.GetMedicalWasteContainerList(filter);
            foreach (MedicalWasteContainerDefinition.GetMedicalWasteContainerList_Class item in list)
            {
                MedicalWasteContainer model = new MedicalWasteContainer();
                model.ObjectID = item.ObjectID;
                model.Name = item.Name;
                model.Capacity = item.Capacity;
                model.Active = item.IsActive;
                model.ObjectDefName = item.ObjectDefName;

                containerList.Add(model);
            }

            return containerList;
        }

        #endregion

        #region Waste Type Definition

        public List<MedicalWasteType> GetMedicalWasteTypeList(string filter)
        {
            List<MedicalWasteType> wasteTypeList = new List<MedicalWasteType>();
            var list = MedicalWasteTypeDefinition.GetMedicalWasteTypeList(filter);
            foreach (MedicalWasteTypeDefinition.GetMedicalWasteTypeList_Class item in list)
            {
                MedicalWasteType model = new MedicalWasteType();
                model.ObjectID = item.ObjectID;
                model.Name = item.Name;
                model.Code = item.Code;
                model.Active = item.IsActive;
                model.ObjectDefName = item.ObjectDefName;

                wasteTypeList.Add(model);
            }

            return wasteTypeList;
        }

        [HttpGet]
        public List<MedicalWasteType> SaveOrUpdateWasteType(string name, string code, bool active, Guid? WasteTypeObjectID = null)
        {
            List<MedicalWasteType> wasteTypeList = new List<MedicalWasteType>();
            using (var objectContext = new TTObjectContext(false))
            {
                MedicalWasteTypeDefinition type;

                if (WasteTypeObjectID == null)
                    type = new MedicalWasteTypeDefinition(objectContext);
                else
                    type = objectContext.GetObject<MedicalWasteTypeDefinition>((Guid)WasteTypeObjectID);


                type.Name = name;
                type.Code = code;
                type.IsActive = active;

                objectContext.Save();

                wasteTypeList = this.GetMedicalWasteTypeList("");

            }
            return wasteTypeList;
        }

        [HttpGet]
        public List<MedicalWasteType> DeleteWasteTypeDefinitionObject(Guid? ObjectID)
        {
            List<MedicalWasteType> wasteTypeList = new List<MedicalWasteType>();
            using (var objectContext = new TTObjectContext(false))
            {

                MedicalWasteTypeDefinition type = objectContext.GetObject<MedicalWasteTypeDefinition>((Guid)ObjectID);
                ((ITTObject)type).Delete();
                objectContext.Save();

                wasteTypeList = this.GetMedicalWasteTypeList("");

                return wasteTypeList;
            }
        }

        #endregion

        #region Procedure Definition
        public List<MedicalWasteProduct> GetMedicalWasteProductList(string filter)
        {
            List<MedicalWasteProduct> productList = new List<MedicalWasteProduct>();
            var list = MedicalWasteProduceDefinition.GetMedicalWasteProcedureList(filter);
            foreach (MedicalWasteProduceDefinition.GetMedicalWasteProcedureList_Class item in list)
            {
                MedicalWasteProduct model = new MedicalWasteProduct();
                model.ObjectID = item.ObjectID;
                model.Name = item.Name;
                model.Code = item.Code;
                model.Active = item.IsActive;
                model.ObjectDefName = item.ObjectDefName;
                model.WasteTypeName = item.Typename;
                model.WasteTypeID = item.Typeobjectid;

                productList.Add(model);
            }

            return productList;
        }


        [HttpGet]
        public List<MedicalWasteProduct> SaveOrUpdateProduct(string name, string code, bool active, Guid? TypeObjectID, Guid? ProductObjectID = null)
        {
            List<MedicalWasteProduct> productList = new List<MedicalWasteProduct>();
            using (var objectContext = new TTObjectContext(false))
            {
                MedicalWasteProduceDefinition product;

                if (ProductObjectID == null)
                    product = new MedicalWasteProduceDefinition(objectContext);
                else
                    product = objectContext.GetObject<MedicalWasteProduceDefinition>((Guid)ProductObjectID);

                MedicalWasteTypeDefinition def = objectContext.GetObject<MedicalWasteTypeDefinition>((Guid)TypeObjectID);
                product.Name = name;
                product.Code = code;
                product.IsActive = active;
                product.MedicalWasteType = def;

                objectContext.Save();

                productList = this.GetMedicalWasteProductList("");

            }
            return productList;
        }


        [HttpGet]
        public List<MedicalWasteProduct> DeleteWasteProductDefinitionObject(Guid? ObjectID)
        {
            List<MedicalWasteProduct> productList = new List<MedicalWasteProduct>();
            using (var objectContext = new TTObjectContext(false))
            {

                MedicalWasteProduceDefinition pro = objectContext.GetObject<MedicalWasteProduceDefinition>((Guid)ObjectID);
                ((ITTObject)pro).Delete();
                objectContext.Save();

                productList = this.GetMedicalWasteProductList("");

                return productList;
            }
        }


        #endregion
    }
}

namespace Core.Models
{
    public class MedicalWasteContainerDefViewModel
    {
        public List<MedicalWasteContainer> ContainerList { get; set; }
        public List<MedicalWasteType> WasteTypeList { get; set; }
        public List<MedicalWasteProduct> ProductList { get; set; }
        public List<MedicalWasteType> ActiveWasteTypeList { get; set; }

    }

    public class MedicalWasteContainer
    {
        public Guid? ObjectID { get; set; }
        public int? Capacity { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string ObjectDefName { get; set; }
    }
    public class MedicalWasteType
    {
        public Guid? ObjectID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string ObjectDefName { get; set; }
    }

    public class MedicalWasteProduct
    {
        public Guid? ObjectID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string ObjectDefName { get; set; }
        public string WasteTypeName { get; set; }
        public Guid? WasteTypeID { get; set; }
    }
}
