
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


namespace TTObjectClasses
{
    public  partial class XXXXXXSptsClasses : TTObject
    {
#region Methods
        [Serializable]
        public class DrugDefinitionInfo
        {
            public Int64 ID;
            public string name;
            public string barkod;
            public Int64 GroupID;
            public string GroupName;
            public Int64 GenericID;
            public string GenericName;   //ilaç jeneriği
            public int RecipeType;  //reçete türü
            
            // NFC ler hepsi veritabanına atılmış olduğundan sadece ID'si gönderiliyor.
            public Int64 NfcID;

            public Int64 NfcImplementationTypeID;
            public string NfcImplementationTypeName; //Nfc uygulama şekli
            public double  Dose;  //İlaç min. kullanım birimi
            public double Volume;   // Toplam ilaç miktarı
            public int UnitID;
            public string UnitName;  //ilaç miktar birimi
            public double PackageAmount;  //ambalaj miktarı
            public Boolean NoDoseCounting;
            
            // Etken maddeler hepsi veritabanına atılmış olduğundan sadece ilaca ait IngredientID ve değerleri gönderiliyor.
            public List<Ingredients> alDrugIngredients;   // etken madde
            
            // ATC ler hepsi veritabanına atılmış olduğundan sadece ID'si gönderiliyor.
            public List<Int64> AtcCodes;
            
            public Int64 FirmID;   //üretici
            public string FirmName;
            public string LicenseNo;  //ruhsatno
            public DateTime LicenceDate;
            public int LicenceInstitute;
            public List<Ingredients> alActiveIngredients;
            public Boolean Active;
            public string MuadilCRC;
            public SPTSPricingDetail pricingDetail;
            
            public override string ToString()
            {
                return ID + " " + name + " " + barkod;
            }
        }
        [Serializable]
        public class Ingredients
        {
            public Int64 IngredientID;
            public double value;   //etken madde miktarı
            public Int64 UnitID;   //etken madde birimi
            public string UnitName;   //etken madde birimi adı
            public double MaxDoze;   //max doz
        }
        
        [Serializable]
        public class DrugRelationInfo
        {
            public Int64 ID;
            public List<Int64> DrugRelations; //Muadillleri Ek-2 ye göre
        }
        
        [Serializable]
        public class SPTSPricingDetail
        {
            public Int64 SPTSPricingDetailID;
            public double Price;
            public DateTime StartDate;
            public DateTime EndDate;
        }

        public static PrescriptionTypeEnum GetPrescriptionTypeEnumByValue (int value)
        {
            foreach (TTDataDictionary.EnumValueDef enumValueDef in TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs.Values)
            {
                if(value == 85)
                {
                    value = 1 ;
                }
                if ((int)enumValueDef.Value==value)
                {
                    return (TTObjectClasses.PrescriptionTypeEnum)enumValueDef.EnumValue;
                }
            }
            throw new Exception(SystemMessage.GetMessageV2(728,value.ToString()));
        }
        
        public static LicencingOrganizationEnum GetLicencingOrganizationEnumByValue (int value)
        {
            foreach (TTDataDictionary.EnumValueDef enumValueDef in TTObjectDefManager.Instance.DataTypes["LicencingOrganizationEnum"].EnumValueDefs.Values)
            {
                if ((int)enumValueDef.Value==value)
                {
                    return (TTObjectClasses.LicencingOrganizationEnum)enumValueDef.EnumValue;
                }
            }
            throw new Exception(SystemMessage.GetMessageV2(729, value.ToString()));
        }
        
