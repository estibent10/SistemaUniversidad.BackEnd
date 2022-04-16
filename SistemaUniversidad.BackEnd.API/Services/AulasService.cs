using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Services.Interfaces;
using SistemaUniversidad.BackEnd.API.UnitOfWork;

namespace SistemaUniversidad.BackEnd.API.Services
{
    public class AulasService : IAulasService
    {
        private IUnitOfWork BD;
        public AulasService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Aula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.AulasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.AulasRepository.Eliminar(id);

                bd.SaveChanges();
            }
        }

        public void Insertar(Aula model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.AulasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Aula SeleccionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Aula> SeleccionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
