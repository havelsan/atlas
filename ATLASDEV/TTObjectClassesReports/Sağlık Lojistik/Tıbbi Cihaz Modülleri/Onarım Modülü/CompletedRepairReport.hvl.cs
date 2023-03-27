
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Tamamlanan Onarım
    /// </summary>
    public partial class CompletedRepairReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class ANAGroup : TTReportGroup
        {
            public CompletedRepairReport MyParentReport
            {
                get { return (CompletedRepairReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField ISTEKSIRANO1 { get {return Header().ISTEKSIRANO1;} }
            public TTReportField ISTEKTARIHI1 { get {return Header().ISTEKTARIHI1;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField GONDERENUNITE1 { get {return Header().GONDERENUNITE1;} }
            public TTReportField NewField12311 { get {return Header().NewField12311;} }
            public TTReportField ISIYAPACAKKISIM1 { get {return Header().ISIYAPACAKKISIM1;} }
            public TTReportField NewField13311 { get {return Header().NewField13311;} }
            public TTReportField ISIYAPACAKPERSONEL1 { get {return Header().ISIYAPACAKPERSONEL1;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField BASLANGICTARIHI1 { get {return Header().BASLANGICTARIHI1;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField BITISTARIHI1 { get {return Header().BITISTARIHI1;} }
            public TTReportField NewField14311 { get {return Header().NewField14311;} }
            public TTReportField DEMIRBAS1 { get {return Header().DEMIRBAS1;} }
            public TTReportField NewField15311 { get {return Header().NewField15311;} }
            public TTReportField SONUC1 { get {return Header().SONUC1;} }
            public TTReportField NewField16311 { get {return Header().NewField16311;} }
            public TTReportField KULLANANPERSONEL1 { get {return Header().KULLANANPERSONEL1;} }
            public TTReportField NewField111341 { get {return Header().NewField111341;} }
            public TTReportField MALZEMESAYISI1 { get {return Header().MALZEMESAYISI1;} }
            public TTReportField NewField1143111 { get {return Header().NewField1143111;} }
            public TTReportField KULLANANTELNO1 { get {return Header().KULLANANTELNO1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public ANAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaterialRepair.GetMaterialRepairQuery_Class>("GetMaterialRepairQuery", MaterialRepair.GetMaterialRepairQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ANAGroupHeader(this);
                _footer = new ANAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ANAGroupHeader : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField ISTEKSIRANO1;
                public TTReportField ISTEKTARIHI1;
                public TTReportField NewField1131;
                public TTReportField GONDERENUNITE1;
                public TTReportField NewField12311;
                public TTReportField ISIYAPACAKKISIM1;
                public TTReportField NewField13311;
                public TTReportField ISIYAPACAKPERSONEL1;
                public TTReportField NewField1231;
                public TTReportField BASLANGICTARIHI1;
                public TTReportField NewField1331;
                public TTReportField BITISTARIHI1;
                public TTReportField NewField14311;
                public TTReportField DEMIRBAS1;
                public TTReportField NewField15311;
                public TTReportField SONUC1;
                public TTReportField NewField16311;
                public TTReportField KULLANANPERSONEL1;
                public TTReportField NewField111341;
                public TTReportField MALZEMESAYISI1;
                public TTReportField NewField1143111;
                public TTReportField KULLANANTELNO1;
                public TTReportShape NewLine11; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 69;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 202, 11, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"TAMAMLANAN ONARIM FORMU";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 14, 39, 19, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"İstek Sıra No:";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 14, 83, 19, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField131.TextFont.Name = "Arial Narrow";
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"İstek Tarihi:";

                    ISTEKSIRANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 20, 39, 25, false);
                    ISTEKSIRANO1.Name = "ISTEKSIRANO1";
                    ISTEKSIRANO1.DrawStyle = DrawStyleConstants.vbInvisible;
                    ISTEKSIRANO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKSIRANO1.VertAlign = VerticalAlignmentEnum.vaTop;
                    ISTEKSIRANO1.TextFont.Name = "Arial Narrow";
                    ISTEKSIRANO1.TextFont.Size = 10;
                    ISTEKSIRANO1.TextFont.CharSet = 1;
                    ISTEKSIRANO1.Value = @"{#REQUESTNO#}";

                    ISTEKTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 20, 83, 25, false);
                    ISTEKTARIHI1.Name = "ISTEKTARIHI1";
                    ISTEKTARIHI1.DrawStyle = DrawStyleConstants.vbInvisible;
                    ISTEKTARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKTARIHI1.VertAlign = VerticalAlignmentEnum.vaTop;
                    ISTEKTARIHI1.TextFont.Name = "Arial Narrow";
                    ISTEKTARIHI1.TextFont.Size = 10;
                    ISTEKTARIHI1.TextFont.CharSet = 1;
                    ISTEKTARIHI1.Value = @"{#REQUESTDATE#}";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 14, 202, 19, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 10;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @"Gönderen Ünite:";

                    GONDERENUNITE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 20, 202, 25, false);
                    GONDERENUNITE1.Name = "GONDERENUNITE1";
                    GONDERENUNITE1.DrawStyle = DrawStyleConstants.vbInvisible;
                    GONDERENUNITE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERENUNITE1.VertAlign = VerticalAlignmentEnum.vaTop;
                    GONDERENUNITE1.ObjectDefName = "ResSection";
                    GONDERENUNITE1.DataMember = "NAME";
                    GONDERENUNITE1.TextFont.Name = "Arial Narrow";
                    GONDERENUNITE1.TextFont.Size = 10;
                    GONDERENUNITE1.TextFont.CharSet = 1;
                    GONDERENUNITE1.Value = @"{#SENDERSECTION#}";

                    NewField12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 28, 202, 33, false);
                    NewField12311.Name = "NewField12311";
                    NewField12311.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12311.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField12311.TextFont.Name = "Arial Narrow";
                    NewField12311.TextFont.Size = 10;
                    NewField12311.TextFont.Bold = true;
                    NewField12311.Value = @"İşi Yapacak Kısım:";

                    ISIYAPACAKKISIM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 34, 202, 39, false);
                    ISIYAPACAKKISIM1.Name = "ISIYAPACAKKISIM1";
                    ISIYAPACAKKISIM1.DrawStyle = DrawStyleConstants.vbInvisible;
                    ISIYAPACAKKISIM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISIYAPACAKKISIM1.VertAlign = VerticalAlignmentEnum.vaTop;
                    ISIYAPACAKKISIM1.ObjectDefName = "ResDivisionSubSection";
                    ISIYAPACAKKISIM1.DataMember = "NAME";
                    ISIYAPACAKKISIM1.TextFont.Name = "Arial Narrow";
                    ISIYAPACAKKISIM1.TextFont.Size = 10;
                    ISIYAPACAKKISIM1.TextFont.CharSet = 1;
                    ISIYAPACAKKISIM1.Value = @"{#WORKSHOP#}";

                    NewField13311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 41, 202, 46, false);
                    NewField13311.Name = "NewField13311";
                    NewField13311.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField13311.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField13311.TextFont.Name = "Arial Narrow";
                    NewField13311.TextFont.Size = 10;
                    NewField13311.TextFont.Bold = true;
                    NewField13311.Value = @"İşi Yapacak Olan Personel:";

                    ISIYAPACAKPERSONEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 47, 202, 52, false);
                    ISIYAPACAKPERSONEL1.Name = "ISIYAPACAKPERSONEL1";
                    ISIYAPACAKPERSONEL1.DrawStyle = DrawStyleConstants.vbInvisible;
                    ISIYAPACAKPERSONEL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISIYAPACAKPERSONEL1.VertAlign = VerticalAlignmentEnum.vaTop;
                    ISIYAPACAKPERSONEL1.ObjectDefName = "ResUser";
                    ISIYAPACAKPERSONEL1.DataMember = "NAME";
                    ISIYAPACAKPERSONEL1.TextFont.Name = "Arial Narrow";
                    ISIYAPACAKPERSONEL1.TextFont.Size = 10;
                    ISIYAPACAKPERSONEL1.TextFont.CharSet = 1;
                    ISIYAPACAKPERSONEL1.Value = @"{#RESPONSIBLEWORKSHOPUSER#}";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 54, 157, 59, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1231.TextFont.Name = "Arial Narrow";
                    NewField1231.TextFont.Size = 10;
                    NewField1231.TextFont.Bold = true;
                    NewField1231.Value = @"Başlangıç Tarihi:";

                    BASLANGICTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 60, 157, 65, false);
                    BASLANGICTARIHI1.Name = "BASLANGICTARIHI1";
                    BASLANGICTARIHI1.DrawStyle = DrawStyleConstants.vbInvisible;
                    BASLANGICTARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLANGICTARIHI1.VertAlign = VerticalAlignmentEnum.vaTop;
                    BASLANGICTARIHI1.TextFont.Name = "Arial Narrow";
                    BASLANGICTARIHI1.TextFont.Size = 10;
                    BASLANGICTARIHI1.TextFont.CharSet = 1;
                    BASLANGICTARIHI1.Value = @"{#STARTDATE#}";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 54, 202, 59, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1331.TextFont.Name = "Arial Narrow";
                    NewField1331.TextFont.Size = 10;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.Value = @"Bitiş Tarihi:";

                    BITISTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 60, 202, 65, false);
                    BITISTARIHI1.Name = "BITISTARIHI1";
                    BITISTARIHI1.DrawStyle = DrawStyleConstants.vbInvisible;
                    BITISTARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BITISTARIHI1.VertAlign = VerticalAlignmentEnum.vaTop;
                    BITISTARIHI1.TextFont.Name = "Arial Narrow";
                    BITISTARIHI1.TextFont.Size = 10;
                    BITISTARIHI1.TextFont.CharSet = 1;
                    BITISTARIHI1.Value = @"{#ENDDATE#}";

                    NewField14311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 28, 83, 33, false);
                    NewField14311.Name = "NewField14311";
                    NewField14311.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14311.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField14311.TextFont.Name = "Arial Narrow";
                    NewField14311.TextFont.Size = 10;
                    NewField14311.TextFont.Bold = true;
                    NewField14311.Value = @"Demirbaş:";

                    DEMIRBAS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 34, 83, 39, false);
                    DEMIRBAS1.Name = "DEMIRBAS1";
                    DEMIRBAS1.DrawStyle = DrawStyleConstants.vbInvisible;
                    DEMIRBAS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMIRBAS1.VertAlign = VerticalAlignmentEnum.vaTop;
                    DEMIRBAS1.ObjectDefName = "FixedAssetDefinition";
                    DEMIRBAS1.DataMember = "NAME";
                    DEMIRBAS1.TextFont.Name = "Arial Narrow";
                    DEMIRBAS1.TextFont.Size = 10;
                    DEMIRBAS1.TextFont.CharSet = 1;
                    DEMIRBAS1.Value = @"{#FIXEDASSETDEFINITION#}";

                    NewField15311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 41, 109, 46, false);
                    NewField15311.Name = "NewField15311";
                    NewField15311.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField15311.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField15311.TextFont.Name = "Arial Narrow";
                    NewField15311.TextFont.Size = 10;
                    NewField15311.TextFont.Bold = true;
                    NewField15311.Value = @"Sonuç:";

                    SONUC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 47, 109, 52, false);
                    SONUC1.Name = "SONUC1";
                    SONUC1.DrawStyle = DrawStyleConstants.vbInvisible;
                    SONUC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONUC1.VertAlign = VerticalAlignmentEnum.vaTop;
                    SONUC1.TextFont.Name = "Arial Narrow";
                    SONUC1.TextFont.Size = 10;
                    SONUC1.TextFont.CharSet = 1;
                    SONUC1.Value = @"{#RESULT#}";

                    NewField16311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 83, 59, false);
                    NewField16311.Name = "NewField16311";
                    NewField16311.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField16311.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField16311.TextFont.Name = "Arial Narrow";
                    NewField16311.TextFont.Size = 10;
                    NewField16311.TextFont.Bold = true;
                    NewField16311.Value = @"Kullanan Personel:";

                    KULLANANPERSONEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 60, 83, 65, false);
                    KULLANANPERSONEL1.Name = "KULLANANPERSONEL1";
                    KULLANANPERSONEL1.DrawStyle = DrawStyleConstants.vbInvisible;
                    KULLANANPERSONEL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KULLANANPERSONEL1.VertAlign = VerticalAlignmentEnum.vaTop;
                    KULLANANPERSONEL1.ObjectDefName = "ResUser";
                    KULLANANPERSONEL1.DataMember = "NAME";
                    KULLANANPERSONEL1.TextFont.Name = "Arial Narrow";
                    KULLANANPERSONEL1.TextFont.Size = 10;
                    KULLANANPERSONEL1.TextFont.CharSet = 1;
                    KULLANANPERSONEL1.Value = @"{#DEVICEUSER#}";

                    NewField111341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 28, 109, 33, false);
                    NewField111341.Name = "NewField111341";
                    NewField111341.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111341.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111341.TextFont.Name = "Arial Narrow";
                    NewField111341.TextFont.Size = 10;
                    NewField111341.TextFont.Bold = true;
                    NewField111341.Value = @"Malzeme Sayısı:";

                    MALZEMESAYISI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 34, 109, 39, false);
                    MALZEMESAYISI1.Name = "MALZEMESAYISI1";
                    MALZEMESAYISI1.DrawStyle = DrawStyleConstants.vbInvisible;
                    MALZEMESAYISI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMESAYISI1.VertAlign = VerticalAlignmentEnum.vaTop;
                    MALZEMESAYISI1.TextFont.Name = "Arial Narrow";
                    MALZEMESAYISI1.TextFont.Size = 10;
                    MALZEMESAYISI1.TextFont.CharSet = 1;
                    MALZEMESAYISI1.Value = @"{#FIXEDASSETMATERIALAMOUNT#}";

                    NewField1143111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 54, 109, 59, false);
                    NewField1143111.Name = "NewField1143111";
                    NewField1143111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1143111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1143111.TextFont.Name = "Arial Narrow";
                    NewField1143111.TextFont.Size = 10;
                    NewField1143111.TextFont.Bold = true;
                    NewField1143111.Value = @"Tel No:";

                    KULLANANTELNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 60, 109, 65, false);
                    KULLANANTELNO1.Name = "KULLANANTELNO1";
                    KULLANANTELNO1.DrawStyle = DrawStyleConstants.vbInvisible;
                    KULLANANTELNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KULLANANTELNO1.VertAlign = VerticalAlignmentEnum.vaTop;
                    KULLANANTELNO1.TextFont.Name = "Arial Narrow";
                    KULLANANTELNO1.TextFont.Size = 10;
                    KULLANANTELNO1.TextFont.CharSet = 1;
                    KULLANANTELNO1.Value = @"{#USERTEL#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 67, 202, 67, false);
                    NewLine11.Name = "NewLine11";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialRepair.GetMaterialRepairQuery_Class dataset_GetMaterialRepairQuery = ParentGroup.rsGroup.GetCurrentRecord<MaterialRepair.GetMaterialRepairQuery_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    ISTEKSIRANO1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.RequestNo) : "");
                    ISTEKTARIHI1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.RequestDate) : "");
                    NewField1131.CalcValue = NewField1131.Value;
                    GONDERENUNITE1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.SenderSection) : "");
                    GONDERENUNITE1.PostFieldValueCalculation();
                    NewField12311.CalcValue = NewField12311.Value;
                    ISIYAPACAKKISIM1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.WorkShop) : "");
                    ISIYAPACAKKISIM1.PostFieldValueCalculation();
                    NewField13311.CalcValue = NewField13311.Value;
                    ISIYAPACAKPERSONEL1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.ResponsibleWorkShopUser) : "");
                    ISIYAPACAKPERSONEL1.PostFieldValueCalculation();
                    NewField1231.CalcValue = NewField1231.Value;
                    BASLANGICTARIHI1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.StartDate) : "");
                    NewField1331.CalcValue = NewField1331.Value;
                    BITISTARIHI1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.EndDate) : "");
                    NewField14311.CalcValue = NewField14311.Value;
                    DEMIRBAS1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.FixedAssetDefinition) : "");
                    DEMIRBAS1.PostFieldValueCalculation();
                    NewField15311.CalcValue = NewField15311.Value;
                    SONUC1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.Result) : "");
                    NewField16311.CalcValue = NewField16311.Value;
                    KULLANANPERSONEL1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.DeviceUser) : "");
                    KULLANANPERSONEL1.PostFieldValueCalculation();
                    NewField111341.CalcValue = NewField111341.Value;
                    MALZEMESAYISI1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.FixedAssetMaterialAmount) : "");
                    NewField1143111.CalcValue = NewField1143111.Value;
                    KULLANANTELNO1.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.UserTel) : "");
                    return new TTReportObject[] { NewField121,NewField13,NewField131,ISTEKSIRANO1,ISTEKTARIHI1,NewField1131,GONDERENUNITE1,NewField12311,ISIYAPACAKKISIM1,NewField13311,ISIYAPACAKPERSONEL1,NewField1231,BASLANGICTARIHI1,NewField1331,BITISTARIHI1,NewField14311,DEMIRBAS1,NewField15311,SONUC1,NewField16311,KULLANANPERSONEL1,NewField111341,MALZEMESAYISI1,NewField1143111,KULLANANTELNO1};
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 202, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"TTObjectClasses.Common.GetTextOfRTFString({#HEKREPORTDESCRIPTION#})";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialRepair.GetMaterialRepairQuery_Class dataset_GetMaterialRepairQuery = ParentGroup.rsGroup.GetCurrentRecord<MaterialRepair.GetMaterialRepairQuery_Class>(0);
                    NewField1.CalcValue = TTObjectClasses.Common.GetTextOfRTFString((dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.HEKReportDescription) : ""));
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public ANAGroup ANA;

        public partial class NotlarGroup : TTReportGroup
        {
            public CompletedRepairReport MyParentReport
            {
                get { return (CompletedRepairReport)ParentReport; }
            }

            new public NotlarGroupBody Body()
            {
                return (NotlarGroupBody)_body;
            }
            public TTReportField NewField14311 { get {return Body().NewField14311;} }
            public TTReportField CIHAZINARIZASI { get {return Body().CIHAZINARIZASI;} }
            public TTReportField NewField111341 { get {return Body().NewField111341;} }
            public TTReportField ONKONTROLNOTLARI { get {return Body().ONKONTROLNOTLARI;} }
            public TTReportField NewField111342 { get {return Body().NewField111342;} }
            public TTReportField ONARIMNOTLARI { get {return Body().ONARIMNOTLARI;} }
            public TTReportField NewField111343 { get {return Body().NewField111343;} }
            public TTReportField SONKONTROLNOTLARI { get {return Body().SONKONTROLNOTLARI;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public NotlarGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NotlarGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new NotlarGroupBody(this);
            }

            public partial class NotlarGroupBody : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField14311;
                public TTReportField CIHAZINARIZASI;
                public TTReportField NewField111341;
                public TTReportField ONKONTROLNOTLARI;
                public TTReportField NewField111342;
                public TTReportField ONARIMNOTLARI;
                public TTReportField NewField111343;
                public TTReportField SONKONTROLNOTLARI;
                public TTReportShape NewLine11; 
                public NotlarGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 66;
                    RepeatCount = 0;
                    
                    NewField14311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 202, 6, false);
                    NewField14311.Name = "NewField14311";
                    NewField14311.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14311.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField14311.TextFont.Name = "Arial Narrow";
                    NewField14311.TextFont.Size = 10;
                    NewField14311.TextFont.Bold = true;
                    NewField14311.Value = @"Cihazın Arızası:";

                    CIHAZINARIZASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 202, 16, false);
                    CIHAZINARIZASI.Name = "CIHAZINARIZASI";
                    CIHAZINARIZASI.DrawStyle = DrawStyleConstants.vbInvisible;
                    CIHAZINARIZASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIHAZINARIZASI.VertAlign = VerticalAlignmentEnum.vaTop;
                    CIHAZINARIZASI.TextFont.Name = "Arial Narrow";
                    CIHAZINARIZASI.TextFont.Size = 10;
                    CIHAZINARIZASI.TextFont.CharSet = 1;
                    CIHAZINARIZASI.Value = @"{#ANA.FAULTDESCRIPTION#}";

                    NewField111341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 202, 22, false);
                    NewField111341.Name = "NewField111341";
                    NewField111341.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111341.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111341.TextFont.Name = "Arial Narrow";
                    NewField111341.TextFont.Size = 10;
                    NewField111341.TextFont.Bold = true;
                    NewField111341.Value = @"Ön Kontrol Notları:";

                    ONKONTROLNOTLARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 23, 202, 32, false);
                    ONKONTROLNOTLARI.Name = "ONKONTROLNOTLARI";
                    ONKONTROLNOTLARI.DrawStyle = DrawStyleConstants.vbInvisible;
                    ONKONTROLNOTLARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONKONTROLNOTLARI.VertAlign = VerticalAlignmentEnum.vaTop;
                    ONKONTROLNOTLARI.TextFont.Name = "Arial Narrow";
                    ONKONTROLNOTLARI.TextFont.Size = 10;
                    ONKONTROLNOTLARI.TextFont.CharSet = 1;
                    ONKONTROLNOTLARI.Value = @"{#ANA.PRECONTROLNOTES#}";

                    NewField111342 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 33, 202, 38, false);
                    NewField111342.Name = "NewField111342";
                    NewField111342.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111342.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111342.TextFont.Name = "Arial Narrow";
                    NewField111342.TextFont.Size = 10;
                    NewField111342.TextFont.Bold = true;
                    NewField111342.Value = @"Onarım Notları:";

                    ONARIMNOTLARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 39, 202, 48, false);
                    ONARIMNOTLARI.Name = "ONARIMNOTLARI";
                    ONARIMNOTLARI.DrawStyle = DrawStyleConstants.vbInvisible;
                    ONARIMNOTLARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONARIMNOTLARI.VertAlign = VerticalAlignmentEnum.vaTop;
                    ONARIMNOTLARI.TextFont.Name = "Arial Narrow";
                    ONARIMNOTLARI.TextFont.Size = 10;
                    ONARIMNOTLARI.TextFont.CharSet = 1;
                    ONARIMNOTLARI.Value = @"{#ANA.REPAIRNOTES#}";

                    NewField111343 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 49, 202, 54, false);
                    NewField111343.Name = "NewField111343";
                    NewField111343.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111343.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111343.TextFont.Name = "Arial Narrow";
                    NewField111343.TextFont.Size = 10;
                    NewField111343.TextFont.Bold = true;
                    NewField111343.Value = @"Son Kontrol Notları:";

                    SONKONTROLNOTLARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 55, 202, 64, false);
                    SONKONTROLNOTLARI.Name = "SONKONTROLNOTLARI";
                    SONKONTROLNOTLARI.DrawStyle = DrawStyleConstants.vbInvisible;
                    SONKONTROLNOTLARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONKONTROLNOTLARI.VertAlign = VerticalAlignmentEnum.vaTop;
                    SONKONTROLNOTLARI.TextFont.Name = "Arial Narrow";
                    SONKONTROLNOTLARI.TextFont.Size = 10;
                    SONKONTROLNOTLARI.TextFont.CharSet = 1;
                    SONKONTROLNOTLARI.Value = @"{#ANA.LASTCONTROLNOTES#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 66, 202, 66, false);
                    NewLine11.Name = "NewLine11";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialRepair.GetMaterialRepairQuery_Class dataset_GetMaterialRepairQuery = MyParentReport.ANA.rsGroup.GetCurrentRecord<MaterialRepair.GetMaterialRepairQuery_Class>(0);
                    NewField14311.CalcValue = NewField14311.Value;
                    CIHAZINARIZASI.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.FaultDescription) : "");
                    NewField111341.CalcValue = NewField111341.Value;
                    ONKONTROLNOTLARI.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.PreControlNotes) : "");
                    NewField111342.CalcValue = NewField111342.Value;
                    ONARIMNOTLARI.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.RepairNotes) : "");
                    NewField111343.CalcValue = NewField111343.Value;
                    SONKONTROLNOTLARI.CalcValue = (dataset_GetMaterialRepairQuery != null ? Globals.ToStringCore(dataset_GetMaterialRepairQuery.LastControlNotes) : "");
                    return new TTReportObject[] { NewField14311,CIHAZINARIZASI,NewField111341,ONKONTROLNOTLARI,NewField111342,ONARIMNOTLARI,NewField111343,SONKONTROLNOTLARI};
                }
            }

        }

        public NotlarGroup Notlar;

        public partial class KULLANILANMALZEMECGroup : TTReportGroup
        {
            public CompletedRepairReport MyParentReport
            {
                get { return (CompletedRepairReport)ParentReport; }
            }

            new public KULLANILANMALZEMECGroupHeader Header()
            {
                return (KULLANILANMALZEMECGroupHeader)_header;
            }

            new public KULLANILANMALZEMECGroupFooter Footer()
            {
                return (KULLANILANMALZEMECGroupFooter)_footer;
            }

            public TTReportField NewField111431111 { get {return Header().NewField111431111;} }
            public TTReportField NewField1111134111 { get {return Header().NewField1111134111;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1111341111 { get {return Header().NewField1111341111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public KULLANILANMALZEMECGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KULLANILANMALZEMECGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KULLANILANMALZEMECGroupHeader(this);
                _footer = new KULLANILANMALZEMECGroupFooter(this);

            }

            public partial class KULLANILANMALZEMECGroupHeader : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField111431111;
                public TTReportField NewField1111134111;
                public TTReportField NewField0;
                public TTReportField NewField1111341111;
                public TTReportField NewField111111;
                public TTReportField NewField10; 
                public KULLANILANMALZEMECGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111431111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 202, 6, false);
                    NewField111431111.Name = "NewField111431111";
                    NewField111431111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111431111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111431111.TextFont.Name = "Arial Narrow";
                    NewField111431111.TextFont.Size = 10;
                    NewField111431111.TextFont.Bold = true;
                    NewField111431111.Value = @"Kullanılan Malzemeler:";

                    NewField1111134111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 118, 17, false);
                    NewField1111134111.Name = "NewField1111134111";
                    NewField1111134111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111134111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111134111.TextFont.Name = "Arial Narrow";
                    NewField1111134111.TextFont.Size = 10;
                    NewField1111134111.TextFont.Bold = true;
                    NewField1111134111.Value = @"MALZEME";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 7, 139, 17, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 10;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"İSTENEN
MİKTAR";

                    NewField1111341111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 7, 160, 17, false);
                    NewField1111341111.Name = "NewField1111341111";
                    NewField1111341111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111341111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111341111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111341111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111341111.TextFont.Name = "Arial Narrow";
                    NewField1111341111.TextFont.Size = 10;
                    NewField1111341111.TextFont.Bold = true;
                    NewField1111341111.Value = @"KARŞILANAN
MİKTAR";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 7, 181, 17, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 10;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"MİKTAR";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 7, 202, 17, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 10;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"BİRİM
FİYAT";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111431111.CalcValue = NewField111431111.Value;
                    NewField1111134111.CalcValue = NewField1111134111.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1111341111.CalcValue = NewField1111341111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField10.CalcValue = NewField10.Value;
                    return new TTReportObject[] { NewField111431111,NewField1111134111,NewField0,NewField1111341111,NewField111111,NewField10};
                }
            }
            public partial class KULLANILANMALZEMECGroupFooter : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportShape NewLine111; 
                public KULLANILANMALZEMECGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 2, 202, 2, false);
                    NewLine111.Name = "NewLine111";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public KULLANILANMALZEMECGroup KULLANILANMALZEMEC;

        public partial class KULLANILANMALZEMEGroup : TTReportGroup
        {
            public CompletedRepairReport MyParentReport
            {
                get { return (CompletedRepairReport)ParentReport; }
            }

            new public KULLANILANMALZEMEGroupBody Body()
            {
                return (KULLANILANMALZEMEGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public KULLANILANMALZEMEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KULLANILANMALZEMEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class>("GetUsedMaterialsOfRepair", UsedConsumedMaterail.GetUsedMaterialsOfRepair((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KULLANILANMALZEMEGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class KULLANILANMALZEMEGroupBody : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField113; 
                public KULLANILANMALZEMEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 118, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.ObjectDefName = "Material";
                    NewField1.DataMember = "NAME";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"{#MATERIAL#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 139, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.CharSet = 1;
                    NewField11.Value = @"{#REQUESTAMOUNT#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 160, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.CharSet = 1;
                    NewField111.Value = @"{#SUPPLIEDAMOUNT#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 181, 5, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField112.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Size = 10;
                    NewField112.TextFont.CharSet = 1;
                    NewField112.Value = @"{#AMOUNT#}";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 202, 5, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField113.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField113.TextFont.Name = "Arial Narrow";
                    NewField113.TextFont.Size = 10;
                    NewField113.TextFont.CharSet = 1;
                    NewField113.Value = @"{#UNITPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class dataset_GetUsedMaterialsOfRepair = ParentGroup.rsGroup.GetCurrentRecord<UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class>(0);
                    NewField1.CalcValue = (dataset_GetUsedMaterialsOfRepair != null ? Globals.ToStringCore(dataset_GetUsedMaterialsOfRepair.Material) : "");
                    NewField1.PostFieldValueCalculation();
                    NewField11.CalcValue = (dataset_GetUsedMaterialsOfRepair != null ? Globals.ToStringCore(dataset_GetUsedMaterialsOfRepair.RequestAmount) : "");
                    NewField111.CalcValue = (dataset_GetUsedMaterialsOfRepair != null ? Globals.ToStringCore(dataset_GetUsedMaterialsOfRepair.SuppliedAmount) : "");
                    NewField112.CalcValue = (dataset_GetUsedMaterialsOfRepair != null ? Globals.ToStringCore(dataset_GetUsedMaterialsOfRepair.Amount) : "");
                    NewField113.CalcValue = (dataset_GetUsedMaterialsOfRepair != null ? Globals.ToStringCore(dataset_GetUsedMaterialsOfRepair.UnitPrice) : "");
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField112,NewField113};
                }
            }

        }

        public KULLANILANMALZEMEGroup KULLANILANMALZEME;

        public partial class CIHAZLAGELENMUHTEVIYATGroup : TTReportGroup
        {
            public CompletedRepairReport MyParentReport
            {
                get { return (CompletedRepairReport)ParentReport; }
            }

            new public CIHAZLAGELENMUHTEVIYATGroupHeader Header()
            {
                return (CIHAZLAGELENMUHTEVIYATGroupHeader)_header;
            }

            new public CIHAZLAGELENMUHTEVIYATGroupFooter Footer()
            {
                return (CIHAZLAGELENMUHTEVIYATGroupFooter)_footer;
            }

            public TTReportField NewField1111134111 { get {return Header().NewField1111134111;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField11111112 { get {return Header().NewField11111112;} }
            public TTReportField NewField111111111 { get {return Header().NewField111111111;} }
            public TTReportField NewField11111113 { get {return Header().NewField11111113;} }
            public TTReportField NewField111111112 { get {return Header().NewField111111112;} }
            public CIHAZLAGELENMUHTEVIYATGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CIHAZLAGELENMUHTEVIYATGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class>("GetRepairItemEquipmentOfCompletedRepair", Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new CIHAZLAGELENMUHTEVIYATGroupHeader(this);
                _footer = new CIHAZLAGELENMUHTEVIYATGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class CIHAZLAGELENMUHTEVIYATGroupHeader : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField1111134111;
                public TTReportField NewField0;
                public TTReportField NewField1111111;
                public TTReportField NewField11111111;
                public TTReportField NewField11111112;
                public TTReportField NewField111111111;
                public TTReportField NewField11111113;
                public TTReportField NewField111111112; 
                public CIHAZLAGELENMUHTEVIYATGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111134111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 202, 6, false);
                    NewField1111134111.Name = "NewField1111134111";
                    NewField1111134111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111134111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1111134111.TextFont.Name = "Arial Narrow";
                    NewField1111134111.TextFont.Size = 10;
                    NewField1111134111.TextFont.Bold = true;
                    NewField1111134111.Value = @"Cihazla Gelen Muhteviyat:";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 86, 17, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 10;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"ADI";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 7, 100, 17, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.TextFont.Size = 10;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.Value = @"MİKTAR";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 7, 114, 17, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111111.TextFont.Name = "Arial Narrow";
                    NewField11111111.TextFont.Size = 10;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.Value = @"EKSİK";

                    NewField11111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 7, 128, 17, false);
                    NewField11111112.Name = "NewField11111112";
                    NewField11111112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111112.TextFont.Name = "Arial Narrow";
                    NewField11111112.TextFont.Size = 10;
                    NewField11111112.TextFont.Bold = true;
                    NewField11111112.Value = @"DEĞİŞİK";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 7, 142, 17, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111111.TextFont.Name = "Arial Narrow";
                    NewField111111111.TextFont.Size = 10;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.Value = @"HASARLI";

                    NewField11111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 7, 156, 17, false);
                    NewField11111113.Name = "NewField11111113";
                    NewField11111113.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111113.TextFont.Name = "Arial Narrow";
                    NewField11111113.TextFont.Size = 10;
                    NewField11111113.TextFont.Bold = true;
                    NewField11111113.Value = @"TAMAM";

                    NewField111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 7, 202, 17, false);
                    NewField111111112.Name = "NewField111111112";
                    NewField111111112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111112.TextFont.Name = "Arial Narrow";
                    NewField111111112.TextFont.Size = 10;
                    NewField111111112.TextFont.Bold = true;
                    NewField111111112.Value = @"DÜŞÜNCELER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class dataset_GetRepairItemEquipmentOfCompletedRepair = ParentGroup.rsGroup.GetCurrentRecord<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class>(0);
                    NewField1111134111.CalcValue = NewField1111134111.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField11111112.CalcValue = NewField11111112.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    NewField11111113.CalcValue = NewField11111113.Value;
                    NewField111111112.CalcValue = NewField111111112.Value;
                    return new TTReportObject[] { NewField1111134111,NewField0,NewField1111111,NewField11111111,NewField11111112,NewField111111111,NewField11111113,NewField111111112};
                }
            }
            public partial class CIHAZLAGELENMUHTEVIYATGroupFooter : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                 
                public CIHAZLAGELENMUHTEVIYATGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public CIHAZLAGELENMUHTEVIYATGroup CIHAZLAGELENMUHTEVIYAT;

        public partial class CIHAZLAGELENMUHTEVIYATCGroup : TTReportGroup
        {
            public CompletedRepairReport MyParentReport
            {
                get { return (CompletedRepairReport)ParentReport; }
            }

            new public CIHAZLAGELENMUHTEVIYATCGroupBody Body()
            {
                return (CIHAZLAGELENMUHTEVIYATCGroupBody)_body;
            }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField11111111 { get {return Body().NewField11111111;} }
            public TTReportField NewField1211111111 { get {return Body().NewField1211111111;} }
            public TTReportField NewField111111111 { get {return Body().NewField111111111;} }
            public TTReportField NewField1111111111 { get {return Body().NewField1111111111;} }
            public TTReportField NewField1111111112 { get {return Body().NewField1111111112;} }
            public TTReportField NewField1111111113 { get {return Body().NewField1111111113;} }
            public CIHAZLAGELENMUHTEVIYATCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CIHAZLAGELENMUHTEVIYATCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new CIHAZLAGELENMUHTEVIYATCGroupBody(this);
            }

            public partial class CIHAZLAGELENMUHTEVIYATCGroupBody : TTReportSection
            {
                public CompletedRepairReport MyParentReport
                {
                    get { return (CompletedRepairReport)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField NewField11111111;
                public TTReportField NewField1211111111;
                public TTReportField NewField111111111;
                public TTReportField NewField1111111111;
                public TTReportField NewField1111111112;
                public TTReportField NewField1111111113; 
                public CIHAZLAGELENMUHTEVIYATCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 86, 6, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField10.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 10;
                    NewField10.Value = @"{#CIHAZLAGELENMUHTEVIYAT.ITEMNAME#}";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 1, 100, 6, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11111111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111111.TextFont.Name = "Arial Narrow";
                    NewField11111111.TextFont.Size = 10;
                    NewField11111111.Value = @"{#CIHAZLAGELENMUHTEVIYAT.AMOUNT#}";

                    NewField1211111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 202, 6, false);
                    NewField1211111111.Name = "NewField1211111111";
                    NewField1211111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1211111111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1211111111.TextFont.Name = "Arial Narrow";
                    NewField1211111111.TextFont.Size = 10;
                    NewField1211111111.Value = @"{#CIHAZLAGELENMUHTEVIYAT.COMMENTS#}";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 114, 6, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111111111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111111.TextFont.Name = "Arial Narrow";
                    NewField111111111.TextFont.Size = 10;
                    NewField111111111.Value = @"{#CIHAZLAGELENMUHTEVIYAT.ISMISSING#}";

                    NewField1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 128, 6, false);
                    NewField1111111111.Name = "NewField1111111111";
                    NewField1111111111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111111111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111111.TextFont.Name = "Arial Narrow";
                    NewField1111111111.TextFont.Size = 10;
                    NewField1111111111.Value = @"{#CIHAZLAGELENMUHTEVIYAT.ISCHANGED#}";

                    NewField1111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 142, 6, false);
                    NewField1111111112.Name = "NewField1111111112";
                    NewField1111111112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111111112.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1111111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111112.TextFont.Name = "Arial Narrow";
                    NewField1111111112.TextFont.Size = 10;
                    NewField1111111112.Value = @"{#CIHAZLAGELENMUHTEVIYAT.ISDAMAGED#}";

                    NewField1111111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 156, 6, false);
                    NewField1111111113.Name = "NewField1111111113";
                    NewField1111111113.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111111113.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1111111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111113.TextFont.Name = "Arial Narrow";
                    NewField1111111113.TextFont.Size = 10;
                    NewField1111111113.Value = @"{#CIHAZLAGELENMUHTEVIYAT.ISNORMAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class dataset_GetRepairItemEquipmentOfCompletedRepair = MyParentReport.CIHAZLAGELENMUHTEVIYAT.rsGroup.GetCurrentRecord<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class>(0);
                    NewField10.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.ItemName) : "");
                    NewField11111111.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.Amount) : "");
                    NewField1211111111.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.Comments) : "");
                    NewField111111111.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.IsMissing) : "");
                    NewField1111111111.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.IsChanged) : "");
                    NewField1111111112.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.IsDamaged) : "");
                    NewField1111111113.CalcValue = (dataset_GetRepairItemEquipmentOfCompletedRepair != null ? Globals.ToStringCore(dataset_GetRepairItemEquipmentOfCompletedRepair.IsNormal) : "");
                    return new TTReportObject[] { NewField10,NewField11111111,NewField1211111111,NewField111111111,NewField1111111111,NewField1111111112,NewField1111111113};
                }
            }

        }

        public CIHAZLAGELENMUHTEVIYATCGroup CIHAZLAGELENMUHTEVIYATC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CompletedRepairReport()
        {
            ANA = new ANAGroup(this,"ANA");
            Notlar = new NotlarGroup(ANA,"Notlar");
            KULLANILANMALZEMEC = new KULLANILANMALZEMECGroup(ANA,"KULLANILANMALZEMEC");
            KULLANILANMALZEME = new KULLANILANMALZEMEGroup(KULLANILANMALZEMEC,"KULLANILANMALZEME");
            CIHAZLAGELENMUHTEVIYAT = new CIHAZLAGELENMUHTEVIYATGroup(ANA,"CIHAZLAGELENMUHTEVIYAT");
            CIHAZLAGELENMUHTEVIYATC = new CIHAZLAGELENMUHTEVIYATCGroup(CIHAZLAGELENMUHTEVIYAT,"CIHAZLAGELENMUHTEVIYATC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Onarım", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COMPLETEDREPAIRREPORT";
            Caption = "Tamamlanan Onarım";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginTop = 10;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}