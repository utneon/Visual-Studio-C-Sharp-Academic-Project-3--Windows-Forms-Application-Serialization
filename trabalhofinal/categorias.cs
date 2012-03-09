using System;
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

    class Categoria : ISerializable
    {
        //Atributos da classe categoria
        //Atributo ESTÁTICO -> que permite ter um valor comum em todas as instancias da classe
        public static int total_categorias = 0;

        //Propriedades da categoria
        private int cod_categoria;
        public int cod_da_categoria
        {
            set { cod_categoria = value; }
            get { return cod_categoria; }
        }

        private string nome_categoria;
        public string nome_da_categoria
        {
            set { nome_categoria = value; }
            get { return nome_categoria; }
        }

        private string tipo_categoria;
        public string tipo_da_categoria
        {
            set { tipo_categoria = value; }
            get { return tipo_categoria; }
        }

        //tipos:
        //1:filme
        //2:musica
        //3:fotografia

        /// <summary>
        /// Construtor único da categoria 
        /// </summary>
        public Categoria(string nome_categoria_par,string tipo)
        {
            total_categorias++;
            this.cod_da_categoria = total_categorias;
            this.nome_da_categoria = nome_categoria_par;
            this.tipo_da_categoria = tipo;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you

            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"

            // then you should read the same with "EmployeeId"

            info.AddValue("CategoriaId", cod_categoria);
            info.AddValue("NomeCategoria", nome_categoria);
            info.AddValue("TipoCategoria", tipo_categoria);
            info.AddValue("IDtotalCategoria", total_categorias);
        }

        //Deserialization constructor.

        public Categoria(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            cod_categoria = (int)info.GetValue("CategoriaId", typeof(int));
            nome_categoria = (string)info.GetValue("NomeCategoria", typeof(string));
            tipo_categoria = (string)info.GetValue("TipoCategoria", typeof(string));
            total_categorias=(int)info.GetValue("IDtotalCategoria",typeof(int));
        }
    }
}