        public static void SaveDrugInfo(DrugDefinitionInfo obj)
        {
            System.IO.FileStream stream = new System.IO.FileStream("C:\\SPSTS_ILAC_LOG.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter swriter = new System.IO.StreamWriter(stream);
            
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                if (obj.GroupID == 0 || string.IsNullOrEmpty(obj.GroupName))
                    throw new TTException(SystemMessage.GetMessageV2(730,obj.ToString()));

                DrugDefinition drugDefinition = null;
                IList existDrugDefinition = DrugDefinition.GetDrugDefinitionBySPTSGroupID(objectContext, obj.GroupID);
                if (existDrugDefinition.Count == 0)
                    drugDefinition = new DrugDefinition(objectContext);
                else if (existDrugDefinition.Count == 1)
                    drugDefinition = (DrugDefinition)existDrugDefinition[0];
                else if (existDrugDefinition.Count > 1)
                    throw new TTException(SystemMessage.GetMessageV2(731,obj.GroupID.ToString()));

                if (existDrugDefinition.Count == 0)
                {
                    if (drugDefinition != null)
                    {
                        drugDefinition.SPTSGroupID = obj.GroupID;
                        drugDefinition.Name = obj.GroupName;
                        drugDefinition.OriginalName = obj.GroupName;
                        drugDefinition.EquivalentCRC = obj.MuadilCRC;
                        drugDefinition.Chargable = true;
                        drugDefinition.AllowToGivePatient = true;

                        MaterialTreeDefinition materialTreeDefinition = objectContext.GetObject(new Guid("f665d343-f740-40ab-bb14-a6ed6d844093"), typeof(MaterialTreeDefinition)) as MaterialTreeDefinition;
                        if (materialTreeDefinition != null)
                            drugDefinition.MaterialTree = materialTreeDefinition;
                        drugDefinition.PrescriptionType = (PrescriptionTypeEnum)(GetPrescriptionTypeEnumByValue(obj.RecipeType));
                        drugDefinition.Dose = obj.Dose;
                        drugDefinition.Volume = obj.Volume;
                        drugDefinition.NoDoseCounting = obj.NoDoseCounting;
                        drugDefinition.IsActive = obj.Active;
                        drugDefinition.LastUpdate = Common.RecTime();

                        SetGenericDrug(objectContext, drugDefinition, obj);
                        SetRouteOfAdmin(objectContext, drugDefinition, obj);
                        SetNFC(objectContext, drugDefinition, obj);
                        SetUnit(objectContext, drugDefinition, obj);
                        AddDrugATCs(objectContext, drugDefinition, obj);
                        AddDrugActiveIngredients(objectContext, drugDefinition, obj);
                        AddBarcodeLevels(objectContext, drugDefinition, obj);
                        AddPricingDetail(objectContext, drugDefinition, obj);
                    }

                    objectContext.Save();

                    swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n");
                }
                //swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + " ilacı mevcut olduğu için aktarılmadı. \r\n");
            }
            catch (Exception ex)
            {
                swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n" + ex.ToString() + "\r\n");
            }
            finally
            {
                objectContext.Dispose();

                if (swriter != null) swriter.Close();
                if (stream != null) stream.Close();
            }
        }

        public static DrugDefinition SaveDrugInfoToReturn(DrugDefinitionInfo obj, string path)
        {
            System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter swriter = new System.IO.StreamWriter(stream);

            DrugDefinition drugDefinition = null;
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                if (obj.GroupID == 0 || string.IsNullOrEmpty(obj.GroupName))
                    throw new TTException(SystemMessage.GetMessageV2(730, obj.ToString()));


                IList existDrugDefinition = objectContext.QueryObjects("DRUGDEFINITION", "SPTSDRUGID = " + obj.ID);
                if (existDrugDefinition.Count == 0)
                    drugDefinition = new DrugDefinition(objectContext);
                else if (existDrugDefinition.Count == 1)
                    drugDefinition = (DrugDefinition)existDrugDefinition[0];
                else if (existDrugDefinition.Count > 1)
                    throw new TTException(SystemMessage.GetMessageV2(731, obj.GroupID.ToString()));

                if (existDrugDefinition.Count == 0)
                {
                    if (drugDefinition != null)
                    {

                        drugDefinition.SPTSDrugID = obj.ID;
                        drugDefinition.Barcode = obj.barkod;
                        drugDefinition.Name = obj.name;
                        drugDefinition.BarcodeName = obj.name;
                        drugDefinition.LicenceNO = obj.LicenseNo;
                        if (obj.LicenceDate.Year < 1800)
                            drugDefinition.LicenceDate = null;
                        else
                            drugDefinition.LicenceDate = obj.LicenceDate;
                        drugDefinition.LicencingOrganization = (LicencingOrganizationEnum)(GetLicencingOrganizationEnumByValue(obj.LicenceInstitute));
                        drugDefinition.PackageAmount = obj.PackageAmount;
                        drugDefinition.CurrentPrice = obj.pricingDetail.Price;
                        drugDefinition.LastUpdate = Common.RecTime();
                        SetProducer(objectContext, drugDefinition, obj);

                        //drugDefinition.CreatedSite = Common.Get
                        //newMaterial.Discount = obj.Discount;
                        drugDefinition.IsOldMaterial = false;
                        drugDefinition.OriginalName = obj.name;
                        drugDefinition.StockCard = null;

                        drugDefinition.EquivalentCRC = obj.MuadilCRC;
                        drugDefinition.Chargable = true;
                        drugDefinition.AllowToGivePatient = true;

                        MaterialTreeDefinition materialTreeDefinition = objectContext.GetObject(new Guid("f665d343-f740-40ab-bb14-a6ed6d844093"), typeof(MaterialTreeDefinition)) as MaterialTreeDefinition;
                        if (materialTreeDefinition != null)
                            drugDefinition.MaterialTree = materialTreeDefinition;
                        drugDefinition.PrescriptionType = (PrescriptionTypeEnum)(GetPrescriptionTypeEnumByValue(obj.RecipeType));
                        drugDefinition.Dose = obj.Dose;
                        drugDefinition.Volume = obj.Volume;
                        drugDefinition.NoDoseCounting = obj.NoDoseCounting;
                        drugDefinition.IsActive = obj.Active;
                        drugDefinition.LastUpdate = Common.RecTime();

                        SetGenericDrug(objectContext, drugDefinition, obj);
                        SetRouteOfAdmin(objectContext, drugDefinition, obj);
                        SetNFC(objectContext, drugDefinition, obj);
                        SetUnit(objectContext, drugDefinition, obj);
                        AddDrugATCs(objectContext, drugDefinition, obj);
                        AddDrugActiveIngredients(objectContext, drugDefinition, obj);
                        //AddBarcodeLevels(objectContext, drugDefinition, obj);
                        AddPricingDetail(objectContext, drugDefinition, obj);
                    }

                    objectContext.Save();

                    swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n");
                }
                //swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + " ilacı mevcut olduğu için aktarılmadı. \r\n");
            }
            catch (Exception ex)
            {
                swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n" + ex.ToString() + "\r\n");
            }
            finally
            {
                objectContext.Dispose();
                
                if (swriter != null) swriter.Close();
                if (stream != null) stream.Close();
            }
            return drugDefinition;
        }

