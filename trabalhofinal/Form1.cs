using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace tfinal
{
    public partial class Form1 : Form
    {   
        //ArrayLists Serializadas e outros dados serializados:
        public ArrayList lista_filmes = new ArrayList();
        public ArrayList lista_musicas = new ArrayList();
        public ArrayList lista_fotografias = new ArrayList();
        public ArrayList lista_categorias = new ArrayList();
        public ArrayList lista_emprestimos = new ArrayList();
        public int preferences_1 = 1;

        //end of arraylists serializadas

        public ArrayList lista_de_filmes_encontrados = new ArrayList();
        public ArrayList lista_de_musicas_encontradas = new ArrayList();
        public ArrayList lista_de_fotografias_encontradas = new ArrayList();

        string[] lista_categorias_em_combo_box_filmes;

        //Objectos temporários de comparação deverá desactivar estas variáveis se não usar o serialize
        //Desactive o seguinte bloco se não usar o serialize
        ///////////////////////////////////////////////////////////////////
        
        Categoria categoria_teste_1;
        Emprestimos emprestimo_teste_1;
        Filme filme_teste_1;
        Music musica_teste_1;
        Fotografia foto_teste_1;
        
        ///////////////////////////////////////////////////////////////////
         
         

        //alguns objectos criados para efeitos de teste - o serialize deve estar desactivado para usar isto
        //desctive o seguinte bloco se usar o serialize
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
        Fotografia foto_teste_1 = new Fotografia("SDC.JPEG", "C:/fotografias", "Férias", "Férias 2010", "");
        Fotografia foto_teste_2 = new Fotografia("turma_2001.JPEG", "C:/fotografias", "Pessoas", "Fotografias 2001", "A fotografia da turma");
        Music musica_teste_1 = new Music("Neutron Star Collision", "C:/music/muse/resistance/", "Alternative Rock", "Muse", "Resistance");
        Filme filme_teste_1 = new Filme("Matrix", "c:/DVD/", "Action", "2h10m", "O neo tenta salvar o mundo", "2000", "Paulo Carvalho");
        Filme filme_teste_2 = new Filme("Matrix 2", "DVD #55", "Action", "1h30m", "Descrição do Matrix 2", "2001", "Paulo Carvalho");
        Filme filme_teste_3 = new Filme("Tony Mendes Biography", "c:/DVD/", "Romance", "0h10m", "O tony mendes está a tirar o curso no isec e vai ser programador.", "2011", "Tony mendes");
        Categoria categoria_teste_1 = new Categoria("Action","Filmes");
        Categoria categoria_teste_2 = new Categoria("Alternative Rock","Musicas");
        Categoria categoria_teste_3 = new Categoria("Férias","Fotografias");
        Categoria categoria_teste_4 = new Categoria("Romance", "Filmes");
        Categoria categoria_teste_5 = new Categoria("Terror", "Filmes");
        Categoria categoria_teste_6 = new Categoria("Pessoas", "Fotografias");
        Emprestimos emprestimo_teste_1 = new Emprestimos("E1", "Pedro Reis");
        Emprestimos emprestimo_teste_2 = new Emprestimos("E2", "Paulo Carvalho");
        Emprestimos emprestimo_teste_3 = new Emprestimos("E3", "Rui Santos");
         */
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         

        public void iniciar_arraylist()
        {
            //Desactive o seguinte bloco se usar o serialize
            //////////////////////////////////////////////////////////
            /*
            lista_fotografias.Add(foto_teste_1);
            lista_fotografias.Add(foto_teste_2);
            lista_musicas.Add(musica_teste_1);
            lista_filmes.Add(filme_teste_1);
            lista_filmes.Add(filme_teste_2);
            lista_filmes.Add(filme_teste_3);
            lista_categorias.Add(categoria_teste_1);
            lista_categorias.Add(categoria_teste_2);
            lista_categorias.Add(categoria_teste_3);
            lista_categorias.Add(categoria_teste_4);
            lista_categorias.Add(categoria_teste_5);
            lista_categorias.Add(categoria_teste_6);
            lista_emprestimos.Add(emprestimo_teste_1);
            lista_emprestimos.Add(emprestimo_teste_2);
            lista_emprestimos.Add(emprestimo_teste_3);
            */
            //////////////////////////////////////////////////////////
            
            //Active a linha abaixo se usar o serialize
            load_data_deserialize_database();
        }

        public void load_data_deserialize_database()
        {
            //Open the file written above and read values from it.
            Stream stream = File.Open("database.dat", FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            Database ut_database;
            ut_database = (Database)bformatter.Deserialize(stream);
            stream.Close();

            lista_categorias = ut_database.db_categorias;
            lista_emprestimos = ut_database.db_emprestimos;
            lista_filmes = ut_database.db_filmes;
            lista_musicas = ut_database.db_musicas;
            lista_categorias = ut_database.db_categorias;
            lista_fotografias = ut_database.db_fotografias;
            preferences_1 = ut_database.avisos_conclusao;
        }

        void delete(int qual_vai_apagar)
        {
            //get the index of the selected Item, same index in the ArrayList
            int intIndex;

            if (qual_vai_apagar == 1)
            {
                intIndex = data_grid_1.CurrentCell.RowIndex;

                try
                { 
                    filme_teste_1 = (Filme)lista_filmes[intIndex];
                    lista_filmes.Remove(filme_teste_1);
                    data_grid_1.DataSource = null;
                    data_grid_1.Refresh();
                    data_grid_1.DataSource = lista_filmes;
                    data_grid_1.Refresh();
                    data_grid_1.Columns[0].Visible = false;
                    data_grid_1.Columns[1].Visible = false;
                    data_grid_1.Columns[2].Visible = false;
                    data_grid_1.Columns[3].Visible = false;
                    data_grid_1.Columns[7].Visible = false;
                    data_grid_1.Columns[8].Visible = false;
                    data_grid_1.Columns[4].HeaderText = "ID";
                    data_grid_1.Columns[5].HeaderText = "Titulo";
                    data_grid_1.Columns[6].HeaderText = "Categoria";
                    data_grid_1.ReadOnly = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            else if (qual_vai_apagar == 2)
            {
                intIndex = data_grid_categorias1.CurrentCell.RowIndex;

                try
                {
                    categoria_teste_1 = (Categoria)lista_categorias[intIndex];
                    lista_categorias.Remove(categoria_teste_1);
                    data_grid_categorias1.DataSource = null;
                    data_grid_categorias1.Refresh();
                    data_grid_categorias1.DataSource = lista_categorias;
                    data_grid_categorias1.Refresh();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            else if (qual_vai_apagar == 3)
            {
                intIndex = data_grid_musicas.CurrentCell.RowIndex;
                try
                {
                    musica_teste_1 = (Music)lista_musicas[intIndex];
                    lista_musicas.Remove(musica_teste_1);
                    data_grid_musicas.DataSource = null;
                    data_grid_musicas.Refresh();
                    data_grid_musicas.DataSource = lista_musicas;
                    data_grid_musicas.Refresh();
                    data_grid_musicas.Columns[0].Visible = true;
                    data_grid_musicas.Columns[0].HeaderText = "Artista";
                    data_grid_musicas.Columns[1].Visible = true;
                    data_grid_musicas.Columns[1].HeaderText = "Album";
                    data_grid_musicas.Columns[2].Visible = false;
                    data_grid_musicas.Columns[2].HeaderText = "ID";
                    data_grid_musicas.Columns[3].Visible = true;
                    data_grid_musicas.Columns[3].HeaderText = "Título";
                    data_grid_musicas.Columns[4].Visible = true;
                    data_grid_musicas.Columns[4].HeaderText = "Categoria";
                    data_grid_musicas.Columns[5].Visible = false;
                    data_grid_musicas.Columns[5].HeaderText = "Storage";
                    data_grid_musicas.Columns[6].Visible = false;
                    data_grid_musicas.Columns[6].HeaderText = "Data";

                    data_grid_musicas.ReadOnly = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            else if (qual_vai_apagar == 4)
            {
                intIndex = data_grid_fotografias.CurrentCell.RowIndex;
                try
                {
                    foto_teste_1 = (Fotografia)lista_fotografias[intIndex];
                    lista_fotografias.Remove(foto_teste_1);
                    data_grid_fotografias.DataSource = null;
                    data_grid_fotografias.Refresh();
                    data_grid_fotografias.DataSource = lista_fotografias;
                    data_grid_fotografias.Refresh();

                    data_grid_fotografias.Columns[0].Visible = true;
                    data_grid_fotografias.Columns[0].HeaderText = "Album";
                    data_grid_fotografias.Columns[1].Visible = false;
                    data_grid_fotografias.Columns[1].HeaderText = "Descrição";
                    data_grid_fotografias.Columns[2].Visible = true;
                    data_grid_fotografias.Columns[2].HeaderText = "ID";
                    data_grid_fotografias.Columns[3].Visible = true;
                    data_grid_fotografias.Columns[3].HeaderText = "Ficheiro";
                    data_grid_fotografias.Columns[4].Visible = true;
                    data_grid_fotografias.Columns[4].HeaderText = "Categoria";
                    data_grid_fotografias.Columns[5].Visible = false;
                    data_grid_fotografias.Columns[5].HeaderText = "Storage";
                    data_grid_fotografias.Columns[6].Visible = false;
                    data_grid_fotografias.Columns[6].HeaderText = "Data";

                    data_grid_fotografias.ReadOnly = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            iniciar_arraylist();
            actualizar_comboboxes();

            /************************************Filmes************************************/
            //We need to add next line of code cause
            //if we don't, every time we add new Address will not
            //apear in the DataGrid
            data_grid_1.DataSource = null;
            data_grid_1.Refresh();

            // Set the DataGrid DataSource to our ArrayList
            // then refresh it
            data_grid_1.DataSource = lista_filmes;
            data_grid_1.Refresh();

            data_grid_1.Columns[0].Visible = false;
            data_grid_1.Columns[1].Visible = false;
            data_grid_1.Columns[2].Visible = false;
            data_grid_1.Columns[3].Visible = false;
            data_grid_1.Columns[7].Visible = false;
            data_grid_1.Columns[8].Visible = false;
            data_grid_1.Columns[4].HeaderText = "ID";
            data_grid_1.Columns[5].HeaderText = "Titulo";
            data_grid_1.Columns[6].HeaderText = "Categoria";
            data_grid_1.ReadOnly = true;
            /************************************Filmes************************************/

            /**********************************Categorias**********************************/
            data_grid_categorias1.DataSource = null;
            data_grid_categorias1.Refresh();
            data_grid_categorias1.DataSource = lista_categorias;
            data_grid_categorias1.Refresh();

            data_grid_categorias1.Columns[0].Visible = true;
            data_grid_categorias1.Columns[0].HeaderText = "ID";
            data_grid_categorias1.Columns[1].Visible = true;
            data_grid_categorias1.Columns[1].HeaderText = "Titulo";
            data_grid_categorias1.Columns[2].Visible = true;
            data_grid_categorias1.Columns[2].HeaderText = "Categoria";

            data_grid_categorias1.Columns[0].ReadOnly = true;
            data_grid_categorias1.Columns[1].ReadOnly = true;
            data_grid_categorias1.Columns[2].ReadOnly = true;
            /**********************************Categorias**********************************/

            /***********************************Musicas************************************/
            data_grid_musicas.DataSource = null;
            data_grid_musicas.Refresh();
            data_grid_musicas.DataSource = lista_musicas;
            data_grid_musicas.Refresh();

            data_grid_musicas.Columns[0].Visible = true;
            data_grid_musicas.Columns[0].HeaderText = "Artista";
            data_grid_musicas.Columns[1].Visible = true;
            data_grid_musicas.Columns[1].HeaderText = "Album";
            data_grid_musicas.Columns[2].Visible = false;
            data_grid_musicas.Columns[2].HeaderText = "ID";
            data_grid_musicas.Columns[3].Visible = true;
            data_grid_musicas.Columns[3].HeaderText = "Título";
            data_grid_musicas.Columns[4].Visible = true;
            data_grid_musicas.Columns[4].HeaderText = "Categoria";
            data_grid_musicas.Columns[5].Visible = false;
            data_grid_musicas.Columns[5].HeaderText = "Storage";
            data_grid_musicas.Columns[6].Visible = false;
            data_grid_musicas.Columns[6].HeaderText = "Data";

            data_grid_musicas.ReadOnly = true;
            /***********************************Musicas************************************/

            /*********************************Fotografias**********************************/
            data_grid_fotografias.DataSource = null;
            data_grid_fotografias.Refresh();
            data_grid_fotografias.DataSource = lista_fotografias;
            data_grid_fotografias.Refresh();

            data_grid_fotografias.Columns[0].Visible = true;
            data_grid_fotografias.Columns[0].HeaderText = "Album";
            data_grid_fotografias.Columns[1].Visible = false;
            data_grid_fotografias.Columns[1].HeaderText = "Descrição";
            data_grid_fotografias.Columns[2].Visible = true;
            data_grid_fotografias.Columns[2].HeaderText = "ID";
            data_grid_fotografias.Columns[3].Visible = true;
            data_grid_fotografias.Columns[3].HeaderText = "Ficheiro";
            data_grid_fotografias.Columns[4].Visible = true;
            data_grid_fotografias.Columns[4].HeaderText = "Categoria";
            data_grid_fotografias.Columns[5].Visible = false;
            data_grid_fotografias.Columns[5].HeaderText = "Storage";
            data_grid_fotografias.Columns[6].Visible = false;
            data_grid_fotografias.Columns[6].HeaderText = "Data";

            data_grid_fotografias.ReadOnly = true;
            /*********************************Fotografias**********************************/

            /*********************************Empréstimos**********************************/
            data_grid_emprestimos.DataSource = null;
            data_grid_emprestimos.Refresh();
            data_grid_emprestimos.DataSource = lista_emprestimos;
            data_grid_emprestimos.Refresh();
            data_grid_emprestimos.ReadOnly = true;
            data_grid_emprestimos.Columns[0].Visible = false;
            data_grid_emprestimos.Columns[0].HeaderText = "ID";
            data_grid_emprestimos.Columns[1].Visible = true;
            data_grid_emprestimos.Columns[1].HeaderText = "Data";
            data_grid_emprestimos.Columns[2].Visible = true;
            data_grid_emprestimos.Columns[2].HeaderText = "Elemento Emprestado";
            data_grid_emprestimos.Columns[3].Visible = true;
            data_grid_emprestimos.Columns[3].HeaderText = "Estado";
            data_grid_emprestimos.Columns[4].Visible = true;
            data_grid_emprestimos.Columns[4].HeaderText = "Devolvido em";
            data_grid_emprestimos.Columns[5].Visible = true;
            data_grid_emprestimos.Columns[5].HeaderText = "Requisitado por";
            /*********************************Empréstimos**********************************/
        }

        private void apagar_filme_selecionado(object sender, EventArgs e)
        {
            try
            {
                delete(1);
                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void limpar_campos(int qual_campos_apagar)
        {
            if (qual_campos_apagar == 1)
            {
                nome_filme_textbox.Text = "";
                loc_filme_textbox.Text = ""; categoria_filme_textbox.Text = ""; dur_filme_textbox.Text = ""; sinopse_filme_textbox.Text = ""; ano_filme_textbox.Text = ""; realizador_filme_textbox.Text = "";
            }
            else if (qual_campos_apagar == 2)
            {
                nome_categoria_filme_textbox.Text = "";
                tipo_categoria_comboBox.Text = "";
            }
            else if (qual_campos_apagar == 3)
            {
                nome_musica_textbox.Text = "";
                loc_musica_textbox.Text = "";
                artista_musica_textbox.Text = "";
                album_musica_textbox.Text = "";
                categoria_musica_combobox.Text = "";
            }
            else if (qual_campos_apagar == 4)
            {
                nome_fotografia_textbox.Text = "";
                loc_fotografia_combobox.Text = "";
                album_fotografia_textbox.Text = "";
                categoria_fotografia_combobox.Text = "";
                descricao_fotografia_textbox.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nome_filme_textbox.Text == "" || loc_filme_textbox.Text=="" || categoria_filme_textbox.Text=="" || dur_filme_textbox.Text=="" || sinopse_filme_textbox.Text=="" ||ano_filme_textbox.Text=="" || realizador_filme_textbox.Text=="")
            {
                aviso_campos_por_preencher aviso = new aviso_campos_por_preencher();
                aviso.ShowDialog();
            }
            else
            {
                Filme filme_a_adicionar = new Filme(nome_filme_textbox.Text, loc_filme_textbox.Text, categoria_filme_textbox.Text, dur_filme_textbox.Text, sinopse_filme_textbox.Text, ano_filme_textbox.Text, realizador_filme_textbox.Text);
                limpar_campos(1);
                lista_filmes.Add(filme_a_adicionar);
                data_grid_1.DataSource = null;
                data_grid_1.DataSource = lista_filmes;
                data_grid_1.Refresh();
                data_grid_1.Columns[0].Visible = false;
                data_grid_1.Columns[1].Visible = false;
                data_grid_1.Columns[2].Visible = false;
                data_grid_1.Columns[3].Visible = false;
                data_grid_1.Columns[7].Visible = false;
                data_grid_1.Columns[8].Visible = false;
                data_grid_1.Columns[4].HeaderText = "ID";
                data_grid_1.Columns[5].HeaderText = "Titulo";
                data_grid_1.Columns[6].HeaderText = "Categoria";
                data_grid_1.ReadOnly = true;
                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nome_categoria_filme_textbox.Text=="" || tipo_categoria_comboBox.Text=="")
            {
                aviso_campos_por_preencher aviso = new aviso_campos_por_preencher();
                aviso.ShowDialog();
            }
            else if (tipo_categoria_comboBox.Text != "Filmes" && tipo_categoria_comboBox.Text != "Fotografias" && tipo_categoria_comboBox.Text != "Musicas")
                {
                    categoria_invalida aviso = new categoria_invalida();
                    aviso.ShowDialog();
                }
            else
            {
                Categoria categoria_a_adicionar = new Categoria(nome_categoria_filme_textbox.Text, tipo_categoria_comboBox.Text);
                limpar_campos(2);
                lista_categorias.Add(categoria_a_adicionar);
                data_grid_categorias1.DataSource = null;
                data_grid_categorias1.DataSource = lista_categorias;
                data_grid_categorias1.Refresh();
                actualizar_comboboxes();

                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
        }

        static string[] converter_arraylist_para_combo_box(ArrayList lista, string tipo)
        {
            string[] lista_categorias;
            int contador = 0;
            foreach (Categoria objecto in lista)
                {
                    if (objecto.tipo_da_categoria == tipo)
                    contador++;
                }
            lista_categorias = new string[contador];
            contador = 0;
            foreach (Categoria objecto in lista)
                {
                    if (objecto.tipo_da_categoria == tipo)
                    {
                        lista_categorias[contador] = objecto.nome_da_categoria;
                        contador++;
                    }
                } 
            return lista_categorias;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                delete(3);
                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (nome_musica_textbox.Text=="" || artista_musica_textbox.Text=="" || album_musica_textbox.Text=="" || categoria_musica_combobox.Text=="" || loc_musica_textbox.Text=="")
            {
                aviso_campos_por_preencher aviso = new aviso_campos_por_preencher();
                aviso.ShowDialog();
            }
            else
            {
                Music musica_a_adicionar = new Music(nome_musica_textbox.Text, loc_musica_textbox.Text, categoria_musica_combobox.Text, artista_musica_textbox.Text, album_musica_textbox.Text);
                limpar_campos(3);
                lista_musicas.Add(musica_a_adicionar);
                data_grid_musicas.DataSource = null;
                data_grid_musicas.DataSource = lista_musicas;
                data_grid_musicas.Refresh();
                data_grid_musicas.Columns[0].Visible = true;
                data_grid_musicas.Columns[0].HeaderText = "Artista";
                data_grid_musicas.Columns[1].Visible = true;
                data_grid_musicas.Columns[1].HeaderText = "Album";
                data_grid_musicas.Columns[2].Visible = false;
                data_grid_musicas.Columns[2].HeaderText = "ID";
                data_grid_musicas.Columns[3].Visible = true;
                data_grid_musicas.Columns[3].HeaderText = "Título";
                data_grid_musicas.Columns[4].Visible = true;
                data_grid_musicas.Columns[4].HeaderText = "Categoria";
                data_grid_musicas.Columns[5].Visible = false;
                data_grid_musicas.Columns[5].HeaderText = "Storage";
                data_grid_musicas.Columns[6].Visible = false;
                data_grid_musicas.Columns[6].HeaderText = "Data";

                data_grid_musicas.ReadOnly = true;

                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
        }

        private void tipo_categoria_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void actualizar_comboboxes()
        {
            lista_categorias_em_combo_box_filmes = converter_arraylist_para_combo_box(lista_categorias, "Filmes");
            categoria_filme_textbox.DataSource = lista_categorias_em_combo_box_filmes;
            filtro_filmes_categorias.DataSource = lista_categorias_em_combo_box_filmes;

            lista_categorias_em_combo_box_filmes = converter_arraylist_para_combo_box(lista_categorias, "Musicas");
            categoria_musica_combobox.DataSource = lista_categorias_em_combo_box_filmes;
            filtro_musicas_categorias.DataSource = lista_categorias_em_combo_box_filmes;
            
            lista_categorias_em_combo_box_filmes = converter_arraylist_para_combo_box(lista_categorias, "Fotografias");
            categoria_fotografia_combobox.DataSource = lista_categorias_em_combo_box_filmes;
            filtro_fotografias_categoria.DataSource = lista_categorias_em_combo_box_filmes;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (nome_fotografia_textbox.Text=="" || loc_fotografia_combobox.Text=="" || categoria_fotografia_combobox.Text=="" || album_fotografia_textbox.Text=="")
            {
                aviso_campos_por_preencher aviso = new aviso_campos_por_preencher();
                aviso.ShowDialog();
            }
            else
            {
                Fotografia fotografia_a_adicionar = new Fotografia(nome_fotografia_textbox.Text, loc_fotografia_combobox.Text, categoria_fotografia_combobox.Text, album_fotografia_textbox.Text, descricao_fotografia_textbox.Text);
                limpar_campos(4);
                lista_fotografias.Add(fotografia_a_adicionar);
                data_grid_fotografias.DataSource = null;
                data_grid_fotografias.DataSource = lista_fotografias;
                data_grid_fotografias.Refresh();
                data_grid_fotografias.Columns[0].Visible = true;
                data_grid_fotografias.Columns[0].HeaderText = "Album";
                data_grid_fotografias.Columns[1].Visible = false;
                data_grid_fotografias.Columns[1].HeaderText = "Descrição";
                data_grid_fotografias.Columns[2].Visible = true;
                data_grid_fotografias.Columns[2].HeaderText = "ID";
                data_grid_fotografias.Columns[3].Visible = true;
                data_grid_fotografias.Columns[3].HeaderText = "Ficheiro";
                data_grid_fotografias.Columns[4].Visible = true;
                data_grid_fotografias.Columns[4].HeaderText = "Categoria";
                data_grid_fotografias.Columns[5].Visible = false;
                data_grid_fotografias.Columns[5].HeaderText = "Storage";
                data_grid_fotografias.Columns[6].Visible = false;
                data_grid_fotografias.Columns[6].HeaderText = "Data";

                data_grid_fotografias.ReadOnly = true;

                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                delete(4);
                if (preferences_1 == 1)
                {
                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                    aviso_alteracao.ShowDialog();
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void entregar_emprestimo(object sender, EventArgs e)
        {
            try
            {
                //get the index of the selected Item, same index in the ArrayList
                int intIndex;
                intIndex = data_grid_emprestimos.CurrentCell.RowIndex;
                aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();

                try
                {
                    //casting the
                    emprestimo_teste_1 = (Emprestimos)lista_emprestimos[intIndex];
                    foreach (Emprestimos objecto in lista_emprestimos)
                    {
                        if (objecto.cod_do_emprestimo == emprestimo_teste_1.cod_do_emprestimo)
                        {
                            objecto.estado_do_emprestimo = "Entregue";
                            DateTime data = DateTime.Now;
                            objecto.data_da_entrega = Convert.ToString(data);
                            foreach (Filme filmez in lista_filmes)
                            {
                                if (objecto.nome_do_elemento == filmez.nome_do_elemento)
                                {
                                    filmez.estado_emprestimo_do_elemento = 0;
                                    if (preferences_1 == 1)
                                    {
                                        aviso_alteracao.ShowDialog();
                                    }
                                }
                            }
                        }
                    }

                    // Must be Inserted or an error will be occured
                    data_grid_emprestimos.DataSource = null;
                    data_grid_emprestimos.Refresh();

                    // Define the DataGrid DataSource then refresh it
                    data_grid_emprestimos.DataSource = lista_emprestimos;
                    data_grid_emprestimos.Refresh();
                    data_grid_emprestimos.Columns[0].Visible = false;
                    data_grid_emprestimos.Columns[0].HeaderText = "ID";
                    data_grid_emprestimos.Columns[1].Visible = true;
                    data_grid_emprestimos.Columns[1].HeaderText = "Data";
                    data_grid_emprestimos.Columns[2].Visible = true;
                    data_grid_emprestimos.Columns[2].HeaderText = "Elemento Emprestado";
                    data_grid_emprestimos.Columns[3].Visible = true;
                    data_grid_emprestimos.Columns[3].HeaderText = "Estado";
                    data_grid_emprestimos.Columns[4].Visible = true;
                    data_grid_emprestimos.Columns[4].HeaderText = "Devolvido em";
                    data_grid_emprestimos.Columns[5].Visible = true;
                    data_grid_emprestimos.Columns[5].HeaderText = "Requisitado por";
                    aviso_alteracao.ShowDialog();
                }
                catch (Exception)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void emprestar_elemento(object sender, EventArgs e)
        {
            try
            {
                emprestar_elemento_funcao("Filmes");
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void emprestar_elemento_funcao(string tipo_de_elemento)
        {
            if (tipo_de_elemento == "Filmes")
            {
                //get the index of the selected Item, same index in the ArrayList
                int intIndex;
                intIndex = data_grid_1.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    filme_teste_1 = (Filme)lista_filmes[intIndex];
                    foreach (Filme objecto in lista_filmes)
                    {
                        if (objecto.cod_do_elemento == filme_teste_1.cod_do_elemento)
                        {
                            if (objecto.estado_emprestimo_do_elemento == 0)
                                {
                                    objecto.estado_emprestimo_do_elemento = 1;
                                    Emprestimos emprestimo = new Emprestimos(objecto.nome_do_elemento, pessoa_emprestimo_textbox.Text);
                                    lista_emprestimos.Add(emprestimo);
                                    pessoa_emprestimo_textbox.Text = "";
                                    if (preferences_1 == 1)
                                    {
                                        aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                                        aviso_alteracao.ShowDialog();
                                    }
                                }
                            else if (objecto.estado_emprestimo_do_elemento == 1)
                                {
                                    aviso_duplicacao aviso = new aviso_duplicacao();
                                    aviso.ShowDialog();
                                }
                        }
                    }

                    // Must be Inserted or an error will be occured
                    data_grid_emprestimos.DataSource = null;
                    data_grid_emprestimos.Refresh();

                    // Define the DataGrid DataSource then refresh it
                    data_grid_emprestimos.DataSource = lista_emprestimos;
                    data_grid_emprestimos.Refresh();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            else if (tipo_de_elemento == "devolver_filme")
            {
                //get the index of the selected Item, same index in the ArrayList
                int intIndex;
                intIndex = data_grid_1.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    filme_teste_1 = (Filme)lista_filmes[intIndex];
                    foreach (Filme objecto in lista_filmes)
                    {
                        if (objecto.cod_do_elemento == filme_teste_1.cod_do_elemento)
                        {
                            if (objecto.estado_emprestimo_do_elemento == 1)
                            {
                                objecto.estado_emprestimo_do_elemento = 0;
                                if (preferences_1 == 1)
                                {
                                    aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                                    aviso_alteracao.ShowDialog();
                                }
                            }
                            else if (objecto.estado_emprestimo_do_elemento == 0)
                            {
                                aviso_alteracao_emprestimo_elemento_ja_por_emprestar aviso_alteracao = new aviso_alteracao_emprestimo_elemento_ja_por_emprestar();
                                aviso_alteracao.ShowDialog();
                            }
                        }
                    }

                    // Must be Inserted or an error will be occured
                    data_grid_emprestimos.DataSource = null;
                    data_grid_emprestimos.Refresh();

                    // Define the DataGrid DataSource then refresh it
                    data_grid_emprestimos.DataSource = lista_emprestimos;
                    data_grid_emprestimos.Refresh();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
        }

        private void devolver_filme_1(object sender, EventArgs e)
        {
            try
            {
                emprestar_elemento_funcao("devolver_filme");
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void detalhes_filme(object sender, EventArgs e)
        {
            try
            {
                int intIndex;
                intIndex = data_grid_1.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    filme_teste_1 = (Filme)lista_filmes[intIndex];
                    foreach (Filme objecto in lista_filmes)
                    {
                        if (objecto.cod_do_elemento == filme_teste_1.cod_do_elemento)
                        {
                            string detalhes = objecto.mostrar_dados_elemento();
                            detalhes_filme_textbox.Text = detalhes;
                        }
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void detalhes_filme_search_filter(object sender, EventArgs e)
        {
            try
            {
                int intIndex;
                intIndex = data_grid_search_filmes.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    filme_teste_1 = (Filme)lista_de_filmes_encontrados[intIndex];
                    foreach (Filme objecto in lista_de_filmes_encontrados)
                    {
                        if (objecto.cod_do_elemento == filme_teste_1.cod_do_elemento)
                        {
                            string detalhes = objecto.mostrar_dados_elemento();
                            detalhes_search_filmes_textbox.Text = detalhes;
                        }
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void editar_filmes(object sender, EventArgs e)
        {
            data_grid_1.DataSource = null;
            data_grid_1.Refresh();
            data_grid_1.DataSource = lista_filmes;
            data_grid_1.Refresh();
            data_grid_1.Columns[0].HeaderText = "Duração";
            data_grid_1.Columns[1].HeaderText = "Sinopse";
            data_grid_1.Columns[2].HeaderText = "Ano";
            data_grid_1.Columns[3].HeaderText = "Realizador";
            data_grid_1.Columns[4].HeaderText = "ID";
            data_grid_1.Columns[5].HeaderText = "Titulo";
            data_grid_1.Columns[6].HeaderText = "Categoria";
            data_grid_1.Columns[7].HeaderText = "Storage";
            data_grid_1.Columns[8].HeaderText = "Data";
            data_grid_1.ReadOnly = false;
            button1.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            button2.Visible = false;
            pessoa_emprestimo_textbox.Visible = false;
            detalhes_filme_textbox.Visible = false;
            nome_filme_textbox.Visible = false;
            loc_filme_textbox.Visible = false;
            categoria_filme_textbox.Visible = false;
            dur_filme_textbox.Visible = false;
            ano_filme_textbox.Visible = false;
            realizador_filme_textbox.Visible = false;
            sinopse_filme_textbox.Visible = false;

            data_grid_1.Width = 730;
            data_grid_1.Height = 350;
            //data_grid_1.Width = 462;
            //data_grid_1.Height = 181;
            data_grid_1.Dock = (DockStyle.Top);
            //data_grid_1.Dock = (DockStyle.None);

        }

        private void guardar_modificacoes_filmes(object sender, EventArgs e)
        {
            data_grid_1.Columns[0].Visible = false;
            data_grid_1.Columns[1].Visible = false;
            data_grid_1.Columns[2].Visible = false;
            data_grid_1.Columns[3].Visible = false;
            data_grid_1.Columns[7].Visible = false;
            data_grid_1.Columns[8].Visible = false;
            data_grid_1.Columns[4].HeaderText = "ID";
            data_grid_1.Columns[5].HeaderText = "Titulo";
            data_grid_1.Columns[6].HeaderText = "Categoria";
            data_grid_1.ReadOnly = true;

            button1.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            button2.Visible = true;
            pessoa_emprestimo_textbox.Visible = true;
            detalhes_filme_textbox.Visible = true;
            nome_filme_textbox.Visible = true;
            loc_filme_textbox.Visible = true;
            categoria_filme_textbox.Visible = true;
            dur_filme_textbox.Visible = true;
            ano_filme_textbox.Visible = true;
            realizador_filme_textbox.Visible = true;
            sinopse_filme_textbox.Visible = true;

            data_grid_1.Width = 462;
            data_grid_1.Height = 181;
            data_grid_1.Dock = (DockStyle.None);
            if (preferences_1 == 1)
            {
                aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                aviso_alteracao.ShowDialog();
            }
        }

        private void detalhes_musica(object sender, EventArgs e)
        {
            try
            {
                int intIndex;
                intIndex = data_grid_musicas.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    musica_teste_1 = (Music)lista_musicas[intIndex];
                    foreach (Music objecto in lista_musicas)
                    {
                        if (objecto.cod_do_elemento == musica_teste_1.cod_do_elemento)
                        {
                            string detalhes = objecto.mostrar_dados_elemento();
                            detalhes_musicas_textbox.Text = detalhes;
                        }
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void detalhes_musica_search_filter(object sender, EventArgs e)
        {
            try
            {
                int intIndex;
                intIndex = data_grid_search_musicas.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    musica_teste_1 = (Music)lista_de_musicas_encontradas[intIndex];
                    foreach (Music objecto in lista_de_musicas_encontradas)
                    {
                        if (objecto.cod_do_elemento == musica_teste_1.cod_do_elemento)
                        {
                            string detalhes = objecto.mostrar_dados_elemento();
                            detalhes_search_musicas_textbox.Text = detalhes;
                        }
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void detalhes_fotografia(object sender, EventArgs e)
        {
            try
            {
                int intIndex;
                intIndex = data_grid_fotografias.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    foto_teste_1 = (Fotografia)lista_fotografias[intIndex];
                    foreach (Fotografia objecto in lista_fotografias)
                    {
                        if (objecto.cod_do_elemento == foto_teste_1.cod_do_elemento)
                        {
                            string detalhes = objecto.mostrar_dados_elemento();
                            detalhes_fotografias_textbox.Text = detalhes;
                        }
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void detalhes_fotografia_search_filter(object sender, EventArgs e)
        {
            try
            {
                int intIndex;
                intIndex = data_grid_search_fotografias.CurrentCell.RowIndex;

                try
                {
                    //casting the
                    foto_teste_1 = (Fotografia)lista_de_fotografias_encontradas[intIndex];
                    foreach (Fotografia objecto in lista_de_fotografias_encontradas)
                    {
                        if (objecto.cod_do_elemento == foto_teste_1.cod_do_elemento)
                        {
                            string detalhes = objecto.mostrar_dados_elemento();
                            detalhes_search_fotografias_textbox.Text = detalhes;
                        }
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
            }
            catch (Exception)
            {
                fail failed = new fail();
                failed.ShowDialog();
            }
        }

        private void editar_musicas(object sender, EventArgs e)
        {
            data_grid_musicas.DataSource = null;
            data_grid_musicas.Refresh();
            data_grid_musicas.DataSource = lista_musicas;
            data_grid_musicas.Refresh();
            data_grid_musicas.ReadOnly = false;

            data_grid_musicas.Columns[0].Visible = true;
            data_grid_musicas.Columns[0].HeaderText = "Artista";
            data_grid_musicas.Columns[1].Visible = true;
            data_grid_musicas.Columns[1].HeaderText = "Album";
            data_grid_musicas.Columns[2].Visible = false;
            data_grid_musicas.Columns[2].HeaderText = "ID";
            data_grid_musicas.Columns[3].Visible = true;
            data_grid_musicas.Columns[3].HeaderText = "Título";
            data_grid_musicas.Columns[4].Visible = true;
            data_grid_musicas.Columns[4].HeaderText = "Categoria";
            data_grid_musicas.Columns[5].Visible = true;
            data_grid_musicas.Columns[5].HeaderText = "Storage";
            data_grid_musicas.Columns[6].Visible = true;
            data_grid_musicas.Columns[6].HeaderText = "Data";

            button5.Visible = false;
            button6.Visible = false;
            button17.Visible = false;

            label13.Visible = false;
            label14.Visible = false;
            label16.Visible = false;
            label20.Visible = false;
            labelloc.Visible = false;
            labelartistamusica.Visible = false;

            detalhes_musicas_textbox.Text = "";
            nome_musica_textbox.Visible = false;
            artista_musica_textbox.Visible = false;
            album_musica_textbox.Visible = false;
            loc_musica_textbox.Visible = false;
            categoria_musica_combobox.Visible = false;

            detalhes_musicas_textbox.Visible = false;

            data_grid_musicas.Width = 730;
            data_grid_musicas.Height = 340;
            data_grid_musicas.Dock = (DockStyle.Top);
        }

        private void guardar_modificacoes_musicas(object sender, EventArgs e)
        {
            data_grid_musicas.DataSource = null;
            data_grid_musicas.Refresh();
            data_grid_musicas.DataSource = lista_musicas;
            data_grid_musicas.Refresh();
            data_grid_musicas.ReadOnly = true;

            data_grid_musicas.Columns[0].Visible = true;
            data_grid_musicas.Columns[0].HeaderText = "Artista";
            data_grid_musicas.Columns[1].Visible = true;
            data_grid_musicas.Columns[1].HeaderText = "Album";
            data_grid_musicas.Columns[2].Visible = false;
            data_grid_musicas.Columns[2].HeaderText = "ID";
            data_grid_musicas.Columns[3].Visible = true;
            data_grid_musicas.Columns[3].HeaderText = "Título";
            data_grid_musicas.Columns[4].Visible = true;
            data_grid_musicas.Columns[4].HeaderText = "Categoria";
            data_grid_musicas.Columns[5].Visible = false;
            data_grid_musicas.Columns[5].HeaderText = "Storage";
            data_grid_musicas.Columns[6].Visible = false;
            data_grid_musicas.Columns[6].HeaderText = "Data";

            button5.Visible = true;
            button6.Visible = true;
            button17.Visible = true;

            label13.Visible = true;
            label14.Visible = true;
            label16.Visible = true;
            label20.Visible = true;
            labelloc.Visible = true;
            labelartistamusica.Visible = true;

            nome_musica_textbox.Visible = true;
            artista_musica_textbox.Visible = true;
            album_musica_textbox.Visible = true;
            loc_musica_textbox.Visible = true;
            categoria_musica_combobox.Visible = true;

            detalhes_musicas_textbox.Visible = true;

            data_grid_musicas.Width = 465;
            data_grid_musicas.Height = 181;
            data_grid_musicas.Dock = (DockStyle.None);
            if (preferences_1 == 1)
            {
                aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                aviso_alteracao.ShowDialog();
            }
        }

        private void search_filtered_content_filmes(object sender, EventArgs e)
        {
            ArrayList resultado = new ArrayList();
            lista_de_filmes_encontrados = resultado;
            int i = 0;

            foreach (Filme objecto in lista_filmes)
            {
                if (objecto.categoria_do_elemento == filtro_filmes_categorias.Text)
                {
                    i++;
                    resultado.Add(objecto);
                }
            }
            if (i > 0)
            {
                data_grid_search_filmes.DataSource = null;
                data_grid_search_filmes.Refresh();
                data_grid_search_filmes.DataSource = resultado;
                data_grid_search_filmes.Refresh();
                data_grid_search_filmes.ReadOnly = true;
                data_grid_search_filmes.Columns[0].Visible = false;
                data_grid_search_filmes.Columns[1].Visible = false;
                data_grid_search_filmes.Columns[2].Visible = false;
                data_grid_search_filmes.Columns[3].Visible = false;
                data_grid_search_filmes.Columns[4].HeaderText = "ID";
                data_grid_search_filmes.Columns[5].HeaderText = "Titulo";
                data_grid_search_filmes.Columns[6].Visible = false;
                data_grid_search_filmes.Columns[7].Visible = false;
                data_grid_search_filmes.Columns[8].Visible = false;
                filtro_filmes_categorias.Text = "";
                label24.Text = Convert.ToString(i) + " registo(s) encontrado(s).";
            }
            else
            {
                data_grid_search_filmes.DataSource = null;
                data_grid_search_filmes.Refresh();
                filtro_filmes_categorias.Text = "";
                detalhes_search_filmes_textbox.Text = "";
                label24.Text = "Não foram encontrados registos. Tente novamente.";
            }
        }

        private void search_filtered_content_musicas(object sender, EventArgs e)
        {
            ArrayList resultado = new ArrayList();
            lista_de_musicas_encontradas = resultado;
            int i = 0;

            foreach (Music objecto in lista_musicas)
            {
                if (objecto.categoria_do_elemento == filtro_musicas_categorias.Text)
                {
                    i++;
                    resultado.Add(objecto);
                }
            }
            if (i > 0)
            {
                data_grid_search_musicas.DataSource = null;
                data_grid_search_musicas.Refresh();
                data_grid_search_musicas.DataSource = resultado;
                data_grid_search_musicas.Refresh();
                data_grid_search_musicas.ReadOnly = true;
                data_grid_search_musicas.Columns[0].Visible = true;
                data_grid_search_musicas.Columns[0].HeaderText = "Artista";
                data_grid_search_musicas.Columns[1].Visible = true;
                data_grid_search_musicas.Columns[1].HeaderText = "Album";
                data_grid_search_musicas.Columns[2].Visible = false;
                data_grid_search_musicas.Columns[3].Visible = true;
                data_grid_search_musicas.Columns[3].HeaderText = "Título";
                data_grid_search_musicas.Columns[4].Visible = true;
                data_grid_search_musicas.Columns[4].HeaderText = "Categoria";
                data_grid_search_musicas.Columns[5].Visible = false;
                data_grid_search_musicas.Columns[6].Visible = false;
                filtro_musicas_categorias.Text = "";
                label25.Text = Convert.ToString(i) + " registo(s) encontrado(s).";
            }
            else
            {
                data_grid_search_musicas.DataSource = null;
                data_grid_search_musicas.Refresh();
                filtro_musicas_categorias.Text = "";
                detalhes_search_musicas_textbox.Text = "";
                label25.Text = "Não foram encontrados registos. Tente novamente.";
            }
        }

        private void search_filtered_content_fotografias(object sender, EventArgs e)
        {
            ArrayList resultado = new ArrayList();
            lista_de_fotografias_encontradas = resultado;
            int i = 0;

            foreach (Fotografia objecto in lista_fotografias)
            {
                if (objecto.categoria_do_elemento == filtro_fotografias_categoria.Text)
                {
                    i++;
                    resultado.Add(objecto);
                }
            }
            if (i > 0)
            {
                data_grid_search_fotografias.DataSource = null;
                data_grid_search_fotografias.Refresh();
                data_grid_search_fotografias.DataSource = resultado;
                data_grid_search_fotografias.Refresh();
                data_grid_search_fotografias.ReadOnly = true;

                data_grid_search_fotografias.Columns[0].Visible = true;
                data_grid_search_fotografias.Columns[0].HeaderText = "Album";
                data_grid_search_fotografias.Columns[1].Visible = false;
                data_grid_search_fotografias.Columns[1].HeaderText = "Descrição";
                data_grid_search_fotografias.Columns[2].Visible = false;
                data_grid_search_fotografias.Columns[2].HeaderText = "ID";
                data_grid_search_fotografias.Columns[3].Visible = true;
                data_grid_search_fotografias.Columns[3].HeaderText = "Ficheiro";
                data_grid_search_fotografias.Columns[4].Visible = true;
                data_grid_search_fotografias.Columns[4].HeaderText = "Categoria";
                data_grid_search_fotografias.Columns[5].Visible = false;
                data_grid_search_fotografias.Columns[5].HeaderText = "Storage";
                data_grid_search_fotografias.Columns[6].Visible = false;
                data_grid_search_fotografias.Columns[6].HeaderText = "Data";

                filtro_fotografias_categoria.Text = "";
                label26.Text = Convert.ToString(i) + " registo(s) encontrado(s).";
            }
            else
            {
                data_grid_search_musicas.DataSource = null;
                data_grid_search_musicas.Refresh();
                filtro_fotografias_categoria.Text = "";
                detalhes_search_fotografias_textbox.Text = "";
                label26.Text = "Não foram encontrados registos. Tente novamente.";
            }
        }

        private void data_grid_fotografias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Método que executa a serialização dos dados da aplicação e guarda num ficheiro binário
        /// </summary>
        private void button20_Click(object sender, EventArgs e)
        {
            Database ut_database = new Database("ut_neon Database");
            ut_database.db_filmes = lista_filmes;
            ut_database.db_musicas = lista_musicas;
            ut_database.db_fotografias = lista_fotografias;
            ut_database.db_categorias = lista_categorias;
            ut_database.db_emprestimos = lista_emprestimos;
            ut_database.avisos_conclusao = preferences_1;

            Stream stream = File.Open("database.dat", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, ut_database);
            stream.Close();

            if (preferences_1 == 1)
            {
                aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
                aviso_alteracao.ShowDialog();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            aviso_alteracao_sucesso aviso_alteracao = new aviso_alteracao_sucesso();
            if (avisos_concluidos_sucesso_checkbox.Checked == true)
            {
                preferences_1 = 0;
                aviso_alteracao.ShowDialog();
                
            }
            else if (avisos_concluidos_sucesso_checkbox.Checked == false)
            {
                preferences_1 = 1;
                if (preferences_1 == 1)
                aviso_alteracao.ShowDialog();
                
            }
        }

//***********************FIMMM DE PROGRAMA****************************///
    }
}
