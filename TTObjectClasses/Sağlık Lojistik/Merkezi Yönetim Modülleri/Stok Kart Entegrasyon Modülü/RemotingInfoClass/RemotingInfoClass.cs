
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


namespace TTObjectClasses
{
    public  abstract  partial class RemotingInfoClass : TTObject
    {
#region Methods
        [Serializable]
        public class StockCardCentralInfo
        {
            public StockCard stockCard;
            public StockCardClass stockCardClass;
            public DistributionTypeDefinition distributionTypeDefinition;

            public StockCardCentralInfo()
            {
            }

            public void AddContext(TTObjectContext objectContext)
            {
                if (stockCardClass != null)
                    objectContext.AddObject(stockCardClass);
                if (distributionTypeDefinition != null)
                    objectContext.AddObject(distributionTypeDefinition);
                if (stockCard != null)
                    objectContext.AddObject(stockCard);
            }
        }

        [Serializable]
        public class MaterialInfo
        {
            public Material material;
            public MaterialTreeDefinition materialTreeDefinition;
            public MaterialTreeDefinition parentMaterialTreeDefinition;
            public Sites createdSite;
            public string barcode;
            public List<RemotingInfoClass.MaterialBarcodeLevelInfo> materialBarcodeLevelInfos;

            public MaterialInfo()
            {
            }

            public void AddContext(TTObjectContext objectContext)
            {
                if (material != null)
                    objectContext.AddObject(material);
                if (materialTreeDefinition != null)
                    objectContext.AddObject(materialTreeDefinition);
                if (parentMaterialTreeDefinition != null)
                    objectContext.AddObject(parentMaterialTreeDefinition);
                if (createdSite != null)
                    objectContext.AddObject(createdSite);
                if (materialBarcodeLevelInfos != null)
                    foreach (RemotingInfoClass.MaterialBarcodeLevelInfo materialBarcodeLevelInfo in materialBarcodeLevelInfos)
                    materialBarcodeLevelInfo.AddContext(objectContext);
            }
        }

        [Serializable]
        public class MaterialBarcodeLevelInfo
        {
            public MaterialBarcodeLevel materialBarcodeLevel;
            public Producer producer;
            public GMDNDefinition gmdnDefinition;

            public MaterialBarcodeLevelInfo()
            {
            }

            public void AddContext(TTObjectContext objectContext)
            {
                if (materialBarcodeLevel != null)
                    objectContext.AddObject(materialBarcodeLevel);
                if (producer != null)
                    objectContext.AddObject(producer);
                if (gmdnDefinition != null)
                    objectContext.AddObject(gmdnDefinition);
            }
        }
        
        [Serializable]
        public class MaterialInheldInfo
        {
            public Accountancy accountancy;
            public Double inheld;
            public Double consigned;
            public Double maxLevel;
            public Double minLevel;
            public Guid mainStoreObjectID;
            public string lotNo;

            public MaterialInheldInfo()
            {
                
            }

            public void AddContext(TTObjectContext objectContext)
            {
                if (accountancy != null)
                    objectContext.AddObject(accountancy);
            }
        }

        [Serializable]
        public class MaterialInheldDetailInfo
        {
            public List<RemotingInfoClass.MaterialOutableDetailInfo> materialOutableDetailInfos;
            public Double inheld;
            public Double consigned;
            public Double maxLevel;
            public Double minLevel;
            public Double totalIn;
            public Double totalOut;
            public Double censusYearCensus;
            public Double censusTotalIn;
            public Double censusTotalOut;
            public Double censusTotalInheld;
            public String censusDescription;
            public Double reservationAmount;

            public MaterialInheldDetailInfo()
            {

            }

            public void AddContext(TTObjectContext objectContext)
            {
                if (materialOutableDetailInfos != null)
                    foreach (RemotingInfoClass.MaterialOutableDetailInfo materialOutableDetailInfo in materialOutableDetailInfos)
                    materialOutableDetailInfo.AddContext(objectContext);
            }
        }

        [Serializable]
        public class MaterialOutableDetailInfo
        {
            public String lotNo;
            public DateTime expirationDate;
            public String restAmount;

            public MaterialOutableDetailInfo()
            {

            }
            public void AddContext(TTObjectContext objectContext)
            {

            }
        }

