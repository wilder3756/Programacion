using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AppMovil.Models
{
    public class MateriaXSemestre
    {
        /*[PrimaryKey, AutoIncrement]
        public int ID { get; set; }*/
        [PrimaryKey, NotNull]
        public string IdMateria { get; set; }
        [ForeignKey(typeof(Materias)), NotNull]
        public string Materia { get; set; }
        [ForeignKey(typeof(Semestres)), NotNull]
        public string Semestre { get; set; }

        public MateriaXSemestre()
        {

        }

        public MateriaXSemestre(string materia, string semestre)
        {
            Materia = materia;
            Semestre = semestre;
            IdMateria = Materia + "-" + Semestre;
        }
    }
}
