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
    class Emprestimos : ISerializable
    {
        //Atributos do elemento empréstimo
        //Atributo ESTÁTICO -> que permite ter um valor comum em todas as instancias da classe
        public static int total_emprestimos = 0;

        //Propriedades do empréstimo
        protected int cod_emprestimo;
        public int cod_do_emprestimo
        {
            set { cod_emprestimo = value; }
            get { return cod_emprestimo; }
        }

        private string data_emprestimo;
        public string data_do_emprestimo
        {
            get { return data_emprestimo; }
            set
            {
                if (value == "") data_emprestimo = "N/A";
                else data_emprestimo = value;
            }
        }

        private string nome_elemento;
        public string nome_do_elemento
        {
            get { return nome_elemento; }
            set
            {
                if (value == "") nome_elemento = "N/A";
                else nome_elemento = value;
            }
        }

        private string estado_emprestimo;
        public string estado_do_emprestimo
        {
            get { return estado_emprestimo; }
            set
            {
                estado_emprestimo = value;
            }
        }

        private string data_entrega;
        public string data_da_entrega
        {
            get { return data_entrega; }
            set
            {
                if (value == "") data_entrega = "N/A";
                else data_entrega = value;
            }
        }

        private string nome_pessoa;
        public string nome_da_pessoa
        {
            get { return nome_pessoa; }
            set
            {
                if (value == "") nome_pessoa = "N/A";
                else nome_pessoa = value;
            }
        }

        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Emprestimos(string nome_elemento_emprestado, string nome_pessoa_emprestado)
        {
            total_emprestimos++;
            this.cod_do_emprestimo = total_emprestimos;
            DateTime data = DateTime.Now;
            this.data_do_emprestimo = Convert.ToString(data);
            this.nome_do_elemento = nome_elemento_emprestado;
            this.estado_do_emprestimo = "Por entregar";
            this.data_da_entrega = "N/A";
            this.nome_da_pessoa = nome_pessoa_emprestado;
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you

            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"

            // then you should read the same with "EmployeeId"

            info.AddValue("EmprestimoID", cod_emprestimo);
            info.AddValue("DataEmprestimo",data_emprestimo);
            info.AddValue("ElementoEmprestado", nome_elemento);
            info.AddValue("EstadoEmprestimo", estado_emprestimo);
            info.AddValue("DataEntregaEmprestimo", data_entrega);
            info.AddValue("PessoaEmprestada", nome_pessoa);
            info.AddValue("totalemprests", total_emprestimos);
        }

        //Deserialization constructor.
        public Emprestimos(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            cod_emprestimo = (int)info.GetValue("EmprestimoID", typeof(int));
            data_emprestimo = (string)info.GetValue("DataEmprestimo", typeof(string));
            nome_elemento = (string)info.GetValue("ElementoEmprestado", typeof(string));
            estado_emprestimo = (string)info.GetValue("EstadoEmprestimo", typeof(string));
            data_entrega = (string)info.GetValue("DataEntregaEmprestimo", typeof(string));
            nome_pessoa = (string)info.GetValue("PessoaEmprestada", typeof(string));
            total_emprestimos = (int)info.GetValue("totalemprests", typeof(int));
        }
    }
}
