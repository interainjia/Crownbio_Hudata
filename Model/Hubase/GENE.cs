using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// Object Data Class for GENE Table
	/// </summary>
	[Serializable]
	[DataTable("GENE",ResourceKey = "GENE")]
	public class GENE: BaseObject
	{
		public GENE()
		{
		}
		public GENE(DealModel initModel):base(initModel)
		{
		}
		public static GENE Convert(BaseObject from)
		{
			return (GENE)from;
		}
		/// <summary>
		/// The GENE_ID Field of GENE Table
		/// </summary>
		private decimal _gene_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.GENE_ID = value; }
			get { return GENE_ID; }
		}

		[RecordIDField("GENE_ID"
			, AliasName = "GENE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 18
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "GENE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal GENE_ID
		{
			set { _gene_id = value; }
			get { return _gene_id; }
		}
		/// <summary>
		/// The PROBE_SET_ID Field of GENE Table
		/// </summary>
		private string _probe_set_id;
		[DataField("PROBE_SET_ID"
			, AliasName = "PROBE_SET_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PROBE_SET_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PROBE_SET_ID
		{
			set { _probe_set_id = value; }
			get { return _probe_set_id; }
		}
		/// <summary>
		/// The GENECHIP_ARRAY Field of GENE Table
		/// </summary>
		private string _genechip_array;
		[DataField("GENECHIP_ARRAY"
			, AliasName = "GENECHIP_ARRAY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENECHIP_ARRAY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENECHIP_ARRAY
		{
			set { _genechip_array = value; }
			get { return _genechip_array; }
		}
		/// <summary>
		/// The SPECIES_SCIENTIFIC_NAME Field of GENE Table
		/// </summary>
		private string _species_scientific_name;
		[DataField("SPECIES_SCIENTIFIC_NAME"
			, AliasName = "SPECIES_SCIENTIFIC_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SPECIES_SCIENTIFIC_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SPECIES_SCIENTIFIC_NAME
		{
			set { _species_scientific_name = value; }
			get { return _species_scientific_name; }
		}
		/// <summary>
		/// The ANNOTATION_DATE Field of GENE Table
		/// </summary>
		private string _annotation_date;
		[DataField("ANNOTATION_DATE"
			, AliasName = "ANNOTATION_DATE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANNOTATION_DATE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANNOTATION_DATE
		{
			set { _annotation_date = value; }
			get { return _annotation_date; }
		}
		/// <summary>
		/// The SEQUENCE_TYPE Field of GENE Table
		/// </summary>
		private string _sequence_type;
		[DataField("SEQUENCE_TYPE"
			, AliasName = "SEQUENCE_TYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SEQUENCE_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SEQUENCE_TYPE
		{
			set { _sequence_type = value; }
			get { return _sequence_type; }
		}
		/// <summary>
		/// The SEQUENCE_SOURCE Field of GENE Table
		/// </summary>
		private string _sequence_source;
		[DataField("SEQUENCE_SOURCE"
			, AliasName = "SEQUENCE_SOURCE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SEQUENCE_SOURCE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SEQUENCE_SOURCE
		{
			set { _sequence_source = value; }
			get { return _sequence_source; }
		}
		/// <summary>
		/// The TRANSCRIPT_ID Field of GENE Table
		/// </summary>
		private string _transcript_id;
		[DataField("TRANSCRIPT_ID"
			, AliasName = "TRANSCRIPT_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TRANSCRIPT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TRANSCRIPT_ID
		{
			set { _transcript_id = value; }
			get { return _transcript_id; }
		}
		/// <summary>
		/// The TARGET_DESCRIPTION Field of GENE Table
		/// </summary>
		private string _target_description;
		[DataField("TARGET_DESCRIPTION"
			, AliasName = "TARGET_DESCRIPTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TARGET_DESCRIPTION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TARGET_DESCRIPTION
		{
			set { _target_description = value; }
			get { return _target_description; }
		}
		/// <summary>
		/// The REPRESENTATIVE_PUBLIC_ID Field of GENE Table
		/// </summary>
		private string _representative_public_id;
		[DataField("REPRESENTATIVE_PUBLIC_ID"
			, AliasName = "REPRESENTATIVE_PUBLIC_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REPRESENTATIVE_PUBLIC_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REPRESENTATIVE_PUBLIC_ID
		{
			set { _representative_public_id = value; }
			get { return _representative_public_id; }
		}
		/// <summary>
		/// The ARCHIVAL_UNIGENE_CLUSTER Field of GENE Table
		/// </summary>
		private string _archival_unigene_cluster;
		[DataField("ARCHIVAL_UNIGENE_CLUSTER"
			, AliasName = "ARCHIVAL_UNIGENE_CLUSTER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ARCHIVAL_UNIGENE_CLUSTER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ARCHIVAL_UNIGENE_CLUSTER
		{
			set { _archival_unigene_cluster = value; }
			get { return _archival_unigene_cluster; }
		}
		/// <summary>
		/// The UNIGENE_ID Field of GENE Table
		/// </summary>
		private string _unigene_id;
		[DataField("UNIGENE_ID"
			, AliasName = "UNIGENE_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "UNIGENE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 33
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string UNIGENE_ID
		{
			set { _unigene_id = value; }
			get { return _unigene_id; }
		}
		/// <summary>
		/// The GENOME_VERSION Field of GENE Table
		/// </summary>
		private string _genome_version;
		[DataField("GENOME_VERSION"
			, AliasName = "GENOME_VERSION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENOME_VERSION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 36
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENOME_VERSION
		{
			set { _genome_version = value; }
			get { return _genome_version; }
		}
		/// <summary>
		/// The ALIGNMENTS Field of GENE Table
		/// </summary>
		private string _alignments;
		[DataField("ALIGNMENTS"
			, AliasName = "ALIGNMENTS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ALIGNMENTS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 39
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ALIGNMENTS
		{
			set { _alignments = value; }
			get { return _alignments; }
		}
		/// <summary>
		/// The GENE_TITLE Field of GENE Table
		/// </summary>
		private string _gene_title;
		[DataField("GENE_TITLE"
			, AliasName = "GENE_TITLE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENE_TITLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 42
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENE_TITLE
		{
			set { _gene_title = value; }
			get { return _gene_title; }
		}
		/// <summary>
		/// The GENE_SYMBOL Field of GENE Table
		/// </summary>
		private string _gene_symbol;
		[DataField("GENE_SYMBOL"
			, AliasName = "GENE_SYMBOL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENE_SYMBOL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 45
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENE_SYMBOL
		{
			set { _gene_symbol = value; }
			get { return _gene_symbol; }
		}
		/// <summary>
		/// The CHROMOSOMAL_LOCATION Field of GENE Table
		/// </summary>
		private string _chromosomal_location;
		[DataField("CHROMOSOMAL_LOCATION"
			, AliasName = "CHROMOSOMAL_LOCATION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CHROMOSOMAL_LOCATION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 48
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CHROMOSOMAL_LOCATION
		{
			set { _chromosomal_location = value; }
			get { return _chromosomal_location; }
		}
		/// <summary>
		/// The UNIGENE_CLUSTER_TYPE Field of GENE Table
		/// </summary>
		private string _unigene_cluster_type;
		[DataField("UNIGENE_CLUSTER_TYPE"
			, AliasName = "UNIGENE_CLUSTER_TYPE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "UNIGENE_CLUSTER_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 51
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string UNIGENE_CLUSTER_TYPE
		{
			set { _unigene_cluster_type = value; }
			get { return _unigene_cluster_type; }
		}
		/// <summary>
		/// The ENSEMBL Field of GENE Table
		/// </summary>
		private string _ensembl;
		[DataField("ENSEMBL"
			, AliasName = "ENSEMBL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ENSEMBL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 54
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ENSEMBL
		{
			set { _ensembl = value; }
			get { return _ensembl; }
		}
		/// <summary>
		/// The ENTREZ_GENE Field of GENE Table
		/// </summary>
		private string _entrez_gene;
		[DataField("ENTREZ_GENE"
			, AliasName = "ENTREZ_GENE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ENTREZ_GENE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 57
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ENTREZ_GENE
		{
			set { _entrez_gene = value; }
			get { return _entrez_gene; }
		}
		/// <summary>
		/// The SWISSPROT Field of GENE Table
		/// </summary>
		private string _swissprot;
		[DataField("SWISSPROT"
			, AliasName = "SWISSPROT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 0
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SWISSPROT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 60
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SWISSPROT
		{
			set { _swissprot = value; }
			get { return _swissprot; }
		}
		/// <summary>
		/// The EC Field of GENE Table
		/// </summary>
		private string _ec;
		[DataField("EC"
			, AliasName = "EC"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "EC"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 63
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string EC
		{
			set { _ec = value; }
			get { return _ec; }
		}
		/// <summary>
		/// The OMIM Field of GENE Table
		/// </summary>
		private string _omim;
		[DataField("OMIM"
			, AliasName = "OMIM"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "OMIM"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 66
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string OMIM
		{
			set { _omim = value; }
			get { return _omim; }
		}
		/// <summary>
		/// The REFSEQ_PROTEIN_ID Field of GENE Table
		/// </summary>
		private string _refseq_protein_id;
		[DataField("REFSEQ_PROTEIN_ID"
			, AliasName = "REFSEQ_PROTEIN_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REFSEQ_PROTEIN_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 69
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REFSEQ_PROTEIN_ID
		{
			set { _refseq_protein_id = value; }
			get { return _refseq_protein_id; }
		}
		/// <summary>
		/// The REFSEQ_TRANSCRIPT_ID Field of GENE Table
		/// </summary>
		private string _refseq_transcript_id;
		[DataField("REFSEQ_TRANSCRIPT_ID"
			, AliasName = "REFSEQ_TRANSCRIPT_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REFSEQ_TRANSCRIPT_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 72
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REFSEQ_TRANSCRIPT_ID
		{
			set { _refseq_transcript_id = value; }
			get { return _refseq_transcript_id; }
		}
		/// <summary>
		/// The FLYBASE Field of GENE Table
		/// </summary>
		private string _flybase;
		[DataField("FLYBASE"
			, AliasName = "FLYBASE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "FLYBASE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 75
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FLYBASE
		{
			set { _flybase = value; }
			get { return _flybase; }
		}
		/// <summary>
		/// The AGI Field of GENE Table
		/// </summary>
		private string _agi;
		[DataField("AGI"
			, AliasName = "AGI"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "AGI"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 78
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string AGI
		{
			set { _agi = value; }
			get { return _agi; }
		}
		/// <summary>
		/// The WORMBASE Field of GENE Table
		/// </summary>
		private string _wormbase;
		[DataField("WORMBASE"
			, AliasName = "WORMBASE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "WORMBASE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 81
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string WORMBASE
		{
			set { _wormbase = value; }
			get { return _wormbase; }
		}
		/// <summary>
		/// The MGI_NAME Field of GENE Table
		/// </summary>
		private string _mgi_name;
		[DataField("MGI_NAME"
			, AliasName = "MGI_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MGI_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 84
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MGI_NAME
		{
			set { _mgi_name = value; }
			get { return _mgi_name; }
		}
		/// <summary>
		/// The RGD_NAME Field of GENE Table
		/// </summary>
		private string _rgd_name;
		[DataField("RGD_NAME"
			, AliasName = "RGD_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "RGD_NAME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 87
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string RGD_NAME
		{
			set { _rgd_name = value; }
			get { return _rgd_name; }
		}
		/// <summary>
		/// The SGD_ACCESSION_NUMBER Field of GENE Table
		/// </summary>
		private string _sgd_accession_number;
		[DataField("SGD_ACCESSION_NUMBER"
			, AliasName = "SGD_ACCESSION_NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 5
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SGD_ACCESSION_NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 90
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SGD_ACCESSION_NUMBER
		{
			set { _sgd_accession_number = value; }
			get { return _sgd_accession_number; }
		}
		/// <summary>
		/// The GENE_ONTOLOGY_BIOLOGICAL_PROCESS Field of GENE Table
		/// </summary>
		private string _gene_ontology_biological_process;
		[DataField("GENE_ONTOLOGY_BIOLOGICAL_PROCESS"
			, AliasName = "GENE_ONTOLOGY_BIOLOGICAL_PROCESS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENE_ONTOLOGY_BIOLOGICAL_PROCESS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 93
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENE_ONTOLOGY_BIOLOGICAL_PROCESS
		{
			set { _gene_ontology_biological_process = value; }
			get { return _gene_ontology_biological_process; }
		}
		/// <summary>
		/// The GENE_ONTOLOGY_CELLULAR_COMPONENT Field of GENE Table
		/// </summary>
		private string _gene_ontology_cellular_component;
		[DataField("GENE_ONTOLOGY_CELLULAR_COMPONENT"
			, AliasName = "GENE_ONTOLOGY_CELLULAR_COMPONENT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENE_ONTOLOGY_CELLULAR_COMPONENT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 96
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENE_ONTOLOGY_CELLULAR_COMPONENT
		{
			set { _gene_ontology_cellular_component = value; }
			get { return _gene_ontology_cellular_component; }
		}
		/// <summary>
		/// The GENE_ONTOLOGY_MOLECULAR_FUNCTION Field of GENE Table
		/// </summary>
		private string _gene_ontology_molecular_function;
		[DataField("GENE_ONTOLOGY_MOLECULAR_FUNCTION"
			, AliasName = "GENE_ONTOLOGY_MOLECULAR_FUNCTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 1000
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "GENE_ONTOLOGY_MOLECULAR_FUNCTION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 99
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string GENE_ONTOLOGY_MOLECULAR_FUNCTION
		{
			set { _gene_ontology_molecular_function = value; }
			get { return _gene_ontology_molecular_function; }
		}
		/// <summary>
		/// The PATHWAY Field of GENE Table
		/// </summary>
		private string _pathway;
		[DataField("PATHWAY"
			, AliasName = "PATHWAY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "PATHWAY"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 102
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PATHWAY
		{
			set { _pathway = value; }
			get { return _pathway; }
		}
		/// <summary>
		/// The INTERPRO Field of GENE Table
		/// </summary>
		private string _interpro;
		[DataField("INTERPRO"
			, AliasName = "INTERPRO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 250
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "INTERPRO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 105
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string INTERPRO
		{
			set { _interpro = value; }
			get { return _interpro; }
		}
		/// <summary>
		/// The TRANS_MEMBRANE Field of GENE Table
		/// </summary>
		private string _trans_membrane;
		[DataField("TRANS_MEMBRANE"
			, AliasName = "TRANS_MEMBRANE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 500
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TRANS_MEMBRANE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 108
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TRANS_MEMBRANE
		{
			set { _trans_membrane = value; }
			get { return _trans_membrane; }
		}
		/// <summary>
		/// The QTL Field of GENE Table
		/// </summary>
		private string _qtl;
		[DataField("QTL"
			, AliasName = "QTL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 25
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "QTL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 111
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string QTL
		{
			set { _qtl = value; }
			get { return _qtl; }
		}
		/// <summary>
		/// The ANNOTATION_DESCRIPTION Field of GENE Table
		/// </summary>
		private string _annotation_description;
		[DataField("ANNOTATION_DESCRIPTION"
			, AliasName = "ANNOTATION_DESCRIPTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANNOTATION_DESCRIPTION"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 114
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANNOTATION_DESCRIPTION
		{
			set { _annotation_description = value; }
			get { return _annotation_description; }
		}
		/// <summary>
		/// The ANNOTATION_TRANSCRIPT_CLUSTER Field of GENE Table
		/// </summary>
		private string _annotation_transcript_cluster;
		[DataField("ANNOTATION_TRANSCRIPT_CLUSTER"
			, AliasName = "ANNOTATION_TRANSCRIPT_CLUSTER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 0
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANNOTATION_TRANSCRIPT_CLUSTER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 117
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANNOTATION_TRANSCRIPT_CLUSTER
		{
			set { _annotation_transcript_cluster = value; }
			get { return _annotation_transcript_cluster; }
		}
		/// <summary>
		/// The TRANSCRIPT_ASSIGNMENTS Field of GENE Table
		/// </summary>
		private string _transcript_assignments;
		[DataField("TRANSCRIPT_ASSIGNMENTS"
			, AliasName = "TRANSCRIPT_ASSIGNMENTS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 0
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TRANSCRIPT_ASSIGNMENTS"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 120
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TRANSCRIPT_ASSIGNMENTS
		{
			set { _transcript_assignments = value; }
			get { return _transcript_assignments; }
		}
		/// <summary>
		/// The ANNOTATION_NOTES Field of GENE Table
		/// </summary>
		private string _annotation_notes;
		[DataField("ANNOTATION_NOTES"
			, AliasName = "ANNOTATION_NOTES"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 0
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ANNOTATION_NOTES"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 123
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ANNOTATION_NOTES
		{
			set { _annotation_notes = value; }
			get { return _annotation_notes; }
		}
		/// <summary>
		/// GENE Table 
		/// </summary>
		public const string TABLE_NAME="GENE";
		public const String GENE_ID_FIELD  ="GENE_ID";
		public const String PROBE_SET_ID_FIELD  ="PROBE_SET_ID";
		public const String GENECHIP_ARRAY_FIELD  ="GENECHIP_ARRAY";
		public const String SPECIES_SCIENTIFIC_NAME_FIELD  ="SPECIES_SCIENTIFIC_NAME";
		public const String ANNOTATION_DATE_FIELD  ="ANNOTATION_DATE";
		public const String SEQUENCE_TYPE_FIELD  ="SEQUENCE_TYPE";
		public const String SEQUENCE_SOURCE_FIELD  ="SEQUENCE_SOURCE";
		public const String TRANSCRIPT_ID_FIELD  ="TRANSCRIPT_ID";
		public const String TARGET_DESCRIPTION_FIELD  ="TARGET_DESCRIPTION";
		public const String REPRESENTATIVE_PUBLIC_ID_FIELD  ="REPRESENTATIVE_PUBLIC_ID";
		public const String ARCHIVAL_UNIGENE_CLUSTER_FIELD  ="ARCHIVAL_UNIGENE_CLUSTER";
		public const String UNIGENE_ID_FIELD  ="UNIGENE_ID";
		public const String GENOME_VERSION_FIELD  ="GENOME_VERSION";
		public const String ALIGNMENTS_FIELD  ="ALIGNMENTS";
		public const String GENE_TITLE_FIELD  ="GENE_TITLE";
		public const String GENE_SYMBOL_FIELD  ="GENE_SYMBOL";
		public const String CHROMOSOMAL_LOCATION_FIELD  ="CHROMOSOMAL_LOCATION";
		public const String UNIGENE_CLUSTER_TYPE_FIELD  ="UNIGENE_CLUSTER_TYPE";
		public const String ENSEMBL_FIELD  ="ENSEMBL";
		public const String ENTREZ_GENE_FIELD  ="ENTREZ_GENE";
		public const String SWISSPROT_FIELD  ="SWISSPROT";
		public const String EC_FIELD  ="EC";
		public const String OMIM_FIELD  ="OMIM";
		public const String REFSEQ_PROTEIN_ID_FIELD  ="REFSEQ_PROTEIN_ID";
		public const String REFSEQ_TRANSCRIPT_ID_FIELD  ="REFSEQ_TRANSCRIPT_ID";
		public const String FLYBASE_FIELD  ="FLYBASE";
		public const String AGI_FIELD  ="AGI";
		public const String WORMBASE_FIELD  ="WORMBASE";
		public const String MGI_NAME_FIELD  ="MGI_NAME";
		public const String RGD_NAME_FIELD  ="RGD_NAME";
		public const String SGD_ACCESSION_NUMBER_FIELD  ="SGD_ACCESSION_NUMBER";
		public const String GENE_ONTOLOGY_BIOLOGICAL_PROCESS_FIELD  ="GENE_ONTOLOGY_BIOLOGICAL_PROCESS";
		public const String GENE_ONTOLOGY_CELLULAR_COMPONENT_FIELD  ="GENE_ONTOLOGY_CELLULAR_COMPONENT";
		public const String GENE_ONTOLOGY_MOLECULAR_FUNCTION_FIELD  ="GENE_ONTOLOGY_MOLECULAR_FUNCTION";
		public const String PATHWAY_FIELD  ="PATHWAY";
		public const String INTERPRO_FIELD  ="INTERPRO";
		public const String TRANS_MEMBRANE_FIELD  ="TRANS_MEMBRANE";
		public const String QTL_FIELD  ="QTL";
		public const String ANNOTATION_DESCRIPTION_FIELD  ="ANNOTATION_DESCRIPTION";
		public const String ANNOTATION_TRANSCRIPT_CLUSTER_FIELD  ="ANNOTATION_TRANSCRIPT_CLUSTER";
		public const String TRANSCRIPT_ASSIGNMENTS_FIELD  ="TRANSCRIPT_ASSIGNMENTS";
		public const String ANNOTATION_NOTES_FIELD  ="ANNOTATION_NOTES";
	}
}