        public static DrugDefinition SaveUBBDrugInfoToReturn(DrugDefinitionInfo obj, string path)
        {
            System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter swriter = new System.IO.StreamWriter(stream);

            DrugDefinition drugDefinition = null;
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                if (obj.GroupID == 0 || string.IsNullOrEmpty(obj.GroupName))
                    throw new TTException(SystemMessage.GetMessageV2(730, obj.ToString()));


                IList existDrugDefinition = objectContext.QueryObjects("DRUGDEFINITION","SPTSDRUGID = " + obj.ID );
                if (existDrugDefinition.Count == 0)
                    drugDefinition = new DrugDefinition(objectContext);
                else if (existDrugDefinition.Count == 1)
                    drugDefinition = (DrugDefinition)existDrugDefinition[0];
                else if (existDrugDefinition.Count > 1)
                    throw new TTException(SystemMessage.GetMessageV2(731, obj.GroupID.ToString()));

                if (existDrugDefinition.Count == 0)
                {
                    if (drugDefinition != null)
                    {

                        drugDefinition.SPTSDrugID = obj.ID;
                        drugDefinition.Barcode = obj.barkod;
                        drugDefinition.Name = obj.name;
                        drugDefinition.LicenceNO = obj.LicenseNo;
                        if (obj.LicenceDate.Year < 1800)
                            drugDefinition.LicenceDate = null;
                        else
                            drugDefinition.LicenceDate = obj.LicenceDate;
                        drugDefinition.LicencingOrganization = (LicencingOrganizationEnum)(GetLicencingOrganizationEnumByValue(obj.LicenceInstitute));
                        drugDefinition.PackageAmount = obj.PackageAmount;
                        drugDefinition.CurrentPrice = obj.pricingDetail.Price;
                        
                        
                        drugDefinition.SPTSGroupID = obj.GroupID;
                        drugDefinition.OriginalName = obj.name;
                        drugDefinition.EquivalentCRC = obj.MuadilCRC;
                        drugDefinition.Chargable = true;
                        drugDefinition.AllowToGivePatient = true;

                        MaterialTreeDefinition materialTreeDefinition = objectContext.GetObject(new Guid("f665d343-f740-40ab-bb14-a6ed6d844093"), typeof(MaterialTreeDefinition)) as MaterialTreeDefinition;
                        if (materialTreeDefinition != null)
                            drugDefinition.MaterialTree = materialTreeDefinition;
                        drugDefinition.PrescriptionType = (PrescriptionTypeEnum)(GetPrescriptionTypeEnumByValue(obj.RecipeType));
                        drugDefinition.Dose = obj.Dose;
                        drugDefinition.Volume = obj.Volume;
                        drugDefinition.NoDoseCounting = obj.NoDoseCounting;
                        drugDefinition.IsActive = obj.Active;
                        drugDefinition.LastUpdate = Common.RecTime();

                        SetGenericDrug(objectContext, drugDefinition, obj);
                        SetRouteOfAdmin(objectContext, drugDefinition, obj);
                        SetNFC(objectContext, drugDefinition, obj);
                        SetUnit(objectContext, drugDefinition, obj);
                        AddDrugATCs(objectContext, drugDefinition, obj);
                        AddDrugActiveIngredients(objectContext, drugDefinition, obj);
                        //AddBarcodeLevels(objectContext, drugDefinition, obj);
                        AddPricingDetail(objectContext, drugDefinition, obj);
                    }

                    objectContext.Save();

                    swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n");
                }
                //swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + " ilacı mevcut olduğu için aktarılmadı. \r\n");
            }
            catch (Exception ex)
            {
                swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n" + ex.ToString() + "\r\n");
            }
            finally
            {
                objectContext.Dispose();

                if (swriter != null) swriter.Close();
                if (stream != null) stream.Close();
            }
            return drugDefinition;
        }
        
        public static void AddDrugRelations(DrugRelationInfo obj)
        {
            //System.IO.FileStream stream = new System.IO.FileStream("C:\\SPSTS_ESDEGER_LOG.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write);
            //System.IO.StreamWriter swriter = new System.IO.StreamWriter(stream);

            TTObjectContext objectContext =  new TTObjectContext(false);
            try
            {
                if (obj.DrugRelations != null)
                {
                    int drugID = ((int)obj.ID);
                    BindingList<MaterialBarcodeLevel> drugs = MaterialBarcodeLevel.GetMaterialBarcodeLevelBySPTSID(objectContext, drugID);
                    if (drugs.Count == 1)
                    {
                        if (drugs[0].Material is DrugDefinition)
                        {
                            DrugDefinition drug = ((DrugDefinition)drugs[0].Material);
                            IList<DrugDefinition> oldRelationDrugs = null;
                            Dictionary<Guid, DrugDefinition> relationDrugs = new Dictionary<Guid, DrugDefinition>();
                            if (drug.DrugRelations.Count > 0)
                            {
                                foreach (DrugRelation eqDrugRelated in drug.DrugRelations)
                                {
                                    oldRelationDrugs.Add(eqDrugRelated.RelationDrug);
                                }
                            }
                            foreach (long drugRelationID in obj.DrugRelations)
                            {
                                int eqDrugID = ((int)drugRelationID);
                                BindingList<MaterialBarcodeLevel> levels = MaterialBarcodeLevel.GetMaterialBarcodeLevelBySPTSID(objectContext, eqDrugID);
                                if (levels.Count == 1)
                                {
                                    MaterialBarcodeLevel barcodeLevel = (MaterialBarcodeLevel)levels[0];
                                    if (barcodeLevel.Material is DrugDefinition)
                                    {
                                        if (oldRelationDrugs != null)
                                        {
                                            if (oldRelationDrugs.Contains(((DrugDefinition)barcodeLevel.Material)) == false)
                                            {
                                                if (relationDrugs.ContainsKey(barcodeLevel.Material.ObjectID) == false)
                                                {
                                                    relationDrugs.Add(barcodeLevel.Material.ObjectID, (DrugDefinition)barcodeLevel.Material);
                                                }
                                            }
                                        }
                                        else if (oldRelationDrugs == null)
                                        {
                                            if (relationDrugs.ContainsKey(barcodeLevel.Material.ObjectID) == false)
                                            {
                                                relationDrugs.Add(barcodeLevel.Material.ObjectID, (DrugDefinition)barcodeLevel.Material);
                                            }
                                        }
                                    }
                                }
                            }
                            if (relationDrugs.Count > 0)
                            {
                                foreach (KeyValuePair<Guid, DrugDefinition> rd in relationDrugs)
                                {
                                    DrugRelation dr = new DrugRelation(objectContext);
                                    dr.RelationDrug = (DrugDefinition)rd.Value;
                                    dr.DrugDefinition = drug;
                                }
                                Dictionary<Guid, object> deleteRelation = new Dictionary<Guid, object>();
                                foreach (DrugRelation eq in drug.DrugRelations)
                                {
                                    if (relationDrugs.ContainsKey(eq.RelationDrug.ObjectID) == false)
                                    {
                                        deleteRelation.Add(eq.RelationDrug.ObjectID, eq);
                                    }
                                }
                                foreach (KeyValuePair<Guid, object> dre in deleteRelation)
                                {
                                    ((ITTObject)dre.Value).Delete();
                                }

                            }
                            else if (relationDrugs.Count == 0)
                            {
                                drug.DrugRelations.DeleteChildren();
                            }
                        }
                    }
                    objectContext.Save();
                    
                    //swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n");
                }
            }
            catch (Exception ex)
            {
                //swriter.Write(DateTime.Now.ToString() + " --- " + obj.ToString() + "\r\n" + ex.ToString() + "\r\n");
            }
            finally
            {
                objectContext.Dispose();

                //if (swriter != null) swriter.Close();
                //if (stream != null) stream.Close();
            }
        }

        private static void SetGenericDrug(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.GenericID == 0)
            {
                drugDefinition.GenericDrug = null;
                return;
            }

            GenericDrug genericDrug = null;
            IList existGenericDrug = GenericDrug.GetGenericDrugBySPTSGenericDrugID(objectContext, obj.GenericID);
            if (existGenericDrug.Count == 0)
                throw new TTException(obj.GenericID.ToString() + " spts id li Generic Name Bulunamadı");
            else if (existGenericDrug.Count == 1)
                genericDrug = (GenericDrug)existGenericDrug[0];
            else if (existGenericDrug.Count > 1)
                throw new TTException(SystemMessage.GetMessageV2(732,obj.GenericID.ToString()));

            if (genericDrug != null)
                drugDefinition.GenericDrug = genericDrug;
        }

        private static void SetRouteOfAdmin(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.NfcImplementationTypeID == 0)
                throw new TTException(SystemMessage.GetMessageV2(733, obj.ToString()));

            RouteOfAdmin routeOfAdmin = null;
            IList existRouteOfAdmin = RouteOfAdmin.GetRouteOfAdminBySPTSRouteOfAdminID(objectContext, obj.NfcImplementationTypeID);
            if (existRouteOfAdmin.Count == 0)
                throw new TTException(obj.NfcImplementationTypeID.ToString() + " ID li Uygulama Şekli Bulunamadı" );
            else if (existRouteOfAdmin.Count == 1)
                routeOfAdmin = (RouteOfAdmin)existRouteOfAdmin[0];
            else if (existRouteOfAdmin.Count > 1)
                throw new TTException(SystemMessage.GetMessageV2(734,obj.NfcImplementationTypeID.ToString()));

            if (routeOfAdmin != null)
                drugDefinition.RouteOfAdmin = routeOfAdmin;
        }

        private static void SetNFC(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.NfcID == 0 )
                throw new TTException(SystemMessage.GetMessageV2(735, obj.ToString()));

            NFC nfc = null;
            IList existNFC = NFC.GetNFCBySPTSNFCIDs(objectContext, obj.NfcID);
            if (existNFC.Count == 0)
                throw new TTException(SystemMessage.GetMessageV2(736,obj.NfcID.ToString()));
            else if (existNFC.Count == 1)
                nfc = (NFC)existNFC[0];
            else if (existNFC.Count > 1)
                throw new TTException(SystemMessage.GetMessageV2(737,obj.NfcID.ToString()));
            
            if (nfc != null)
                drugDefinition.NFC = nfc;
        }

        private static void SetUnit(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.UnitID == 0)
                throw new TTException(SystemMessage.GetMessageV2(738, obj.ToString()));

            UnitDefinition unitDefinition = null;
            IList existUnitDefinition = UnitDefinition.GetUnitDefinitionByVademecumUnitID(objectContext, obj.UnitID);
            if (existUnitDefinition.Count == 0)
                throw new TTException(SystemMessage.GetMessageV2(739, obj.UnitID.ToString()));
            else if (existUnitDefinition.Count == 1 || existUnitDefinition.Count > 1)
                unitDefinition = (UnitDefinition)existUnitDefinition[0];
            //else if (existUnitDefinition.Count > 1)
            //    throw new TTException(SystemMessage.GetMessage(739, obj.UnitID.ToString()));
            
            if (unitDefinition != null)
                drugDefinition.Unit = unitDefinition;
        }

        private static void AddDrugATCs(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            drugDefinition.DrugATCs.Clear();
            if (obj.AtcCodes != null)
            {
                foreach (long atcID in obj.AtcCodes)
                {
                    ATC atc = null;
                    IList existATC = ATC.GetAtcBySPTSATCID(objectContext, atcID);
                    if (existATC.Count == 0)
                        throw new TTException(SystemMessage.GetMessageV2(740, atcID.ToString()));
                    else if (existATC.Count == 1)
                        atc = (ATC)existATC[0];
                    else if (existATC.Count > 1)
                        throw new TTException(SystemMessage.GetMessageV2(741,atcID.ToString()));
                    if (atc != null)
                    {
                        DrugATC drugATC = new DrugATC(objectContext);
                        drugATC.ATC = atc;
                        drugDefinition.DrugATCs.Add(drugATC);
                    }
                }
            }
        }

        
        
        private static void AddDrugActiveIngredients(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            drugDefinition.DrugActiveIngredients.Clear();
            if (obj.alDrugIngredients != null)
            {
                foreach (Ingredients ingredient in obj.alDrugIngredients)
                {

                    ActiveIngredientDefinition activeIngredientDefinition = null;
                    IList existActiveIngredientDefinition = ActiveIngredientDefinition.GetActiveIngredientbySPTSActiveIngredientID(objectContext, ingredient.IngredientID);
                    if (existActiveIngredientDefinition.Count == 0)
                        throw new TTException(SystemMessage.GetMessageV2(742,ingredient.IngredientID.ToString()));
                    else if (existActiveIngredientDefinition.Count == 1)
                        activeIngredientDefinition = (ActiveIngredientDefinition)existActiveIngredientDefinition[0];
                    else if (existActiveIngredientDefinition.Count > 1)
                    {
                        //throw new TTException(SystemMessage.GetMessage(743,ingredient.IngredientID.ToString()));
                        activeIngredientDefinition = (ActiveIngredientDefinition)existActiveIngredientDefinition[0];
                    }
                    if (activeIngredientDefinition != null)
                    {
                        DrugActiveIngredient drugActiveIngredient = new DrugActiveIngredient(objectContext);
                        drugActiveIngredient.MaxDose = ingredient.MaxDoze;
                        drugActiveIngredient.Value = ingredient.value;

                        SetUnitIngredient(objectContext, drugActiveIngredient, ingredient);

                        drugActiveIngredient.ActiveIngredient = activeIngredientDefinition;
                        drugDefinition.DrugActiveIngredients.Add(drugActiveIngredient);
                    }
                }
            }
        }

        private static void SetUnitIngredient(TTObjectContext objectContext, DrugActiveIngredient drugActiveIngredient, Ingredients ingredient)
        {
            if (ingredient.UnitID == 0 || string.IsNullOrEmpty(ingredient.UnitName))
                throw new TTException(SystemMessage.GetMessageV2(738, ingredient.ToString()));

            UnitDefinition unitDefinition = null;
            IList existUnitDefinition = UnitDefinition.GetUnitDefinitionByVademecumUnitID(objectContext, ingredient.UnitID);
            if (existUnitDefinition.Count == 0)
                throw new TTException(ingredient.UnitID.ToString() + " ID li Doz Birim bulunamadı");
            else if (existUnitDefinition.Count == 1)
                unitDefinition = (UnitDefinition)existUnitDefinition[0];
            else if (existUnitDefinition.Count > 1)
                throw new TTException(SystemMessage.GetMessageV2(739, ingredient.UnitID.ToString()));

            if (unitDefinition != null)
                drugActiveIngredient.Unit = unitDefinition;
        }

        private static void AddBarcodeLevels(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.ID == 0 || string.IsNullOrEmpty(obj.name))
                throw new TTException(SystemMessage.GetMessageV2(744, obj.ToString()));

            MaterialBarcodeLevel materialBarcodeLevel = null;
            IList existMaterialBarcodeLevel = drugDefinition.MaterialBarcodeLevels.Select("SPTSDRUGID = " + obj.ID);
            if (existMaterialBarcodeLevel.Count == 0)
                materialBarcodeLevel = new MaterialBarcodeLevel(objectContext);
            else if (existMaterialBarcodeLevel.Count == 1)
                materialBarcodeLevel = (MaterialBarcodeLevel)existMaterialBarcodeLevel[0];
            else if (existMaterialBarcodeLevel.Count > 1)
                throw new TTException(SystemMessage.GetMessageV2(745, obj.ID.ToString()));

            if (materialBarcodeLevel != null)
            {
                materialBarcodeLevel.SPTSDrugID = obj.ID;
                materialBarcodeLevel.Barcode = obj.barkod;
                materialBarcodeLevel.Name = obj.name;
                materialBarcodeLevel.LicenceNO = obj.LicenseNo;
                if(obj.LicenceDate.Year < 1800)
                    materialBarcodeLevel.LicenceDate = null;
                else
                    materialBarcodeLevel.LicenceDate = obj.LicenceDate;
                materialBarcodeLevel.LicencingOrganization = (LicencingOrganizationEnum)(GetLicencingOrganizationEnumByValue(obj.LicenceInstitute));
                materialBarcodeLevel.PackageAmount = obj.PackageAmount;
                materialBarcodeLevel.CurrentPrice = obj.pricingDetail.Price;
                materialBarcodeLevel.LastUpdate = Common.RecTime();
                //SetProducer(objectContext, materialBarcodeLevel, obj);

                if (((ITTObject)materialBarcodeLevel).IsNew)
                    drugDefinition.MaterialBarcodeLevels.Add(materialBarcodeLevel);
            }
        }

        private static void SetProducer(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.FirmID == 0)
            {
                drugDefinition.Producer = null;
                return;
            }

            Producer producer = null;
            IList existProducer = Producer.GetProducerBySPTSProducerID(objectContext, obj.FirmID);
            if (existProducer.Count == 0)
                producer = new Producer(objectContext);
            else if (existProducer.Count == 1)
                producer = (Producer)existProducer[0];
            else if (existProducer.Count > 1)
                throw new TTException(SystemMessage.GetMessageV2(746, obj.FirmID.ToString()));

            if (producer != null)
                drugDefinition.Producer = producer;
        }
        
        private static void AddPricingDetail(TTObjectContext objectContext, DrugDefinition drugDefinition, DrugDefinitionInfo obj)
        {
            if (obj.pricingDetail == null)
                throw new TTException(SystemMessage.GetMessageV2(747, obj.ToString()));

            MaterialPrice materialPrice = null;
            IList existMaterialPrice = MaterialPrice.GetMaterialPriceBySPTSPricingDetailID(objectContext, obj.pricingDetail.SPTSPricingDetailID);
            if (existMaterialPrice.Count == 0)
                materialPrice = new MaterialPrice(objectContext);
            else if (existMaterialPrice.Count == 1)
                materialPrice = (MaterialPrice)existMaterialPrice[0];
            else if (existMaterialPrice.Count > 1)
                materialPrice = (MaterialPrice)existMaterialPrice[0];

            if (materialPrice != null)
            {
                materialPrice.Material = drugDefinition;

                PricingDetailDefinition pricingDetailDefinition = null;
                if (materialPrice.PricingDetail != null)
                {
                    pricingDetailDefinition = materialPrice.PricingDetail;
                }
                else
                {
                    pricingDetailDefinition = new PricingDetailDefinition(objectContext);
                    materialPrice.PricingDetail = pricingDetailDefinition;
                }

                if (pricingDetailDefinition != null)
                {
                    pricingDetailDefinition.SPTSPricingDetailID = obj.pricingDetail.SPTSPricingDetailID;
                    pricingDetailDefinition.Description = drugDefinition.Name;
                    pricingDetailDefinition.ExternalCode = obj.barkod ;
                    pricingDetailDefinition.DateStart = obj.pricingDetail.StartDate;
                    pricingDetailDefinition.DateEnd = obj.pricingDetail.EndDate;
                    if(obj.PackageAmount > 1)
                        pricingDetailDefinition.Price = obj.pricingDetail.Price / obj.PackageAmount;
                    else
                        pricingDetailDefinition.Price = obj.pricingDetail.Price;
                    pricingDetailDefinition.IsActive = true;
                    pricingDetailDefinition.LastUpdate = Common.RecTime();

                    CurrencyTypeDefinition currencyTypeDefinition = objectContext.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition)) as CurrencyTypeDefinition;
                    if (currencyTypeDefinition != null)
                        pricingDetailDefinition.CurrencyType = currencyTypeDefinition;
                    else
                        throw new TTException(SystemMessage.GetMessageV2(749, obj.pricingDetail.SPTSPricingDetailID.ToString()));

                    
                    //PricingListDefinition pricingListDefinition = objectContext.GetObject(new Guid("56796e39-0c1c-4f10-b7d6-588192e6ce1b"), typeof(PricingListDefinition)) as PricingListDefinition;
                    PricingListDefinition pricingListDefinition = objectContext.GetObject(new Guid("57c5a43f-2083-433a-9f05-94c49c284436"), typeof(PricingListDefinition)) as PricingListDefinition;
                    if (pricingListDefinition != null)
                        pricingDetailDefinition.PricingList = pricingListDefinition;
                    else
                        throw new TTException(SystemMessage.GetMessageV2(750, obj.pricingDetail.SPTSPricingDetailID.ToString()));

                    //PricingListGroupDefinition pricingListGroupDefinition = objectContext.GetObject(new Guid("19d833fa-51b6-4420-ba9e-fd07b4a9f310"), typeof(PricingListGroupDefinition)) as PricingListGroupDefinition;
                    PricingListGroupDefinition pricingListGroupDefinition = objectContext.GetObject(new Guid("b3e200fb-9caa-405d-9d92-01f75948b452"), typeof(PricingListGroupDefinition)) as PricingListGroupDefinition;
                    if (pricingListGroupDefinition != null)
                        pricingDetailDefinition.PricingListGroup = pricingListGroupDefinition;
                    else
                        throw new TTException(SystemMessage.GetMessageV2(751, obj.pricingDetail.SPTSPricingDetailID.ToString()));
                }
                if (((ITTObject)materialPrice).IsNew)
                {
                    //  materialPrice.CurrentStateDefID = MaterialPrice.States.New;
                    drugDefinition.MaterialPrices.Add(materialPrice);
                }
            }
        }

        [Serializable]
        public class HastaIlacInfo
        {
            public Int32 ActionId;
            public string DailyDose;
            public string DrugExpDate;
            public string DrugName;
            public string PrescDate;
        }
        
        [Serializable]
        public class HastaInfo
        {
            public string TCNo;
            public Int64 sptsId;
            public string ad;
            public string soyad;
            public string patientGuid;
            public string cinsiyet;
            public string dogumTarihi;
            public string dogumYeri;
            public string yakinlikId;
            public string yakinlikDerecesi;
            public string anaAdi;
            public string babaAdi;
            public string emekliNo;
            public string sicilNo;
            public string sskNo;
            public string deleted;
            public string srcTable;
            public DateTime XXXXXXeGirisTarihi;
            public DateTime sonGuncellenmeTarihi;
            public Int16 hasSahiplikGrubu;

        }


        [Serializable]
        public class ReceteIlacSonuc
        {
            public int ilacId;
            public Boolean odenir;
            public string ilacSonucAciklamasi;
            public double hastaPayi;
        }

        [Serializable]
        public class DrugInfo
        {
            public string name;
            public double barkod;
            public Int32 packageAmount;
            public string dosageForm;
            public string licenseNo;
            public string licenseDate;
            public double price;
            public double KurumFiyati;
            public string priceDate;
            public string GenericEsdeger;
            public string birimIlacSayisi;
            public string birimIlacBirimi;
            public string dozajHesapTuru;
            public List<ActiveSubstance> alActiveSubstances;
            public List<DrugInfo> alEquivalentDrugs;
            public List<DrugInfo> alEK2EquivalentDrugs;
            public List<DrugRule> alDrugRules;
        }

        [Serializable]
        public class ActiveSubstance
        {
            public string name;
            public double amount;
            public string substanceUnit;
        }

        [Serializable]
        public class DrugRule
        {
            public string RuleText;
            public string RuleParPredefined;
            public string RuleParFreeText;
        }

        [Serializable]
        public class ProvReturn
        {
            public string SonucAciklamasi;
            public int sonuckodu;
            public string ReceteSonucAciklamasi;
            public DrugInfo ilac;
            public List<HastaIlacInfo> HastaIlac;
            public List<ReceteIlacSonuc> receteIlacSonuc;
            public List<HastaInfo> hastaBilgileri;
        }

        [Serializable]
        public class RaporInfo
        {
            public string HastaId;
            public int kurumId;
            public int kurumturu;
            public string raporno;
            public string raporbaslangictarihi;
            public string raporbitistarihi;
            public string tedavisema;
            public string zdegeri;
            public string patoloji;
            public string agizdanbeslenemez;
            public string yasboy;
            public string ovulasyon;
            public string intrauterin;
            public int diplomano;
            public int uzmanlikdali;
            public string protokolno;
            public string acildurum;
            public string XXXXXX;
            public List<raporilac> ilaclar;
            public List<raportani> tanilar;
            public List<uzmanlik> uzmanliklar;
        }

        [Serializable]
        public class raporilac
        {
            public int Id;
            public string name;
            public int PacketAmount;
            public int Dosage;
            public int DosageAmount;
            public int AlternativeId;
            public int weeklyMonthly;
            public Boolean hasReport;
            public Boolean hasTenDays;
        }

        [Serializable]
        public class raportani
        {
            public string kodu;
            public string adi;
        }

        [Serializable]
        public class uzmanlik
        {
            public string kodu;
            public string adi;
        }

        [Serializable]
        public class ReceteInfo
        {
            public string HastaId;
            public string ReceteObjectId;
            public int ayaktanyatan;
            public string sicilno;
            public string patientgroup;
            public string receteturu;
            public string serbesttani;
            public int diplomano;
            public int kurumId;
            public string recetetarihi;
            public string ilacverilistarihi;
            public int uzmanlikdali;
            public string protokolno;
            public string acildurum;
            public string XXXXXX;
            public List<receteilac> ilaclar;
            public List<recetetani> tanilar;
        }
        
        [Serializable]
        public class receteilac
        {
            public int Id;
            public string name;
            public int PacketAmount;
            public int Dosage;
            public int DosageAmount;
            public int AlternativeId;
            public int weeklyMonthly;
            public Boolean hasReport;
            public Boolean hasTenDays;
        }

        [Serializable]
        public class recetetani
        {
            public string kodu;
            public string adi;
        }
        
#endregion Methods

    }
}