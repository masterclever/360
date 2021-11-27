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
	public class DashBoard_CorporativoPageProvider : GeneralProvider
	{
		public DashBoard_Corporativo_Grid2GridDataProvider DashBoard_Corporativo_Grid2Provider;
		public DashBoard_Corporativo_Grid3GridDataProvider DashBoard_Corporativo_Grid3Provider;
		public Grid5GridDataProvider Grid5Provider;
		public DashBoard_Corporativo_Grid4GridDataProvider DashBoard_Corporativo_Grid4Provider;
		public DashBoard_Corporativo_Grid6GridDataProvider DashBoard_Corporativo_Grid6Provider;
		public DashBoard_Corporativo_Grid7GridDataProvider DashBoard_Corporativo_Grid7Provider;
		public DashBoard_Corporativo_Grid8GridDataProvider DashBoard_Corporativo_Grid8Provider;
		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		public List<RadComboBoxDataItem> Grid3_GridColumn104Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem4").ToString(), "0"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem5").ToString(), "99"),
				};
			}
		}
		public List<RadComboBoxDataItem> Grid6_GridColumn116Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem6").ToString(), "0"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem7").ToString(), "99"),
				};
			}
		}
		

		public DashBoard_CorporativoPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _BD_DADOS_TB_PARAMETRODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "", "DashBoard_Corporativo");
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "AUX_DashBoard_Corporativo_TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "AUX_DashBoard_Corporativo_TB_TAREFA");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "AUX_DashBoard_Corporativo_VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "AUX_DashBoard_Corporativo_TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "AUX_DashBoard_Corporativo_TB_ASISTENCIA");
			DashBoard_Corporativo_Grid2Provider = new DashBoard_Corporativo_Grid2GridDataProvider(this);
			DashBoard_Corporativo_Grid2Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(DashBoard_Corporativo_Grid2Provider_SetRelationFields);
			DashBoard_Corporativo_Grid3Provider = new DashBoard_Corporativo_Grid3GridDataProvider(this);
			DashBoard_Corporativo_Grid3Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(DashBoard_Corporativo_Grid3Provider_SetRelationFields);
			Grid5Provider = new Grid5GridDataProvider(this);
			Grid5Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Grid5Provider_SetRelationFields);
			DashBoard_Corporativo_Grid4Provider = new DashBoard_Corporativo_Grid4GridDataProvider(this);
			DashBoard_Corporativo_Grid4Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(DashBoard_Corporativo_Grid4Provider_SetRelationFields);
			DashBoard_Corporativo_Grid6Provider = new DashBoard_Corporativo_Grid6GridDataProvider(this);
			DashBoard_Corporativo_Grid6Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(DashBoard_Corporativo_Grid6Provider_SetRelationFields);
			DashBoard_Corporativo_Grid7Provider = new DashBoard_Corporativo_Grid7GridDataProvider(this);
			DashBoard_Corporativo_Grid7Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(DashBoard_Corporativo_Grid7Provider_SetRelationFields);
			DashBoard_Corporativo_Grid8Provider = new DashBoard_Corporativo_Grid8GridDataProvider(this);
			DashBoard_Corporativo_Grid8Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(DashBoard_Corporativo_Grid8Provider_SetRelationFields);
		}


		private void DashBoard_Corporativo_Grid2Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				DashBoard_Corporativo_Grid2Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}

		private void DashBoard_Corporativo_Grid3Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				DashBoard_Corporativo_Grid3Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}

		private void Grid5Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Grid5Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}

		private void DashBoard_Corporativo_Grid4Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				DashBoard_Corporativo_Grid4Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}

		private void DashBoard_Corporativo_Grid6Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				DashBoard_Corporativo_Grid6Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}

		private void DashBoard_Corporativo_Grid7Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				DashBoard_Corporativo_Grid7Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}

		private void DashBoard_Corporativo_Grid8Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				DashBoard_Corporativo_Grid8Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _BD_DADOS_TB_PARAMETROItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "AUX_DashBoard_Corporativo_TB_NEGOCIO")
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider.Name == "AUX_DashBoard_Corporativo_TB_TAREFA")
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider.Name == "AUX_DashBoard_Corporativo_VIEW_TAREFAS")
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider.Name == "AUX_DashBoard_Corporativo_TB_VENDAS")
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider.Name == "AUX_DashBoard_Corporativo_TB_ASISTENCIA")
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First,false);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First,false);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First,true);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First,true);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First,true);
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
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '_' + " + Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
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
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '_' + " + Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("CLI_NOME") + " Asc", false, "");
		}
		
		public DataRow CBLinea_Producto_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + FiltroLineaProducto();
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LIN_DESCRIPCION") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LIN_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_LINEA_PRODUTO") + " WHERE " + Dao.PoeColAspas("LIN_CODFASTRAX") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
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
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string CboFilter = "";
			try
			{
				CboFilter = FiltroLineaProducto();
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("LIN_DESCRIPCION");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LINEA_PRODUTO", DisplayFields, "LIN_CODFASTRAX", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow CBFiltroProduto_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("PROD_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillCBFiltroProduto(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields = "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("PROD_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_PRODUTO", DisplayFields, "PROD_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("PROD_NOME") + " Asc", false, "");
		}
		
		public DataRow ComboBox1_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + Dao.PoeColAspas("LOGIN_GROUP_NAME") + " = " + Dao.ToSql("VENDEDOR", FieldType.Text);
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_NAME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox1(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string CboFilter = "";
			try
			{
				CboFilter = Dao.PoeColAspas("LOGIN_GROUP_NAME") + " = " + Dao.ToSql("VENDEDOR", FieldType.Text);
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_NAME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_LOGIN", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		public DataRow Grid2_GridColumn133_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid2_GridColumn133_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid3_GridColumn105_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid3_GridColumn105_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid3_GridColumn131_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("PROD_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid3_GridColumn131_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("PROD_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_PRODUTO", DisplayFields, "PROD_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid3_GridColumn104_ComboBox_GetComboItem(string Value)
		{
			try
			{
				return Grid3_GridColumn104Items.Find(i => i.Value == Value).ToDataRow();
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid3_GridColumn104_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, Grid3_GridColumn104Items.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, Grid3_GridColumn104Items);
		}
		
		public DataRow Grid6_GridColumn116_ComboBox_GetComboItem(string Value)
		{
			try
			{
				return Grid6_GridColumn116Items.Find(i => i.Value == Value).ToDataRow();
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid6_GridColumn116_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, Grid6_GridColumn116Items.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, Grid6_GridColumn116Items);
		}
		
		public DataRow Grid6_GridColumn117_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid6_GridColumn117_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid6_GridColumn132_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("PROD_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid6_GridColumn132_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("PROD_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_PRODUTO", DisplayFields, "PROD_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid7_GridColumn128_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("NOMELONG") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("NOMELONG") + " FROM  " + Dao.PoeColAspas("VW_COMPRA_PREVISAO") + " WHERE " + Dao.PoeColAspas("NOMELONG") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid7_GridColumn128_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("NOMELONG");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "VW_COMPRA_PREVISAO", DisplayFields, "NOMELONG", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid8_GridColumn135_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("PROD_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_NOME") + " FROM  " + Dao.PoeColAspas("TEMPO_ESTOQUE") + " WHERE " + Dao.PoeColAspas("PROD_NOME") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid8_GridColumn135_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("PROD_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TEMPO_ESTOQUE", DisplayFields, "PROD_NOME", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}


		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			DataTable dt;
			string Select = "";
			DataAccessObject Dao;
			string CboFilter = "";
			switch (GridColumnId)
			{
				case "Grid2_GridColumn133":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") + " FROM " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid3_GridColumn105":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") + " FROM " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid3_GridColumn131":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("PROD_NOME") + " FROM " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid3_GridColumn104":
					RadComboBoxDataItem Grid3_GridColumn104Item = Utility.FindComboBoxItem(Grid3_GridColumn104Items, FieldId);
					if (Grid3_GridColumn104Item != null) return Grid3_GridColumn104Item.Text;
					return "";
				case "Grid6_GridColumn116":
					RadComboBoxDataItem Grid6_GridColumn116Item = Utility.FindComboBoxItem(Grid6_GridColumn116Items, FieldId);
					if (Grid6_GridColumn116Item != null) return Grid6_GridColumn116Item.Text;
					return "";
				case "Grid6_GridColumn117":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") + " FROM " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid6_GridColumn132":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("PROD_NOME") + " FROM " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_CODFASTRAX") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid7_GridColumn128":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("NOMELONG") + " FROM " + Dao.PoeColAspas("VW_COMPRA_PREVISAO") + " WHERE " + Dao.PoeColAspas("NOMELONG") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid8_GridColumn135":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("PROD_NOME") + " FROM " + Dao.PoeColAspas("TEMPO_ESTOQUE") + " WHERE " + Dao.PoeColAspas("PROD_NOME") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				default:
					return "";
			}
		}
		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		
		private string FiltroLineaProducto()
		{
    		string filtro = " 1 = 1 ";
			string sSql = string.Empty;
			sSql = string.Format("SELECT LOGIN_USER_PM FROM TB_LOGIN_USER WHERE LOGIN_USER_LOGIN = '{0}'", EnvironmentVariable.LoggedLoginUser);

			DataAccessObject dao = ((GeneralDataPage)this.MainProvider).Dao;
			DataSet ds = dao.RunSql(sSql);
			string pm = ds.Tables[0].Rows[0]["LOGIN_USER_PM"].ToString();

			if (pm != "0" )
            {
                filtro += " AND LIN_PM = " + pm;
            }
            return filtro;		
		}

	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class DashBoard_Corporativo_Grid2GridDataProvider : GeneralGridProvider
	{
		public string TAR_TIPOField;
		public string TAR_DESCField;
		public long CLI_CODFASTRAXField;
		public string TAR_RESPONSAVELField;
		public DateTime TAR_DATAHORAField;
		public long LOJACORField;
		public long TAR_IDField;
		public long NEG_IDField;
		public long CLI_IDField;
		public bool TAR_FINALIZADOField;
		public string TAR_CRIADORField;
		public DateTime TAR_DATAHORA_FIMField;
		public string TAR_GER_RESPONSABLEField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_TB_TAREFADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_TB_TAREFADataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "TB_TAREFA"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public DashBoard_Corporativo_Grid2GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_TB_TAREFADataProvider(this, TableName, DatabaseName, "PK_TB_TAREFA", "DashBoard_Corporativo_Grid2");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_TB_TAREFAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_TB_TAREFAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "DashBoard_Corporativo_Grid2")
			{
				return new _BD_DADOS_TB_TAREFAItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			TAR_TIPOField = Convert.ToString(Item["TAR_TIPO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_TIPOField"))
			{
				AliasVariables["TAR_TIPOField"] = TAR_TIPOField;
			}
			else
			{
				AliasVariables.Add("TAR_TIPOField" ,TAR_TIPOField);
			}
			TAR_DESCField = Convert.ToString(Item["TAR_DESC"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_DESCField"))
			{
				AliasVariables["TAR_DESCField"] = TAR_DESCField;
			}
			else
			{
				AliasVariables.Add("TAR_DESCField" ,TAR_DESCField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			TAR_RESPONSAVELField = Convert.ToString(Item["TAR_RESPONSAVEL"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_RESPONSAVELField"))
			{
				AliasVariables["TAR_RESPONSAVELField"] = TAR_RESPONSAVELField;
			}
			else
			{
				AliasVariables.Add("TAR_RESPONSAVELField" ,TAR_RESPONSAVELField);
			}
			TAR_DATAHORAField = Convert.ToDateTime(Item["TAR_DATAHORA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_DATAHORAField"))
			{
				AliasVariables["TAR_DATAHORAField"] = TAR_DATAHORAField;
			}
			else
			{
				AliasVariables.Add("TAR_DATAHORAField" ,TAR_DATAHORAField);
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
			TAR_IDField = Convert.ToInt64(Item["TAR_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_IDField"))
			{
				AliasVariables["TAR_IDField"] = TAR_IDField;
			}
			else
			{
				AliasVariables.Add("TAR_IDField" ,TAR_IDField);
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
			CLI_IDField = Convert.ToInt64(Item["CLI_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_IDField"))
			{
				AliasVariables["CLI_IDField"] = CLI_IDField;
			}
			else
			{
				AliasVariables.Add("CLI_IDField" ,CLI_IDField);
			}
			TAR_FINALIZADOField = Convert.ToBoolean(Item["TAR_FINALIZADO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_FINALIZADOField"))
			{
				AliasVariables["TAR_FINALIZADOField"] = TAR_FINALIZADOField;
			}
			else
			{
				AliasVariables.Add("TAR_FINALIZADOField" ,TAR_FINALIZADOField);
			}
			TAR_CRIADORField = Convert.ToString(Item["TAR_CRIADOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_CRIADORField"))
			{
				AliasVariables["TAR_CRIADORField"] = TAR_CRIADORField;
			}
			else
			{
				AliasVariables.Add("TAR_CRIADORField" ,TAR_CRIADORField);
			}
			TAR_DATAHORA_FIMField = Convert.ToDateTime(Item["TAR_DATAHORA_FIM"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_DATAHORA_FIMField"))
			{
				AliasVariables["TAR_DATAHORA_FIMField"] = TAR_DATAHORA_FIMField;
			}
			else
			{
				AliasVariables.Add("TAR_DATAHORA_FIMField" ,TAR_DATAHORA_FIMField);
			}
			TAR_GER_RESPONSABLEField = Convert.ToString(Item["TAR_GER_RESPONSABLE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TAR_GER_RESPONSABLEField"))
			{
				AliasVariables["TAR_GER_RESPONSABLEField"] = TAR_GER_RESPONSABLEField;
			}
			else
			{
				AliasVariables.Add("TAR_GER_RESPONSABLEField" ,TAR_GER_RESPONSABLEField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_TAREFA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "TAR_ID") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class DashBoard_Corporativo_Grid3GridDataProvider : GeneralGridProvider
	{
		public long LOJACORField;
		public long NOTASAIField;
		public DateTime FECHA_EMISIONField;
		public long CLI_CODFASTRAXField;
		public long PROD_CODFASTRAXField;
		public long VALOSAIField;
		public string VENDEDORField;
		public int ECOMERCEField;
		public DateTime FECHA_CONFIRMACIONField;
		public int OPESAIField;
		public string SITSAIField;
		public int VNDCLIField;
		public double VALOTOTALField;
		public long LIN_CODFASTRAXField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_VIEW_VENDAS_PENDENTESDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VIEW_VENDAS_PENDENTESDataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "VIEW_VENDAS_PENDENTES"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public DashBoard_Corporativo_Grid3GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VIEW_VENDAS_PENDENTESDataProvider(this, TableName, DatabaseName, "", "DashBoard_Corporativo_Grid3");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_VIEW_VENDAS_PENDENTESItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VIEW_VENDAS_PENDENTESItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "DashBoard_Corporativo_Grid3")
			{
				return new _BD_DADOS_VIEW_VENDAS_PENDENTESItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
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
			NOTASAIField = Convert.ToInt64(Item["NOTASAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTASAIField"))
			{
				AliasVariables["NOTASAIField"] = NOTASAIField;
			}
			else
			{
				AliasVariables.Add("NOTASAIField" ,NOTASAIField);
			}
			FECHA_EMISIONField = Convert.ToDateTime(Item["FECHA_EMISION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_EMISIONField"))
			{
				AliasVariables["FECHA_EMISIONField"] = FECHA_EMISIONField;
			}
			else
			{
				AliasVariables.Add("FECHA_EMISIONField" ,FECHA_EMISIONField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			VALOSAIField = Convert.ToInt64(Item["VALOSAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VALOSAIField"))
			{
				AliasVariables["VALOSAIField"] = VALOSAIField;
			}
			else
			{
				AliasVariables.Add("VALOSAIField" ,VALOSAIField);
			}
			VENDEDORField = Convert.ToString(Item["VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VENDEDORField"))
			{
				AliasVariables["VENDEDORField"] = VENDEDORField;
			}
			else
			{
				AliasVariables.Add("VENDEDORField" ,VENDEDORField);
			}
			ECOMERCEField = Convert.ToInt32(Item["ECOMERCE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ECOMERCEField"))
			{
				AliasVariables["ECOMERCEField"] = ECOMERCEField;
			}
			else
			{
				AliasVariables.Add("ECOMERCEField" ,ECOMERCEField);
			}
			FECHA_CONFIRMACIONField = Convert.ToDateTime(Item["FECHA_CONFIRMACION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_CONFIRMACIONField"))
			{
				AliasVariables["FECHA_CONFIRMACIONField"] = FECHA_CONFIRMACIONField;
			}
			else
			{
				AliasVariables.Add("FECHA_CONFIRMACIONField" ,FECHA_CONFIRMACIONField);
			}
			OPESAIField = Convert.ToInt32(Item["OPESAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("OPESAIField"))
			{
				AliasVariables["OPESAIField"] = OPESAIField;
			}
			else
			{
				AliasVariables.Add("OPESAIField" ,OPESAIField);
			}
			SITSAIField = Convert.ToString(Item["SITSAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("SITSAIField"))
			{
				AliasVariables["SITSAIField"] = SITSAIField;
			}
			else
			{
				AliasVariables.Add("SITSAIField" ,SITSAIField);
			}
			VNDCLIField = Convert.ToInt32(Item["VNDCLI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VNDCLIField"))
			{
				AliasVariables["VNDCLIField"] = VNDCLIField;
			}
			else
			{
				AliasVariables.Add("VNDCLIField" ,VNDCLIField);
			}
			try{VALOTOTALField = Convert.ToDouble(Item["VALOTOTAL"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("VALOTOTALField"))
			{
				AliasVariables["VALOTOTALField"] = VALOTOTALField;
			}
			else
			{
				AliasVariables.Add("VALOTOTALField" ,VALOTOTALField);
			}
			LIN_CODFASTRAXField = Convert.ToInt64(Item["LIN_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LIN_CODFASTRAXField"))
			{
				AliasVariables["LIN_CODFASTRAXField"] = LIN_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("LIN_CODFASTRAXField" ,LIN_CODFASTRAXField);
			}
			FillAuxiliarTables();
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Grid5GridDataProvider : GeneralGridProvider
	{
		public long LOJACORField;
		public long CLI_CODFASTRAXField;
		public string NOMCLIField;
		public DateTime FECHA_ENTRADAField;
		public DateTime FECHA_PREVISTAField;
		public long PROD_CODFASTRAXField;
		public string NOMEField;
		public long DIAS_PARADOField;
		public string SERIEField;
		public string GARANTIAField;
		public string StatusField;
		public long ORDNUMField;
		public long ASIS_IDField;
		public long ANOField;
		public long NOTASAIField;
		public long NOTAENTField;
		public DateTime FECHA_CIERREField;
		public DateTime DataKONField;
		public DateTime FECHA_VENTAField;
		public DateTime DataSITField;
		public long DIAS_RETORNOField;
		public int QuantField;
		public string PROD_OSField;
		public double VALORField;
		public double COSTOField;
		public int FORPROField;
		public string MARCPROField;
		public string NOMMARCField;
		public string NOMFORField;
		public string INFTECField;
		public string CONTATOField;
		public string INFORMEField;
		public long LIN_CODFASTRAXField;
		public string VENDEDORField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_VIEW_TB_ASISTENCIADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VIEW_TB_ASISTENCIADataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "VIEW_TB_ASISTENCIA"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public Grid5GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VIEW_TB_ASISTENCIADataProvider(this, TableName, DatabaseName, "", "Grid5");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_VIEW_TB_ASISTENCIAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VIEW_TB_ASISTENCIAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Grid5")
			{
				return new _BD_DADOS_VIEW_TB_ASISTENCIAItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
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
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			NOMCLIField = Convert.ToString(Item["NOMCLI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMCLIField"))
			{
				AliasVariables["NOMCLIField"] = NOMCLIField;
			}
			else
			{
				AliasVariables.Add("NOMCLIField" ,NOMCLIField);
			}
			FECHA_ENTRADAField = Convert.ToDateTime(Item["FECHA_ENTRADA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_ENTRADAField"))
			{
				AliasVariables["FECHA_ENTRADAField"] = FECHA_ENTRADAField;
			}
			else
			{
				AliasVariables.Add("FECHA_ENTRADAField" ,FECHA_ENTRADAField);
			}
			FECHA_PREVISTAField = Convert.ToDateTime(Item["FECHA_PREVISTA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_PREVISTAField"))
			{
				AliasVariables["FECHA_PREVISTAField"] = FECHA_PREVISTAField;
			}
			else
			{
				AliasVariables.Add("FECHA_PREVISTAField" ,FECHA_PREVISTAField);
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			NOMEField = Convert.ToString(Item["NOME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMEField"))
			{
				AliasVariables["NOMEField"] = NOMEField;
			}
			else
			{
				AliasVariables.Add("NOMEField" ,NOMEField);
			}
			DIAS_PARADOField = Convert.ToInt64(Item["DIAS_PARADO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DIAS_PARADOField"))
			{
				AliasVariables["DIAS_PARADOField"] = DIAS_PARADOField;
			}
			else
			{
				AliasVariables.Add("DIAS_PARADOField" ,DIAS_PARADOField);
			}
			SERIEField = Convert.ToString(Item["SERIE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("SERIEField"))
			{
				AliasVariables["SERIEField"] = SERIEField;
			}
			else
			{
				AliasVariables.Add("SERIEField" ,SERIEField);
			}
			GARANTIAField = Convert.ToString(Item["GARANTIA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("GARANTIAField"))
			{
				AliasVariables["GARANTIAField"] = GARANTIAField;
			}
			else
			{
				AliasVariables.Add("GARANTIAField" ,GARANTIAField);
			}
			StatusField = Convert.ToString(Item["Status"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("StatusField"))
			{
				AliasVariables["StatusField"] = StatusField;
			}
			else
			{
				AliasVariables.Add("StatusField" ,StatusField);
			}
			ORDNUMField = Convert.ToInt64(Item["ORDNUM"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ORDNUMField"))
			{
				AliasVariables["ORDNUMField"] = ORDNUMField;
			}
			else
			{
				AliasVariables.Add("ORDNUMField" ,ORDNUMField);
			}
			ASIS_IDField = Convert.ToInt64(Item["ASIS_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ASIS_IDField"))
			{
				AliasVariables["ASIS_IDField"] = ASIS_IDField;
			}
			else
			{
				AliasVariables.Add("ASIS_IDField" ,ASIS_IDField);
			}
			ANOField = Convert.ToInt64(Item["ANO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ANOField"))
			{
				AliasVariables["ANOField"] = ANOField;
			}
			else
			{
				AliasVariables.Add("ANOField" ,ANOField);
			}
			NOTASAIField = Convert.ToInt64(Item["NOTASAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTASAIField"))
			{
				AliasVariables["NOTASAIField"] = NOTASAIField;
			}
			else
			{
				AliasVariables.Add("NOTASAIField" ,NOTASAIField);
			}
			NOTAENTField = Convert.ToInt64(Item["NOTAENT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTAENTField"))
			{
				AliasVariables["NOTAENTField"] = NOTAENTField;
			}
			else
			{
				AliasVariables.Add("NOTAENTField" ,NOTAENTField);
			}
			FECHA_CIERREField = Convert.ToDateTime(Item["FECHA_CIERRE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_CIERREField"))
			{
				AliasVariables["FECHA_CIERREField"] = FECHA_CIERREField;
			}
			else
			{
				AliasVariables.Add("FECHA_CIERREField" ,FECHA_CIERREField);
			}
			DataKONField = Convert.ToDateTime(Item["DataKON"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DataKONField"))
			{
				AliasVariables["DataKONField"] = DataKONField;
			}
			else
			{
				AliasVariables.Add("DataKONField" ,DataKONField);
			}
			FECHA_VENTAField = Convert.ToDateTime(Item["FECHA_VENTA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_VENTAField"))
			{
				AliasVariables["FECHA_VENTAField"] = FECHA_VENTAField;
			}
			else
			{
				AliasVariables.Add("FECHA_VENTAField" ,FECHA_VENTAField);
			}
			DataSITField = Convert.ToDateTime(Item["DataSIT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DataSITField"))
			{
				AliasVariables["DataSITField"] = DataSITField;
			}
			else
			{
				AliasVariables.Add("DataSITField" ,DataSITField);
			}
			DIAS_RETORNOField = Convert.ToInt64(Item["DIAS_RETORNO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DIAS_RETORNOField"))
			{
				AliasVariables["DIAS_RETORNOField"] = DIAS_RETORNOField;
			}
			else
			{
				AliasVariables.Add("DIAS_RETORNOField" ,DIAS_RETORNOField);
			}
			QuantField = Convert.ToInt32(Item["Quant"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("QuantField"))
			{
				AliasVariables["QuantField"] = QuantField;
			}
			else
			{
				AliasVariables.Add("QuantField" ,QuantField);
			}
			PROD_OSField = Convert.ToString(Item["PROD_OS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_OSField"))
			{
				AliasVariables["PROD_OSField"] = PROD_OSField;
			}
			else
			{
				AliasVariables.Add("PROD_OSField" ,PROD_OSField);
			}
			try{VALORField = Convert.ToDouble(Item["VALOR"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("VALORField"))
			{
				AliasVariables["VALORField"] = VALORField;
			}
			else
			{
				AliasVariables.Add("VALORField" ,VALORField);
			}
			try{COSTOField = Convert.ToDouble(Item["COSTO"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("COSTOField"))
			{
				AliasVariables["COSTOField"] = COSTOField;
			}
			else
			{
				AliasVariables.Add("COSTOField" ,COSTOField);
			}
			FORPROField = Convert.ToInt32(Item["FORPRO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FORPROField"))
			{
				AliasVariables["FORPROField"] = FORPROField;
			}
			else
			{
				AliasVariables.Add("FORPROField" ,FORPROField);
			}
			MARCPROField = Convert.ToString(Item["MARCPRO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("MARCPROField"))
			{
				AliasVariables["MARCPROField"] = MARCPROField;
			}
			else
			{
				AliasVariables.Add("MARCPROField" ,MARCPROField);
			}
			NOMMARCField = Convert.ToString(Item["NOMMARC"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMMARCField"))
			{
				AliasVariables["NOMMARCField"] = NOMMARCField;
			}
			else
			{
				AliasVariables.Add("NOMMARCField" ,NOMMARCField);
			}
			NOMFORField = Convert.ToString(Item["NOMFOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMFORField"))
			{
				AliasVariables["NOMFORField"] = NOMFORField;
			}
			else
			{
				AliasVariables.Add("NOMFORField" ,NOMFORField);
			}
			INFTECField = Convert.ToString(Item["INFTEC"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("INFTECField"))
			{
				AliasVariables["INFTECField"] = INFTECField;
			}
			else
			{
				AliasVariables.Add("INFTECField" ,INFTECField);
			}
			CONTATOField = Convert.ToString(Item["CONTATO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CONTATOField"))
			{
				AliasVariables["CONTATOField"] = CONTATOField;
			}
			else
			{
				AliasVariables.Add("CONTATOField" ,CONTATOField);
			}
			INFORMEField = Convert.ToString(Item["INFORME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("INFORMEField"))
			{
				AliasVariables["INFORMEField"] = INFORMEField;
			}
			else
			{
				AliasVariables.Add("INFORMEField" ,INFORMEField);
			}
			LIN_CODFASTRAXField = Convert.ToInt64(Item["LIN_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LIN_CODFASTRAXField"))
			{
				AliasVariables["LIN_CODFASTRAXField"] = LIN_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("LIN_CODFASTRAXField" ,LIN_CODFASTRAXField);
			}
			VENDEDORField = Convert.ToString(Item["VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VENDEDORField"))
			{
				AliasVariables["VENDEDORField"] = VENDEDORField;
			}
			else
			{
				AliasVariables.Add("VENDEDORField" ,VENDEDORField);
			}
			FillAuxiliarTables();
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class DashBoard_Corporativo_Grid4GridDataProvider : GeneralGridProvider
	{
		public long LOJACORField;
		public DateTime DATA_LANCAMENTOField;
		public string AREAField;
		public string TIPO_DE_AVISOField;
		public long CLI_IDField;
		public string CLIENTEField;
		public string VENDEDORField;
		public string DESCRIPCIONField;
		public long IDField;
		public long CLI_CODFASTRAXField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_VIEW_NOTICIASDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VIEW_NOTICIASDataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "VIEW_NOTICIAS"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public DashBoard_Corporativo_Grid4GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VIEW_NOTICIASDataProvider(this, TableName, DatabaseName, "", "DashBoard_Corporativo_Grid4");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_VIEW_NOTICIASItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VIEW_NOTICIASItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "DashBoard_Corporativo_Grid4")
			{
				return new _BD_DADOS_VIEW_NOTICIASItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
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
			DATA_LANCAMENTOField = Convert.ToDateTime(Item["DATA_LANCAMENTO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DATA_LANCAMENTOField"))
			{
				AliasVariables["DATA_LANCAMENTOField"] = DATA_LANCAMENTOField;
			}
			else
			{
				AliasVariables.Add("DATA_LANCAMENTOField" ,DATA_LANCAMENTOField);
			}
			AREAField = Convert.ToString(Item["AREA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("AREAField"))
			{
				AliasVariables["AREAField"] = AREAField;
			}
			else
			{
				AliasVariables.Add("AREAField" ,AREAField);
			}
			TIPO_DE_AVISOField = Convert.ToString(Item["TIPO_DE_AVISO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TIPO_DE_AVISOField"))
			{
				AliasVariables["TIPO_DE_AVISOField"] = TIPO_DE_AVISOField;
			}
			else
			{
				AliasVariables.Add("TIPO_DE_AVISOField" ,TIPO_DE_AVISOField);
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
			CLIENTEField = Convert.ToString(Item["CLIENTE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLIENTEField"))
			{
				AliasVariables["CLIENTEField"] = CLIENTEField;
			}
			else
			{
				AliasVariables.Add("CLIENTEField" ,CLIENTEField);
			}
			VENDEDORField = Convert.ToString(Item["VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VENDEDORField"))
			{
				AliasVariables["VENDEDORField"] = VENDEDORField;
			}
			else
			{
				AliasVariables.Add("VENDEDORField" ,VENDEDORField);
			}
			DESCRIPCIONField = Convert.ToString(Item["DESCRIPCION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DESCRIPCIONField"))
			{
				AliasVariables["DESCRIPCIONField"] = DESCRIPCIONField;
			}
			else
			{
				AliasVariables.Add("DESCRIPCIONField" ,DESCRIPCIONField);
			}
			IDField = Convert.ToInt64(Item["ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("IDField"))
			{
				AliasVariables["IDField"] = IDField;
			}
			else
			{
				AliasVariables.Add("IDField" ,IDField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			FillAuxiliarTables();
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class DashBoard_Corporativo_Grid6GridDataProvider : GeneralGridProvider
	{
		public long NOTASAIField;
		public DateTime FECHA_EMISIONField;
		public int ECOMERCEField;
		public long CLI_CODFASTRAXField;
		public long PROD_CODFASTRAXField;
		public long VALOSAIField;
		public string VENDEDORField;
		public long PRE_IDField;
		public DateTime FECHA_CONFIRMACIONField;
		public long LOJACORField;
		public int OPESAIField;
		public string SITSAIField;
		public int VNDCLIField;
		public double VALOTOTALField;
		public long LIN_CODFASTRAXField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_VIEW_PRE_VENDASDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VIEW_PRE_VENDASDataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "VIEW_PRE_VENDAS"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public DashBoard_Corporativo_Grid6GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VIEW_PRE_VENDASDataProvider(this, TableName, DatabaseName, "", "DashBoard_Corporativo_Grid6");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_VIEW_PRE_VENDASItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VIEW_PRE_VENDASItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "DashBoard_Corporativo_Grid6")
			{
				return new _BD_DADOS_VIEW_PRE_VENDASItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			NOTASAIField = Convert.ToInt64(Item["NOTASAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTASAIField"))
			{
				AliasVariables["NOTASAIField"] = NOTASAIField;
			}
			else
			{
				AliasVariables.Add("NOTASAIField" ,NOTASAIField);
			}
			FECHA_EMISIONField = Convert.ToDateTime(Item["FECHA_EMISION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_EMISIONField"))
			{
				AliasVariables["FECHA_EMISIONField"] = FECHA_EMISIONField;
			}
			else
			{
				AliasVariables.Add("FECHA_EMISIONField" ,FECHA_EMISIONField);
			}
			ECOMERCEField = Convert.ToInt32(Item["ECOMERCE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ECOMERCEField"))
			{
				AliasVariables["ECOMERCEField"] = ECOMERCEField;
			}
			else
			{
				AliasVariables.Add("ECOMERCEField" ,ECOMERCEField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			VALOSAIField = Convert.ToInt64(Item["VALOSAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VALOSAIField"))
			{
				AliasVariables["VALOSAIField"] = VALOSAIField;
			}
			else
			{
				AliasVariables.Add("VALOSAIField" ,VALOSAIField);
			}
			VENDEDORField = Convert.ToString(Item["VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VENDEDORField"))
			{
				AliasVariables["VENDEDORField"] = VENDEDORField;
			}
			else
			{
				AliasVariables.Add("VENDEDORField" ,VENDEDORField);
			}
			PRE_IDField = Convert.ToInt64(Item["PRE_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PRE_IDField"))
			{
				AliasVariables["PRE_IDField"] = PRE_IDField;
			}
			else
			{
				AliasVariables.Add("PRE_IDField" ,PRE_IDField);
			}
			FECHA_CONFIRMACIONField = Convert.ToDateTime(Item["FECHA_CONFIRMACION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("FECHA_CONFIRMACIONField"))
			{
				AliasVariables["FECHA_CONFIRMACIONField"] = FECHA_CONFIRMACIONField;
			}
			else
			{
				AliasVariables.Add("FECHA_CONFIRMACIONField" ,FECHA_CONFIRMACIONField);
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
			OPESAIField = Convert.ToInt32(Item["OPESAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("OPESAIField"))
			{
				AliasVariables["OPESAIField"] = OPESAIField;
			}
			else
			{
				AliasVariables.Add("OPESAIField" ,OPESAIField);
			}
			SITSAIField = Convert.ToString(Item["SITSAI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("SITSAIField"))
			{
				AliasVariables["SITSAIField"] = SITSAIField;
			}
			else
			{
				AliasVariables.Add("SITSAIField" ,SITSAIField);
			}
			VNDCLIField = Convert.ToInt32(Item["VNDCLI"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VNDCLIField"))
			{
				AliasVariables["VNDCLIField"] = VNDCLIField;
			}
			else
			{
				AliasVariables.Add("VNDCLIField" ,VNDCLIField);
			}
			try{VALOTOTALField = Convert.ToDouble(Item["VALOTOTAL"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("VALOTOTALField"))
			{
				AliasVariables["VALOTOTALField"] = VALOTOTALField;
			}
			else
			{
				AliasVariables.Add("VALOTOTALField" ,VALOTOTALField);
			}
			LIN_CODFASTRAXField = Convert.ToInt64(Item["LIN_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LIN_CODFASTRAXField"))
			{
				AliasVariables["LIN_CODFASTRAXField"] = LIN_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("LIN_CODFASTRAXField" ,LIN_CODFASTRAXField);
			}
			FillAuxiliarTables();
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class DashBoard_Corporativo_Grid7GridDataProvider : GeneralGridProvider
	{
		public DateTime DataOPEField;
		public long NOTAENTField;
		public DateTime PRE_CHEField;
		public long PROD_CODFASTRAXField;
		public string NOMELONGField;
		public long ID_compra_previsaoField;
		public long QTDEField;
		public string UsuarioField;
		public string NuevoField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_VW_COMPRA_PREVISAODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VW_COMPRA_PREVISAODataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "VW_COMPRA_PREVISAO"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public DashBoard_Corporativo_Grid7GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VW_COMPRA_PREVISAODataProvider(this, TableName, DatabaseName, "", "DashBoard_Corporativo_Grid7");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_VW_COMPRA_PREVISAOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VW_COMPRA_PREVISAOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "DashBoard_Corporativo_Grid7")
			{
				return new _BD_DADOS_VW_COMPRA_PREVISAOItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			DataOPEField = Convert.ToDateTime(Item["DataOPE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DataOPEField"))
			{
				AliasVariables["DataOPEField"] = DataOPEField;
			}
			else
			{
				AliasVariables.Add("DataOPEField" ,DataOPEField);
			}
			NOTAENTField = Convert.ToInt64(Item["NOTAENT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTAENTField"))
			{
				AliasVariables["NOTAENTField"] = NOTAENTField;
			}
			else
			{
				AliasVariables.Add("NOTAENTField" ,NOTAENTField);
			}
			PRE_CHEField = Convert.ToDateTime(Item["PRE_CHE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PRE_CHEField"))
			{
				AliasVariables["PRE_CHEField"] = PRE_CHEField;
			}
			else
			{
				AliasVariables.Add("PRE_CHEField" ,PRE_CHEField);
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			NOMELONGField = Convert.ToString(Item["NOMELONG"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMELONGField"))
			{
				AliasVariables["NOMELONGField"] = NOMELONGField;
			}
			else
			{
				AliasVariables.Add("NOMELONGField" ,NOMELONGField);
			}
			ID_compra_previsaoField = Convert.ToInt64(Item["ID_compra_previsao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ID_compra_previsaoField"))
			{
				AliasVariables["ID_compra_previsaoField"] = ID_compra_previsaoField;
			}
			else
			{
				AliasVariables.Add("ID_compra_previsaoField" ,ID_compra_previsaoField);
			}
			QTDEField = Convert.ToInt64(Item["QTDE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("QTDEField"))
			{
				AliasVariables["QTDEField"] = QTDEField;
			}
			else
			{
				AliasVariables.Add("QTDEField" ,QTDEField);
			}
			UsuarioField = Convert.ToString(Item["Usuario"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("UsuarioField"))
			{
				AliasVariables["UsuarioField"] = UsuarioField;
			}
			else
			{
				AliasVariables.Add("UsuarioField" ,UsuarioField);
			}
			NuevoField = Convert.ToString(Item["Nuevo"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NuevoField"))
			{
				AliasVariables["NuevoField"] = NuevoField;
			}
			else
			{
				AliasVariables.Add("NuevoField" ,NuevoField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_VW_COMPRA_PREVISAO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ID_compra_previsao") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class DashBoard_Corporativo_Grid8GridDataProvider : GeneralGridProvider
	{
		public long PROD_CODFASTRAXField;
		public string PROD_NOMEField;
		public long QTD_DIASField;
		public long ESTOQUEField;
		public string CUSTO_MEDIOField;
		public long TEMPO_IDField;
		public long LIN_CODFASTRAXField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 6;
		}
		private _BD_DADOS_VIEW_TEMPO_ESTOQUEDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VIEW_TEMPO_ESTOQUEDataProvider;
			}
		}

		public DashBoard_CorporativoPageProvider ParentPageProvider;

		public _BD_DADOS_TB_NEGOCIODataProvider AUX_DashBoard_Corporativo_TB_NEGOCIOProvider;
		public _BD_DADOS_TB_TAREFADataProvider AUX_DashBoard_Corporativo_TB_TAREFAProvider;
		public _BD_DADOS_VIEW_TAREFASDataProvider AUX_DashBoard_Corporativo_VIEW_TAREFASProvider;
		public _BD_DADOS_TB_VENDASDataProvider AUX_DashBoard_Corporativo_TB_VENDASProvider;
		public _BD_DADOS_TB_ASISTENCIADataProvider AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider;
		
		public override string TableName { get { return "VIEW_TEMPO_ESTOQUE"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29846"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public DashBoard_Corporativo_Grid8GridDataProvider(DashBoard_CorporativoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VIEW_TEMPO_ESTOQUEDataProvider(this, TableName, DatabaseName, "", "DashBoard_Corporativo_Grid8");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider = new _BD_DADOS_TB_NEGOCIODataProvider(MainProvider, "TB_NEGOCIO", "BD_DADOS", "", "TB_NEGOCIO");
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_TAREFAProvider = new _BD_DADOS_TB_TAREFADataProvider(MainProvider, "TB_TAREFA", "BD_DADOS", "", "TB_TAREFA");
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider = new _BD_DADOS_VIEW_TAREFASDataProvider(MainProvider, "VIEW_TAREFAS", "BD_DADOS", "", "VIEW_TAREFAS");
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_VENDASProvider = new _BD_DADOS_TB_VENDASDataProvider(MainProvider, "TB_VENDAS", "BD_DADOS", "", "TB_VENDAS");
			AUX_DashBoard_Corporativo_TB_VENDASProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider = new _BD_DADOS_TB_ASISTENCIADataProvider(MainProvider, "TB_ASISTENCIA", "BD_DADOS", "", "TB_ASISTENCIA");
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public _BD_DADOS_VIEW_TEMPO_ESTOQUEItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VIEW_TEMPO_ESTOQUEItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "DashBoard_Corporativo_Grid8")
			{
				return new _BD_DADOS_VIEW_TEMPO_ESTOQUEItem(DatabaseName);
			}
			else if (Provider is _BD_DADOS_TB_NEGOCIODataProvider)
			{
				return new _BD_DADOS_TB_NEGOCIOItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_TAREFADataProvider)
			{
				return new _BD_DADOS_TB_TAREFAItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_VIEW_TAREFASDataProvider)
			{
				return new _BD_DADOS_VIEW_TAREFASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_VENDASDataProvider)
			{
				return new _BD_DADOS_TB_VENDASItem("BD_DADOS");
			}
			else if (Provider is _BD_DADOS_TB_ASISTENCIADataProvider)
			{
				return new _BD_DADOS_TB_ASISTENCIAItem("BD_DADOS");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_NEGOCIOProvider);
			AUX_DashBoard_Corporativo_TB_NEGOCIOProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_TAREFAProvider);
			AUX_DashBoard_Corporativo_TB_TAREFAProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_VIEW_TAREFASProvider);
			AUX_DashBoard_Corporativo_VIEW_TAREFASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_VENDASProvider);
			AUX_DashBoard_Corporativo_TB_VENDASProvider.SelectItem(1, FormPositioningEnum.First);
			MainProvider.SetParametersValues(AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider);
			AUX_DashBoard_Corporativo_TB_ASISTENCIAProvider.SelectItem(1, FormPositioningEnum.First);
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (DashBoard_CorporativoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
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
			QTD_DIASField = Convert.ToInt64(Item["QTD_DIAS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("QTD_DIASField"))
			{
				AliasVariables["QTD_DIASField"] = QTD_DIASField;
			}
			else
			{
				AliasVariables.Add("QTD_DIASField" ,QTD_DIASField);
			}
			ESTOQUEField = Convert.ToInt64(Item["ESTOQUE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ESTOQUEField"))
			{
				AliasVariables["ESTOQUEField"] = ESTOQUEField;
			}
			else
			{
				AliasVariables.Add("ESTOQUEField" ,ESTOQUEField);
			}
			CUSTO_MEDIOField = Convert.ToString(Item["CUSTO_MEDIO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CUSTO_MEDIOField"))
			{
				AliasVariables["CUSTO_MEDIOField"] = CUSTO_MEDIOField;
			}
			else
			{
				AliasVariables.Add("CUSTO_MEDIOField" ,CUSTO_MEDIOField);
			}
			TEMPO_IDField = Convert.ToInt64(Item["TEMPO_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TEMPO_IDField"))
			{
				AliasVariables["TEMPO_IDField"] = TEMPO_IDField;
			}
			else
			{
				AliasVariables.Add("TEMPO_IDField" ,TEMPO_IDField);
			}
			LIN_CODFASTRAXField = Convert.ToInt64(Item["LIN_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LIN_CODFASTRAXField"))
			{
				AliasVariables["LIN_CODFASTRAXField"] = LIN_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("LIN_CODFASTRAXField" ,LIN_CODFASTRAXField);
			}
			FillAuxiliarTables();
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
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
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
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}


}

}