        [Serializable]
        public class StockCardInfo
        {
            public StockCard stockCard;
            public StockCardClass stockCardClass;
            public StockCardClass parentStockCardClass;
            public DistributionTypeDefinition distributionTypeDefinition;
            public NATOGroupCode natoGroupCode;
            public GMDNDefinition gmdnDefinition;
            public Sites createdSite;
            public List<RemotingInfoClass.MaterialInfo> materialInfos;

            public StockCardInfo()
            {
            }

            public StockCardInfo(Guid objectID)
                : this()
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                StockCard stockCardObject = (StockCard)objectContext.GetObject(objectID, typeof(StockCard));

                if (stockCardObject != null)
                {
                    stockCard = stockCardObject;
                    stockCardClass = stockCardObject.StockCardClass;
                    if (stockCardObject.StockCardClass != null)
                        parentStockCardClass = stockCardObject.StockCardClass.ParentStockCardClass;
                    distributionTypeDefinition = stockCardObject.DistributionType;
                    gmdnDefinition = stockCardObject.GMDNCode;
                    createdSite = stockCardObject.CreatedSite;

                    if (stockCardObject.Materials.Count > 0)
                    {
                        materialInfos = new List<RemotingInfoClass.MaterialInfo>();
                        foreach (Material material in stockCardObject.Materials)
                        {
                            //if (material.IsOldMaterial == false)
                            //{
                            RemotingInfoClass.MaterialInfo materialInfo = new RemotingInfoClass.MaterialInfo();
                            materialInfo.material = material;
                            materialInfo.materialTreeDefinition = material.MaterialTree;
                            materialInfo.createdSite = material.CreatedSite;
                            if (material.MaterialTree.ParentMaterialTree != null)
                                materialInfo.parentMaterialTreeDefinition = material.MaterialTree.ParentMaterialTree;

                            if (material.MaterialBarcodeLevels.Count > 0)
                            {
                                materialInfo.materialBarcodeLevelInfos = new List<RemotingInfoClass.MaterialBarcodeLevelInfo>();
                                foreach (MaterialBarcodeLevel materialBarcodeLevel in material.MaterialBarcodeLevels)
                                {
                                    RemotingInfoClass.MaterialBarcodeLevelInfo materialBarcodeLevelInfo = new RemotingInfoClass.MaterialBarcodeLevelInfo();
                                    materialBarcodeLevelInfo.gmdnDefinition = materialBarcodeLevel.GMDNDefinition;
                                    materialBarcodeLevelInfo.materialBarcodeLevel = materialBarcodeLevel;
                                    materialBarcodeLevelInfo.producer = materialBarcodeLevel.Producer;
                                    materialInfo.materialBarcodeLevelInfos.Add(materialBarcodeLevelInfo);
                                }
                            }
                            materialInfos.Add(materialInfo);
                            //}
                        }
                    }
                }

            }

           /*  public string Save()
            {

               if (newStockCard == null)
                    throw new TTException(SystemMessage.GetMessage(938));

                TTObjectContext objectContext = new TTObjectContext(false);
                AddContext(objectContext);

                StockCard createdStockCard = (StockCard)objectContext.GetObject(stockCard.ObjectID, stockCard.ObjectDef);
                createdStockCard.Name = newStockCard.Name;
                
                createdStockCard.CardPicture = newStockCard.StockCardPicture;
                if (newStockCard.StockCardPicture != null)
                    createdStockCard.CardPicture = newStockCard.StockCardPicture;
                if (createdStockCard.MainStoreCheckbox.HasValue == false)
                    createdStockCard.MainStoreCheckbox = false;
                if (createdStockCard.ProductionCheckbox.HasValue == false)
                    createdStockCard.ProductionCheckbox = false;
                createdStockCard.CreatedSite = newStockCard.CreatedSite;
                if (createdStockCard.CreatedSite == null)
                    createdStockCard.CreatedSite = Sites.AllSites[Sites.SiteMerkezSagKom];
                AccountancyStockCard accountancyStockCard = new AccountancyStockCard(objectContext);
                accountancyStockCard.Accountancy = ((MainStoreDefinition)newStockCard.SelectedStore).Accountancy;
                accountancyStockCard.CardDrawer = newStockCard.CardDrawer;
                accountancyStockCard.CreationDate = newStockCard.CreationDate;
                accountancyStockCard.Status = newStockCard.Status;
                accountancyStockCard.StockCard = createdStockCard;


                foreach (Material material in newStockCard.SelectedMaterials)
                {
                    if (material.Stocks.Count == 0)
                    {
                        new Stock(objectContext, newStockCard.SelectedStore, material);
                    }
                }

                objectContext.Save();
                objectContext.Dispose();
                return createdStockCard.Name + " isimli stok kartı başarıyla yaratılmıştır.";
            }*/

