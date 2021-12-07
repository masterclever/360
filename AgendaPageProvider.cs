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
	public class AgendaPageProvider : GeneralProvider
	{
			public Agenda_Scheduler1SchedulerBaseProvider Agenda_Scheduler1SchedulerProvider;

		public AgendaPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_TB_AGENDAMENTODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_AGENDAMENTO", "Agenda");
			MainProvider.DataProvider.PageProvider = this;
			Agenda_Scheduler1SchedulerProvider = new Agenda_Scheduler1SchedulerBaseProvider(this);
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_TB_AGENDAMENTOItem(MainProvider.DatabaseName);
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_AGENDAMENTO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "AGE_ID") });
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


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Agenda_Scheduler1SchedulerBaseProvider : GeneralSchedulerProvider
	{
		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}

		private _25246FASTRAX_TB_AGENDAMENTODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _25246FASTRAX_TB_AGENDAMENTODataProvider;
			}
		}

		public AgendaPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_AGENDAMENTO"; } }

		public override string DatabaseName { get { return "25246FASTRAX"; } }

		public override string FormID { get { return "31970"; } }
		
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

		public Agenda_Scheduler1SchedulerBaseProvider(AgendaPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _25246FASTRAX_TB_AGENDAMENTODataProvider(this, TableName, DatabaseName, "PK_TB_AGENDAMENTO", "Agenda_Scheduler1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}

		public _25246FASTRAX_TB_AGENDAMENTOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _25246FASTRAX_TB_AGENDAMENTOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Agenda_Scheduler1")
			{
				return new _25246FASTRAX_TB_AGENDAMENTOItem(DatabaseName);
			}
			return null;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_AGENDAMENTO", false, new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName) });
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
		}
	}

}
