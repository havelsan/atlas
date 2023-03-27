
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
    /// Hasar ve Durum Tespit Raporu (Ek-4.5)
    /// </summary>
    public partial class HasarveDurumTespitRaporu_1 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HasarveDurumTespitRaporu_1 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_1)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField115 { get {return Body().NewField115;} }
            public TTReportField EKSIKMALZEMELER { get {return Body().EKSIKMALZEMELER;} }
            public TTReportField DEGISIKMALZEMELER { get {return Body().DEGISIKMALZEMELER;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField HASARLIMALZEMELER { get {return Body().HASARLIMALZEMELER;} }
            public TTReportField NewField164 { get {return Body().NewField164;} }
            public TTReportField NewField127 { get {return Body().NewField127;} }
            public TTReportField NewField156 { get {return Body().NewField156;} }
            public TTReportField NewField174 { get {return Body().NewField174;} }
            public TTReportField NewField137 { get {return Body().NewField137;} }
            public TTReportField NewField166 { get {return Body().NewField166;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField1461 { get {return Body().NewField1461;} }
            public TTReportField NewField1721 { get {return Body().NewField1721;} }
            public TTReportField NewField1651 { get {return Body().NewField1651;} }
            public TTReportField NewField1471 { get {return Body().NewField1471;} }
            public TTReportField NewField1731 { get {return Body().NewField1731;} }
            public TTReportField NewField1661 { get {return Body().NewField1661;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField MARKMODELSERIALNO { get {return Body().MARKMODELSERIALNO;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HasarveDurumTespitRaporu_1 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_1)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField111;
                public TTReportField NewField101;
                public TTReportField NewField19;
                public TTReportField NewField18;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField151;
                public TTReportField NewField115;
                public TTReportField EKSIKMALZEMELER;
                public TTReportField DEGISIKMALZEMELER;
                public TTReportField NewField125;
                public TTReportField HASARLIMALZEMELER;
                public TTReportField NewField164;
                public TTReportField NewField127;
                public TTReportField NewField156;
                public TTReportField NewField174;
                public TTReportField NewField137;
                public TTReportField NewField166;
                public TTReportField NewField112;
                public TTReportField NewField1461;
                public TTReportField NewField1721;
                public TTReportField NewField1651;
                public TTReportField NewField1471;
                public TTReportField NewField1731;
                public TTReportField NewField1661;
                public TTReportField MATERIALNAME;
                public TTReportField MILITARYUNIT;
                public TTReportField MARKMODELSERIALNO;
                public TTReportField NATOSTOCKNO;
                public TTReportField ORDERNO;
                public TTReportField REPORTDATE;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField SERIALNO;
                public TTReportField REQUESTNO;
                public TTReportField NewField13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 41, 195, 49, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 10;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @" İş İstek ve İş Emri Belgesi :";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 33, 195, 41, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @" Gönderen Birlik :";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 49, 105, 59, false);
                    NewField101.Name = "NewField101";
                    NewField101.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField101.TextFont.Size = 10;
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @" NATO Stok Nu. :";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 49, 68, 59, false);
                    NewField19.Name = "NewField19";
                    NewField19.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField19.TextFont.Size = 10;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @" Marka/Model/Seri Nu. :";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 33, 105, 49, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 10;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @" Malzeme :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 10, 120, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"HİZMETE ÖZEL";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 21, 155, 27, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"HASAR VE DURUM TESPİT RAPORU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 49, 152, 59, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @" Sipariş Nu. :";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 59, 105, 65, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.TextFont.Size = 10;
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @"Eksik Malzemeler";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 59, 195, 65, false);
                    NewField115.Name = "NewField115";
                    NewField115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115.TextFont.Size = 10;
                    NewField115.TextFont.Bold = true;
                    NewField115.Value = @"Değişik Malzemeler";

                    EKSIKMALZEMELER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 65, 105, 104, false);
                    EKSIKMALZEMELER.Name = "EKSIKMALZEMELER";
                    EKSIKMALZEMELER.TextFont.Size = 10;
                    EKSIKMALZEMELER.TextFont.Bold = true;
                    EKSIKMALZEMELER.Value = @"";

                    DEGISIKMALZEMELER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 65, 195, 104, false);
                    DEGISIKMALZEMELER.Name = "DEGISIKMALZEMELER";
                    DEGISIKMALZEMELER.TextFont.Size = 10;
                    DEGISIKMALZEMELER.TextFont.Bold = true;
                    DEGISIKMALZEMELER.Value = @"";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 104, 195, 110, false);
                    NewField125.Name = "NewField125";
                    NewField125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125.TextFont.Size = 10;
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @"Hasarlı Malzemeler ve Görülen Arızalar";

                    HASARLIMALZEMELER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 110, 195, 150, false);
                    HASARLIMALZEMELER.Name = "HASARLIMALZEMELER";
                    HASARLIMALZEMELER.TextFont.Size = 10;
                    HASARLIMALZEMELER.TextFont.Bold = true;
                    HASARLIMALZEMELER.Value = @"";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 150, 69, 160, false);
                    NewField164.Name = "NewField164";
                    NewField164.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField164.TextFont.Size = 10;
                    NewField164.TextFont.Bold = true;
                    NewField164.Value = @"Üye";

                    NewField127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 150, 123, 160, false);
                    NewField127.Name = "NewField127";
                    NewField127.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField127.TextFont.Size = 10;
                    NewField127.TextFont.Bold = true;
                    NewField127.Value = @"Üye";

                    NewField156 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 150, 195, 160, false);
                    NewField156.Name = "NewField156";
                    NewField156.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField156.TextFont.Size = 10;
                    NewField156.TextFont.Bold = true;
                    NewField156.Value = @"Kalite Güvence Müdürlüğü İlgili Personeli";

                    NewField174 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 160, 69, 175, false);
                    NewField174.Name = "NewField174";
                    NewField174.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField174.TextFont.Size = 10;
                    NewField174.TextFont.Bold = true;
                    NewField174.Value = @"";

                    NewField137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 160, 123, 175, false);
                    NewField137.Name = "NewField137";
                    NewField137.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField137.TextFont.Size = 10;
                    NewField137.TextFont.Bold = true;
                    NewField137.Value = @"";

                    NewField166 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 160, 195, 175, false);
                    NewField166.Name = "NewField166";
                    NewField166.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField166.TextFont.Size = 10;
                    NewField166.TextFont.Bold = true;
                    NewField166.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 49, 195, 59, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Size = 10;
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @" Rapor Tarihi :";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 175, 69, 190, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1461.TextFont.Size = 10;
                    NewField1461.TextFont.Bold = true;
                    NewField1461.Value = @"";

                    NewField1721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 175, 123, 190, false);
                    NewField1721.Name = "NewField1721";
                    NewField1721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1721.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1721.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1721.TextFont.Size = 10;
                    NewField1721.TextFont.Bold = true;
                    NewField1721.Value = @"";

                    NewField1651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 175, 195, 190, false);
                    NewField1651.Name = "NewField1651";
                    NewField1651.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1651.TextFont.Size = 10;
                    NewField1651.TextFont.Bold = true;
                    NewField1651.Value = @"";

                    NewField1471 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 190, 69, 205, false);
                    NewField1471.Name = "NewField1471";
                    NewField1471.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1471.TextFont.Size = 10;
                    NewField1471.TextFont.Bold = true;
                    NewField1471.Value = @"";

                    NewField1731 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 190, 123, 205, false);
                    NewField1731.Name = "NewField1731";
                    NewField1731.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1731.TextFont.Size = 10;
                    NewField1731.TextFont.Bold = true;
                    NewField1731.Value = @"";

                    NewField1661 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 190, 195, 205, false);
                    NewField1661.Name = "NewField1661";
                    NewField1661.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1661.TextFont.Size = 10;
                    NewField1661.TextFont.Bold = true;
                    NewField1661.Value = @"";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 34, 104, 48, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbInvisible;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.Value = @"{#FIXEDASSETNAME#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 34, 194, 40, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbInvisible;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.TextFont.Size = 10;
                    MILITARYUNIT.Value = @"{#ACCOUNTANCYMILITARYUNIT#}";

                    MARKMODELSERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 53, 67, 58, false);
                    MARKMODELSERIALNO.Name = "MARKMODELSERIALNO";
                    MARKMODELSERIALNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    MARKMODELSERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODELSERIALNO.TextFont.Size = 10;
                    MARKMODELSERIALNO.Value = @"";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 53, 104, 58, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 51, 151, 57, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Size = 10;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 51, 194, 57, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.TextFont.Size = 10;
                    REPORTDATE.Value = @"{@printdate@}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 25, 249, 30, false);
                    MARK.Name = "MARK";
                    MARK.Visible = EvetHayirEnum.ehHayir;
                    MARK.DrawStyle = DrawStyleConstants.vbInvisible;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.VertAlign = VerticalAlignmentEnum.vaTop;
                    MARK.TextFont.Name = "Arial Narrow";
                    MARK.TextFont.Size = 10;
                    MARK.TextFont.CharSet = 1;
                    MARK.Value = @"{#MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 34, 249, 39, false);
                    MODEL.Name = "MODEL";
                    MODEL.Visible = EvetHayirEnum.ehHayir;
                    MODEL.DrawStyle = DrawStyleConstants.vbInvisible;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.VertAlign = VerticalAlignmentEnum.vaTop;
                    MODEL.TextFont.Name = "Arial Narrow";
                    MODEL.TextFont.Size = 10;
                    MODEL.TextFont.CharSet = 1;
                    MODEL.Value = @"{#MODEL#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 43, 249, 48, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.Visible = EvetHayirEnum.ehHayir;
                    SERIALNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaTop;
                    SERIALNO.TextFont.Name = "Arial Narrow";
                    SERIALNO.TextFont.Size = 10;
                    SERIALNO.TextFont.CharSet = 1;
                    SERIALNO.Value = @"{#SERIALNUMBER#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 42, 193, 48, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 279, 120, 284, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField115.CalcValue = NewField115.Value;
                    EKSIKMALZEMELER.CalcValue = EKSIKMALZEMELER.Value;
                    DEGISIKMALZEMELER.CalcValue = DEGISIKMALZEMELER.Value;
                    NewField125.CalcValue = NewField125.Value;
                    HASARLIMALZEMELER.CalcValue = HASARLIMALZEMELER.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField127.CalcValue = NewField127.Value;
                    NewField156.CalcValue = NewField156.Value;
                    NewField174.CalcValue = NewField174.Value;
                    NewField137.CalcValue = NewField137.Value;
                    NewField166.CalcValue = NewField166.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField1721.CalcValue = NewField1721.Value;
                    NewField1651.CalcValue = NewField1651.Value;
                    NewField1471.CalcValue = NewField1471.Value;
                    NewField1731.CalcValue = NewField1731.Value;
                    NewField1661.CalcValue = NewField1661.Value;
                    MATERIALNAME.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Accountancymilitaryunit) : "");
                    MARKMODELSERIALNO.CalcValue = @"";
                    NATOSTOCKNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    ORDERNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    REPORTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    MARK.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "");
                    MODEL.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "");
                    SERIALNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    REQUESTNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "");
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField121,NewField111,NewField101,NewField19,NewField18,NewField1,NewField12,NewField11,NewField151,NewField115,EKSIKMALZEMELER,DEGISIKMALZEMELER,NewField125,HASARLIMALZEMELER,NewField164,NewField127,NewField156,NewField174,NewField137,NewField166,NewField112,NewField1461,NewField1721,NewField1651,NewField1471,NewField1731,NewField1661,MATERIALNAME,MILITARYUNIT,MARKMODELSERIALNO,NATOSTOCKNO,ORDERNO,REPORTDATE,MARK,MODEL,SERIALNO,REQUESTNO,NewField13};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(MARK.CalcValue == "")
                MARK.CalcValue = "---";
            
            if(MODEL.CalcValue == "")
                MODEL.CalcValue = "---";
            
            if(SERIALNO.CalcValue == "")
                SERIALNO.CalcValue = "---";
            
            MARKMODELSERIALNO.CalcValue = MARK.CalcValue + "/" + MODEL.CalcValue + "/" + SERIALNO.CalcValue;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HasarveDurumTespitRaporu_1()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HASARVEDURUMTESPITRAPORU_1";
            Caption = "Hasar ve Durum Tespit Raporu (Ek-4.5)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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