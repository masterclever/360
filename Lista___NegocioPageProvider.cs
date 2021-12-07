using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class Lista___NegocioPageProvider : GeneralProvider
	{
		public VIEW_LISTANEGOCIODataListDataProvider DataList1DataListProvider;
		public _25246FASTRAX_TB_FASEDataProvider PAR_FASE1Provider;
		public _25246FASTRAX_TB_FASEDataProvider PAR_FASE2Provider;
		public _25246FASTRAX_TB_FASEDataProvider PAR_FASE3Provider;
		public _25246FASTRAX_TB_FASEDataProvider PAR_FASE4Provider;
		public _25246FASTRAX_TB_FASEDataProvider PAR_FASE5Provider;
		public List<RadComboBoxDataItem> CBFiltroStatusItems
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "Concluído"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "Em andamento"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem3").ToString(), "Perdido"),
				};
			}
		}
		public List<RadComboBoxDataItem> CBFiltroTipoNegItems
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "LICITACIONPUBLICANACIONAL").ToString(), "1"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "LICITACIONPRIVADA").ToString(), "2"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "PRESUPUESTONORMAL").ToString(), "3"),
				};
			}
		}
		
		public List<RadComboBoxDataItem> CBFiltroVisitasItems
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "Si").ToString(), "Si"),
				};
			}
		}
		

		public Lista___NegocioPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_TB_PARAMETRODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "", "Lista___Negocio");
			MainProvider.DataProvider.PageProvider = this;
			PAR_FASE1Provider = new _25246FASTRAX_TB_FASEDataProvider(MainProvider, "TB_FASE", "25246FASTRAX", "PK_FASE", "PAR_FASE1");
			PAR_FASE2Provider = new _25246FASTRAX_TB_FASEDataProvider(MainProvider, "TB_FASE", "25246FASTRAX", "PK_FASE", "PAR_FASE2");
			PAR_FASE3Provider = new _25246FASTRAX_TB_FASEDataProvider(MainProvider, "TB_FASE", "25246FASTRAX", "PK_FASE", "PAR_FASE3");
			PAR_FASE4Provider = new _25246FASTRAX_TB_FASEDataProvider(MainProvider, "TB_FASE", "25246FASTRAX", "PK_FASE", "PAR_FASE4");
			PAR_FASE5Provider = new _25246FASTRAX_TB_FASEDataProvider(MainProvider, "TB_FASE", "25246FASTRAX", "PK_FASE", "PAR_FASE5");
			DataList1DataListProvider = new VIEW_LISTANEGOCIODataListDataProvider(this);
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_TB_PARAMETROItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "PAR_FASE1")
			{
				return new _25246FASTRAX_TB_FASEItem("25246FASTRAX");
			}
			else if (Provider.Name == "PAR_FASE2")
			{
				return new _25246FASTRAX_TB_FASEItem("25246FASTRAX");
			}
			else if (Provider.Name == "PAR_FASE3")
			{
				return new _25246FASTRAX_TB_FASEItem("25246FASTRAX");
			}
			else if (Provider.Name == "PAR_FASE4")
			{
				return new _25246FASTRAX_TB_FASEItem("25246FASTRAX");
			}
			else if (Provider.Name == "PAR_FASE5")
			{
				return new _25246FASTRAX_TB_FASEItem("25246FASTRAX");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(PAR_FASE1Provider);
			PAR_FASE1Provider.Dao = MainProvider.DataProvider.Dao;
			PAR_FASE1Provider.SelectItem(1, FormPositioningEnum.First,true);
			MainProvider.SetParametersValues(PAR_FASE2Provider);
			PAR_FASE2Provider.Dao = MainProvider.DataProvider.Dao;
			PAR_FASE2Provider.SelectItem(1, FormPositioningEnum.First,true);
			MainProvider.SetParametersValues(PAR_FASE3Provider);
			PAR_FASE3Provider.Dao = MainProvider.DataProvider.Dao;
			PAR_FASE3Provider.SelectItem(1, FormPositioningEnum.First,true);
			MainProvider.SetParametersValues(PAR_FASE4Provider);
			PAR_FASE4Provider.Dao = MainProvider.DataProvider.Dao;
			PAR_FASE4Provider.SelectItem(1, FormPositioningEnum.First,true);
			MainProvider.SetParametersValues(PAR_FASE5Provider);
			PAR_FASE5Provider.Dao = MainProvider.DataProvider.Dao;
			PAR_FASE5Provider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		
		public override void GetTableIdentity()
		{
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void ExecuteSingleProcess(string ProcessName)
        {
            CreateProcess(ProcessName, false);
            List<Process> ProcList = new List<Process>(Process.Values);
            if (ProcList.Count > 0)
                DataProcessEntry.ExecuteProcess(ProcList, MainProvider.DataProvider.Dao);
        }
		
		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
		}

		public override void CreateReverseProcess(int Pos , string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			object ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}
		
		public DataRow CBFiltroCliente_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_ID") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBFiltroCliente(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields =  Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("CLI_NOME") + " Asc", false, "");
		}
		
		public DataRow CBFiltroStatus_GetComboItem(string Value)
		{
			try
			{
				return CBFiltroStatusItems.Find(i => i.Value == Value).ToDataRow();
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBFiltroStatus(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, CBFiltroStatusItems.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, CBFiltroStatusItems);
		}
		
		public DataRow CBUser_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_LOGIN") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBUser(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_LOGIN");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_LOGIN", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("LOGIN_USER_LOGIN") + " Asc", false, "");
		}
		
		public DataRow CBFiltroTipoNeg_GetComboItem(string Value)
		{
			try
			{
				return CBFiltroTipoNegItems.Find(i => i.Value == Value).ToDataRow();
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBFiltroTipoNeg(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, CBFiltroTipoNegItems.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, CBFiltroTipoNegItems);
		}
		
		public DataRow CBFiltroVisitas_GetComboItem(string Value)
		{
			try
			{
				return CBFiltroVisitasItems.Find(i => i.Value == Value).ToDataRow();
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBFiltroVisitas(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, CBFiltroVisitasItems.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, CBFiltroVisitasItems);
		}
		
		public DataRow CBNegId_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("NEG_ID") + " as varchar) " +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("NEG_ID") + " FROM  " + Dao.PoeColAspas("TB_NEGOCIO") + " WHERE " + Dao.PoeColAspas("NEG_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBNegId(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields = "cast(" + Dao.PoeColAspas("NEG_ID") + " as varchar) ";
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_NEGOCIO", DisplayFields, "NEG_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow CBLinea_Producto_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LIN_DESCRIPCION") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LIN_ID") + " FROM  " + Dao.PoeColAspas("TB_LINEA_PRODUTO") + " WHERE " + Dao.PoeColAspas("LIN_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBLinea_Producto(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields =  Dao.PoeColAspas("LIN_DESCRIPCION");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LINEA_PRODUTO", DisplayFields, "LIN_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("LIN_DESCRIPCION") + " Asc", false, "");
		}


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do DataList
	/// </summary>
	public class VIEW_LISTANEGOCIODataListDataProvider : GeneralListControlProvider
	{
		public long NEG_IDField;
		public string NEG_TITULOField;
		public long CLI_IDField;
		public string CLI_NOMEField;
		public long FASE_IDField;
		public string FASE_NOMEField;
		public long PROD_IDField;
		public string PROD_NOMEField;
		public string NEG_STATUSField;
		public long NEG_VALORTOTALField;
		public string CLI_CONTATOField;
		public long NEG_VALORULTField;
		public string NEG_RESPONSAVELField;
		public DateTime NEG_DATAINICIALField;
		public DateTime NEG_DATACONCLUSAOField;
		public string NEG_TIPOField;
		public string PROD_EDSField;
		public long LOJACORField;

		#region GeneralDataListProvider Members

		private _25246FASTRAX_VIEW_LISTANEGOCIODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _25246FASTRAX_VIEW_LISTANEGOCIODataProvider;
			}
		}

		public Lista___NegocioPageProvider ParentPageProvider;
		
		public override string TableName { get { return "VIEW_LISTANEGOCIO"; } }

		public override string DatabaseName { get { return "25246FASTRAX"; } }

		public override string FormID { get { return "28711"; } }
		
		/// <summary>
		/// Valida se todos os campos do DataList foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public VIEW_LISTANEGOCIODataListDataProvider(Lista___NegocioPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _25246FASTRAX_VIEW_LISTANEGOCIODataProvider(this, TableName, DatabaseName, "", "VIEW_LISTANEGOCIO");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}

		public _25246FASTRAX_VIEW_LISTANEGOCIOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _25246FASTRAX_VIEW_LISTANEGOCIOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "VIEW_LISTANEGOCIO")
			{
				return new _25246FASTRAX_VIEW_LISTANEGOCIOItem(DatabaseName);
			}
			return null;
		}
		
		public override void SetParametersValues(GeneralDataProvider Provider)
        {
            try
            {
            }
            catch
            {
            }
        }

		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
		    if (AliasVariables == null)
            {
                AliasVariables = new Dictionary<string, object>();
            }

			NEG_IDField = Convert.ToInt64(Item["NEG_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_IDField"))
			{
				AliasVariables["NEG_IDField"] = NEG_IDField;
			}
			else
			{
				AliasVariables.Add("NEG_IDField" ,NEG_IDField);
			}
			NEG_TITULOField = Convert.ToString(Item["NEG_TITULO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_TITULOField"))
			{
				AliasVariables["NEG_TITULOField"] = NEG_TITULOField;
			}
			else
			{
				AliasVariables.Add("NEG_TITULOField" ,NEG_TITULOField);
			}
			CLI_IDField = Convert.ToInt64(Item["CLI_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_IDField"))
			{
				AliasVariables["CLI_IDField"] = CLI_IDField;
			}
			else
			{
				AliasVariables.Add("CLI_IDField" ,CLI_IDField);
			}
			CLI_NOMEField = Convert.ToString(Item["CLI_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_NOMEField"))
			{
				AliasVariables["CLI_NOMEField"] = CLI_NOMEField;
			}
			else
			{
				AliasVariables.Add("CLI_NOMEField" ,CLI_NOMEField);
			}
			FASE_IDField = Convert.ToInt64(Item["FASE_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FASE_IDField"))
			{
				AliasVariables["FASE_IDField"] = FASE_IDField;
			}
			else
			{
				AliasVariables.Add("FASE_IDField" ,FASE_IDField);
			}
			FASE_NOMEField = Convert.ToString(Item["FASE_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FASE_NOMEField"))
			{
				AliasVariables["FASE_NOMEField"] = FASE_NOMEField;
			}
			else
			{
				AliasVariables.Add("FASE_NOMEField" ,FASE_NOMEField);
			}
			PROD_IDField = Convert.ToInt64(Item["PROD_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_IDField"))
			{
				AliasVariables["PROD_IDField"] = PROD_IDField;
			}
			else
			{
				AliasVariables.Add("PROD_IDField" ,PROD_IDField);
			}
			PROD_NOMEField = Convert.ToString(Item["PROD_NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_NOMEField"))
			{
				AliasVariables["PROD_NOMEField"] = PROD_NOMEField;
			}
			else
			{
				AliasVariables.Add("PROD_NOMEField" ,PROD_NOMEField);
			}
			NEG_STATUSField = Convert.ToString(Item["NEG_STATUS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_STATUSField"))
			{
				AliasVariables["NEG_STATUSField"] = NEG_STATUSField;
			}
			else
			{
				AliasVariables.Add("NEG_STATUSField" ,NEG_STATUSField);
			}
			NEG_VALORTOTALField = Convert.ToInt64(Item["NEG_VALORTOTAL"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_VALORTOTALField"))
			{
				AliasVariables["NEG_VALORTOTALField"] = NEG_VALORTOTALField;
			}
			else
			{
				AliasVariables.Add("NEG_VALORTOTALField" ,NEG_VALORTOTALField);
			}
			CLI_CONTATOField = Convert.ToString(Item["CLI_CONTATO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CONTATOField"))
			{
				AliasVariables["CLI_CONTATOField"] = CLI_CONTATOField;
			}
			else
			{
				AliasVariables.Add("CLI_CONTATOField" ,CLI_CONTATOField);
			}
			NEG_VALORULTField = Convert.ToInt64(Item["NEG_VALORULT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_VALORULTField"))
			{
				AliasVariables["NEG_VALORULTField"] = NEG_VALORULTField;
			}
			else
			{
				AliasVariables.Add("NEG_VALORULTField" ,NEG_VALORULTField);
			}
			NEG_RESPONSAVELField = Convert.ToString(Item["NEG_RESPONSAVEL"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_RESPONSAVELField"))
			{
				AliasVariables["NEG_RESPONSAVELField"] = NEG_RESPONSAVELField;
			}
			else
			{
				AliasVariables.Add("NEG_RESPONSAVELField" ,NEG_RESPONSAVELField);
			}
			NEG_DATAINICIALField = Convert.ToDateTime(Item["NEG_DATAINICIAL"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_DATAINICIALField"))
			{
				AliasVariables["NEG_DATAINICIALField"] = NEG_DATAINICIALField;
			}
			else
			{
				AliasVariables.Add("NEG_DATAINICIALField" ,NEG_DATAINICIALField);
			}
			NEG_DATACONCLUSAOField = Convert.ToDateTime(Item["NEG_DATACONCLUSAO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_DATACONCLUSAOField"))
			{
				AliasVariables["NEG_DATACONCLUSAOField"] = NEG_DATACONCLUSAOField;
			}
			else
			{
				AliasVariables.Add("NEG_DATACONCLUSAOField" ,NEG_DATACONCLUSAOField);
			}
			NEG_TIPOField = Convert.ToString(Item["NEG_TIPO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NEG_TIPOField"))
			{
				AliasVariables["NEG_TIPOField"] = NEG_TIPOField;
			}
			else
			{
				AliasVariables.Add("NEG_TIPOField" ,NEG_TIPOField);
			}
			PROD_EDSField = Convert.ToString(Item["PROD_EDS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_EDSField"))
			{
				AliasVariables["PROD_EDSField"] = PROD_EDSField;
			}
			else
			{
				AliasVariables.Add("PROD_EDSField" ,PROD_EDSField);
			}
			LOJACORField = Convert.ToInt64(Item["LOJACOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOJACORField"))
			{
				AliasVariables["LOJACORField"] = LOJACORField;
			}
			else
			{
				AliasVariables.Add("LOJACORField" ,LOJACORField);
			}
		}
		
		public override void GetTableIdentity()
		{
		}


	public partial class TB_NEGOCIO_LINEADataListDataProvider : System.Web.UI.Page{
		}

}
	}

}
