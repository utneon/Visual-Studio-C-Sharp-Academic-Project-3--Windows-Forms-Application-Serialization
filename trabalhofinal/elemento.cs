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
    class Elemento : ISerializable
    {
        //Atributos do elemento multimédia
        //Atributo ESTÁTICO -> que permite ter um valor comum em todas as instancias da classe
        public static int total_elementos = 0;
        public int estado_emprestimo_do_elemento = 0;

        //Propriedades do elemento de multimédia
        protected int cod_elemento;
        public int cod_do_elemento
            {
                set { cod_elemento = value; }
                get { return cod_elemento; }
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

        private string categoria_elemento;
        public string categoria_do_elemento
        {
            get { return categoria_elemento; }
            set
            {
                categoria_elemento = value;
            }
        }

        private string loc_elemento;
        public string loc_do_elemento
        {
            get { return loc_elemento; }
            set
            {
                loc_elemento = value;
            }
        }

        private string data_elemento;
        public string data_do_elemento
        {
            get { return data_elemento; }
            set
            {
                if (value == "") data_elemento = "N/A";
                else data_elemento = value;
            }
        }

        /// <summary>
        /// Construtor por defeito 
        /// Protected porque não se vão criar objectos apenas do tipo elemento
        /// </summary>
        protected Elemento(string nome_elemento_par, string loc_elemento_par, string categoria_elemento_par)
        {
            total_elementos++;
            this.cod_do_elemento=total_elementos;
            DateTime data = DateTime.Now;
            this.data_do_elemento = Convert.ToString(data);
            this.nome_do_elemento = nome_elemento_par;
            this.loc_do_elemento = loc_elemento_par;
            this.categoria_do_elemento = categoria_elemento_par;
        }

        //Métodos públicos

        /// <summary>
        /// Lista a informação do elemento multimédia.
        /// </summary>
        public virtual string mostrar_dados_elemento()
        {
            //mostrar dados consoante a necessidade dos forms.
            string detalhes = "Nada para devolver";
            return detalhes;
        }

        /// <summary>
        /// Método que permite efectuar a alteração de dados de um elemento. Os elementos que podem ser alterados são: Nome do elemento, Localização do Elemento, Categoria do Elemento e a data mantém-se porque é referente à data em que entrou na base de dados.
        /// </summary>
        /// <param name="novo_nome">Novo nome para o elemento.</param>
        /// <param name="nova_localizacao">Nova localização do ficheiro.</param>
        /// <param name="nova_categoria">Nova Categoria.</param>
        public virtual void actualizar_elemento(string novo_nome, string nova_localizacao, string nova_categoria)
        {
            this.nome_do_elemento = novo_nome;
            this.loc_do_elemento = nova_localizacao;
            this.categoria_do_elemento = nova_categoria;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ElementoID", cod_elemento);
            info.AddValue("DataElemento", data_elemento);
            info.AddValue("NomeElemento", nome_elemento);
            info.AddValue("LocElemento", loc_elemento);
            info.AddValue("CategoriaElemento", categoria_elemento);
            info.AddValue("EstadoEmpElemento", estado_emprestimo_do_elemento);
            info.AddValue("total_elemntos", total_elementos);
        }
        //Deserialization constructor.
        public Elemento(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            cod_elemento = (int)info.GetValue("ElementoID", typeof(int));
            data_elemento = (string)info.GetValue("DataElemento", typeof(string));
            nome_elemento = (string)info.GetValue("NomeElemento", typeof(string));
            loc_elemento = (string)info.GetValue("LocElemento", typeof(string));
            categoria_elemento = (string)info.GetValue("CategoriaElemento", typeof(string));
            estado_emprestimo_do_elemento=(int)info.GetValue("EstadoEmpElemento", typeof(int));
            total_elementos = (int)info.GetValue("total_elementos", typeof(int));
        }

        public Elemento()
        {
        }

    }

    [Serializable()]
    class Filme : Elemento
    {
        //Propriedades do filme
        private string duration;
        public string dur_filme
        {
            get { return duration; }
            set
            {
                duration = value;
            }
        }

        private string sinopse;
        public string sinopse_filme
        {
            get { return sinopse; }
            set
            {
                sinopse = value;
            }
        }

        private string ano;
        public string ano_filme
        {
            get { return ano; }
            set
            {
                ano = value;
            }
        }

        private string realizador;
        public string realizador_filme
        {
            get { return realizador; }
            set
            {
                realizador = value;
            }
        }

        //Constructor do filme
        /// <summary>
        /// Construtor para o objecto Filme.
        /// </summary>
        public Filme(string nome_filme_par, string loc_filme_par, string categoria_filme_par, string dur_filmne_par, string sinopse_filme_par, string ano_filme_par, string director_filme_par):base(nome_filme_par, loc_filme_par, categoria_filme_par)
        {
            this.realizador_filme = director_filme_par;
            this.sinopse_filme = sinopse_filme_par;
            this.dur_filme = dur_filmne_par;
            this.ano_filme = ano_filme_par;
        }

        //Métodos públicos

        /// <summary>
        /// Lista a informação do filme.
        /// </summary>
        public override string mostrar_dados_elemento()
        {
            //mostrar dados consoante a necessidade dos forms.
            string detalhes = "ID: " + Convert.ToString(base.cod_elemento) + "\nCategoria: " + base.categoria_do_elemento + "\nData: " + base.data_do_elemento + "\nTitulo: " + base.nome_do_elemento + "\nAno: " + this.ano_filme + "\nRealizador: " + this.realizador_filme + "\nDuração: " + this.dur_filme + "\nSinopse: " + this.sinopse_filme + "\nStorage: " + base.loc_do_elemento + "\n\nEstado: Available";
            if (this.estado_emprestimo_do_elemento == 1)
            {
                detalhes = "ID: " + Convert.ToString(base.cod_elemento) + "\nCategoria: " + base.categoria_do_elemento + "\nData: " + base.data_do_elemento + "\nTitulo: " + base.nome_do_elemento + "\nAno: " + this.ano_filme + "\nRealizador: " + this.realizador_filme + "\nDuração: " + this.dur_filme + "\nSinopse: " + this.sinopse_filme + "\nStorage: " + base.loc_do_elemento + "\n\nEstado: Emprestado";
            }
                return detalhes;
        }

        //Serialization constructor
        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("FilmeID", cod_elemento);
            info.AddValue("DataFilme", data_do_elemento);
            info.AddValue("NomeFilme", nome_do_elemento);
            info.AddValue("LocFilme", loc_do_elemento);
            info.AddValue("CategoriaFilme", categoria_do_elemento);
            info.AddValue("EstadoEmpFilme", estado_emprestimo_do_elemento);

            info.AddValue("DurFilme", duration);
            info.AddValue("SinopseFilme", sinopse);
            info.AddValue("AnoFilme", ano);
            info.AddValue("RealizadorFilme", realizador);

            info.AddValue("total_filmes", total_elementos);
        }
        //Deserialization constructor.
        public Filme(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            duration = (string)info.GetValue("DurFilme", typeof(string));
            sinopse = (string)info.GetValue("SinopseFilme", typeof(string));
            ano = (string)info.GetValue("AnoFilme", typeof(string));
            realizador = (string)info.GetValue("RealizadorFilme", typeof(string));

            cod_elemento = (int)info.GetValue("FilmeID", typeof(int));
            data_do_elemento = (string)info.GetValue("DataFilme", typeof(string));
            nome_do_elemento = (string)info.GetValue("NomeFilme", typeof(string));
            loc_do_elemento = (string)info.GetValue("LocFilme", typeof(string));
            categoria_do_elemento = (string)info.GetValue("CategoriaFilme", typeof(string));
            estado_emprestimo_do_elemento=(int)info.GetValue("EstadoEmpFilme", typeof(int));

            total_elementos = (int)info.GetValue("total_filmes", typeof(int));
        }
    }

    [Serializable()]
    class Music : Elemento
    {
        //Propriedades da música
        private string artista;
        public string artista_music
        {
            get { return artista; }
            set
            {
                artista = value;
            }
        }

        private string album;
        public string album_music
        {
            get { return album; }
            set
            {
                album = value;
            }
        }

        //Constructor da Music
        /// <summary>
        /// Construtor para o objecto Music.
        /// </summary>
        public Music(string nome_music_par, string loc_music_par, string categoria_music_par, string artista_music_par, string album_music_par)
            : base(nome_music_par, loc_music_par, categoria_music_par)
        {
            this.artista_music = artista_music_par;
            this.album_music = album_music_par;
        }

        //Métodos públicos

        /// <summary>
        /// Lista a informação da Música.
        /// </summary>
        public override string mostrar_dados_elemento()
        {
            //mostrar dados consoante a necessidade dos forms.
            string detalhes = "ID: " + Convert.ToString(base.cod_elemento) + "\nCategoria: " + base.categoria_do_elemento + "\nData: " + base.data_do_elemento + "\nTitulo: " + base.nome_do_elemento + "\nArtista: " + this.artista_music + "\nAlbum: " + this.album_music+"\nStorage: " + base.loc_do_elemento + "\n\nEstado: Available";
            if (this.estado_emprestimo_do_elemento == 1)
            {
                detalhes = "ID: " + Convert.ToString(base.cod_elemento) + "\nCategoria: " + base.categoria_do_elemento + "\nData: " + base.data_do_elemento + "\nTitulo: " + base.nome_do_elemento + "\nArtista: " + this.artista_music + "\nAlbum: " + this.album_music + "\nStorage: " + base.loc_do_elemento + "\n\nEstado: Emprestado";
            }
            return detalhes;
        }

        //Serialization constructor
        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("MusicaID", cod_elemento);
            info.AddValue("DataMusica", data_do_elemento);
            info.AddValue("NomeMusica", nome_do_elemento);
            info.AddValue("LocMusica", loc_do_elemento);
            info.AddValue("CategoriaMusica", categoria_do_elemento);
            info.AddValue("EstadoEmpMusica", estado_emprestimo_do_elemento);

            info.AddValue("ArtistaMusica", artista);
            info.AddValue("AlbumMusica", album);

            info.AddValue("total_musicas", total_elementos);
        }
        //Deserialization constructor.
        public Music(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            artista = (string)info.GetValue("ArtistaMusica", typeof(string));
            album = (string)info.GetValue("AlbumMusica", typeof(string));

            cod_elemento = (int)info.GetValue("MusicaID", typeof(int));
            data_do_elemento = (string)info.GetValue("DataMusica", typeof(string));
            nome_do_elemento = (string)info.GetValue("NomeMusica", typeof(string));
            loc_do_elemento = (string)info.GetValue("LocMusica", typeof(string));
            categoria_do_elemento = (string)info.GetValue("CategoriaMusica", typeof(string));
            estado_emprestimo_do_elemento=(int)info.GetValue("EstadoEmpMusica", typeof(int));

            total_elementos = (int)info.GetValue("total_musicas", typeof(int));
        }
    }
    
    [Serializable()]
    class Fotografia : Elemento
    {
        //Propriedades da fotografia
        private string albumf;
        public string album_fotografia
        {
            get { return albumf; }
            set
            {
                albumf = value;
            }
        }

        private string descricao;
        public string descricao_fotografia
        {
            get { return descricao; }
            set
            {
                descricao = value;
            }
        }

        //Constructor da Fotografia
        /// <summary>
        /// Construtor para o objecto Fotografia.
        /// </summary>
        public Fotografia(string nome_fotografia_par, string loc_fotografia_par, string categoria_fotografia_par, string albumf_par, string descricao_fotografia_par)
            : base(nome_fotografia_par, loc_fotografia_par, categoria_fotografia_par)
        {
            this.album_fotografia = albumf_par;
            this.descricao_fotografia = descricao_fotografia_par;
        }

        //Métodos públicos

        /// <summary>
        /// Lista a informação da fotografia.
        /// </summary>
        public override string mostrar_dados_elemento()
        {
            //mostrar dados consoante a necessidade dos forms.
            string detalhes = "ID: " + Convert.ToString(base.cod_elemento) + "\nCategoria: " + base.categoria_do_elemento + "\nData: " + base.data_do_elemento + "\nTitulo: " + base.nome_do_elemento + "\nAlbum: " + this.album_fotografia + "\nDescrição: " + this.descricao_fotografia + "\nStorage: " + base.loc_do_elemento + "\n\nEstado: Available";
            if (this.estado_emprestimo_do_elemento == 1)
            {
                detalhes = "ID: " + Convert.ToString(base.cod_elemento) + "\nCategoria: " + base.categoria_do_elemento + "\nData: " + base.data_do_elemento + "\nTitulo: " + base.nome_do_elemento + "\nAlbum: " + this.album_fotografia + "\nDescrição: " + this.descricao_fotografia + "\nStorage: " + base.loc_do_elemento + "\n\nEstado: Emprestado";
            }
            return detalhes;
        }
        //Serialization constructor
        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("FotografiaID", cod_elemento);
            info.AddValue("DataFotografia", data_do_elemento);
            info.AddValue("NomeFotografia", nome_do_elemento);
            info.AddValue("LocFotografia", loc_do_elemento);
            info.AddValue("CategoriaFotografia", categoria_do_elemento);
            info.AddValue("EstadoEmpFotografia", estado_emprestimo_do_elemento);

            info.AddValue("DescMusica", descricao);
            info.AddValue("AlbumFotografia", albumf);

            info.AddValue("total_fotos", total_elementos);
        }
        //Deserialization constructor.
        public Fotografia(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            descricao = (string)info.GetValue("DescMusica", typeof(string));
            albumf = (string)info.GetValue("AlbumFotografia", typeof(string));

            cod_elemento = (int)info.GetValue("FotografiaID", typeof(int));
            data_do_elemento = (string)info.GetValue("DataFotografia", typeof(string));
            nome_do_elemento = (string)info.GetValue("NomeFotografia", typeof(string));
            loc_do_elemento = (string)info.GetValue("LocFotografia", typeof(string));
            categoria_do_elemento = (string)info.GetValue("CategoriaFotografia", typeof(string));
            estado_emprestimo_do_elemento = (int)info.GetValue("EstadoEmpFotografia", typeof(int));

            total_elementos = (int)info.GetValue("total_fotos", typeof(int));
        }

    }
}
