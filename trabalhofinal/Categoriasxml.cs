using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace tfinal
{
    [Serializable()]

    class Database : ISerializable
    {
        public ArrayList db_filmes;
        public ArrayList db_musicas;
        public ArrayList db_fotografias;
        public ArrayList db_categorias;
        public ArrayList db_emprestimos;
        public int avisos_conclusao = 1;
        public string nome_da_base_de_dados;

        /// <summary>
        /// Construtor único da categoria 
        /// </summary>
        public Database(string nome_base_dados)
        {
            db_filmes = new ArrayList();
            db_musicas = new ArrayList();
            db_fotografias = new ArrayList();
            db_categorias = new ArrayList();
            db_emprestimos = new ArrayList();
            this.nome_da_base_de_dados=nome_base_dados;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("DBfilmes", db_filmes);
            info.AddValue("DBmusicas", db_musicas);
            info.AddValue("DBfotografias", db_fotografias);
            info.AddValue("DBcategorias", db_categorias);
            info.AddValue("DBemprestimos", db_emprestimos);
            info.AddValue("NomeBaseDeDados",nome_da_base_de_dados);
            info.AddValue("Preferences1", avisos_conclusao);
        }

        //Deserialization constructor.
        public Database(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            db_filmes = (ArrayList)info.GetValue("DBfilmes", typeof(ArrayList));
            db_musicas = (ArrayList)info.GetValue("DBmusicas", typeof(ArrayList));
            db_fotografias = (ArrayList)info.GetValue("DBfotografias", typeof(ArrayList));
            db_categorias = (ArrayList)info.GetValue("DBcategorias", typeof(ArrayList));
            db_emprestimos = (ArrayList)info.GetValue("DBemprestimos", typeof(ArrayList));
            nome_da_base_de_dados = (String)info.GetValue("NomeBaseDeDados", typeof(string));
            avisos_conclusao = (int)info.GetValue("Preferences1", typeof(int));
        }
    }
}