using UnityEngine;
using System.Collections;
using Mono.Data;
using System.Data;


public class db_manager : MonoBehaviour {

	// Use this for initialization
	string koneksi;
	string sqlQuery;

	IDbConnection koneksi_var;
	IDbCommand dbcmd;
	IDataReader reader;
	float dbl;

	private int score;
	private int life;
	private bool lvl_1;
	private bool lvl_2;
	private bool lvl_3;
	private bool lvl_4;

	private float X_pos;
	private float Y_pos;

	void Start () 
	{
		koneksi = "URI=file:" + Application.dataPath + "/unity_database.s3db";
		koneksi_var = (IDbConnection)new SqliteConnection (koneksi);
		koneksi_var.Open ();

	

		getData ();


		//reader.Close ();
		//reader = null;
		//dbcmd.Dispose ();
		//dbcmd = null;
		//koneksi_var.Close ();
		//koneksi_var = null;
	}
	
	public void updateData (int int_val,float f_val,int index)
	{
		dbcmd = koneksi_var.CreateCommand ();
		switch (index) 
		{
			case 1 : sqlQuery = "update tabel_data set life = "+int_val;break;
			case 2 : sqlQuery = "update tabel_data set score = "+int_val;break;
			case 3 : sqlQuery = "update tabel_data set X_pos = "+f_val;break;
			case 4 : sqlQuery = "update tabel_data set Y_pos = "+f_val;break;
		    case 5 : sqlQuery = "update tabel_data set level_1 = "+int_val;break;
		    case 6 : sqlQuery = "update tabel_data set level_2 = "+int_val;break;
			case 7 : sqlQuery = "update tabel_data set level_3 = "+int_val;break;
			case 8 : sqlQuery = "update tabel_data set level_4 = "+int_val;break;
		}

		dbcmd.CommandText = sqlQuery;
		reader = dbcmd.ExecuteReader ();
	}

	public void getData ()
	{
		dbcmd = koneksi_var.CreateCommand ();
		sqlQuery = "select life,score,X_pos,Y_pos,level_1,level_2,level_3,level_4 "+"from tabel_data";
		dbcmd.CommandText = sqlQuery;
		reader = dbcmd.ExecuteReader ();
		
		while (reader.Read()) 
		{
			life = reader.GetInt32(0);
			score = reader.GetInt32(1);
			X_pos = reader.GetFloat(2);
			Y_pos = reader.GetFloat(3);
			lvl_1 = reader.GetBoolean(4);
			lvl_2 = reader.GetBoolean(5);
			lvl_3 = reader.GetBoolean(6);
			lvl_4 = reader.GetBoolean(7);
		}
	}

	public int getLife ()
	{
		getData ();
		return life;
	}

	public int getScore ()
	{
		getData ();
		return score;
	}

	public bool getLvl1()
	{
		getData ();
		return lvl_1;
	}

	public bool getLvl2()
	{
		getData ();
		return lvl_2;
	}

	public bool getLvl3()
	{
		getData ();
		return lvl_3;
	}

	public bool getLvl4()
	{
		getData ();
		return lvl_4;
	}

	public float getX_pos ()
	{
		getData ();
		return X_pos;
	}

	public float getY_pos ()
	{
		getData ();
		return Y_pos;
	}
	
}
