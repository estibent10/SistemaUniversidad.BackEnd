using SistemaUniversidad.BackEnd.API.Repository;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        //Acá van todos los repositorios del sistema
        IAulasRepository AulasRepository { get; }
    }
}
