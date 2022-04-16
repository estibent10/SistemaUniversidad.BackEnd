﻿using SistemaUniversidad.BackEnd.API.Repository;
using SistemaUniversidad.BackEnd.API.Repository.SqlServer;
using System.Data.SqlClient;

namespace SistemaUniversidad.BackEnd.API.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        //Acá van todos los otros repositorios
        public IAulasRepository AulasRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            //Acá van todos los otros repositorios

            AulasRepository = new AulasRepository(context, transaction);

        }

    }
}
