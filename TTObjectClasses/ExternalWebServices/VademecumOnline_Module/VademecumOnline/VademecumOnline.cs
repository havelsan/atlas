
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
    public partial class VademecumOnline : TTObject
    {
        #region Methods

        #region AllProductSearch_JsonTypes
        public class AllProductSearch_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Barcode { get; set; }
            public string TitckName { get; set; }
            public string[] Barcodes { get; set; }
        }

        public class AllProductSearch_Response
        {
            public bool Success { get; set; }
            public AllProductSearch_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }


        #endregion AllProductSearch_JsonTypes

        #region AllProductList_JsonTypes
        public class AllProductList_Datum
        {
            public int DrugId { get; set; }
            public int DrugFormId { get; set; }
            public int DrugTypeId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int? GenericStatusId { get; set; }
            public string Barcode { get; set; }
            public string PublicNumber { get; set; }
            public bool Exportation { get; set; }
            public int CompanyId { get; set; }
            public int PrescriptionTypeId { get; set; }
            public int PharmaceuticalFormId { get; set; }
            public int NfcCodeId { get; set; }
            public AllProductList_İngredients[] İngredients { get; set; }
            public int UpdatedAt { get; set; }
            public bool AbroadProduct { get; set; }
        }

        public class AllProductList_İngredients
        {
            public int SubstanceId { get; set; }
            public double? Amount { get; set; }
            public int? UnitId { get; set; }
            public int? ChemicalformId { get; set; }
        }

        public class AllProductList_Response
        {
            public bool Success { get; set; }
            public AllProductList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion AllProductList_JsonTypes

        #region AllProductPriceList_JsonTypes

        public class AllProductPriceList_Datum
        {
            public int Id { get; set; }
            public double? Factory { get; set; }
            public double? Storage { get; set; }
            public double? Pharmacy { get; set; }
            public double? Retail { get; set; }
            public string Barcode { get; set; }
            public string EffectiveDate { get; set; }
            public int TaxPercent { get; set; }
            public double? DiscountRate { get; set; }
            public double? PublicPrice { get; set; }
            public double? PublicPriceVATInc { get; set; }
            public string CurrencyCode { get; set; }
            public bool StorageBased { get; set; }
            public double? StorageSalesPrice { get; set; }
            public bool SkipPriceCalc { get; set; }
            public bool Passive { get; set; }
            public bool Reimbursement { get; set; }
            public AllProductPriceList_PublicPaidPrice[] PublicPaidPrice { get; set; }
            public bool AbroadProduct { get; set; }
            public object AbroadPublicPaidPrice { get; set; }
            public object AbroadRetail { get; set; }
            public object AbroadPublicPrice { get; set; }
            public int UpdatedAt { get; set; }
        }

        public class AllProductPriceList_PublicPaidPrice
        {
            public double Price { get; set; }
            public double PriceVatInc { get; set; }
            public string GroupCode { get; set; }
            public int? GroupType { get; set; }
            public bool GroupLowestUnitPrice { get; set; }
            public object EquivalentGroupCode { get; set; }
        }

        public class AllProductPriceList_Response
        {
            public bool Success { get; set; }
            public AllProductPriceList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion AllProductPriceList_JsonTypes

        #region ApplicationMethodList_JsonTypes

        public class ApplicationMethodList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class ApplicationMethodList_Response
        {
            public bool Success { get; set; }
            public ApplicationMethodList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion ApplicationMethodList_JsonTypes

        #region BodyPartList_JsonTypes

        public class BodyPartList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class BodyPartList_Response
        {
            public bool Success { get; set; }
            public BodyPartList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }


        #endregion BodyPartList_JsonTypes

        #region ColorList_JsonTypes

        public class ColorList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }
            public string HtmlCode { get; set; }
        }

        public class ColorList_Response
        {
            public bool Success { get; set; }
            public ColorList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion ColorList_JsonTypes

        #region CompanyList_JsonTypes

        public class CompanyList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string OfficialName { get; set; }
            public string Website { get; set; }
        }

        public class CompanyList_Response
        {
            public bool Success { get; set; }
            public CompanyList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion CompanyList_JsonTypes

        #region DiseaseList_JsonTypes

        public class DiseaseList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class DiseaseList_Response
        {
            public bool Success { get; set; }
            public DiseaseList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion DiseaseList_JsonTypes

        #region DrugList_JsonTypes

        public class DrugList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class DrugList_Response
        {
            public bool Success { get; set; }
            public DrugList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion DrugList_JsonTypes

        #region DrugTypeList_JsonTypes

        public class DrugTypeList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class DrugTypeList_Response
        {
            public bool Success { get; set; }
            public DrugTypeList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion DrugTypeList_JsonTypes

        #region GenericStatusTypeList_JsonTypes

        public class GenericStatusTypeList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class GenericStatusTypeList_Response
        {
            public bool Success { get; set; }
            public GenericStatusTypeList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion GenericStatusTypeList_JsonTypes

        #region IcdIndexList_JsonTypes

        public class IcdIndexList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int BranchOf { get; set; }
        }

        public class IcdIndexList_Response
        {
            public bool Success { get; set; }
            public IcdIndexList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }


        #endregion IcdIndexList_JsonTypes

        #region InteractionClasses

        public class Disease
        {
            public int id;
        }

        public class ICDCode
        {
            public string name;
        }

        public class Nutrition
        {
            public int id;
        }

        public class PatientCharacteristics
        {
            public int? weight;

            public int? height;

            public string birthdate;

            public string pregnancyDate;

            public string gender;

            public bool? smokingHabit;

            public bool? drugHabit;

            public bool? pregnancyProbability;

            public bool? breastFeeding;

            public bool? contactLensUsage;

            public bool? saltFreeDiet;

            public bool? electroshockTherapy;

            public bool? postpartumPeriod;

            public bool? bloodDonation;

            public bool? pregnant;
        }

        public class Product
        {
            public int id;
        }

        public class Symptom
        {
            public int id;
        }

        #endregion InteractionClasses

        #region NfcCodeList_JsonTypes

        public class NfcCodeList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class NfcCodeList_Last
        {
            public string Href { get; set; }
        }

        public class NfcCodeList_Links
        {
            public Self Self { get; set; }
            public NfcCodeList_Next Next { get; set; }
            public NfcCodeList_Last Last { get; set; }
        }

        public class NfcCodeList_Next
        {
            public string Href { get; set; }
        }

        internal class NfcCodeList_Response
        {
            public bool Success { get; set; }
            public NfcCodeList_Datum[] Data { get; set; }
            public NfcCodeList_Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion NfcCodeList_JsonTypes

        #region NutritionList_JsonTypes

        public class NutritionList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class NutritionList_Response
        {
            public bool Success { get; set; }
            public NutritionList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion NutritionList_JsonTypes

        #region PatientCategoryList_JsonTypes

        public class PatientCategoryList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class PatientCategoryList_Response
        {
            public bool Success { get; set; }
            public PatientCategoryList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }


        #endregion PatientCategoryList_JsonTypes

        #region PharmaceuticalFormList_JsonTypes

        public class PharmaceuticalFormList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ApplicationMethodList_Datum ApplicationMethod { get; set; }
            public BodyPartList_Datum AffectingBodyPart { get; set; }
        }

        public class PharmaceuticalFormList_Response
        {
            public bool Success { get; set; }
            public PharmaceuticalFormList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion PharmaceuticalFormList_JsonTypes

        #region PrescriptionTypeList_JsonTypes

        public class PrescriptionTypeList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class PrescriptionTypeList_Response
        {
            public bool Success { get; set; }
            public PrescriptionTypeList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion PrescriptionTypeList_JsonTypes

        #region ProductList_JsonTypes

        public class ProductList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Barcode { get; set; }
        }

        public class ProductList_Response
        {
            public bool Success { get; set; }
            public ProductList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion ProductList_JsonTypes

        #region ProductReimbursementPrice_JsonTypes

        public class ProductReimbursementPrice_Data
        {
            public ProductList_Datum Product { get; set; }
            public ProductReimbursementPrice_PriceInfo PriceInfo { get; set; }
        }

        public class ProductReimbursementPrice_PriceInfo
        {
            public double Factory { get; set; }
            public int Storage { get; set; }
            public double Pharmacy { get; set; }
            public double Retail { get; set; }
            public string EffectiveDate { get; set; }
            public int TaxPercent { get; set; }
            public int DiscountRate { get; set; }
            public double PublicPrice { get; set; }
            public double PublicPriceVATInc { get; set; }
            public string CurrencyCode { get; set; }
            public bool StorageBased { get; set; }
            public object StorageSalesPrice { get; set; }
            public bool SkipPriceCalc { get; set; }
            public bool Passive { get; set; }
            public bool Reimbursement { get; set; }
            public ProductReimbursementPrice_PublicPaidPrice[] PublicPaidPrice { get; set; }
            public bool AbroadProduct { get; set; }
            public object AbroadPublicPaidPrice { get; set; }
            public object AbroadRetail { get; set; }
            public object AbroadPublicPrice { get; set; }
            public int UpdatedAt { get; set; }
        }

        public class ProductReimbursementPrice_PublicPaidPrice
        {
            public double Price { get; set; }
            public double PriceVatInc { get; set; }
            public object GroupCode { get; set; }
            public object GroupType { get; set; }
            public bool GroupLowestUnitPrice { get; set; }
            public object EquivalentGroupCode { get; set; }
        }

        public class ProductReimbursementPrice_Response
        {
            public bool Success { get; set; }
            public ProductReimbursementPrice_Data Data { get; set; }
        }

        #endregion ProductReimbursementPrice_JsonTypes

        #region SubstanceList_JsonTypes

        public class SubstanceList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class SubstanceList_Response
        {
            public bool Success { get; set; }
            public SubstanceList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion SubstanceList_JsonTypes

        #region SymptomsList_JsonTypes

        public class SymptomsList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class SymptomsList_Response
        {
            public bool Success { get; set; }
            public SymptomsList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion SymptomsList_JsonTypes

        #region UnitList_JsonTypes

        public class UnitList_Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class UnitList_Response
        {
            public bool Success { get; set; }
            public UnitList_Datum[] Data { get; set; }
            public Links Links { get; set; }
            public Meta Meta { get; set; }
        }

        #endregion UnitList_JsonTypes


        public class AuthResult
        {
            public bool success { get; set; }
            public AuthResultData data { get; set; }
        }

        public class AuthResultData
        {
            public string token { get; set; }
            public long expires_at { get; set; }
            public string Base64Token
            {
                get
                {
                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(token + ":"));
                }
            }

            public DateTime ExpireTime
            {
                get
                {
                    return new DateTime(expires_at);
                }
            }
        }

        public class Links
        {
            public Self Self { get; set; }
        }

        public class Meta
        {
            public int TotalCount { get; set; }
            public int PageCount { get; set; }
            public int CurrentPage { get; set; }
            public int PerPage { get; set; }
        }

        public class Self
        {
            public string Href { get; set; }
        }

        #endregion
    }
}