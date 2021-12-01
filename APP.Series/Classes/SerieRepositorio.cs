using System;
using System.Collections.Generic;
using APP.Series.Interfaces;

namespace APP.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listDeSerie = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listDeSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listDeSerie[id].Excluir();
        }

        public void Inserir(Serie entidade)
        {
            listDeSerie.Add(entidade);
        }

        public List<Serie> Listar()
        {
            return listDeSerie;
        }

        public int ProximoId()
        {
            return listDeSerie.Count;
        }

        public Serie RetornarPorId(int id)
        {
            return listDeSerie[id];
        }

        public bool VerificaExistenciaSerie(int id){
            if(listDeSerie.Count > 0){
                foreach (Serie serie in listDeSerie)
                {
                    if(serie.Id == id){
                        return true;
                    }
                }
            }
            return false;
        }
    }
}