            public void AddContext(TTObjectContext objectContext)
            {
                if (parentStockCardClass != null)
                    objectContext.AddObject(parentStockCardClass);
                if (stockCardClass != null)
                    objectContext.AddObject(stockCardClass);
                if (distributionTypeDefinition != null)
                    objectContext.AddObject(distributionTypeDefinition);
                if (gmdnDefinition != null)
                    objectContext.AddObject(gmdnDefinition);
                if (natoGroupCode != null)
                    objectContext.AddObject(natoGroupCode);
                if (createdSite != null)
                    objectContext.AddObject(createdSite);
                if (stockCard != null)
                    objectContext.AddObject(stockCard);
                if (materialInfos != null)
                    foreach (RemotingInfoClass.MaterialInfo materialInfo in materialInfos)
                    materialInfo.AddContext(objectContext);
            }
        }

        [Serializable]
        public class FixedAssetInfo
        {
            public FixedAssetDefinition fixedAssetDefinition;
            public FixedAssetMaterialDefinition fixedAssetMaterialDefinition;
            public FixedAssetMaintenanceParameter fixedAssetMaintenanceParameter;
            public CalibrationTestDefinition calibrationTestDefinition;
            public FixedAssetMaterialContent content;

            public FixedAssetInfo()
            {
            }

            public string Save()
            {
                // Demirbaş varmı diye kontrol etmek lazım. SS.
                TTObjectContext objectContext = new TTObjectContext(false);

                AddContext(objectContext);

                objectContext.Save();
                objectContext.Dispose();
                return TTUtils.CultureService.GetText("M25405", "Demirbaş başarıyla yaratılmıştır.");

            }

            public void AddContext(TTObjectContext objectContext)
            {
                if (fixedAssetDefinition != null)
                    objectContext.AddObject(fixedAssetDefinition);
                if (fixedAssetMaterialDefinition != null)
                    objectContext.AddObject(fixedAssetMaterialDefinition);
                if (fixedAssetMaintenanceParameter != null)
                    objectContext.AddObject(fixedAssetMaintenanceParameter);
                if (calibrationTestDefinition != null)
                    objectContext.AddObject(calibrationTestDefinition);
                if (content != null)
                    objectContext.AddObject(content);
            }
        }

        [Serializable]
        public class NewInputSendingDocument
        {
            public Accountancy senderAccountancy;
            public Accountancy accountancy;
            public DateTime stockActionDate;
            public String outputReqNumber;
            public String outputSeqNumber;
            public int addDocumentCount;
            public List<RemotingInfoClass.NewInputSendingDocumentMaterial> outputMaterailDetails;

            public NewInputSendingDocument()
            {
            }
        }

        [Serializable]
        public class NewInputSendingDocumentMaterial
        {
            public Material material;
            public Double amount;
            public Double unitPrice;
            public StockLevelTypeEnum stockLevelType;
            public List<RemotingInfoClass.NewInputSendingDocumentMaterialFixedAsset> outputFixedAssets;

            public NewInputSendingDocumentMaterial()
            {
            }
        }
        [Serializable]
        public class NewInputSendingDocumentMaterialFixedAsset
        {
            public Guid fixedAssetDefinitionId;

            public NewInputSendingDocumentMaterialFixedAsset()
            {
            }
        }

        [Serializable]
        public class StockCardStockInfo
        {
            public Double SumOfInheld;
            public Double SumOfConsigned;

            public StockCardStockInfo()
            {
                SumOfInheld = 0;
                SumOfConsigned = 0;
            }
        }
        
        [Serializable]
        public class ResLaboratoryDepartmentInfo
        {
            public Guid LabID;
            public string LabName;
            
            public ResLaboratoryDepartmentInfo()
            {}
        }
        
        [Serializable]
        public class LaboratoryListInfo
        {
            public Guid LabTestDefID;
            public string LabTestDefName;
            
            public LaboratoryListInfo()
            {}
        }
        
#endregion Methods

    }
}